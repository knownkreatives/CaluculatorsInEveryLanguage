namespace CalculateCsharpV2 {
    /// <summary>
    /// The form that values will be inputed as
    /// </summary>
    public struct InputValues() {
        public List<double> Values {
            readonly get => _values;
            init => _values = value;
        }
        private List<double> _values;

        public InputValues(List<double> values) : this() {
            _values = values;
        }

        public InputValues(int size) : this() {
            _values = new List<double>(size);
        }
    }

    /// <summary>
    /// The methods associated to inputs in general
    /// </summary>
    /// <typeparam name="T">A convertable type</typeparam>
    public class Inputs<T> where T : IConvertible {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The inputed value</returns>
        public static T ReadTypeValue() {
            Console.WriteLine($"Input {typeof(T).Name}/N");
            string? tValue = Console.ReadLine();

            if (tValue == null)
                if (!tValue.Equals("N", StringComparison.CurrentCultureIgnoreCase)) {
                    Console.WriteLine($"Invalid response!/nValue not an {typeof(T).Name}/nInput {typeof(T).Name}/n");
                    tValue = Console.ReadLine();
                } else {
                    Console.WriteLine("Escaped reading");
                    tValue = null;
                }

            return (T)Convert.ChangeType(tValue, typeof(T));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg">A custom message that will be used ate the start and </param>
        /// <returns>The inputed value</returns>
        public static T ReadTypeValue(string msg) {
            Console.WriteLine($"{msg}/n");
            string? tValue = Console.ReadLine();

            if (tValue == null)
                if (!tValue.Equals("N", StringComparison.CurrentCultureIgnoreCase)) {
                    Console.WriteLine($"Invalid response read!/nValue not an {typeof(T).Name}/n{msg}/n");
                    tValue = Console.ReadLine();
                } else {
                    Console.WriteLine("Escaped reading");
                    tValue = null;
                }

            return (T)Convert.ChangeType(tValue, typeof(T));
        }
    }

    /// <summary>
    /// The form that values will be outputed as
    /// </summary>
    public struct OutputValues() {
        public List<double>? Values {
            readonly get => _values;
            set => _values = value;
        }
        private List<double>? _values;

        public OutputValues(List<double> values) : this() {
            _values = values;
        }
    }
}
