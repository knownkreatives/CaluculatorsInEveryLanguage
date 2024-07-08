namespace CalculateCsharpV2 {
    internal class Program {
        static void Main(string [] args) {
            Calculator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="repeat"></param>
        /// <param name="onContinue"></param>
        /// <param name="onEnd"></param>
        public static void ManageTopic(string topic, bool repeat, Action onContinue, Action onEnd) {
            Console.WriteLine($"Starting {topic.ToLower()}? Y/N");
            string cont = Console.ReadLine().ToUpper(); // continue the program

            do {
                if (cont != "Y") {
                    Console.WriteLine("Invalid response!");
                } else {
                    // call the continue action
                    onContinue();
                    Console.WriteLine($"Continuing {topic.ToLower()}");

                    // if "repeat" is false stop the topic
                    if (!repeat) break;
                }

                Console.WriteLine($"Continue {topic.ToLower()}? Y/N");
                cont = Console.ReadLine().ToUpper();

            } while (cont != "N");

            // call the end action
            onEnd();
            Console.WriteLine($"Ending {topic.ToLower()}");
        }

        /// <summary>
        /// The main method that ties togeter the entire application
        /// </summary>
        static void Calculator(bool logOperation = false) {
            OutputValues output = new();

            ManageTopic("Calculator", true, () => {
                //
                byte choice = Operations.ChooseOperation();

                // get the funtcion that will calculate a result
                Func<InputValues, OutputValues> operation = Operations.GetOperation(choice);

                bool shouldCarry = false;
                // ask if the user wants to carry the previous result into the next operation
                ManageTopic("carry", false, () => {
                    shouldCarry = true;
                }, () => { });

                // a local method that calculates and returns the values for the input
                List<double> GetInputValues() {
                    List<double> vs = [];

                    // if "shouldCarry" is true and the carry value is not null, carryover the previous value
                    if (shouldCarry && output.Values != null)
                        vs.Add(output.Values [0]);

                    ManageTopic("Input", true, () => {
                        var v = Inputs<double>.ReadTypeValue("Input");
                        vs.Add(v);
                    }, () => { });

                    return vs;
                }

                // create an "InputValue" type for the selected operation
                InputValues input = new(GetInputValues());

                // if "logOperation" is true, write the expected operation to the console
                if (logOperation)
                    switch (choice) {
                        case 1: case 2: case 3: case 4:
                        string str = $"{input.Values [0]}";
                        foreach (decimal i in input.Values.Skip(1).ToArray().Select(v => (decimal)v)) {
                            string v = i < 0 ? $"({i})" : $"{i}";
                            str = $"({str} {choice switch {1 => "+", 2 => "-", 3 => "*", 4 => "/", _ => "+"}} {v})";
                        }
                        Console.WriteLine(str);
                        break;
                        case 5: case 6:
                        break;
                        case 7:
                        break;
                    }

                // calculate the output using the selected operation
                output = operation.Invoke(input);
            }, () => {
                Console.WriteLine("Thank you for using this calculator!!!");
            });
        }
    }
}
