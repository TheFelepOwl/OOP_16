using System;

namespace Integration
{
    class Program
    {
        // оголошення типу-делегата
        delegate double Function(double x);

        static void Main(string[] args)
        {
            // обчислення інтеграла f(x) = 1/sqrt(x^3) на проміжку [1, 2]
            Function f1 = x => 1 / Math.Sqrt(Math.Pow(x, 1.0/3.0));
            double a1 = 1;
            double b1 = 2;
            int n1 = 10000;
            double result1 = TrapezoidalRule(f1, a1, b1, n1);
            Console.WriteLine($"Integral of 1/sqrt^3(x) from {a1} to {b1} is approximately {result1:F5}");

            // обчислення інтеграла f(x) = 1/sqrt(x) на проміжку [1, 2]
            Function f2 = x => 1 / Math.Sqrt(x);
            double a2 = 1;
            double b2 = 2;
            int n2 = 10000;
            double result2 = TrapezoidalRule(f2, a2, b2, n2);
            Console.WriteLine($"Integral of 1/sqrt(x) from {a2} to {b2} is approximately {result2:F5}");

            // обчислення інтеграла f(x) = cos(x) на проміжку [0, pi/2]
            Function f3 = x => Math.Cos(x);
            double a3 = 0;
            double b3 = Math.PI / 2;
            int n3 = 10000;
            double result3 = TrapezoidalRule(f3, a3, b3, n3);
            Console.WriteLine($"Integral of cos(x) from {a3} to {b3} is approximately {result3:F5}");
        }

        // метод трапеції для обчислення інтеграла функції f на проміжку [a, b]
        static double TrapezoidalRule(Function f, double a, double b, int n)
        {
            double h = (b - a) / n;
            double sum = (f(a) + f(b)) / 2.0;

            for (int i = 1; i < n; i++)
            {
                double x = a + i * h;
                sum += f(x);
            }

            return h * sum;
        }
    }
}