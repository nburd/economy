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
    /// Interaction logic for PurchaseWindow.xaml
    /// </summary>
    public partial class PurchaseWindow : Window
    {
        public PurchaseWindow()
        {
            InitializeComponent();
            UpdateComboBox();
            UpdateDataGrid();    
        }

        #region Metods

        private void UpdateComboBox()
        {
            purchaseCmbBox.ItemsSource = null;
            purchaseCmbBox.Items.Clear();
            using (var db = new Model.BudgetModel())
            {
                var sources = db.Sources.ToList();
                List<ListBoxItem> items = new List<ListBoxItem>();
                foreach (var source in sources)
                {
                    var item = new ListBoxItem(source.Id, source.Name);
                    items.Add(item);
                }
                purchaseCmbBox.ItemsSource = items;
            }
            purchaseDataTime.SelectedDate = DateTime.Today;
        }

        private void UpdateDataGrid()
        {
            purchaseDataGrid.ColumnWidth = DataGridLength.SizeToHeader;
            using (var db = new Model.BudgetModel())
            {
                var purchases = db.Purchases.ToList();
                foreach (var purchase in purchases)
                {
                    if (purchase.ChekItems.ToList().Count == 0) db.Purchases.Remove(purchase);
                }
                db.SaveChanges();
                purchaseDataGrid.ItemsSource = db.Purchases.Include("Source").ToList();
            }
        }

        #endregion
        #region Events Handlers

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            using (var db = new Model.BudgetModel())
            {
                var purchase = new Purchase();
                purchase.DateTime = purchaseDataTime.SelectedDate.Value;
                var selectedSource = purchaseCmbBox.SelectedItem as ListBoxItem;
                if (selectedSource == null)
                {
                    MessageBox.Show("Выберите источник");
                    return;
                }
                purchase.Source = db.Sources.Find(selectedSource.Id);
                db.Purchases.Add(purchase);
                db.SaveChanges();
                ChekItemWindow chekItemWindow = new ChekItemWindow(purchase.Id);
                chekItemWindow.ShowDialog();
            }
            UpdateDataGrid();
        }

        private void RenameButtonClick(object sender, RoutedEventArgs e)
        {
            using (var db = new Model.BudgetModel())
            {
                Purchase purchase = purchaseDataGrid.SelectedItem as Purchase;
                ChekItemWindow chekItemWindow = new ChekItemWindow(purchase.Id);
                chekItemWindow.ShowDialog();
            }
            UpdateDataGrid();
        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Удалить?", "Удаление", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.No) return;
            using (var db = new Model.BudgetModel())
            {
                Purchase purchase = purchaseDataGrid.SelectedItem as Purchase;
                db.Purchases.Remove(db.Purchases.Find(purchase.Id));
                db.SaveChanges();
                UpdateDataGrid();
            }
        }

        private void ChangeButtonClick(object sender, RoutedEventArgs e)
        {
            addButton.Visibility = Visibility.Hidden;
            cancelButton.Visibility = Visibility.Visible;
            saveBut.IsEnabled = true;
            using (var db = new Model.BudgetModel())
            {
                Purchase purchase = purchaseDataGrid.SelectedItem as Purchase;
                purchaseDataGrid.IsEnabled = false;
                purchaseDataTime.SelectedDate = purchase.DateTime;
                for (int i = 0; i < purchaseCmbBox.Items.Count; i++)
                {
                    var item = purchaseCmbBox.Items[i] as ListBoxItem;
                    if (item.Id == purchase.Source.Id)
                    {
                        purchaseCmbBox.SelectedIndex = i;
                        return;
                    }
                }
            }
        }

        private void SaveButClick(object sender, RoutedEventArgs e)
        {
            using (var db = new Model.BudgetModel())
            {
                Purchase purchase = purchaseDataGrid.SelectedItem as Purchase;
                var selectedPurchase = db.Purchases.Find(purchase.Id);
                selectedPurchase.DateTime = purchaseDataTime.SelectedDate.Value;
                var selectedSource = purchaseCmbBox.SelectedItem as ListBoxItem;
                selectedPurchase.Source = db.Sources.Find(selectedSource.Id);
                db.SaveChanges();
                UpdateDataGrid();
                saveBut.IsEnabled = false;
                addButton.IsEnabled = true;
                purchaseDataGrid.IsEnabled = true;
            }
        }


        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            saveBut.IsEnabled = false;
            purchaseDataGrid.IsEnabled = true;
            cancelButton.Visibility = Visibility.Hidden;
            addButton.Visibility = Visibility.Visible;
        }

        private void PurchaseDataGridLoadingRow(object sender, DataGridRowEventArgs e)=>        
            e.Row.Header = e.Row.GetIndex() + 1;

        #endregion
    }
}
