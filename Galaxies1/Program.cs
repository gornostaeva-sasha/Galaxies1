using System;
using System.Collections.Generic;

namespace ConsoleApp_FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Galaxy News!");
            IterateThroughList();
            Console.ReadKey();
        }

        private static void IterateThroughList()
        {
            var theGalaxies = new List<Galaxy>
            {
                new Galaxy() { Name="Tadpole", MegaLightYears=400, GalaxyType=new GType('S')},
                new Galaxy() { Name="Pinwheel", MegaLightYears=25, GalaxyType=new GType('S')},
                new Galaxy() { Name="Cartwheel", MegaLightYears=500, GalaxyType=new GType('L')},
                new Galaxy() { Name="Small Magellanic Cloud", MegaLightYears=.2, GalaxyType=new GType('I')},
                new Galaxy() { Name="Andromeda", MegaLightYears=3, GalaxyType=new GType('S')},
                new Galaxy() { Name="Maffei 1", MegaLightYears=11, GalaxyType=new GType('E')}
            };

            foreach (Galaxy theGalaxy in theGalaxies)
            {
                Console.WriteLine(theGalaxy.Name + "  " + theGalaxy.MegaLightYears + ",  " + theGalaxy.GalaxyType);
            }
        }
    }

    public class Galaxy
    {
        public string Name { get; set; }
        public double MegaLightYears { get; set; }
        public GType GalaxyType { get; set; } // Тип изменен на GType
    }

    public class GType
    {
        public enum Type { Spiral, Elliptical, Irregular, Lenticular } // Перечисление сделано публичным

        public Type MyGType { get; set; } // Свойство использует публичное перечисление

        public GType(char type)
        {
            switch (type)
            {
                case 'S':
                    MyGType = Type.Spiral;
                    break;
                case 'E':
                    MyGType = Type.Elliptical;
                    break;
                case 'l':
                case 'I': // Добавлен случай для 'I'
                    MyGType = Type.Irregular;
                    break;
                case 'L':
                    MyGType = Type.Lenticular;
                    break;
                default:
                    throw new ArgumentException("Invalid galaxy type.");
            }
        }

        public override string ToString()
        {
            return MyGType.ToString(); // Переопределен метод ToString для корректного вывода
        }
    }
}