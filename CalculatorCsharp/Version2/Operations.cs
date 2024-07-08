using System;
using System.Numerics;

namespace CalculateCsharpV2 {
    /// <summary>
    /// 
    /// </summary>
    public class Operations {
        /// <summary>
        /// Adds the first value to the rest of the values
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static OutputValues Add(InputValues values) {
            double result = values.Values [0];

            foreach (var value in values.Values.Skip(1)) {
                result += value;
            }

            return new([result]);
        }
        /// <summary>
        /// Subtracts the first value with the rest of the values
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static OutputValues Subtract(InputValues values) {
            double result = values.Values [0];

            foreach (var value in values.Values.Skip(1)) {
                result -= value;
            }

            return new([result]);
        }
        /// <summary>
        /// Multiplyes the first value with the rest of the values
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static OutputValues Multiply(InputValues values) {
            double result = values.Values [0];
            foreach (var value in values.Values.Skip(1)) {
                result *= value;
            }

            return new([result]);
        }
        /// <summary>
        /// Divides the first value by the rest of the values
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static OutputValues Divide(InputValues values) {
            double result = values.Values [0];

            foreach (var value in values.Values.Skip(1)) {
                result /= value;
            }

            return new([result]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static OutputValues Exponent(InputValues values) {
            double result = Math.Pow(values.Values [0], values.Values [1]);

            return new([result]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static OutputValues Modulos(InputValues values) {
            double result = values.Values [0] % values.Values[1];

            return new([result]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static OutputValues Absolute(InputValues values) {
            double result = values.Values [0];

            return new([result]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static byte ChooseOperation() {
            Console.WriteLine("Here are some options available: \n1) Addition \n2) Subtraction\n3) Multiplication \n4) Division \n5) Exponents \n6) Modulos \n7) Absolute");
            byte choice = Inputs<byte>.ReadTypeValue("Choose an option above");
            return choice;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public static Func<InputValues, OutputValues> GetOperation(byte option) {
            Func<InputValues, OutputValues> operation = option switch {
                1 => Add,
                2 => Subtract,
                3 => Multiply,
                4 => Divide,
                5 => Exponent,
                6 => Modulos,
                7 => Absolute,
                _ => Add,
            };

            return operation;
        }
    }
}
