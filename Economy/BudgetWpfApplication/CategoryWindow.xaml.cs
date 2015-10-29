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
        public CategoryWindow()
        {
            InitializeComponent();
            UpdateListBox();
        }

        #region Metods

        private void UpdateListBox()
        {
            categoryListBox.Items.Clear();
            using (var db = new Model.BudgetModel())
            {
                var categories = db.Categories.ToList();
                foreach (var category in categories)
                {
                    var item = new ListBoxItem(category.Id, category.Name);
                    categoryListBox.Items.Add(item);
                }
            }
        }

        #endregion

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
