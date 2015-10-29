using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Source
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Source()
        {
            Purchases = new HashSet<Purchase>();
        }
    }
}
