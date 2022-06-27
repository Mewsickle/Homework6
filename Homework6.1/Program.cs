using System;
using System.IO;

namespace Homework6._1
{

    //2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
    //а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум.Использовать массив(или список) делегатов, в котором хранятся различные функции.
    //б) * Переделать функцию Load, чтобы она возвращала массив считанных значений.Пусть она возвращает минимум через параметр(с использованием модификатора out).
    // Студент Ким Алексей

    //задача 2
    class Program
    {
        public delegate double function(double x);
        public static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F2(double x)
        {
            return 2 * x * x - 20 * x + 45;
        }
        public static double F3(double x)
        {
            return 4 * x * x - 30 * x + 50;
        }





        public static void SaveFunc(string fileName, double a, double b, double h, function F)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }
        static void Main(string[] args)
        {
            function[] F = { F1, F2, F3 };
            Console.WriteLine($"Выберите функцию:");
            Console.WriteLine($"1: x * x - 50 * x + 10");
            Console.WriteLine($"2: 2 * x * x - 20 * x + 45");
            Console.WriteLine($"3: 4 * x * x - 30 * x + 50");


            int index = int.Parse(Console.ReadLine());
            SaveFunc("data.bin", -100, 100, 0.5, F[index - 1]);
            Console.WriteLine($"Минимум функции: {Load("data.bin")}");
            Console.ReadKey();
        }
    }


}
