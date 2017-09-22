using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_1
{
    class Program
    {
        public static void Return(int[] mas, string name)
        {
            int max, min;
            max = mas[0];
            min = mas[0];
            for (int i = 0; i < mas.Length; i++)
            {
                
                if (mas[i] > max)
                {
                    max = mas[i];
                }
                if (mas[i] < min)
                {
                    min = mas[i];
                }
            }
            var tuple = Tuple.Create<int, int>(max, min);
            String s = name.Substring(0, 1);
            Console.WriteLine(tuple.Item1 + " " + tuple.Item2 + " " + s);

        }
            
        static void Main(string[] args)
        {
            bool word = true;
            byte value = 20, v;
            sbyte svalue = -20, s;
            char lit = 'a';
            decimal deci = 45m, d;
            double doubly = 34.56, dd;
            float floaty = 4.5f, f;
            int inty = 3, i;
            uint uinty = 4294, ui;
            long longy = 854775808, lo;
            ulong ulongy = 546218475663, ul;
            object objy = 23, ob;
            short shorty = 15, sh;
            ushort ushorty = 2, us;
            string stry = "Hey!";

            //Явное приведение
            i = (int)doubly;
            dd = (double)floaty;
            f = (float)deci;
            d = (decimal)longy;
            sh = (short)longy;

            //Неявное приведение
            dd = inty;
            d = uinty;
            f = shorty;
            i = ushorty;
            d = longy;

            //Упаковка
            inty = 13;
            object o = inty;
            floaty = 13.5f;
            object flo = floaty;
            //Распаковка
            o = 13;
            inty = (int)o;
            flo = 13.5f;
            floaty = (float)flo;

            //Неявно типизированные переменные
            var num = 3;
            var name = "DOGE";
            var dnum = 34.23;

            Type numType = num.GetType();
            Type nameType = name.GetType();
            Type dnumType = dnum.GetType();
            Console.WriteLine("Типы неявных переменных: ");
            Console.WriteLine(numType);
            Console.WriteLine(nameType);
            Console.WriteLine(dnumType);
            
            
           //Nullable-переменные

            int? nnum = null;  //Nullable<int> nnum = null;
            bool?enab = null;  //Nullable<bool> enab = null;
            //nnum = 13;
            if (nnum.HasValue)
            {
                Console.WriteLine("num = " + nnum.Value);
            }
            else
            {
                Console.WriteLine("num = null");
            }
            

            if (nnum.HasValue)
            {
                int nnum2 = (int)nnum;
                Console.WriteLine(nnum2);
            }

            int? x = null;
            int x1 = x ?? 100;


            //Строки
            // Строковые литералы

            string str1 = "Hey!";
            string str2 = "Hey, cats!";
            string str3 = str1;
            Console.WriteLine(str1 == str2);
            Console.WriteLine(str1 == str3);
            Console.WriteLine(string.Compare(str1, str3, true));

            // Действия со строками
            string s1 = "So glad to see you well";
            string s2 = "Overcome and completely silent now";
            string s3 = "With heaven's help";
            string s4 = String.Copy(s1);
            Console.WriteLine(s1 + " " + s2 + " "  +s3);
            Console.WriteLine(String.Concat(s1, s2, s3));
            Console.WriteLine(s4);
            string sub1 = s1.Substring(0, 7);
            string sub2 = s2.Substring(0, 7);
            string sub3 = s3.Substring(0, 7);
            String[] words = s1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(words[0]);
            Console.WriteLine(words[1]);
            Console.WriteLine(words[2]);
            string mods1 = s1.Insert(8, sub2);
            Console.WriteLine(mods1);
            string rems3 = s3.Remove(6, 5);
            Console.WriteLine(rems3);
            string nul = null;
            string empty = " ";
            string test;
            string test1, test2;
            test = nul + empty;
            // = String.Copy(nul);
            test2 = String.Copy(empty);
            Console.WriteLine(test);
            StringBuilder MyString = new StringBuilder("Hey, cats!", 25);
            Console.WriteLine(MyString);
            MyString.Append(" Hey!");
            Console.WriteLine(MyString);
            MyString.Insert(0, "Meow! ");
            Console.WriteLine(MyString);
            MyString.Remove(2, 3);
            Console.WriteLine(MyString);
            

            //Массивы
            int[,] matrix = new int[3, 3];
            Random val = new Random();
            for (int n = 0; n < 3; n++)
            {
                for (int m = 0; m < 3; m++)
                 {
                    matrix[n, m] = val.Next(1, 4);
                    Console.Write("{0}\t", matrix[n, m]);
                 }
                Console.WriteLine();
             }
 
            string[] strarray = { "So", "Glad", "To", "See", "You", "Well" };
            int kol = strarray.Length;
            for (int k = 0; k < kol; k++)
            {
                Console.Write(strarray[k] + " ");
            }
            

            Console.WriteLine("Введите слово");
            string key = Console.ReadLine();
            Console.WriteLine("Введите заменяемое слово");
            string item = Console.ReadLine();
            for (int k = 0; k < kol; k++)
            {
                if (strarray[k] == item)
                {
                    strarray[k] = key;
                }

                Console.Write(strarray[k] + " ");
            }

            //Ступенчатый массив
            
           Console.WriteLine("Вывод ступенчатого массива\n");
            int[][] stairs = new int[3][];
            stairs[0] = new int[2];
            stairs[1] = new int[3];
            stairs[2] = new int[4];

            int g = 0;
            int p = 0;
            for (g = 0; g < stairs.Length; g++)
            {
                for (p = 0; p < stairs[g].Length; p++)
                {
                    stairs[g][p] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int n = 0; n < stairs.Length; n++)
            {
                for (int m = 0; m < stairs[n].Length; m++)
                {

                    Console.Write("{0} ", stairs[n][m]);
                }

                Console.WriteLine();

            }

            Console.WriteLine();
            Console.WriteLine();
            var stroka = "Привет!";
            var mas = new[] { 1, 10, 100, 1000 };

            // Кортежи

            var myTuple = Tuple.Create<int, string, char, string, ulong>(18, "Anya", 'F', "Kovshik", 13101998);
            var myTuple2 = Tuple.Create<int, string, char, string, ulong>(18, "Anya", 'F', "Kovshik", 13101998);
            var myTuple3 = Tuple.Create<int, string, string>(18, "Anya", "Kovshik");
         
           
            // 
          
            Console.WriteLine("{0}\n " + " {1}\n"
                + "{2}\n" + " {3}\n" + " {4}\n" , myTuple.Item5, myTuple.Item1, myTuple.Item2, myTuple.Item3, myTuple.Item4);

            Console.WriteLine("{0}\n " + " {3}\n" + " {4}\n", myTuple.Item1, myTuple.Item3, myTuple.Item4, myTuple.Item3, myTuple.Item4);

            int age = myTuple.Item1;
            string name1 = myTuple.Item2;
            char gender = myTuple.Item3;
            string surname = myTuple.Item4;
            ulong data = myTuple.Item5;

            Console.WriteLine(myTuple.Equals(myTuple2));
            Console.WriteLine(myTuple.Equals(myTuple3));

            int[] arr;
            arr = new int[5] {3, 10, 12, 48, 0};
            string texto = "Ehehe";

            Return(arr, texto);

            Console.ReadLine();


           
           


            


            
          



        }
    }
}
