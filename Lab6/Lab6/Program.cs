using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab_6
{

   

    
    public class Computer<T>
    {
        public List<T> Box;
        public Computer()
        {
            Box = new List<T>();
        }

        public T this[int num]
        {
            get { return Box[num]; }
            set { Box[num] = value; }

        }

        public void Push(T thing)
        {
            Box.Add(thing);
        }
        public void Pop()
        {
            Box.RemoveAt(Box.Count - 1);
        }

        public void Print()
        {
            Console.WriteLine("\nНа компьютере хранится: ");
            for (int i = 0; i < Box.Count; i++)
            {
                Console.WriteLine(Box[i]);
            }

        }
        public int Size
        {
            get { return Box.Count; }
        }
    }

    public class CompControl
    {
        public Computer<Software> Soft;
        public Computer<Game> Games;
        public Computer<w_processor> Words;
        string genre, Gen, ver, version;


        public CompControl(Computer<Software> shtuka)
        {
            this.Soft = shtuka;
        }

        public CompControl(Computer<Game> shtuka)
        {
            this.Games = shtuka;
        }

        public CompControl(Computer<w_processor> shtuka)
        {
            this.Words = shtuka;
        }

        public void GameHunt(string genre)
        {
            this.genre = Gen;
            for (int i = 0; i < Games.Size; i++)
            {
                if (Games[i].Genre == Gen)
                    Console.WriteLine(Games[i]);
            }

        }

        public void WordHunt(int ver)
        {
            this.ver = version;
            for (int i = 0; i < Words.Size; i++)
            {
                if (Words[i].version == ver)
                    Console.WriteLine(Words[i]);
            }

        }
    }


        struct UserInfo
        {
            public string Name;
            public int Age;

            public UserInfo(string Name, int Age)
            {
                this.Name = Name;
                this.Age = Age;
            }

            public void PrintUserInfo()
            {
                Console.WriteLine("Имя: {0}, Возраст: {1}", Name, Age);
            }
        }

    public class SoftwareException : Exception
    {
        public SoftwareException(string alert) : base(alert)
        { }
    }

    public class GameException : Exception
    {
        public GameException(string alert) : base(alert)
        { }
    }
    public class WordEx : SoftwareException
    {
        public WordEx (string alert) : base(alert)
        { }
    }
    public class CapcomEx : GameException
    {
        public CapcomEx(string alert) : base(alert)
        { }
    }


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
            public int version;

            public w_processor()
            {
                Input();
            }
            public w_processor(string Organization, string name, int version)
            {
                this.Organization = Organization;
                this.name = name;
                this.version = version;
               
                if (version<0)
            {
                Console.WriteLine("Вы ввели неверную версию. Обратите внимание, ваша версия: " + version);
                throw new WordEx("Версия не может быть меньше нуля");
            }

            
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
                Console.Write("Input Version: ");
                version = Convert.ToInt32(Console.ReadLine());

            }

            public void Show()
            {
                Console.WriteLine("\nText Processor\nName: {0}\nSize: {1}\nVersion: {2}", Name(), Size() + "Mb", version);
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

            if (Size <= 0)
            {
                throw new CapcomEx("Размер не может быть меньше нуля!");
            }
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

            if (Part<0)
            {
                Console.WriteLine("Обратите внимание! Вы ввели часть игры. Число меньше нуля. Вы ввели: " + Part);
                throw new CapcomEx("Часть игры не может быть меньше нуля!");
            }

            bool Test = String.IsNullOrWhiteSpace(Name) ;
            if (Test)
            {
                
                throw new CapcomEx("Ошибка! Строка имя пуста!");
            }
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

            public class Day
            {
                enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat };


                static void Main(string[] args)
                {



                Console.WriteLine("-------------Проверка исключений---------------");

                try
                {
                    GameFace Test = new Capcom("Resident Evil", "Horror", 1240, -2);
                }
                catch (CapcomEx exception)
                {
                    Console.WriteLine("Error: " + exception.Message);
                    Console.WriteLine("Method: " + exception.TargetSite);
                    Console.WriteLine("Source: " + exception.Source);
                }

                Console.WriteLine("----------------------------");

                try
                {
                    GameFace Test = new Capcom(" ", "Horror", 1240, 2);
                }
                catch (CapcomEx exception)
                {
                    Console.WriteLine("Error: " + exception.Message);
                    Console.WriteLine("Method: " + exception.TargetSite);
                    Console.WriteLine("Source: " + exception.Source);
                }

                Console.WriteLine("----------------------------");

                try
                {
                    Face Notepad = new w_processor("Unknown", "Notepad", -10);
                }
                catch (WordEx exception)
                {
                    Console.WriteLine("Error: " + exception.Message);
                    Console.WriteLine("Method: " + exception.TargetSite);
                    Console.WriteLine("Source: " + exception.Source);
                }

                Console.WriteLine("----------------------------");
                try
                {
                    GameFace FH = new Ubisoft("For Honor", "Action", 0);
                }
                catch (CapcomEx exception)
                {
                    Console.WriteLine("Error: " + exception.Message);
                    Console.WriteLine("Method: " + exception.TargetSite);
                    Console.WriteLine("Source: " + exception.Source);
                }

                finally
                {
                    Console.WriteLine("Все ошибки пойманы!");
                }

                Console.WriteLine("--------------Конец проверки--------------");

                

                Face PS = new g_editor("Adobe", "Photoshop", "Windows");
                Face Word = new w_processor("Microsoft", "Word", 10);
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

                    Computer<Game> games = new Computer<Game>();
                    Computer<w_processor> words = new Computer<w_processor>();
                    games.Push(new Capcom("Resident Evil", "Horror", 1240, 4));
                    games.Push(new Ubisoft("Rayman", "Adventure", 340));
                    words.Push(new w_processor("Microsoft", "Word", 12));
                    words.Push(new w_processor("Unknown", "Notepad", 3));
                    CompControl Gc = new CompControl(games);
                    CompControl Wc = new CompControl(words);
                bool Kek = false;

              
                UserInfo Ann = new UserInfo("Ann", 19);
                   
                    Gc.GameHunt("Horror");
                    Wc.WordHunt(12);

                


                Debug.Assert(Kek);

                Console.WriteLine("----------------------------");
                    Console.WriteLine("User Info:");
                    Console.WriteLine("Name: " + Ann.Name);
                    Console.WriteLine("Age: " + Ann.Age);
                    Console.WriteLine("----------------------------");

                Console.ReadKey();

                







            }
            }
        }
    }
