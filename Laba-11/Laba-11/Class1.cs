using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_11
{
    public class Bus : IComparable<Bus>
    {
        public int quantity; //колличество автобусов
        public int[] array;  // массив автобусов
        public Bus(int tmp)//конструктор
        {
            array = new int[tmp];
            quantity = tmp;
            Random rnd = new Random();
            for (int i = 0; i < quantity; i++)
            {
                array[i] = rnd.Next(1, 9);
            }
        }
        public void Output() //вывод
        {
            for (int i = 0; i < quantity; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        public int Even()
        {
            int b = 0;
            for (int i = 0; i < quantity; i++)
            {
                if (array[i] % 2 == 0) b += 1;
            }
            if (b == quantity) return 0;
            else return 1;
        }
        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < quantity; i++)
            {
                sum += array[i];
            }
            return sum;
        }
        public bool Contains( int r)
        {
            for (int i = 0; i < quantity; i++)
            {
                if (array[i] == r) return true;
            }
            return false;
        }
        public int CompareTo(Bus c)
        {
            if (quantity == c.quantity)
                return 0;
            else
                return -1;
        }
    }
}