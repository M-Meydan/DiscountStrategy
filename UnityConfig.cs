using BEIS;
using BEIS.PriceStrategy;
using System;
using Unity;
using Unity.Lifetime;

namespace BEIS
{
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the types with Unity container
        /// <example>
        ///  - for simple types: container.RegisterType<IApplication, Application>();
        ///  - for named type registration container.RegisterType<IStrategy, Addition>("add", new ContainerControlledLifetimeManager());
        /// </example>
        /// </summary>
        public static void RegisterTypes()
        {
            var container = UnityConfig.Container;
            container.RegisterType<IApplication, Application>();
            container.RegisterType<IProductValidator, ProductValidator>();

            container.RegisterType<IPriceStrategy, BluetoothSpeaker7Discount>("Bluetooth Speaker", new ContainerControlledLifetimeManager());
            container.RegisterType<IPriceStrategy, Headphones15Discount>("Headphones", new ContainerControlledLifetimeManager());

        }
    }

    
}
