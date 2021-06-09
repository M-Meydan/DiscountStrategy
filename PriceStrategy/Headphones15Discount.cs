namespace BEIS.PriceStrategy
{
    public class Headphones15Discount : BasePrice, IPriceStrategy
    {
        public Headphones15Discount() : base()
        {
            discount = 15;
        }
    }
}
