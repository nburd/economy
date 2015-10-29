using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace BudgetWinForms
{
    public partial class GoodsForm : Form
    {
        #region Constructors

        public GoodsForm()
        {
            InitializeComponent();
            UpdateComboBoxCategory();
        }
        
        #endregion
        #region Metods

        private void UpdateListBox()
        {
            goodsItemListBox.Items.Clear();
            using (var db = new Model.BudgetModel())
            {
                var selectedCategory = goodsItemComboBox.SelectedItem as ListBoxItem;
                if (selectedCategory == null) return;
                var goods = db.Categories.Find(selectedCategory.Id).GoodsItems.ToList();
                foreach (var goodsItem in goods)
                {
                    var item = new ComplexListBoxItem(goodsItem.Id, goodsItem.Name, goodsItem.UnitOfMeasure.ShortName);
                    goodsItemListBox.Items.Add(item);
                }
            }
        }  

        private void UpdateComboBoxCategory()
        {
            using (var db = new Model.BudgetModel())
            {
                var categories = db.Categories.ToList();
                foreach (var category in categories)
                {
                    var item = new ListBoxItem(category.Id, category.Name);
                    goodsItemComboBox.Items.Add(item);
                } 
            }
        }

        #endregion
        #region Event Handlers

        private void goodsItemAddButtonClick(object sender, EventArgs e)
        {
            using (var db = new Model.BudgetModel())
            {
                var selectedCategory = goodsItemComboBox.SelectedItem as ListBoxItem;
                AddGoodsItemForm addGoodsItemForm = new AddGoodsItemForm();
                if (selectedCategory != null) addGoodsItemForm = new AddGoodsItemForm(selectedCategory);
                addGoodsItemForm.ShowDialog(this);
                var goods = new GoodsItem();
                if (string.IsNullOrWhiteSpace(addGoodsItemForm.Value)) return;
                else
                {
                    goods.Name = addGoodsItemForm.Value;
                    goods.Category = db.Categories.Find(addGoodsItemForm.SelectedCategory.Id);
                    goods.UnitOfMeasure = db.UnitOfMeasures.Find(addGoodsItemForm.SelectedUnitOfMeasure.Id);
                    db.Goods.Add(goods);
                    db.SaveChanges();
                }
            }
            UpdateListBox();
        }

        private void goodsItemComboBoxSelectedIndexChanged(object sender, EventArgs e) => UpdateListBox();

        private void RenameToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (var db = new Model.BudgetModel())
            {
                var selectedItem = goodsItemListBox.SelectedItem as ListBoxItem;
                if (selectedItem == null) return;
                var selectedCategory = goodsItemComboBox.SelectedItem as ListBoxItem;
                var selectedGoodsItem = db.Goods.Find(selectedItem.Id);
                var selectedUnitOfMeasure = db.UnitOfMeasures.Find(selectedGoodsItem.UnitOfMeasure.Id);
                AddGoodsItemForm addGoodsForm = new AddGoodsItemForm(
                    selectedCategory,
                    selectedUnitOfMeasure,
                    selectedGoodsItem.Name
                    );
                addGoodsForm.ShowDialog(this);
                if (string.IsNullOrWhiteSpace(addGoodsForm.Value)) return;
                else
                {
                    selectedGoodsItem.Name = addGoodsForm.Value;
                    selectedGoodsItem.Category = db.Categories.Find(addGoodsForm.SelectedCategory.Id);
                    selectedGoodsItem.UnitOfMeasure = db.UnitOfMeasures.Find(addGoodsForm.SelectedUnitOfMeasure.Id);
                    db.SaveChanges();
                    UpdateListBox();
                }
            }
        }

        private void DeleteToolStripMenuItemClick(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Удалить?", "Удаление элемента", MessageBoxButtons.YesNo);
            if (res == DialogResult.No) return;
            else
            {
                using (var db = new Model.BudgetModel())
                {
                    var selectedItem = goodsItemListBox.SelectedItem as ListBoxItem;
                    if (selectedItem == null) return;
                    var removeGoodsItem = db.Goods.Find(selectedItem.Id);
                    db.Goods.Remove(removeGoodsItem);
                    db.SaveChanges();
                }
            }
            UpdateListBox();
        }

        #endregion
    }
}
