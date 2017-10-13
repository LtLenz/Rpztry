using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{

    public abstract class Software
    {
        public abstract string Name();
        public abstract int Size();
    }

    public interface Face
    {
        void Show();
        void Input();
    }

    public class w_processor : Software, Face
    {
        public string Organization;
        public string name;

        public w_processor()
        {
            Input();
        }
        public w_processor(string Organization, string name)
        {
            this.Organization = Organization;
            this.name = name;
        }
        public override string Name()
        {

            return Organization + " " + name;
        }
        public override int Size()
        {
            Random rnd = new Random();
            int i = 5 + rnd.Next(1000);

            return i;
        }
        public override string ToString()
        {
            Show();
            return base.ToString();
        }
        public void Input()
        {
            Console.Write("Input Organization: ");
            Organization = Convert.ToString(Console.ReadLine());
            Console.Write("Input Name: ");
            name = Convert.ToString(Console.ReadLine());

        }

        public void Show()
        {
            Console.WriteLine("\nText Processor\nName: {0}\nSize: {1}", Name(), Size() + "Mb");
        }
    }

    public class g_editor : Software, Face
    {
        public string Organization;
        public string name;
        public string OS;


        public g_editor()
        {
            Input();
        }
        public g_editor(string Organization, string name, string OS)
        {
            this.Organization = Organization;
            this.name = name;
            this.OS = OS;
        }
        public override string Name()
        {

            return Organization + " " + name;
        }


        public override int Size()
        {
            Random rnd = new Random();
            int t = 5 + rnd.Next(1000);

            return t;
        }
        public override string ToString()
        {
            Show();
            return base.ToString();
        }
        public void Input()
        {
            Console.Write("Input Organization: ");
            Organization = Convert.ToString(Console.ReadLine());
            Console.Write("Input Name: ");
            name = Convert.ToString(Console.ReadLine());
            Console.Write("Input OS: ");
            OS = Convert.ToString(Console.ReadLine());

        }

        public void Show()
        {
            Console.WriteLine("\nGrapic Editor\nName: {0}\nSize: {1}, \nOS: {2}", Name(), Size() + "Mb", OS);
        }
    }

    public class Game
    {
        public string Name;
        public int Size;
        public string Genre;
    }

    public interface GameFace
    {
        void Show();
    }

    public class Ubisoft : Game, GameFace
    {
        public Ubisoft(string Name, string Genre, int Size)
        {
            this.Name = Name;
            this.Genre = Genre;
            this.Size = Size;
        }
        public void Show()
        {
            Console.WriteLine("\nUbisoft Game \nName: {0}\nGenre: {1}\nSize: {2}\n", Name, Genre, Size);
        }
        public override string ToString()
        {
            Show();
            return base.ToString();
        }
    }

    public class Capcom : Game, GameFace
    {
        int Part;
        public Capcom(string Name, string Genre, int Size, int Part)
        {
            this.Name = Name;
            this.Genre = Genre;
            this.Size = Size;
            this.Part = Part;
        }
        public void Show()
        {
            Console.WriteLine("\nCapcom Game \nName: {0}\nGenre: {1}\nSize: {2}\nPart: {3}", Name, Genre, Size, Part);
        }
        public override string ToString()
        {
            Show();
            return base.ToString();
        }
    }

    sealed public class Printer
    {
        public Printer() { }
        public string Print(Face obj)
        {
            return obj.ToString();
        }

        public string Print(GameFace obj)
        {
            return obj.ToString();
        }


    }




    class Program
    {

        static void Main(string[] args)
        {
            Face Word = new w_processor("Microsoft", "Word");
            Face PS = new g_editor("Adobe", "Photoshop", "Windows");
            GameFace Rayman = new Ubisoft("Rayman", "Adventure", 340);
            GameFace RE = new Capcom("Resident Evil", "Horror", 1240, 4);
            Printer printer = new Printer();
            Console.WriteLine("Is the Word a Text Processor?: {0}\nIs the Word a Graphic Editor?: {1}", Word is w_processor, Word is g_editor);
            Face Smth;
            Smth = PS as Face; // обычное приведение, только вместо исключения выбрасывает null
            printer.Print(Word);
            printer.Print(PS);
            printer.Print(Rayman);
            printer.Print(RE);
        }
    }
}

