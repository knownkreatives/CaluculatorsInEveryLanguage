namespace CalculatorCsharpV1 {
    internal class Program {
        static void Main(string [] args) {
            CalculatorProgram();
        }

        /// <summary>
        /// Asks the user if they would continue the program, validates the response ands runs an action if the program can continue
        /// </summary>
        /// <param name="onContinue">the action to perform is the program can continue</param>
        /// <param name="onEnd">the action to perform is the program cannot continue</param>
        /// <param name="topic">the name of the topic</param>
        public static void ContinueTopic(Action onContinue, Action onEnd, string topic) {
            Console.WriteLine($"Continue {topic.ToLower()}? Y/N");
            string cont = Console.ReadLine().ToUpper(); // continue the program

            while (cont != "N" && cont != "Y") {
                Console.WriteLine("Invalid response!");
                Console.WriteLine($"Continue {topic.ToLower()}? Y/N");
                cont = Console.ReadLine().ToUpper();
            }

            while (cont == "Y") {
                Console.WriteLine($"Continuing {topic.ToLower()}");
                onContinue();

                Console.WriteLine($"Continue {topic.ToLower()}? Y/N");
                cont = Console.ReadLine().ToUpper();

                while (cont != "N" || cont != "Y") {
                    Console.WriteLine("Invalid response!");
                    Console.WriteLine($"Continue {topic.ToLower()}? Y/N");
                    cont = Console.ReadLine().ToUpper();
                }
            }

            Console.WriteLine($"Ending {topic.ToLower()}");
            onEnd();
        }

        /// <summary>
        /// 
        /// </summary>
        static void CalculatorProgram() {
            Output output = new () { };

            Console.WriteLine("Starting calculator");
            Calculate(ref output);

            ContinueTopic(() => {
                Console.WriteLine("Carry over result? Y/anything");
                string carry = Console.ReadLine().ToUpper(); // carry over the next value

                while (carry != "N") {
                    if (carry == "Y") {
                        Console.WriteLine("Carrying over result");
                        Console.WriteLine("Starting Calculator");
                        Calculate(ref output, true);
                        break;
                    } else {
                        Console.WriteLine("Invalid Response!");
                        Console.WriteLine("Carry over result? Y/anything");
                        carry = Console.ReadLine().ToUpper();
                    }
                }

                if (carry == "N") {
                    Console.WriteLine("Starting Calculator");
                }
            },
            () => {
                Console.WriteLine("Thank you for using this calculator");
            }, "Calculator");
        }

        /// <summary>
        /// Manages the inputs, outputs and actions for the operations
        /// </summary>
        /// <param name="output">The output that is updated and used to continue carryover calculations</param>
        /// <param name="carryover">If the user will carryover the previous result</param>

        static void Calculate(ref Output output, bool carryover = false) {
            int option = GiveOptions();

            InputType type = InputType.One; // just to initialize the variable;
            switch (option) {
                case 1:
                case 2:
                case 3:
                case 4:
                type = InputType.Multiple;
                break;
                case 5:
                case 6:
                type = InputType.Two;
                break;
            }

            Operations operations = new() {
                Input = new Input(type)
            };

            Action action = SelectOption(option, operations);
            action();

            output = operations.Output;
            Console.WriteLine(output.Result);
        }

        /// <summary>
        /// Lists the avilable options, and asks for in integer value associated with the option
        /// </summary>
        /// <returns>The option value</returns>
        static int GiveOptions() {
            Console.WriteLine("Here are some options available: \n1) Addition \n2) Subtraction\n3) Multiplication \n4) Division \n5) Exponents \n6) Modulos");

            int option = Input.GetIntValue("Choose an option above");

            while (!(0 < option && option <= 6)) {
                Console.WriteLine("Invalid option! \nSelect one of the displayed options \n1) Addition \n2) Subtraction\n3) Multiplication \n4) Division \n5) Exponents \n6) Modulos");
                option = Input.GetIntValue("Choose an option above");
            }

            return option;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="option"></param>
        /// <param name="operations"></param>
        /// <returns></returns>
        static Action SelectOption(int option, Operations operations) {
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
}
