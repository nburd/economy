using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Purchase
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public virtual Source Source { get; set; }

        public virtual ICollection<ChekItem> ChekItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Purchase()
        {
            ChekItems = new HashSet<ChekItem>();
        }
    }
}
