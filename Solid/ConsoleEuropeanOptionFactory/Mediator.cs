using System;

namespace ConsoleEuropeanOptionFactory {
    /// <summary>
    /// this struct coordinates data and control between the others classes and systems.
    /// this object promotes "loose coupling" between the components
    /// </summary>
    public struct Mediator {
        private static IOptionFactory GetFactory() => new ConsoleEuropeanOptionFactory();

        public void Calculate() {
            // 1. Choose how the data in the option will be created
            var fac = GetFactory();

            // 2. Create the option
            var myOption = fac.Create();

            // 3. Get the price
            var stock = 101.0;

            // 4. Display the result
            Console.WriteLine("Price: {0}", myOption.Price(stock));
        }
    }
}
