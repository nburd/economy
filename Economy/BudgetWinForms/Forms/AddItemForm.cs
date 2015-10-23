using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetWinForms
{
    public partial class AddItemForm : Form
    {
        public string Value { get; private set; }

        public AddItemForm()
        {
            InitializeComponent();
        }

        public AddItemForm(string str)
        {
            InitializeComponent();
            addItemTextBox.Text = str;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Value = addItemTextBox.Text;
        }
    }
}
