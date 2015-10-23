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
            using (var db = new BudgetModel())
            {
                var selectedCategory = goodsItemComboBox.SelectedItem as ListBoxItem;
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
            using (var db = new BudgetModel())
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

        private void goodsItemAddButton_Click(object sender, EventArgs e)
        {
            AddGoodsItemForm addGoodsItemForm = new AddGoodsItemForm();
            using (var db = new BudgetModel())
            {
                if(addGoodsItemForm.ShowDialog(this) == DialogResult.OK)
                {
                    var goods = new GoodsItem();
                    goods.Name = addGoodsItemForm.Value;
                    goods.Category = db.Categories.Find(addGoodsItemForm.SelectedCategory.Id);
                    goods.UnitOfMeasure = db.UnitOfMeasures.Find(addGoodsItemForm.SelectedUnitOfMeasure.Id);
                    db.Goods.Add(goods);
                    db.SaveChanges();
                }
            }
            UpdateListBox();
        }

        private void goodsItemComboBox_SelectedIndexChanged(object sender, EventArgs e) => UpdateListBox();

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var db = new BudgetModel()) {
                var selectedItem = goodsItemListBox.SelectedItem as ListBoxItem;
                var selectedCategory = goodsItemComboBox.SelectedItem as ListBoxItem;
                var selectedGoodsItem = db.Goods.Find(selectedItem.Id);
                var selectedUnitOfMeasure = db.UnitOfMeasures.Find(selectedGoodsItem.UnitOfMeasure.Id);
                AddGoodsItemForm addGoodsForm = new AddGoodsItemForm(selectedCategory, selectedUnitOfMeasure, selectedGoodsItem.Name);
                if(addGoodsForm.ShowDialog(this) == DialogResult.OK)
                {
                    selectedGoodsItem.Name = addGoodsForm.Value;
                    selectedGoodsItem.Category = db.Categories.Find(addGoodsForm.SelectedCategory.Id);
                    selectedGoodsItem.UnitOfMeasure = db.UnitOfMeasures.Find(addGoodsForm.SelectedUnitOfMeasure.Id);
                    db.SaveChanges();
                }
                UpdateListBox();
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var db = new BudgetModel())
            {
                var selectedItem = goodsItemListBox.SelectedItem as ListBoxItem;
                var removeGoodsItem = db.Goods.Find(selectedItem.Id);
                db.Goods.Remove(removeGoodsItem);
                db.SaveChanges();
            }
            UpdateListBox();
        }

        #endregion
    }
}
