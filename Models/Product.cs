using BEIS.PriceStrategy;
using Unity;
namespace BEIS.Models
{
    public class Product
    {
        public Product() { }

        public Product(string id, string productType, float price)
        {
            Id = id;
            ProductType = productType;
            _price = price;
        }

        public string Id { get; private set; }
        public string ProductType { get; private set; }
        private float _price;
        public string PriceFormatted => string.Format("{0:n3}", GetPrice());

        public float GetPrice()
        {
            // Unity used as factory method here:
            // if the discount pricing is so simple  then a simple dictionary with (productName:discount)
            // could just work fine. You just introduce new product and discount thats all.
            // For complex pricing structure this price strategy is more organised
            if (UnityConfig.Container.IsRegistered<IPriceStrategy>(ProductType))
            {
                var discountStrategy = UnityConfig.Container.Resolve<IPriceStrategy>(ProductType);
                return discountStrategy.Price(_price);
            }

            return _price;
        }
    }
}
