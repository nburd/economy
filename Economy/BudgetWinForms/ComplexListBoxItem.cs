using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWinForms
{
    public class ComplexListBoxItem : ListBoxItem
    {
        public string ShortName { get; set; }

        public ComplexListBoxItem(int id, string name, string shortName): base(id, name)
        {
            ShortName = shortName;
        }

        public override string ToString() => $"{Name} ({ShortName})";
        
    }
}
