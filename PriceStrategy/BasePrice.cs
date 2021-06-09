using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEIS.PriceStrategy
{
   public abstract class BasePrice
    {
        protected float discount = 0f;

        public BasePrice() { }

        public virtual float Price(float price)
        {   
            if (discount == 0) return price; // default price

            var discountAmount = price * (discount/100);
            var discountedPrice = price - discountAmount;
            return discountedPrice;
        }
    }
}
