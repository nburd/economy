using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ChekItem
    {
        public int Id { get; set; }

        [Index("IX_PriceAndGoods", 1, IsUnique = true)]
        public double Price { get; set; }
      
        public double Quantity { get; set; }

        [Index("IX_PriceAndGoods", 2, IsUnique = true)]
        public virtual GoodsItem GoodsItem { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}
