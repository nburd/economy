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
    /// Interaction logic for AddGoodsWindow.xaml
    /// </summary>
    public partial class AddGoodsWindow : Window
    {
        public string Value { get; set; }

        public ListBoxItem Category { get; set; }

        public ListBoxItem UnitOfMeasure { get; set; }

        #region Constructors

        public AddGoodsWindow()
        {
            InitializeComponent();
            UpdateComboBoxs();
        }

        public AddGoodsWindow(int categoryId)
        {
            InitializeComponent();
            UpdateComboBoxs();
            categoryCmbBox.SelectedIndex = FindCategoryIndex(categoryId);
        }

        public AddGoodsWindow(int categoryId, int unitOfMeasureId, string name)
        { 
            InitializeComponent();
            UpdateComboBoxs();
            categoryCmbBox.SelectedIndex = FindCategoryIndex(categoryId);
            unitOfMeasureCmbBox.SelectedIndex = FindUnitOfMeasureIndex(unitOfMeasureId);
            goodsTextBox.Text = name;
        }

        #endregion
        #region Metods

        private int FindCategoryIndex(int id)
        {
            for(int i = 0; i < categoryCmbBox.Items.Count; i++)
            {
                var item = categoryCmbBox.Items[i] as ListBoxItem;
                if (item.Id == id) return i;
            }
            return -1;
        }

        private int FindUnitOfMeasureIndex(int id)
        {
            for (int i = 0; i < unitOfMeasureCmbBox.Items.Count; i++)
            {
                var item = unitOfMeasureCmbBox.Items[i] as ListBoxItem;
                if (item.Id == id) return i;
            }
            return -1;
        }

        private void UpdateComboBoxs()
        {
            categoryCmbBox.ItemsSource = null;
            categoryCmbBox.Items.Clear();
            using (var db = new Model.BudgetModel())
            {
                var categories = db.Categories.ToList();
                List<ListBoxItem> items = new List<ListBoxItem>();
                foreach (var category in categories)
                {
                    var item = new ListBoxItem(category.Id, category.Name);
                    items.Add(item);
                }
                categoryCmbBox.ItemsSource = items;
            }
            unitOfMeasureCmbBox.ItemsSource = null;
            unitOfMeasureCmbBox.Items.Clear();
            using (var db = new Model.BudgetModel())
            {
                var unitOFMeasures = db.UnitOfMeasures.ToList();
                List <ComplexListBoxItem>items = new List<ComplexListBoxItem>();
                foreach (var unitOFMeasure in unitOFMeasures)
                {
                    var item = new ComplexListBoxItem(unitOFMeasure.Id, unitOFMeasure.Name, unitOFMeasure.ShortName);
                    items.Add(item);
                }
                unitOfMeasureCmbBox.ItemsSource = items;
            }
        }

        #endregion
        #region Events Handlers

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            Value = goodsTextBox.Text;
            Category = categoryCmbBox.SelectedItem as ListBoxItem;
            UnitOfMeasure = unitOfMeasureCmbBox.SelectedItem as ListBoxItem;
            if (string.IsNullOrWhiteSpace(Value))
                MessageBox.Show("Введите название");
            else if (categoryCmbBox.SelectedItem == null) MessageBox.Show("Выберите категорию");
            else if (unitOfMeasureCmbBox.SelectedItem == null) MessageBox.Show("Выберите ед.измерения");
            else Close();
        }

        #endregion
    }
}
