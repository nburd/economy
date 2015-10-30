using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Category
    {
        public int Id { get; set; }
       
        [Index(IsUnique = true)]                
        public string Name { get; set; }
        
        public virtual ICollection<GoodsItem> GoodsItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            GoodsItems = new HashSet<GoodsItem>();
        }
    }
}
