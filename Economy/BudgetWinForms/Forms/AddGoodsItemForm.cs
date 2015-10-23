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
    public partial class AddGoodsItemForm : Form
    {
        public string Value { get; private set; }

        public ListBoxItem SelectedCategory { get; private set; }

        public ComplexListBoxItem SelectedUnitOfMeasure { get; private set; }

        #region Constructors

        public AddGoodsItemForm()
        {
            InitializeComponent();
            FillForm();
        }

        public AddGoodsItemForm(ListBoxItem category, UnitOfMeasure unitOfMeasure, string value)
        {
            InitializeComponent();
            FillForm();
            addGoodsCategoryComboBox.SelectedIndex = addGoodsCategoryComboBox.FindString(category.Name);                
            addGoodsUnitOfMeasureComboBox.SelectedIndex = addGoodsUnitOfMeasureComboBox.FindString(unitOfMeasure.Name);
            addGoodsItemTextBox.Text = value;
            
        }

        #endregion
        #region Metods

        private void FillForm()
        {
            using (var db = new BudgetModel())
            {
                var categories = db.Categories.ToList();
                foreach (var category in categories)
                {
                    var item = new ListBoxItem(category.Id, category.Name);
                    addGoodsCategoryComboBox.Items.Add(item);
                }
                var unitOfMeasures = db.UnitOfMeasures.ToList();
                foreach (var unitOfMeasure in unitOfMeasures)
                {
                    var item = new ComplexListBoxItem(unitOfMeasure.Id, unitOfMeasure.Name, unitOfMeasure.ShortName);
                    addGoodsUnitOfMeasureComboBox.Items.Add(item);
                }
            }
        }

        #endregion
        #region Events Handlers

        private void addGoodsItemButton_Click(object sender, EventArgs e) => Value = addGoodsItemTextBox.Text;

        private void addGoodsCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e) => SelectedCategory = addGoodsCategoryComboBox.SelectedItem as ListBoxItem;

        private void AddGoodsUnitOfMeasureComboBox_SelectedIndexChanged(object sender, EventArgs e) => SelectedUnitOfMeasure = addGoodsUnitOfMeasureComboBox.SelectedItem as ComplexListBoxItem;

        #endregion
    }
}
