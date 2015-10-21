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
                    sourcesListBox.Items.Add(source);
            }
        }

        #endregion
        #region Events Handlers

        private void sourceAddButton_Click(object sender, EventArgs e)
        {
            AddItemForm addItemForm = new AddItemForm();
            if(addItemForm.ShowDialog(this) == DialogResult.OK)
            {
                using (var db = new BudgetModel())
                {
                    var source = new Source();
                    source.Name = addItemForm.Value;
                    db.Sources.Add(source);
                    db.SaveChanges();
                }
                UpdateListBox();
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedItem = sourcesListBox.SelectedItem as Source;
            if (selectedItem == null) return;
            AddItemForm addItemForm = new AddItemForm(selectedItem.Name);
            if (addItemForm.ShowDialog(this) == DialogResult.OK)
            {
                using (var db = new BudgetModel())
                {
                    var renameItem = db.Sources.Find(selectedItem.Id);
                    renameItem.Name = addItemForm.Value;
                    db.SaveChanges();
                }
                UpdateListBox();
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedItem = sourcesListBox.SelectedItem as Source;
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
