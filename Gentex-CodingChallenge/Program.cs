using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gentex_CodingChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Display user message to gather file name information:
            Console.WriteLine("Please enter the full text filename. ex: shapes.txt");
            Console.WriteLine("Please make sure the file is located in the same directory as this program.");

            bool Exist = true;

            while (Exist)
            {
                String file = Console.ReadLine();
                bool DoesFileExist = System.IO.File.Exists(file);

                if (DoesFileExist)
                {
                    Console.WriteLine("File exists, please allow for processing. Thank you. \n\n");
                    ReadFile(file);
                    Console.WriteLine("Results saved to Results.txt");
                }
                if (DoesFileExist == false)
                {
                    Console.WriteLine("File does not exist, please enter a valid file name. \n\n");
                }
            }
        }

        public static void ReadFile(String filename)
        {
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                AnalyzeShape(line);
            }
        }
        public static void AnalyzeShape(String line)
        {
            string[] _line = line.Split(',');

            if (_line[1] == "Circle")
            {
                Circle c = new Circle(_line);
                Save(c.Id + "," + c.Area + "," + c.Circumference + "," + c.CentroidX + "," + c.CentroidY);
            }
            else if (_line[1] == "Equilateral Triangle")
            {
                EquilateralTri Tri = new EquilateralTri(_line);
                Save(Tri.Id + "," + Tri.Area + "," + Tri.Perimeter + "," + Tri.CentroidX + "," + Tri.CentroidY);
            }
            else if (_line[1] == "Square")
            {
                Square S = new Square(_line);
                Save(S.Id + "," + S.Area + "," + S.Perimeter + "," + S.CentroidX + "," + S.CentroidY);

            }
            else if (_line[1] == "Ellipse")
            {
                Ellipse E = new Ellipse(_line);
                Save(E.Id + "," + E.Area + "," + E.Circumference + "," + E.CentroidX + "," + E.CentroidY);
            }
            else if (_line[1] == "Polygon")
            {
                Polygon P = new Polygon(_line);
                Save(P.Id + "," + P.Area + "," + P.Perimeter + "," + 0 + "," + 0);
            }
        }
        public static void Save(string line)
        {
            string path = @"Results.txt";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Id, Area, Perimeter, CentroidX, CentroidY");
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(line);
            }

        }
    }
}
