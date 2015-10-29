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
    public partial class SourceForm : Form
    {
        #region Constructors

        public SourceForm()
        {
            InitializeComponent();
            UpdateListBox();
        }

        #endregion
        #region Metods

        private void UpdateListBox()
        {
            sourcesListBox.Items.Clear();
            using (var db = new BudgetModel())
            {
                var sources = db.Sources.ToList();
                foreach (var source in sources)
                {
                    var item = new ListBoxItem(source.Id, source.Name);
                    sourcesListBox.Items.Add(item);
                }
            }
        }

        #endregion
        #region Events Handlers

        private void sourceAddButtonClick(object sender, EventArgs e)
        {
            AddItemForm addItemForm = new AddItemForm();
            if(addItemForm.ShowDialog(this) == DialogResult.OK)
            {
                using (var db = new BudgetModel())
                {
                    var source = new Source();
                    if (string.IsNullOrWhiteSpace(addItemForm.Value)) MessageBox.Show("Введите название");
                    else
                    {
                        source.Name = addItemForm.Value;
                        db.Sources.Add(source);
                        db.SaveChanges();
                    }
                }
                UpdateListBox();
            }
        }

        private void RenameToolStripMenuItemClick(object sender, EventArgs e)
        {
            var selectedItem = sourcesListBox.SelectedItem as ListBoxItem;
            if (selectedItem == null) return;
            AddItemForm addItemForm = new AddItemForm(selectedItem.Name);
            if (addItemForm.ShowDialog(this) == DialogResult.OK)
            {
                using (var db = new BudgetModel())
                {
                    var renameItem = db.Sources.Find(selectedItem.Id);
                    if(string.IsNullOrWhiteSpace(addItemForm.Value)) MessageBox.Show("Введите название");
                    else
                    {
                        renameItem.Name = addItemForm.Value;
                        db.SaveChanges();
                    }
                }
                UpdateListBox();
            }
        }

        private void DeleteToolStripMenuItemClick(object sender, EventArgs e)
        {
            var selectedItem = sourcesListBox.SelectedItem as ListBoxItem;
            if (selectedItem == null) return;
            using (var db = new BudgetModel())
            {
                var removeItem = db.Sources.Find(selectedItem.Id);
                db.Sources.Remove(removeItem);
                db.SaveChanges();
            }
            UpdateListBox();
        }

        #endregion
    }
}
