namespace CalculatorCsharpV1 {
    public enum InputType {
        One, // one value is given
        Two, // two values are given
        Multiple // more than two values can be given
    }

    public record struct Input() {
        public decimal X {
            readonly get => _x;
            set => _x = value;
        }
        private decimal _x;

        public decimal [] Y {
            readonly get => _y;
            set => _y = value;
        }
        private decimal [] _y;

        public readonly InputType Type => _type;
        private InputType _type;

        public Input(InputType type) : this() {
            _type = type;

            switch (_type) {
                case InputType.One:
                _x = Input.GetDecimalValue();
                break;
                case InputType.Two:
                _x = Input.GetDecimalValue();
                _y = [Input.GetDecimalValue()];
                break;
                case InputType.Multiple:
                _x = Input.GetDecimalValue();
                List<decimal> values = [];
                Program.ContinueTopic(() => {
                    values.Add(Input.GetDecimalValue(   ));
                },
                () => {
                    // dosn't need an end action
                }, "Input logging");
                _y = [..values];
                break;
            }
        }
        public Input(decimal x, decimal [] y) : this() {
            _x = x;

            if (!(y == null || y.Length == 0)) {
                _y = y;
            } else {
                _y = [];
            }

            DetermineInputType();
        }
        public Input(int x, int [] y) : this() {
            _x = (decimal)x;

            if (y != null || y.Length != 0) {
                _y = Array.ConvertAll(y, v => (decimal)v);
            } else {
                _y = [];
            }

            DetermineInputType();
        }

        public override readonly string ToString() {
            string response = $"{_x}";

            switch (_type) {
                case InputType.One:
                response += ". 1 Value";
                break;
                case InputType.Two:
                response += $", {_y [0]}";
                response += ". 2 Values";
                break;
                case InputType.Multiple:
                foreach (decimal v in _y) {
                    response += $", {v} Values";
                }
                response += $". {_y.Length} Values";
                break;
            }

            return response;
        }


        /// <summary>
        /// Asks the user to input and integer and validates the response before returning the value
        /// </summary>
        /// <returns>a validated value inputed into the console</returns>
        public static int GetIntValue() {
            Console.WriteLine("Input integer value");
            string value = Console.ReadLine();

            while (!int.TryParse(value, out _)) {
                if (!value.Equals("escape", StringComparison.CurrentCultureIgnoreCase)) {
                    Console.WriteLine("Invalid response!");
                    Console.WriteLine("Value not an integer");
                    Console.WriteLine("Input integer value");
                    value = Console.ReadLine();
                } else {
                    Console.WriteLine("Escaped integer input");
                    value = "0";
                }
            }

            return int.Parse(value);
        }
        /// <summary>
        /// Asks the user to input and float and validates the response before returning the value
        /// </summary>
        /// <param name="msg">a custom message for the input</param>
        /// <returns>a validated value inputed into the console</returns>
        public static int GetIntValue(string msg) {
            Console.WriteLine(msg);
            string value = Console.ReadLine();

            while (!decimal.TryParse(value, out _)) {
                if (!value.Equals("escape", StringComparison.CurrentCultureIgnoreCase)) {
                    Console.WriteLine("Invalid response!");
                    Console.WriteLine("Value not a integer");
                    Console.WriteLine(msg);
                    value = Console.ReadLine();
                } else {
                    Console.WriteLine("Escaped decimal input");
                    value = "0";
                }
            }

            return int.Parse(value);
        }

        /// <summary>
        /// Asks the user to input and float and validates the response before returning the value
        /// </summary>
        /// <returns>a validated value inputed into the console</returns>
        public static float GetFloatValue() {
            Console.WriteLine("Input float value");
            string value = Console.ReadLine();

            while (!float.TryParse(value, out _)) {
                if (!value.Equals("escape", StringComparison.CurrentCultureIgnoreCase)) {
                    Console.WriteLine("Invalid response!");
                    Console.WriteLine("Value not a float");
                    Console.WriteLine("Input float value");
                    value = Console.ReadLine();
                } else {
                    Console.WriteLine("Escaped float input");
                    value = "0";
                }
            }

            return float.Parse(value);
        }
        /// <summary>
        /// Asks the user to input and float and validates the response before returning the value
        /// </summary>
        /// <param name="msg">a custom message for the input</param>
        /// <returns>a validated value inputed into the console</returns>
        public static float GetFloatValue(string msg) {
            Console.WriteLine(msg);
            string value = Console.ReadLine();

            while (!decimal.TryParse(value, out _)) {
                if (!value.Equals("escape", StringComparison.CurrentCultureIgnoreCase)) {
                    Console.WriteLine("Invalid response!");
                    Console.WriteLine("Value not a float");
                    Console.WriteLine(msg);
                    value = Console.ReadLine();
                } else {
                    Console.WriteLine("Escaped decimal input");
                    value = "0";
                }
            }

            return float.Parse(value);
        }

