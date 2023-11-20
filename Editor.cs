using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EditorHtml
{
    internal class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("------------");
            Start();
        }

        public static void Start()
        {
            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);

            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Console.WriteLine("------------");
            Console.WriteLine("Deseja salvar o arquivo?");


            Console.WriteLine("1 - Sim!");
            Console.WriteLine(" ");
            Console.WriteLine("0 - Sair sem salvar!");
            Console.WriteLine("");
            var text = file.ToString();

            string salvar = Console.ReadLine();


            switch (salvar)
            {
                case "1": Save(text); break;
                case "0": System.Environment.Exit(0); break;
                default: Menu.Show(); break;
            }
            Viewer.Show(file.ToString());
        }

        public static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Onde deseja salvar o arquivo");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"O arquivo foi salvo em {path}");
            Console.ReadLine();
            Menu.Show();
        }

        public static void GetFile()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Qual o nome do arquivo?");

            string filename = Console.ReadLine();



            ReadFile(filename);
        }

        public static void ReadFile(string filename)
        {
            using (StreamReader readfile = new StreamReader(filename))
            {
                string line;
                while ((line = readfile.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
