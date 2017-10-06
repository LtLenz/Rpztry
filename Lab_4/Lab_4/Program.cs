using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        public class Array
        {
            private List<int> array;
            public static int count;
            private int size;

            public Array()
            {
                Array.count++;
                Console.Write("Введите размер массива: ");
                size = Convert.ToInt32(Console.ReadLine());
                array = new List<int>(size);
                Push();
            }

            public Array(List<int> numbers)
            {
                Array.count++;
                this.array = numbers;
                size = array.Count;
            }

            public void Push()
            {
                Console.WriteLine("Заполните массив");
                for (int i = 0; i < size; i++)
                {
                    array.Add(Convert.ToInt32(Console.ReadLine()));
                }
            }
            public void Push(int num)
            {
                array.Add(num);
            }

            public void Size(out int num)
            {
                num = size;
            }
            public int this[int number]
            {
                get { return array[number]; }
                set { array[number] = value; }
            }

            public static Array operator +(Array array, int num)
            {
                for (int i = 0; i < array.size; i++)
                {
                    array[i] += num;
                }
                return array;
            }
        }


        static void Main(string[] args)
        {
            Array arr1 = new Array(new List<int>() { 13, 10, 19, 98 });
            Console.WriteLine(arr1);
            Console.ReadLine();
        }
    }
}
