using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace BudgetWpfApplication
{
    /// <summary>
    /// Interaction logic for ChekItemWindiw.xaml
    /// </summary>
    public partial class ChekItemWindow : Window
    {
        public int IdPurchase { get; private set; }

        Model.BudgetModel db = new Model.BudgetModel();

        private bool isButtonPressed;

        #region Constructors

        public ChekItemWindow()
        {
            InitializeComponent();
        }

        public ChekItemWindow(int id)
        {
            InitializeComponent();
            IdPurchase = id;
            UpdateComboBox();
            UpdateDataGrid();
        }

        #endregion
        #region Metods

        private void UpdateComboBox()
        {
            categoryCmbBox.ItemsSource = null;
            categoryCmbBox.Items.Clear();
            var categories = db.Categories.ToList();
            List<ListBoxItem> items = new List<ListBoxItem>();
            foreach (var category in categories)
            {
                var item = new ListBoxItem(category.Id, category.Name);
                items.Add(item);
            }
            categoryCmbBox.ItemsSource = items;
            categoryCmbBox.SelectedIndex = 1;
        }

        private void UpdateListBox()
        {
        goodsLstBox.ItemsSource = null;
        goodsLstBox.Items.Clear();
            var selectedCategory = categoryCmbBox.SelectedItem as ListBoxItem;
            var goods = db.Categories.Find(selectedCategory.Id).GoodsItems.ToList();
            List<ComplexListBoxItem> items = new List<ComplexListBoxItem>();
            foreach (var goodsItem in goods)
            {
                var item = new ComplexListBoxItem(goodsItem.Id, goodsItem.Name, goodsItem.UnitOfMeasure.ShortName);
                items.Add(item);
            }
            goodsLstBox.ItemsSource = items;
            goodsLstBox.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void UpdateDataGrid() => 
            chekItemsDataGrid.ItemsSource = db.Purchases.Find(IdPurchase).ChekItems.ToList();

        private bool Check()
        {
            if (goodsLstBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите товар");
                return false;
            }
            if (string.IsNullOrWhiteSpace(priceTxtBox.Text))
            {
                MessageBox.Show("Введите цену");
                return false;
            }
            double res;
            if(!double.TryParse(priceTxtBox.Text.Replace(",", ".").Replace(".", ","), out res))
            {
                MessageBox.Show("Введите корректную цену");
                return false;
            }
            if (string.IsNullOrWhiteSpace(quantityTxtBox.Text))
            {
                MessageBox.Show("Введите количество");
                return false;
            }
            if (!double.TryParse(quantityTxtBox.Text.Replace(",", ".").Replace(".", ","), out res))
            {
                MessageBox.Show("Введите корректное количество");
                return false;
            }
            return true;
        }

        #endregion
        #region Events Handlers

        private void categoryCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateListBox();
        
        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            if (!Check()) return; 
            var chekItem = new ChekItem();
            var purchase = chekItem.Purchase = db.Purchases.Find(IdPurchase);
            var selectedGoodsItem = goodsLstBox.SelectedValue as ListBoxItem;
            chekItem.GoodsItem = db.Goods.Find(selectedGoodsItem.Id);
            chekItem.Price = double.Parse(priceTxtBox.Text.Replace(",", ".").Replace(".", ","));
            chekItem.Quantity = double.Parse(quantityTxtBox.Text.Replace(",", ".").Replace(".", ","));
            if (purchase.ChekItems.Any(x => x.GoodsItem.Id == chekItem.GoodsItem.Id && x.Price == chekItem.Price))
            {
                MessageBox.Show("Такая позиция уже существует!");
                return;
            }
            db.ChekItems.Add(chekItem);
            UpdateDataGrid();
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isButtonPressed == true)
            {
                db.SaveChanges();
                db.Dispose();
            }
            else
            {
                var res = MessageBox.Show("Сохранить?", "Сохранение", MessageBoxButton.YesNoCancel);
                if (res == MessageBoxResult.Yes)
                {
                    db.SaveChanges();
                    db.Dispose();
                }
                else if (res == MessageBoxResult.No) db.Dispose();
                else e.Cancel = true;
            }
        }

        private void RenameButtonClick(object sender, RoutedEventArgs e)
        {
            cancelButton.Visibility = Visibility.Visible;
            addButton.Visibility = Visibility.Hidden;
            saveButton.Visibility = Visibility.Visible;
            savePurchaseButton.Visibility = Visibility.Hidden;
            ChekItem chekItem = chekItemsDataGrid.SelectedItem as ChekItem;
            chekItemsDataGrid.IsEnabled = false;
            for (int i = 0; i < categoryCmbBox.Items.Count; i++)
            {
                var item = categoryCmbBox.Items[i] as ListBoxItem;
                if (item.Id == chekItem.GoodsItem.Category.Id)
                {
                    categoryCmbBox.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < goodsLstBox.Items.Count; i++)
            {
                var item = goodsLstBox.Items[i] as ListBoxItem;
                if (item.Id == chekItem.GoodsItem.Id)
                {
                    goodsLstBox.SelectedIndex = i;
                    break;
                }
            }
            priceTxtBox.Text = chekItem.Price.ToString();
            quantityTxtBox.Text = chekItem.Quantity.ToString();
        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Удалить?", "Удаление", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.No) return;
            ChekItem chekItem = chekItemsDataGrid.SelectedItem as ChekItem;
            var removeChekItem = db.ChekItems.Find(chekItem.Id);
            db.ChekItems.Remove(removeChekItem);
            UpdateDataGrid();

        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (!Check()) return;
            ChekItem chekItem = chekItemsDataGrid.SelectedItem as ChekItem;
            var renameChekItem = db.ChekItems.Find(chekItem.Id);
            renameChekItem.Purchase = db.Purchases.Find(IdPurchase);
            var selectedGoodsItem = goodsLstBox.SelectedValue as ListBoxItem;
            renameChekItem.GoodsItem = db.Goods.Find(selectedGoodsItem.Id);
            renameChekItem.Price = double.Parse(priceTxtBox.Text.Replace(",", ".").Replace(".", ","));
            renameChekItem.Quantity = double.Parse(quantityTxtBox.Text.Replace(",", ".").Replace(".", ","));
            UpdateDataGrid();
            saveButton.IsEnabled = false;
            addButton.IsEnabled = true;
            chekItemsDataGrid.IsEnabled = true;
        }

        private void PriceTxtBoxGotFocus(object sender, RoutedEventArgs e) => priceTxtBox.SelectAll();

        private void QuantityTxtBoxGotFocus(object sender, RoutedEventArgs e) => quantityTxtBox.SelectAll();

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            addButton.Visibility = Visibility.Visible;
            cancelButton.Visibility = Visibility.Hidden;
            saveButton.Visibility = Visibility.Hidden;
            savePurchaseButton.Visibility = Visibility.Visible;
            chekItemsDataGrid.IsEnabled = true;
            priceTxtBox.Clear();
            quantityTxtBox.Clear();
        }
        
        private void SavePurchaseButtonClick(object sender, RoutedEventArgs e)
        {
            isButtonPressed = true;
            Close();
        }

        private void ChekItemsDataGridLoadingRow(object sender, DataGridRowEventArgs e)=> 
            e.Row.Header = e.Row.GetIndex() + 1;

        #endregion
    }
}
