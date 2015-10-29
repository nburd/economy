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
            using (var db = new Model.BudgetModel())
            {
                var categories = db.Categories.ToList();
                foreach (var category in categories)
                {
                    var item = new ListBoxItem(category.Id, category.Name);
                    categoriesListBox.Items.Add(item);
                }
            }
        }

        #endregion
        #region Events Handlers

        private void categoryAddButtonClick(object sender, EventArgs e)
        {
            AddItemForm addItemForm = new AddItemForm();
            if(addItemForm.ShowDialog(this) == DialogResult.OK)
            {
                using (var db = new Model.BudgetModel())
                {
                    var category = new Category();
                    if (string.IsNullOrWhiteSpace(addItemForm.Value)) MessageBox.Show("Введите название");
                    else
                    {
                        category.Name = addItemForm.Value;
                        db.Categories.Add(category);
                        db.SaveChanges();
                    }
                }
                UpdateListBox();
            }
        }

        private void RenameToolStripMenuItemClick(object sender, EventArgs e)
        {
            var selectedItem = categoriesListBox.SelectedItem as ListBoxItem;
            if (selectedItem == null) return;
            AddItemForm addItemForm = new AddItemForm(selectedItem.Name);
            if (addItemForm.ShowDialog(this) == DialogResult.OK)
            {
                using (var db = new Model.BudgetModel())
                {
                    var renameItem = db.Categories.Find(selectedItem.Id);
                    if (string.IsNullOrWhiteSpace(addItemForm.Value)) MessageBox.Show("Введите название");
                    else
                    {
                        renameItem.Name = addItemForm.Value;
                        db.SaveChanges();
                    }
                }
                UpdateListBox();
            }
        }

        private void RemoveToolStripMenuItemClick(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Удалить?", "Удаление элемента", MessageBoxButtons.YesNo);
            if (res == DialogResult.No) return;
            else
            {
                var selectedItem = categoriesListBox.SelectedItem as ListBoxItem;
                if (selectedItem == null) return;
                using (var db = new Model.BudgetModel())
                {
                    var removeItem = db.Categories.Find(selectedItem.Id);
                    db.Categories.Remove(removeItem);
                    db.SaveChanges();
                }
            }
            UpdateListBox();
        }

        #endregion
    }
}
