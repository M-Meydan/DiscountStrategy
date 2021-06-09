using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEIS.PriceStrategy
{
    public interface IPriceStrategy
    {
        float Price(float price);
    }
}
