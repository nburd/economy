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
    /// Interaction logic for SourceWindow.xaml
    /// </summary>
    public partial class SourceWindow : Window
    {
        #region Constructors

        public SourceWindow()
        {
            InitializeComponent();
            UpdateListBox();
        }

        #endregion
        #region Metods

        private void UpdateListBox()
        {
            sourceLstBox.ItemsSource = null;
            sourceLstBox.Items.Clear();
            using (var db = new Model.BudgetModel())
            {
                var sources = db.Sources.ToList();
                List<ListBoxItem> items = new List<ListBoxItem>();
                foreach (var source in sources)
                {
                    var item = new ListBoxItem(source.Id, source.Name);
                    items.Add(item);
                }
                sourceLstBox.ItemsSource = items;
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
                var source = new Source();
                if (string.IsNullOrWhiteSpace(addItemsWindow.Value)) MessageBox.Show("Введите название");
                else
                {
                    source.Name = addItemsWindow.Value;
                    db.Sources.Add(source);
                    db.SaveChanges();
                    UpdateListBox();
                }
            }
        }

        private void renameMenuItemClick(object sender, RoutedEventArgs e)
        {
            using (var db = new Model.BudgetModel())
            {
                var selectedItem = sourceLstBox.SelectedItem as ListBoxItem;
                if (selectedItem == null) return;
                AddItemsWindow addItemsWindow = new AddItemsWindow(selectedItem.Name);
                addItemsWindow.ShowDialog();
                var renameItem = db.Sources.Find(selectedItem.Id);
                if (string.IsNullOrWhiteSpace(addItemsWindow.Value)) MessageBox.Show("Введите название");
                else
                {
                    renameItem.Name = addItemsWindow.Value;
                    db.SaveChanges();
                    UpdateListBox();
                }
            }
        }

        private void removeMenuItemClick(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Удалить?", "Удаление", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                using (var db = new Model.BudgetModel())
                {
                    var selectedItem = sourceLstBox.SelectedItem as ListBoxItem;
                    if (selectedItem == null) return;
                    var removeItem = db.Sources.Find(selectedItem.Id);
                    db.Sources.Remove(removeItem);
                    db.SaveChanges();
                }
                UpdateListBox();
            }
            else return;
        }

        #endregion
    }
}
