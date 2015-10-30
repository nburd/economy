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
    public partial class CategoryWindow : Window
    {

        #region Constructors

        public CategoryWindow()
        {
            InitializeComponent();
            UpdateListBox();
        }

        #endregion
        #region Metods

        private void UpdateListBox()
        {
            categoryLstBox.ItemsSource = null;
            categoryLstBox.Items.Clear();
            using (var db = new Model.BudgetModel())
            {
                var categories = db.Categories.ToList();
                List<ListBoxItem> items = new List<ListBoxItem>();
                foreach (var category in categories)
                {
                    var item = new ListBoxItem(category.Id, category.Name);
                    items.Add(item);
                }
                categoryLstBox.ItemsSource = items;
            }
        }

        #endregion
        #region Events Handlers

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddItemsWindow addItemsWindow = new AddItemsWindow();
            addItemsWindow.ShowDialog();
            using (var db = new Model.BudgetModel())
            {
                var category = new Category();
                if (string.IsNullOrWhiteSpace(addItemsWindow.Value)) MessageBox.Show("Введите название");
                else
                {
                    category.Name = addItemsWindow.Value;
                    db.Categories.Add(category);
                    db.SaveChanges();
                    UpdateListBox();
                }
            }
        }

        private void RemoveMenuItemClick(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Удалить?", "Удаление", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                using (var db = new Model.BudgetModel())
                {
                    var selectedItem = categoryLstBox.SelectedItem as ListBoxItem;
                    if (selectedItem == null) return;
                    var removeItem = db.Categories.Find(selectedItem.Id);
                    db.Categories.Remove(removeItem);
                    db.SaveChanges();
                }
                UpdateListBox();
            }
            else return;
        }

        private void RenameMenuItemClick(object sender, RoutedEventArgs e)
        {
            using (var db = new Model.BudgetModel())
            {
                var selectedItem = categoryLstBox.SelectedItem as ListBoxItem;
                if (selectedItem == null) return;
                AddItemsWindow addItemsWindow = new AddItemsWindow(selectedItem.Name);
                addItemsWindow.ShowDialog();
                var renameItem = db.Categories.Find(selectedItem.Id);
                if (string.IsNullOrWhiteSpace(addItemsWindow.Value)) MessageBox.Show("Введите название");
                else
                {
                    renameItem.Name = addItemsWindow.Value;
                    db.SaveChanges();
                    UpdateListBox();
                }
            }
        }

        #endregion
    }
}
