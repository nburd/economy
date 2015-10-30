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

namespace BudgetWpfApplication
{
    /// <summary>
    /// Interaction logic for AddItemsWindow.xaml
    /// </summary>
    public partial class AddItemsWindow : Window
    {
        public string Value { get; set; }

        public AddItemsWindow()
        {
            InitializeComponent();
        }

        public AddItemsWindow(string text)
        {
            InitializeComponent();
            textBox.Text = text;
            textBox.SelectAll();
            textBox.Focus();
            Value = textBox.Text;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Value = textBox.Text;
            Close();
        }
    }
}
