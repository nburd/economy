using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWinForms
{
    public class UnitOfMeasure
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public virtual ICollection<GoodsItem> GoodsItems { get; set; }

        public UnitOfMeasure()
        {
            GoodsItems = new HashSet<GoodsItem>();
        }
    }
}
