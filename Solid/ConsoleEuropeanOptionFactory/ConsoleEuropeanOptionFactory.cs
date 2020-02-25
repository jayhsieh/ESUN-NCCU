namespace ConsoleEuropeanOptionFactory {
    /// <summary>
    /// 單一職責原則: Single Responsinility Principle (SRP)
    /// Factory: this class whose responsibility is to initialize the data and other relevent infomation pertaining to the objects that we wish to create.
    /// </summary>
    public class ConsoleEuropeanOptionFactory : IOptionFactory {
        /// <summary>
        /// implement the interface and re-write the function Create()
        /// </summary>
        /// <returns></returns>
        public Option Create() {
            var r = 0.05;
            var sig = 0.1;
            var k = 100.0;
            var t = 1.0;
            var b = 0.01;
            var type = "call";
            var opt = new Option(type, t, k, b, r, sig);
            return opt;
        }
    }
}
