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

namespace BudgetWpfApplication
{
    /// <summary>
    /// Interaction logic for GoodsWindow.xaml
    /// </summary>
    public partial class GoodsWindow : Window
    {
        #region Constructors

        public GoodsWindow()
        {
            InitializeComponent();
            UpdateComboBox();
        }

        #endregion
        #region Metods

        private void UpdateComboBox()
        {
            goodsComboBox.ItemsSource = null;
            goodsComboBox.Items.Clear();
            using (var db = new Model.BudgetModel())
            {
                var categories = db.Categories.ToList();
                List<ListBoxItem> items = new List<ListBoxItem>();
                foreach (var category in categories)
                {
                    var item = new ListBoxItem(category.Id, category.Name);
                    items.Add(item);
                }
                goodsComboBox.ItemsSource = items;
            }
            goodsComboBox.SelectedIndex = 1;
        }

        private void UpdateListBox()
        {
            goodsLstBox.ItemsSource = null;
            goodsLstBox.Items.Clear();
            using(var db = new Model.BudgetModel())
            {
                var selectedCategory = goodsComboBox.SelectedItem as ListBoxItem;
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
        }

        #endregion
        #region Events Handlers

        private void GoodsComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateListBox();

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = goodsComboBox.SelectedValue as ListBoxItem;
            AddGoodsWindow addGoodsWindow = new AddGoodsWindow();
            if (selectedItem != null) addGoodsWindow = new AddGoodsWindow(selectedItem.Id);
            addGoodsWindow.ShowDialog();
            if (string.IsNullOrWhiteSpace(addGoodsWindow.Value)) return;
            using (var db = new Model.BudgetModel())
            {
                var goodsItem = new GoodsItem();
                goodsItem.Name = addGoodsWindow.Value;
                goodsItem.Category = db.Categories.Find(addGoodsWindow.Category.Id);
                goodsItem.UnitOfMeasure = db.UnitOfMeasures.Find(addGoodsWindow.UnitOfMeasure.Id);
                db.Goods.Add(goodsItem);
                db.SaveChanges();
            }
            UpdateListBox();
        }

        private void RenameMenuItemClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = goodsLstBox.SelectedValue as ListBoxItem;
            var selectedCategory = goodsComboBox.SelectedValue as ListBoxItem;
            if (selectedItem == null) return;
            using (var db = new Model.BudgetModel())
            {
                var goodsItem = db.Goods.Find(selectedItem.Id);
                AddGoodsWindow addGoodsItem = new AddGoodsWindow(
                    goodsItem.Category.Id,
                    goodsItem.UnitOfMeasure.Id,
                    goodsItem.Name
                    );
                addGoodsItem.ShowDialog();
                if (addGoodsItem.Category == null || addGoodsItem.UnitOfMeasure == null
                    || string.IsNullOrWhiteSpace(addGoodsItem.Value))
                    return;
                goodsItem.Name = addGoodsItem.Value;
                goodsItem.Category = db.Categories.Find(addGoodsItem.Category.Id);
                goodsItem.UnitOfMeasure = db.UnitOfMeasures.Find(addGoodsItem.UnitOfMeasure.Id);
                db.SaveChanges();
                UpdateListBox();
            }
        }

        private void RemoveMenuItemClick(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Удалить?", "Удаление", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                using (var db = new Model.BudgetModel())
                {
                    var selectedItem = goodsLstBox.SelectedItem as ListBoxItem;
                    if (selectedItem == null) return;
                    var removeItem = db.Goods.Find(selectedItem.Id);
                    db.Goods.Remove(removeItem);
                    db.SaveChanges();
                }
                UpdateListBox();
            }
            else return;
        }

        #endregion
    }
}
