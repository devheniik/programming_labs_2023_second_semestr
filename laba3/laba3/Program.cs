using System;

namespace ComplexNumber
{
    public class Complex
    {
        private double _real;
        private double _imaginary;

        public Complex(double real, double imaginary)
        {
            _real = real;
            _imaginary = imaginary;
        }

        // Геттери
        public double GetReal()
        {
            return _real;
        }

        public double GetImaginary()
        {
            return _imaginary;
        }

        
        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a._real + b._real, a._imaginary + b._imaginary);
        }

        
        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a._real - b._real, a._imaginary - b._imaginary);
        }

        
        public static Complex operator *(Complex a, Complex b)
        {
            double real = a._real * b._real - a._imaginary * b._imaginary;
            double imaginary = a._real * b._imaginary + a._imaginary * b._real;
            return new Complex(real, imaginary);
        }

        
        public static Complex operator /(Complex a, Complex b)
        {
            double denominator = b._real * b._real + b._imaginary * b._imaginary;
            double real = (a._real * b._real + a._imaginary * b._imaginary) / denominator;
            double imaginary = (a._imaginary * b._real - a._real * b._imaginary) / denominator;
            return new Complex(real, imaginary);
        }

        
        public double GetMagnitude()
        {
            return Math.Sqrt(_real * _real + _imaginary * _imaginary);
        }

        
        public double GetArgument()
        {
            return Math.Atan2(_imaginary, _real);
        }
 
        public Complex ToTrigonometricForm()
        {
            double magnitude = GetMagnitude();
            double argument = GetArgument();
            return new Complex(magnitude * Math.Cos(argument), magnitude * Math.Sin(argument));
        }
 
        public Complex ToExponentialForm()
        {
            double magnitude = GetMagnitude();
            double argument = GetArgument();
            return new Complex(magnitude * Math.Exp(argument), 0);
        }
 
        public Complex Pow(double power)
        {
            double magnitude = Math.Pow(GetMagnitude(), power);
            double argument = GetArgument() * power;
            return new Complex(magnitude * Math.Cos(argument), magnitude * Math.Sin(argument));
        }
 
        public Complex[] Sqrt(int n)
        {
            Complex[] roots = new Complex[n];
            double magnitude = Math.Pow(GetMagnitude(), 1.0 / n);
            double phi = GetArgument();
            for (int i = 0; i < n; i++)
            {
                double real = magnitude * Math.Cos((phi + 2 * Math.PI * i) / n);
                double imaginary = magnitude * Math.Sin((phi + 2 * Math.PI * i) / n);
                roots[i] = new Complex(real, imaginary);
            }
            return roots;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Complex z1 = new Complex(3, 4);
            Complex z2 = new Complex(-2, 1);

            Complex sum = z1 + z2;
            Console.WriteLine($"Sum: ({sum.GetReal()}, {sum.GetImaginary()})");

            Complex difference = z1 - z2;
            Console.WriteLine($"Difference: ({difference.GetReal()}, {difference.GetImaginary()})");

            Complex product = z1 * z2;
            Console.WriteLine($"Product: ({product.GetReal()}, {product.GetImaginary()})");

            Complex quotient = z1 / z2;
            Console.WriteLine($"Quotient: ({quotient.GetReal()}, {quotient.GetImaginary()})");

            Complex power = z1.Pow(2);
            Console.WriteLine($"Z1 squared: ({power.GetReal()}, {power.GetImaginary()})");

            Complex[] roots = z1.Sqrt(3);
            Console.WriteLine($"Z1 cube roots:");
            foreach (Complex root in roots)
            {
                Console.WriteLine($"({root.GetReal()}, {root.GetImaginary()})");
            }

            Complex trigonometricForm = z1.ToTrigonometricForm();
            Console.WriteLine($"Trigonometric form of z1: ({trigonometricForm.GetReal()}, {trigonometricForm.GetImaginary()})");

            Complex exponentialForm = z1.ToExponentialForm();
            Console.WriteLine($"Exponential form of z1: ({exponentialForm.GetReal()}, {exponentialForm.GetImaginary()})");
        }
    }
}   