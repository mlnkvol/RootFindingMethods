using System;

class RootFinding
{
    // Функція f(x) для першого рівняння (метод релаксації)
    static double Func1(double x)
    {
        return Math.Pow(x, 3) - 6 * Math.Pow(x, 2) + 5 * x + 12;
    }

    // Похідна f'(x) для першого рівняння
    static double DerivativeFunc1(double x)
    {
        return 3 * Math.Pow(x, 2) - 12 * x + 5;
    }

    // Функція f(x) для другого рівняння (метод Ньютона)
    static double Func2(double x)
    {
        return Math.Pow(x, 3) + 3 * Math.Pow(x, 2) - x - 3;
    }

    // Похідна f'(x) для другого рівняння
    static double DerivativeFunc2(double x)
    {
        return 3 * Math.Pow(x, 2) + 6 * x - 1;
    }

    // Метод релаксації
    static void RelaxationMethod(Func<double, double> f, double tau, double x0, double epsilon, int maxIterations)
    {
        double x = x0;
        Console.WriteLine("Iteration\t       x\t\t\t   f(x)");
        for (int i = 0; i < maxIterations; i++)
        {
            double fx = f(x);
            Console.WriteLine($"{i}\t\t {x,-20} {fx}");

            if (Math.Abs(fx) < epsilon)
            {
                Console.WriteLine("Solution found.");
                return;
            }

            x = x + tau * fx; // Формула релаксації
        }
        Console.WriteLine("Maximum number of iterations reached.");
    }

    // Метод Ньютона
    static void NewtonMethod(Func<double, double> f, Func<double, double> fPrime, double x0, double epsilon, int maxIterations)
    {
        double x = x0;
        Console.WriteLine("Iteration\t       x\t\t\t   f(x)");
        for (int i = 0; i < maxIterations; i++)
        {
            double fx = f(x);
            double fpx = fPrime(x);
            Console.WriteLine($"{i}\t\t {x,-20} {fx}");

            if (Math.Abs(fx) < epsilon)
            {
                Console.WriteLine("Solution found.");
                return;
            }

            if (Math.Abs(fpx) < 1e-12)
            {
                Console.WriteLine("Derivative is too small.");
                return;
            }

            x = x - fx / fpx; // Формула Ньютона
        }
        Console.WriteLine("Maximum number of iterations reached.");
    }

    static void Main()
    {
        // Початкові дані для рівняння
        double epsilon;
        int maxIterations = 100; // Максимальна кількість ітерацій

        // Введення точності
        Console.Write("Enter precision (e.g., 1e-3): ");
        epsilon = Convert.ToDouble(Console.ReadLine());

        // Метод релаксації для рівняння x^3 - 6x^2 + 5x + 12 = 0
        double tau = 100.0 / 409.0; // Параметр релаксації (можна обчислити теоретично)
        double x0_relax = 2.9; // Початкове наближення для методу релаксації
        Console.WriteLine("Relaxation method for equation x^3 - 6x^2 + 5x + 12 = 0");
        RelaxationMethod(Func1, tau, x0_relax, epsilon, maxIterations);

        // Метод Ньютона для рівняння x^3 + 3x^2 - x - 3 = 0
        double x0_newton = 4.0 / 3.0; // Початкове наближення для методу Ньютона
        Console.WriteLine("\nNewton's method for equation x^3 + 3x^2 - x - 3 = 0");
        NewtonMethod(Func2, DerivativeFunc2, x0_newton, epsilon, maxIterations);
    }
}
