using System;

namespace ConsoleEuropeanOptionFactory {

    /// <summary>
    /// Math functions could be static
    /// </summary>
    public static class SpecialFunctions {
        public static double PDF(double x) {
            var A = 1.0 / Math.Sqrt(2.0 * 3.1415);
            return A * Math.Exp(-x * x * 0.5);
        }

        public static double CDF(double x) {
            var a1 = 0.4361836;
            var a2 = -0.1201676;
            var a3 = 0.9372980;
            var k = 1.0 / (1.0 + 0.33267 * x);

            if (x >= 0.0) {
                return 1.0 - PDF(x) * (a1 * k + a2 * k * k + a3 * k * k * k);
            } else {
                return 1.0 - CDF(-x);
            }
        }
    }
}