        /// <summary>
        /// Asks the user to input and double and validates the response before returning the value
        /// </summary>
        /// <returns>a validated value inputed into the console</returns>
        public static double GetDoubleValue() {
            Console.WriteLine("Input double value");
            string value = Console.ReadLine();

            while (!double.TryParse(value, out _)) {
                if (!value.Equals("escape", StringComparison.CurrentCultureIgnoreCase)) {
                    Console.WriteLine("Invalid response!");
                    Console.WriteLine("Value not a double");
                    Console.WriteLine("Input double value");
                    value = Console.ReadLine();
                } else {
                    Console.WriteLine("Escaped double input");
                    value = "0";
                }
            }

            return double.Parse(value);
        }
        /// <summary>
        /// Asks the user to input and double and validates the response before returning the value
        /// </summary>
        /// <param name="msg">a custom message for the input</param>
        /// <returns>a validated value inputed into the console</returns>
        public static double GetDoubleValue(string msg) {
            Console.WriteLine(msg);
            string value = Console.ReadLine();

            while (!decimal.TryParse(value, out _)) {
                if (!value.Equals("escape", StringComparison.CurrentCultureIgnoreCase)) {
                    Console.WriteLine("Invalid response!");
                    Console.WriteLine("Value not a double");
                    Console.WriteLine(msg);
                    value = Console.ReadLine();
                } else {
                    Console.WriteLine("Escaped decimal input");
                    value = "0";
                }
            }

            return double.Parse(value);
        }

        /// <summary>
        /// Asks the user to input and decimal and validates the response before returning the value
        /// </summary>
        /// <returns>a validated value inputed into the console</returns>
        public static decimal GetDecimalValue() {
            Console.WriteLine("Input decimal value");
            string value = Console.ReadLine();

            while (!decimal.TryParse(value, out _)) {
                if (!value.Equals("escape", StringComparison.CurrentCultureIgnoreCase)) {
                    Console.WriteLine("Invalid response!");
                    Console.WriteLine("Value not a decimal");
                    Console.WriteLine("Input decimal value");
                    value = Console.ReadLine();
                } else {
                    Console.WriteLine("Escaped decimal input");
                    value = "0";
                }
            }

            return decimal.Parse(value);
        }
        /// <summary>
        /// Asks the user to input and decimal and validates the response before returning the value
        /// </summary>
        /// <param name="msg">a custom message for the input</param>
        /// <returns>a validated value inputed into the console</returns>
        public static decimal GetDecimalValue(string msg) {
            Console.WriteLine(msg);
            string value = Console.ReadLine();

            while (!decimal.TryParse(value, out _)) {
                if (!value.Equals("escape", StringComparison.CurrentCultureIgnoreCase)) {
                    Console.WriteLine("Invalid response!");
                    Console.WriteLine("Value not a decimal");
                    Console.WriteLine(msg);
                    value = Console.ReadLine();
                } else {
                    Console.WriteLine("Escaped decimal input");
                    value = "0";
                }
            }

            return decimal.Parse(value);
        }

        /// <summary>
        /// Swiches the input type of an Input object
        /// </summary>
        private void DetermineInputType() {
            switch (_y) {
                case null:
                _type = InputType.One;
                break;
                default:
                if (_y.Length == 1) {
                    _type = InputType.Two;
                } else {
                    _type = InputType.Multiple;
                }
                break;
            }
        }
    }

    public readonly record struct Output() {
        public decimal [] Result {
            get;
            init;
        } = [];

        public decimal [] Values {
            get;
            init;
        } = [];

        public Output(decimal [] result, decimal [] values) : this() {
            Result = result;
            Values = values;
        }
        public Output(int [] result, int [] values) : this() {
            if (result != null || result.Length != 0) {
                Result = Array.ConvertAll(Result, v => v);
            } else {
                Result = [];
            }

            if (values != null || values.Length != 0) {
                Values = Array.ConvertAll(Values, v => v);
            } else {
                Values = [];
            }
        }

        public override string ToString() {
            return $"f({Values}) => {Result}";
        }
    }
}
