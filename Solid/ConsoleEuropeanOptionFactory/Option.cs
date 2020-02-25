using System;

namespace ConsoleEuropeanOptionFactory {
    /// <summary>
    /// Computation: this subsystem contains the classes that perform calculations and that compute results.
    /// </summary>
    public class Option {
        /// <summary>
        /// Interest rate
        /// </summary>
        private readonly double r;

        /// <summary>
        /// Volatility
        /// </summary>
        private readonly double sig;

        /// <summary>
        /// Strike price
        /// </summary>
        private readonly double k;

        /// <summary>
        /// Expiry date
        /// </summary>
        private readonly double t;

        /// <summary>
        /// Cost of carry
        /// </summary>
        private readonly double b;

        /// <summary>
        /// Option name: call or put
        /// </summary>
        private readonly string type;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        private double CallPrice(double stock) {
            var tmp = this.sig * Math.Sqrt(this.t);
            var d1 = (Math.Log(stock / this.k) + (this.b + 0.5 * this.sig * this.sig) * this.t) / tmp;
            var d2 = d1 - tmp;
            var ans = stock * Math.Exp((this.b - this.r) * this.t) * SpecialFunctions.CDF(d1) - this.k * Math.Exp(-this.r * this.t) * SpecialFunctions.CDF(d2);
            return ans;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        private double PutPrice(double stock) {
            var tmp = this.sig * Math.Sqrt(this.t);
            var d1 = (Math.Log(stock / this.k) + (this.b + 0.5 * this.sig * this.sig) * this.t) / tmp;
            var d2 = d1 - tmp;
            var ans = -stock * Math.Exp((this.b - this.r) * this.t) * SpecialFunctions.CDF(-d1) + this.k * Math.Exp(-this.r * this.t) * SpecialFunctions.CDF(-d2);
            return ans;
        }

        public Option(string opType, double expiry, double strike, double costCarry, double interest, double vol) {
            this.type = opType;
            this.t = expiry;
            this.k = strike;
            this.b = costCarry;
            this.r = interest;
            this.sig = vol;
        }

        public double Price(double stock) {
            if (this.type == "call") {
                return this.CallPrice(stock);
            } else {
                return this.PutPrice(stock);
            }
        }
    }
}
