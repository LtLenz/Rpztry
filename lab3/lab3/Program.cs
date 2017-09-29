using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab3
{
    public partial class Vector
    {
        //private Vector() закрытый конструктор
        //{ }
        static Vector()
        { Id = DateTime.Now.Ticks; count = 0; }
        public Vector()
        {
            Vector.count++;
            Console.Write("Введите размер вектора: ");
            size = Convert.ToInt32(Console.ReadLine());
            vector = new List<int>(size);
            Push();
        }
        public Vector(List<int> numbers)
        {
            Vector.count++;
            this.vector = numbers;
            size = vector.Count;
        }
        public int this[int number]
        {
            get { return vector[number]; }
            set { vector[number] = value; }
        }
        public void Push()
        {
            Console.WriteLine("Заполните вектор");
            for (int i = 0; i < size; i++)
            {
                vector.Add(Convert.ToInt32(Console.ReadLine()));
            }
        }
        public void Push(int num)
        {
            vector.Add(num);
        }
        public void Pop()
        {
            vector.Remove(size - 1);
        }
        public static void Swap(ref Vector vector1, ref Vector vector2)
        {
            Vector temp = vector1;
            vector1 = vector2;
            vector2 = temp;
        }
        public bool inZero()
        {
            for (int i = 0; i < size; i++)
            {
                if (vector[i] == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public void Size(out int num)
        {
            num = size;
        }
        public static Vector operator + (Vector vector, int num)
        {
            for (int i = 0; i < vector.size; i++)
            {
                vector[i] += num;
            }
            return vector;
        }
        public static Vector operator * (Vector vector, int num)
        {
            for (int i = 0; i < vector.size; i++)
            {
                vector[i] *= num;
            }
            return vector;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            foreach (int num in vector)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("\nХозяин вектора: {0}\nID сессии: {1}\n", Vector.owner, Vector.Id);
            return base.ToString();
        }
        public static void getClassInfo()
        {
            Console.WriteLine("\nКоличество векторов: {0}", Vector.count);
        }
    }
    class Program
    {
        static void Main (string[] args)
        {
            Vector vector1 = new Vector();
            Vector vector2 = new Vector(new List<int>() { 13, 10, 19, 98 });
            Vector vector3 = new Vector(new List<int>() { 27, 42, 69, 0 });
            Vector vector4 = new Vector(new List<int>() { 96, 34, 78, 256 });
            int vector4Size;
            vector4.Size(out vector4Size);
            vector2.ToString();
            Console.WriteLine(vector2 + 100);
            Console.WriteLine(vector2 * 100);
            Console.WriteLine("Сравнение двух векторов");
            Console.WriteLine("Вектор-2 и Вектор-2: {0}\nВектор-2 и Вектор-1: {1}\n", 
                vector2.Equals(vector2), vector2.Equals(vector3));
            Console.WriteLine("Хэши векторов\n{0}\n{1}\n{2}\n{3}\n", vector1.GetHashCode(), 
                vector2.GetHashCode(), vector3.GetHashCode(), vector4.GetHashCode());
            Vector[] vectors = new Vector[4];
            vectors[0] = vector1;
            vectors[1] = vector2;
            vectors[2] = vector3;
            vectors[3] = vector4;
            Console.WriteLine("Векторы с нулём внутри: ");
            for (int i = 0; i < vectors.Length; i++)
            {
                if (vectors[i].inZero() == true)
                {
                    vectors[i].ToString();
                }
            }
            Vector.getClassInfo();
            var anonVector = new { array = new List<int>() { 8, 1, 6, 3, 7 } }; // анонимный тип на основе Vector
            for (int i = 0; i < anonVector.array.Count - 1; i++)
            {
                Console.Write(anonVector.array[i] + " ");
            }
            Console.ReadKey();


        }
    }
}
