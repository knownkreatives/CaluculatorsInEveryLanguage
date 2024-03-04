namespace CalculatorCsharp {
    internal class ProgramV1 {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetIntValue() {
            Console.WriteLine("Input integer value");
            string value = Console.ReadLine();

            while (!int.TryParse(value, out _)) {
                Console.WriteLine("Value not an integer");
                Console.WriteLine("Input integer value");
                value = Console.ReadLine();
            }

            return int.Parse(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static float GetFloatValue() {
            Console.WriteLine("Input float value");
            string value = Console.ReadLine();

            while (!float.TryParse(value, out _)) {
                Console.WriteLine("Value not an float");
                Console.WriteLine("Input float value");
                value = Console.ReadLine();
            }

            return float.Parse(value);
        }

        /// <summary>
        /// Runs the validation of continuing the program, and runs an action if the program can continue
        /// </summary>
        /// <param name="action">An action that would be ran as the program is allowed</param>
        /// <param name="msg">Optional: a mesage sent as the program is not allowed to continue</param>
        public static void ContinueTopic(Action onContinue, Action onEnd, string topic) {
            Console.WriteLine($"Continue {topic.ToLower()}? Y/N");
            string cont = Console.ReadLine().ToUpper(); // continue the program

            while (cont != "N") {
                if (cont == "Y") {
                    onContinue();
                } else {
                    Console.WriteLine("Invalid response!");
                }

                Console.WriteLine($"Continue {topic.ToLower()}? Y/N");
                cont = Console.ReadLine().ToUpper();
            }

            if (cont == "N") {
                onEnd();
            }
        }
    }

    public class Calculator {
        static void Main(string [] args) {
            CalculatorProgram();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void CalculatorProgram() {
            Output output = new();

            Console.WriteLine("Starting calculator");
            Calculate(ref output);

            ProgramV1.ContinueTopic(() => {
                Console.WriteLine("Carry over result? Y/anything");
                string carry = Console.ReadLine().ToUpper(); // carry over the next value

                while (carry != "N") {
                    if (carry == "Y") {
                        Console.WriteLine("Starting calculator");
                        Calculate(ref output, true);
                        break;
                    } else {
                        Console.WriteLine("Invalid Response!");

                        Console.WriteLine("Carry over result? Y/anything");
                        carry = Console.ReadLine().ToUpper();
                    }
                }
            },
            () => {
                Console.WriteLine("Thank you for using this calculator");
            }, "Calculator");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="output"></param>
        /// <param name="carryover"></param>
        public static void Calculate(ref Output output, bool carryover = false) {
            int option = GiveOptions();

            Input input = new(option, carryover, output.Result);

            Operations operations = new() {
                CurrentInput = input
            };

            Action action = SelectOption(option, operations);
            action();

            output = operations.CurrentOutput;
            Console.WriteLine(output.Result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GiveOptions() {
            Console.WriteLine("Here are some options available");
            Console.WriteLine("1) Addition");
            Console.WriteLine("2) Subtraction");
            Console.WriteLine("3) Multiplication");
            Console.WriteLine("4) Division");
            Console.WriteLine("5) Exponents");
            Console.WriteLine("6) Modulos");

            int option = ProgramV1.GetIntValue();

            while (!(0 < option && option <= 6)) {
                Console.WriteLine("Invalid option!");
                option = ProgramV1.GetIntValue();
            }

            return option;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="option"></param>
        /// <param name="operations"></param>
        /// <returns></returns>
        public static Action SelectOption(int option, Operations operations) {
            Action action = () => { };
            switch (option) {
                case 1:
                action = operations.Add;
                break;
                case 2:
                action = operations.Subtract;
                break;
                case 3:
                action = operations.Multiply;
                break;
                case 4:
                action = operations.Divide;
                break;
                case 5:
                action = operations.Exponent;
                break;
                case 6:
                action = operations.Modulos;
                break;
            }

            return action;
        }
    }

    public class Operations {
        public Input CurrentInput {
            get => _input;
            set => _input = value;
        }
        Input _input;

        public Output CurrentOutput {
            get => _output;
            private set => _output = value;
        }
        Output _output;

        public void Add() {
            float x = _input.X;
            float [] y = _input.Y;

            string str = $"{x}";
            foreach (float i in y) {
                string v = i < 0 ? $"({i})" : $"{i}";
                str = $"{str} + {v}";
            }
            Console.WriteLine(str);

            float result = x;
            List<float> values = [x];
            foreach (float n in y) {
                result += n;
                values.Add(n);
            }

            _output = new(result, values);
        }

        public void Subtract() {
            float x = _input.X;
            float [] y = _input.Y;

            string str = $"{x}";
            foreach (float i in y) {
                string v = i < 0 ? $"({i})" : $"{i}";
                str = $"{str} - {v}";
            }
            Console.WriteLine(str);

            float result = x;
            List<float> values = [x];
            foreach (float n in y) {
                result -= n;
                values.Add(n);
            }

            _output = new(result, values);
        }

        public void Multiply() {
            float x = _input.X;
            float [] y = _input.Y;

            string str = $"{x}";
            foreach (float i in y) {
                string v = i < 0 ? $"({i})" : $"{i}";
                str = $"{str} * {v}";
            }
            Console.WriteLine(str);

            float result = x;
            List<float> values = [x];
            foreach (float n in y) {
                result *= n;
                values.Add(n);
            }

            _output = new(result, values);
        }

        public void Divide() {
            float x = _input.X;
            float [] y = _input.Y;

            string str = $"{x}";
            foreach (float i in y) {
                string v = i < 0 ? $"({i})" : $"{i}";
                str = $"({str} / {v})";
            }
            Console.WriteLine(str);

            float result = x;
            List<float> values = [x];
            foreach (float n in y) {
                result /= n;
                values.Add(n);
            }

            _output = new(result, values);
        }

        public void Exponent() {
            float x = _input.X;
            float y = _input.Y [0];

            string str = $"{x} ^ {y}";
            Console.WriteLine(str);

            float result = (float)Math.Pow(x, y);
            List<float> values = [x, y];

            _output = new(result, values);
        }

        public void Modulos() {
            float x = _input.X;
            float y = _input.Y [0];

            string str = $"{x} ^ {y}";
            Console.WriteLine(str);

            float result = (float)(x % y);
            List<float> values = [x, y];

            _output = new(result, values);
        }
    }

    public struct Input {
        public float X {
            readonly get => _x;
            private set => _x = value;
        }
        float _x;

        public float [] Y {
            readonly get => _y;
            private set => _y = value;
        }
        float [] _y;

        public Input(int option, bool carryover, float carry) {
            var values = GetInputs(option, carryover, carry);
            _x = values [0];
            _y = values.Skip(1).ToArray();
        }

        public Input(float x, params float [] y) {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="option"></param>
        /// <param name="carryover"></param>
        /// <param name="carry"></param>
        /// <returns></returns>
        public static float [] GetInputs(int option, bool carryover, float carry = 0) {
            List<float> values = [];

            if (carryover) {
                values = [carry];
                Console.WriteLine($"{values [0]} is the first value");
            } else {
                Console.WriteLine($"Input the first value");
                values = [ProgramV1.GetFloatValue()];
            }

            switch (option) {
                case 1:
                case 2:
                case 3:
                case 4:
                Console.WriteLine($"Input the next set of values");
                ProgramV1.ContinueTopic(() => {
                    values.Add(ProgramV1.GetFloatValue());
                },
                () => {
                    Console.WriteLine("Ending input logging");
                }, "Inputs");
                break;
                case 5:
                case 6:
                Console.WriteLine($"Input the second value");
                values.Add(ProgramV1.GetFloatValue());
                break;
            }

            return [.. values];
        }
    }

    public struct Output(float result, List<float> values) {
        public float Result {
            readonly get => _result;
            private set => _result = value;
        }
        float _result = result;

        public List<float> Values {
            readonly get => _values;
            private set => _values = value;
        }
        List<float> _values = values;
    }
}
