using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWinForms
{
    public class Purchase
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public virtual Source Source { get; set; }

        public virtual ICollection<ChekItem> ChekItems { get; set; }

        public Purchase()
        {
            ChekItems = new HashSet<ChekItem>();
        }
    }
}
