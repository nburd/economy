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
    public partial class ChekItemForm : Form
    {   
        public int IdPurchase { get; set; }

        public int IdChekItem { get; set; }
            
        #region Constructors

        public ChekItemForm()
        {
            InitializeComponent();
            UpdateComboBoxCategory();
        }

        public ChekItemForm(int id)
        {
            InitializeComponent();
            UpdateComboBoxCategory();
            IdPurchase = id;
            UpdateDataGrid();
        }

        #endregion
        #region Metods

        private void UpdateComboBoxCategory()
        {
            using (var db = new BudgetModel())
            {
                var categories = db.Categories.ToList();
                foreach (var category in categories)
                {
                    var item = new ListBoxItem(category.Id, category.Name);
                    chekCategoryComboBox.Items.Add(item);
                }
            }
        }

        private void UpdateListBox()
        {
            chekGoodsListBox.Items.Clear();
            using (var db = new BudgetModel())
            {
                var selectedCategory = chekCategoryComboBox.SelectedItem as ListBoxItem;
                var goods = db.Categories.Find(selectedCategory.Id).GoodsItems.ToList();
                foreach (var goodsItem in goods)
                {
                    var item = new ComplexListBoxItem(goodsItem.Id, goodsItem.Name, goodsItem.UnitOfMeasure.ShortName);
                    chekGoodsListBox.Items.Add(item);
                }
            }
        }

        private void UpdateDataGrid()
        {
            chekItemDataGridView.Rows.Clear();
            using (var db = new BudgetModel())
            {
                var chekItems = db.Purchases.Find(IdPurchase).ChekItems.ToList();
                var renameButton = new DataGridViewButtonCell();
                var removeButton = new DataGridViewButtonCell();
                foreach (var chekItem in chekItems)
                    chekItemDataGridView.Rows.Add(chekItem.Id, chekItem.GoodsItem.Category.Name, chekItem.GoodsItem.Name, chekItem.Price, chekItem.Quantity, renameButton, removeButton);
            }
        }

        private void CreateChekItem()
        {
            using (var db = new BudgetModel())
            {
                var chekItem = new ChekItem();                
                var selectedGoods = chekGoodsListBox.SelectedItem as ListBoxItem;
                chekItem.GoodsItem = db.Goods.Find(selectedGoods.Id);
                chekItem.Price = double.Parse(chekPriceTextBox.Text);
                chekItem.Quantity = double.Parse(chekQuantityTextBox.Text);
                chekItem.Purchase = db.Purchases.Find(IdPurchase);
                db.ChekItems.Add(chekItem);
                db.SaveChanges();
            }
        }

        private void RenameChekItem(int idItem)
        {
            using (var db = new BudgetModel())
            {
                var chekItem = db.ChekItems.Find(idItem);
                var selectedGoods = chekGoodsListBox.SelectedItem as ListBoxItem;
                chekItem.GoodsItem = db.Goods.Find(selectedGoods.Id);
                chekItem.Price = double.Parse(chekPriceTextBox.Text);
                chekItem.Quantity = double.Parse(chekQuantityTextBox.Text);
                db.SaveChanges();
            }
        }

        #endregion
        #region Events Handlers

        private void chekCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e) => UpdateListBox();
        
        private void ClearForm()
        {
            chekCategoryComboBox.Items.Clear();
            chekGoodsListBox.Items.Clear();
            chekPriceTextBox.Clear();
            chekQuantityTextBox.Clear();
            UpdateComboBoxCategory();
        }

        private void chekAddButton_Click(object sender, EventArgs e)
        {
            CreateChekItem();
            UpdateDataGrid();
            ClearForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chekItemDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 5)
            {
                saveButton.Enabled = true;
                IdChekItem = (int)(chekItemDataGridView[0, e.RowIndex].Value);
                using (var db = new BudgetModel())
                {
                    var chekItem = db.ChekItems.Find(IdChekItem);
                    chekCategoryComboBox.SelectedIndex = chekCategoryComboBox.FindString(chekItem.GoodsItem.Category.Name);     
                    UpdateListBox();
                    chekGoodsListBox.SelectedIndex = chekGoodsListBox.FindString(chekItem.GoodsItem.Name);
                    chekPriceTextBox.Text = chekItem.Price.ToString();
                    chekQuantityTextBox.Text = chekItem.Quantity.ToString();
                }
            }
            else if (e.ColumnIndex == 6)
            {
                var IdItem = (int)(chekItemDataGridView[0, e.RowIndex].Value);
                using (var db = new BudgetModel())
                {
                    var removeItem = db.ChekItems.Find(IdItem);
                    db.ChekItems.Remove(removeItem);
                    db.SaveChanges();
                }
            }
            UpdateDataGrid();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            RenameChekItem(IdChekItem);
            UpdateDataGrid();
        }

        #endregion
    }
}
