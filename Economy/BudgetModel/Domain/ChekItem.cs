using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ChekItem
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public double Quantity { get; set; }

        public virtual GoodsItem GoodsItem { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}
