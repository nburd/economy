using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWinForms
{
    public class GoodsItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Category Category { get; set; }

        public virtual UnitOfMeasure UnitOfMeasure { get; set; }

        public virtual ICollection<ChekItem> ChekItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoodsItem()
        {
            ChekItems = new HashSet<ChekItem>();
        }
    }
}
