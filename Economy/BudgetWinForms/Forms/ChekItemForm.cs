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
                    chekItemDataGridView.Rows.Add(
                        chekItem.Id, 
                        chekItem.GoodsItem.Category.Name, 
                        chekItem.GoodsItem.Name, 
                        chekItem.Price, 
                        chekItem.Quantity, 
                        renameButton, 
                        removeButton
                        );
            }
        }

        private void CreateChekItem()
        {
            using (var db = new BudgetModel())
            {
                var chekItem = new ChekItem();                
                var selectedGoods = chekGoodsListBox.SelectedItem as ListBoxItem;
                chekItem.GoodsItem = db.Goods.Find(selectedGoods.Id);
                chekItem.Price = double.Parse(chekPriceTextBox.Text.Replace(",", ".").Replace(".", ","));
                chekItem.Quantity = double.Parse(chekQuantityTextBox.Text.Replace(",", ".").Replace(".", ","));
                chekItem.Purchase = db.Purchases.Find(IdPurchase);
                db.ChekItems.Add(chekItem);
                db.SaveChanges();
            }
        }

        private void RenameChekItem(int idItem)
        {
            double res;
            if (chekCategoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию");
                return;
            }
            if (chekGoodsListBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите товар");
                return;
            }
            if (string.IsNullOrWhiteSpace(chekPriceTextBox.Text))
            {
                MessageBox.Show("Введите цену");
                return;
            }
            else if (!double.TryParse(chekPriceTextBox.Text.Replace(",", ".").Replace(".", ","), out res))
            {
                MessageBox.Show("Введите корректную цену");
                return;
            }
            if (string.IsNullOrWhiteSpace(chekQuantityTextBox.Text))
            {
                MessageBox.Show("Введите количество");
                return;
            }
            else if (!double.TryParse(chekQuantityTextBox.Text.Replace(",", ".").Replace(".", ","), out res))
            {
                MessageBox.Show("Введите корректное количество");
                return;
            }
            using (var db = new BudgetModel())
            {
                var chekItem = db.ChekItems.Find(idItem);
                var selectedGoods = chekGoodsListBox.SelectedItem as ListBoxItem;
                chekItem.GoodsItem = db.Goods.Find(selectedGoods.Id);
                chekItem.Price = double.Parse(chekPriceTextBox.Text.Replace(",", ".").Replace(".", ","));
                chekItem.Quantity = double.Parse(chekQuantityTextBox.Text.Replace(",", ".").Replace(".", ","));
                db.SaveChanges();
            }
        }
       
        #endregion
        #region Events Handlers

        private void chekCategoryComboBoxSelectedIndexChanged(object sender, EventArgs e) => UpdateListBox();
        
        private void ClearForm()
        {
            chekCategoryComboBox.Items.Clear();
            chekGoodsListBox.Items.Clear();
            chekPriceTextBox.Clear();
            chekQuantityTextBox.Clear();
            UpdateComboBoxCategory();
        }

        private void chekAddButtonClick(object sender, EventArgs e)
        {
            double res;
            if (chekCategoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию");
                return;
            }
            if (chekGoodsListBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите товар");
                return;
            }
            if (string.IsNullOrWhiteSpace(chekPriceTextBox.Text))
            {
                MessageBox.Show("Введите цену");
                return;
            }
            else if (!double.TryParse(chekPriceTextBox.Text.Replace(",", ".").Replace(".", ","), out res))
            {
                MessageBox.Show("Введите корректную цену");
                return;
            }
            if (string.IsNullOrWhiteSpace(chekQuantityTextBox.Text))
            {
                MessageBox.Show("Введите количество");
                return;
            }
            else if (!double.TryParse(chekQuantityTextBox.Text.Replace(",", ".").Replace(".", ","), out res))
            {
                MessageBox.Show("Введите корректное количество");
                return;
            }
            CreateChekItem();
            UpdateDataGrid();
            ClearForm();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            using (var db = new BudgetModel())
            {
                var chekItems = db.Purchases.Find(IdPurchase).ChekItems.ToList();
                if (chekItems.Count != 0) Close();
                else
                {
                    var purchase = db.Purchases.Find(IdPurchase);
                    db.Purchases.Remove(purchase);
                    db.SaveChanges();
                }
            }
        }

        private void chekItemDataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == 5)
            {
                saveButton.Enabled = true;
                chekAddButton.Enabled = false;
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
                var res = MessageBox.Show("Удалить?", "Удаление элемента", MessageBoxButtons.YesNo);
                if (res == DialogResult.No) return;
                else
                {
                    var IdItem = (int)(chekItemDataGridView[0, e.RowIndex].Value);
                    using (var db = new BudgetModel())
                    {
                        var removeItem = db.ChekItems.Find(IdItem);
                        db.ChekItems.Remove(removeItem);
                        db.SaveChanges();
                    }
                }
            }
            UpdateDataGrid();
        }

        private void saveButtonClick(object sender, EventArgs e)
        {
            RenameChekItem(IdChekItem);
            UpdateDataGrid();
        }

        #endregion
    }
}
