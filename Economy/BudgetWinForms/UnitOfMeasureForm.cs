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
    public partial class UnitOfMeasureForm : Form
    {
        #region Constructors

        public UnitOfMeasureForm()
        {
            InitializeComponent();
            UpdateListBox();
        }

        #endregion
        #region Metods

        private void UpdateListBox()
        {
            unitOfMeasureListBox.Items.Clear();
            using (var db = new BudgetModel())
            {
                var unitOfMeasures = db.UnitOfMeasures.ToList();
                foreach (var unitOfMeasure in unitOfMeasures)
                    unitOfMeasureListBox.Items.Add(unitOfMeasure);
            }
        }

        #endregion
        #region Events Handlers

        private void unitOfMeasureAddButton_Click(object sender, EventArgs e)
        {
            using (var db = new BudgetModel())
            {
                var unitOfMeasure = new UnitOfMeasure();
                AddItemForm addItemForm = new AddItemForm("Введите полное название");
                if (addItemForm.ShowDialog(this) == DialogResult.OK)
                    unitOfMeasure.Name = addItemForm.Value;
                addItemForm = new AddItemForm("Введите сокращенное название");
                if (addItemForm.ShowDialog(this) == DialogResult.OK)
                    unitOfMeasure.ShortName = addItemForm.Value;
                db.UnitOfMeasures.Add(unitOfMeasure);
                db.SaveChanges();
            }
            UpdateListBox();
        }
        
        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedItem = unitOfMeasureListBox.SelectedItem as UnitOfMeasure;
            using (var db = new BudgetModel())
            {
                var renameItem = db.UnitOfMeasures.Find(selectedItem.Id);
                AddItemForm addItemForm = new AddItemForm(selectedItem.Name);
                if (addItemForm.ShowDialog(this) == DialogResult.OK)
                    renameItem.Name = addItemForm.Value;
                addItemForm = new AddItemForm(selectedItem.ShortName);
                if (addItemForm.ShowDialog(this) == DialogResult.OK)
                    renameItem.ShortName = addItemForm.Value;
                db.SaveChanges();
            }
            UpdateListBox();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedItem = unitOfMeasureListBox.SelectedItem as UnitOfMeasure;
            if (selectedItem == null) return;
            using (var db = new BudgetModel())
            {
                var removeItem = db.UnitOfMeasures.Find(selectedItem.Id);
                db.UnitOfMeasures.Remove(removeItem);
                db.SaveChanges();
            }
            UpdateListBox();
        }

        #endregion
    }
}
