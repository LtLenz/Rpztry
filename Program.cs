using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{

    public static class StringHunter
    {

        public static string Meow (string str)
        {
            return str.Insert(0, "meow");
        }

        public static string Upper(string str)
        {
            return str.ToUpper();
        }

        public static string Lower(string str)
        {
            return str.ToLower();
        }
        public static string Cutter(string str)
        {
            string newy = str.Substring(2, 5);
            return newy;
        }

        public static string Finder(string str, string start)
        {

            bool Test = str.StartsWith(start);
            if (Test)
                return "Yes";
            else
                return "No";
        }
    }

    public class User
    {
        public int _position;
        public int _size;
        public delegate void RemoveHandler(string message);
        public delegate void CompressHandler(string message);
        public event RemoveHandler CheckPosition;
        public event RemoveHandler HoldPosition;
        public event CompressHandler CompressQ;

        public User(int position, int size)
        {
            _position = position;
            _size = size;
        }


        public void Remove(int position)
        {
            _position += position;
            if (CheckPosition != null)
                CheckPosition("Текущая позиция: " + _position + " шагов от начала");
        }

        public void Compress(int size)
        {
            _size -= size;
            if (CompressQ != null)
                CompressQ("Текущий размер квадрата положения: " + size);
        }
        public void Hold(int position)
        {
            if (position <= _position)
            {
                int prom = _position - position;
                if (HoldPosition != null)
                    HoldPosition("Ваш человек сдвинулся. Находится на " + prom + " шага от начала");
            }
        }
    }
    class Program
    {
        private static void Get_Message(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            User David = new User(13, 2);
            User Elena = new User(21, 3);
            David.HoldPosition += Get_Message;
            David.CheckPosition += Get_Message;
            David.Remove(17);
            David.Hold(11);
            David.CheckPosition -= Get_Message;
            David.HoldPosition -= Get_Message;
            Elena.HoldPosition += Get_Message;
            Elena.CheckPosition += Get_Message;
            Elena.CompressQ += Get_Message;
            Elena.Remove(3);
            Elena.Hold(22);
            Elena.Compress(1);
            Elena.CheckPosition -= Get_Message;
            Elena.HoldPosition -= Get_Message;
            Elena.CompressQ -= Get_Message;

            Console.ReadLine();

            string test = "So glad to  see  you  well";
            Func<string, string> Tester = StringHunter.Meow;
            Console.WriteLine(Tester(test));
            Tester = StringHunter.Lower;
            Console.WriteLine(Tester(test));
            Tester = StringHunter.Upper;
            Console.WriteLine(Tester(test));
            Tester = StringHunter.Cutter;
            Console.WriteLine(Tester(test));
            Func<string, string, string> NewTester = StringHunter.Finder;
            Console.WriteLine(NewTester(test, "So"));
            Console.WriteLine(NewTester(test, "glad"));
        }
    }
}
