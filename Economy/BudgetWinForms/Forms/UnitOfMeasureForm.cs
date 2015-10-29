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
            using (var db = new Model.BudgetModel())
            {
                var unitOfMeasures = db.UnitOfMeasures.ToList();
                foreach (var unitOfMeasure in unitOfMeasures)
                {
                    var item = new ComplexListBoxItem(unitOfMeasure.Id, unitOfMeasure.Name, unitOfMeasure.ShortName);
                    unitOfMeasureListBox.Items.Add(item);
                }
            }
        }

        #endregion
        #region Events Handlers

        private void unitOfMeasureAddButtonClick(object sender, EventArgs e)
        {
            using (var db = new Model.BudgetModel())
            {
                var unitOfMeasure = new UnitOfMeasure();
                AddItemForm addItemForm = new AddItemForm("Введите полное название");
                if (addItemForm.ShowDialog(this) == DialogResult.OK)
                    if (string.IsNullOrWhiteSpace(addItemForm.Value) 
                        || addItemForm.Value == "Введите полное название")
                    {
                        MessageBox.Show("Введите название");
                        return;
                    }
                    else
                    {
                        unitOfMeasure.Name = addItemForm.Value;
                        addItemForm = new AddItemForm("Введите сокращенное название");
                        if (addItemForm.ShowDialog(this) == DialogResult.OK)
                            if (string.IsNullOrWhiteSpace(addItemForm.Value) 
                                || addItemForm.Value == "Введите сокращенное название")
                            {
                                MessageBox.Show("Введите название");
                                return;
                            }
                            else
                            {
                                unitOfMeasure.ShortName = addItemForm.Value;
                                db.UnitOfMeasures.Add(unitOfMeasure);
                                db.SaveChanges();
                            }
                    }
                UpdateListBox();
            }
        }
        
        private void RenameToolStripMenuItemClick(object sender, EventArgs e)
        {
            var selectedItem = unitOfMeasureListBox.SelectedItem as ComplexListBoxItem;
            if (selectedItem == null) return;
            using (var db = new Model.BudgetModel())
            {
                var renameItem = db.UnitOfMeasures.Find(selectedItem.Id);
                AddItemForm addItemForm = new AddItemForm(selectedItem.Name);
                if (addItemForm.ShowDialog(this) == DialogResult.OK)
                    if (string.IsNullOrWhiteSpace(addItemForm.Value))
                    {
                        MessageBox.Show("Введите название");
                        return;
                    }
                    else
                    {
                        renameItem.Name = addItemForm.Value;
                        addItemForm = new AddItemForm(selectedItem.ShortName);
                        if (addItemForm.ShowDialog(this) == DialogResult.OK)
                            if (string.IsNullOrWhiteSpace(addItemForm.Value))
                            {
                                MessageBox.Show("Введите название");
                                return;
                            }
                        renameItem.ShortName = addItemForm.Value;
                        db.SaveChanges();
                    }
            }
            UpdateListBox();
        }

        private void DeleteToolStripMenuItemClick(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Удалить?", "Удаление элемента", MessageBoxButtons.YesNo);
            if (res == DialogResult.No) return;
            else
            {
                var selectedItem = unitOfMeasureListBox.SelectedItem as ComplexListBoxItem;
                if (selectedItem == null) return;
                using (var db = new Model.BudgetModel())
                {
                    var removeItem = db.UnitOfMeasures.Find(selectedItem.Id);
                    db.UnitOfMeasures.Remove(removeItem);
                    db.SaveChanges();
                }
            }
            UpdateListBox();
        }

        #endregion
    }
}
