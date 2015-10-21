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
    public partial class CategoryForm : Form
    {

        #region Constructors

        public CategoryForm()
        {
            InitializeComponent();
            UpdateListBox();
        }

        #endregion
        #region Metods

        private void UpdateListBox()
        {
            categoriesListBox.Items.Clear();
            using (var db = new BudgetModel())
            {
                var categories = db.Categories.ToList();
                foreach (var category in categories)
                    categoriesListBox.Items.Add(category);
            }
        }

        #endregion
        #region Events Handlers

        private void categoryAddButton_Click(object sender, EventArgs e)
        {
            AddItemForm addItemForm = new AddItemForm();
            if(addItemForm.ShowDialog(this) == DialogResult.OK)
            {
                using (var db = new BudgetModel())
                {
                    var category = new Category();
                    category.Name = addItemForm.Value;
                    db.Categories.Add(category);
                    db.SaveChanges();
                }
                UpdateListBox();
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedItem = categoriesListBox.SelectedItem as Category;
            if (selectedItem == null) return;
            AddItemForm addItemForm = new AddItemForm(selectedItem.Name);
            if (addItemForm.ShowDialog(this) == DialogResult.OK)
            {
                using (var db = new BudgetModel())
                {
                    var renameItem = db.Categories.Find(selectedItem.Id);
                    renameItem.Name = addItemForm.Value;
                    db.SaveChanges();
                }
                UpdateListBox();
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedItem = categoriesListBox.SelectedItem as Category;
            if (selectedItem == null) return;
            using (var db = new BudgetModel())
            {
                var removeItem = db.Categories.Find(selectedItem.Id);
                db.Categories.Remove(removeItem);
                db.SaveChanges();
            }
            UpdateListBox();
        }

        #endregion
    }
}
