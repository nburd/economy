using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWpfApplication
{
    public class ListBoxItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ListBoxItem(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;
    }
}
