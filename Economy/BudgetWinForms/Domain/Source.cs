using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWinForms
{
    public class Source
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Source()
        {
            Purchases = new HashSet<Purchase>();
        }
    }
}
