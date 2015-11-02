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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BudgetWpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var db = new Model.BudgetModel()) { }
        }

        private void categoryButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryWindow category = new CategoryWindow();
            category.ShowDialog();
        }

        private void unitOfMeasureButton_Click(object sender, RoutedEventArgs e)
        {
            UnitofMeasureWindow unitOfMeasure = new UnitofMeasureWindow();
            unitOfMeasure.ShowDialog();
        }

        private void sourceButton_Click(object sender, RoutedEventArgs e)
        {
            SourceWindow source = new SourceWindow();
            source.ShowDialog();
        }

        private void goodsButton_Click(object sender, RoutedEventArgs e)
        {
            GoodsWindow goods = new GoodsWindow();
            goods.ShowDialog();
        }
    }
}
