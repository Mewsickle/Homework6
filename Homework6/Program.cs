using System;

namespace Homework6
{
    //    1. Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). Продемонстрировать работу на функции с функцией a* x^2 и функцией a* sin(x).
    //2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
    //а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум.Использовать массив(или список) делегатов, в котором хранятся различные функции.
    //б) * Переделать функцию Load, чтобы она возвращала массив считанных значений.Пусть она возвращает минимум через параметр(с использованием модификатора out).

    //Студент Ким Алексей

    // Задача 1

    public delegate double Fun(double x);
    public delegate double Fun1(double x, double y);
    internal class Program
    {

        public static void Table1(Fun1 F, double x, double b, double y)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, y));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }


        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double x, double y)
        {
            return y * x * x * x;
        }
        public static double MyFunc1(double x, double y)
        {
            return y * Math.Sin(x);
        }


        static void Main(string[] args)
        {
     

            Console.WriteLine("Таблица функции MyFunc:");
            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            Table1(new Fun1(MyFunc), -2, 2, 5);
            Console.WriteLine("Таблица функции a * Sin:");
            Table1(new Fun1(MyFunc1), -2, 2, 5);


        }
    }
}
