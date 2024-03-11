namespace CalculatorCsharpV1 {
    public class Operations {
        public Input Input {
            get => _input;
            set => _input = value;
        }
        private Input _input;

        public Output Output {
            get => _output;
        }
        private Output _output;

        public void Add() {
            string str = $"{_input.X}";
            foreach (decimal i in _input.Y) {
                string v = i < 0 ? $"({i})" : $"{i}";
                str = $"{str} + {v}";
            }
            Console.WriteLine(str);

            decimal result = _input.X;
            List<decimal> values = [_input.X];
            foreach (decimal i in _input.Y) {
                result += i;
                values.Add(i);
            }

            _output = new Output() {Result = [result], Values = [..values]};
        }

        public void Subtract() {
            string str = $"{_input.X}";
            foreach (decimal i in _input.Y) {
                string v = i < 0 ? $"({i})" : $"{i}";
                str = $"{str} - {v}";
            }
            Console.WriteLine(str);

            decimal result = _input.X;
            List<decimal> values = [_input.X];
            foreach (decimal i in _input.Y) {
                result -= i;
                values.Add(i);
            }

            _output = new Output() { Result = [result], Values = [.. values] };
        }

        public void Multiply() {
            string str = $"{_input.X}";
            foreach (decimal i in _input.Y) {
                string v = i < 0 ? $"({i})" : $"{i}";
                str = $"{str} * {v}";
            }
            Console.WriteLine(str);

            decimal result = _input.X;
            List<decimal> values = [_input.X];
            foreach (decimal i in _input.Y) {
                result *= i;
                values.Add(i);
            }

            _output = new Output() { Result = [result], Values = [.. values] };
        }

        public void Divide() {
            string str = $"{_input.X}";
            foreach (decimal i in _input.Y) {
                string v = i < 0 ? $"({i})" : $"{i}";
                str = $"({str} / {v})";
            }
            Console.WriteLine(str);

            decimal result = _input.X;
            List<decimal> values = [_input.X];
            foreach (decimal i in _input.Y) {
                result /= i;
                values.Add(i);
            }

            _output = new Output() { Result = [result], Values = [.. values] };
        }

        /// <summary>
        /// Raise to a power or root a value by another value
        /// </summary>
        public void Exponent() {
            string str = $"{_input.X} ^ {_input.Y}";
            Console.WriteLine(str);

            decimal result = (decimal)Math.Pow((double)_input.X, (double)_input.Y [0]);
            List<decimal> values = [_input.X, _input.Y[0]];

            _output = new Output() { Result = [result], Values = [.. values] };
        }

        /// <summary>
        /// Divide two values and find the remainder
        /// </summary>
        public void Modulos() {
            string str = $"{_input.X} ^ {_input.Y}";
            Console.WriteLine(str);

            decimal result = (decimal)(_input.X % _input.Y [0]);
            List<decimal> values = [_input.X, _input.Y [0]];

            _output = new Output() {Result = [result], Values = [..values]};
        }
    }
}