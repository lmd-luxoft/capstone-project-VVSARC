using System;
using System.Threading.Tasks;

namespace RCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 1;
            double b = 2;
            double c = 1;




            var tasks = new Task<double>[]
            {
               new TaskFactory().StartNew<double>(() =>
               {

                     double d = CalcDescr(a,b,c);
                     if (d < 0)
                        throw new ArgumentOutOfRangeException();
                    return  d == 0 ? CalcZeroDescrRoot(a,b) : CalcRoot(true,a,b,d);
               }),
               new TaskFactory().StartNew<double>(() =>
            {
                  double d = CalcDescr(a,b,c);
                  if (d < 0)
                        throw new ArgumentOutOfRangeException();
                  return  d == 0 ? CalcZeroDescrRoot(a,b) : CalcRoot(false,a,b,d);
            }) };

            var finalTask = new TaskFactory().ContinueWhenAll(tasks, (t) =>
            {

                if (t[0].Status == TaskStatus.Faulted || t[1].Status == TaskStatus.Faulted)
                {
                    Console.WriteLine($"a={a}, b={b}, c={c}  Ошибка вычисления корней уравнения");
                    return;
                }
                Console.WriteLine($"x1 = {t[0].Result}");
                Console.WriteLine($"x2 = {t[1].Result}");

            });

            finalTask.Wait();
            Console.ReadKey();
        }

        static double CalcDescr(double a, double b, double c)
        {
            return Math.Pow(b, 2) - 4 * a * c;
        }

        static double CalcRoot(bool isPositive, double a, double b, double d)
        {
            return (-b + (isPositive ? 1 : -1) * Math.Sqrt(d)) / (2 * a);
        }

        static double CalcZeroDescrRoot(double a, double b)
        {
            return -Math.Pow(b, 2) / (2 * a);
        }
      
    }
}
