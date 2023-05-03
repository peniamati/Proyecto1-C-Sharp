using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    // modelo, anio, kilometraje actual, kilometraje de service, color y el duenio
    internal class Program
    {
        public struct Auto
        {
            public string duenio;
            public string color;
            public int anio;
            public int kilometraje_actual;
            public int kilometraje_service;


            public Auto(string duenio, string color, int anio, int kilometraje_actual, int kilometraje_service)
            {
                this.duenio = duenio;
                this.color = color;
                this.anio = anio;
                this.kilometraje_actual = kilometraje_actual;
                this.kilometraje_service = kilometraje_service;
            }   
        }

        static void Main(string[] args)
        {
            bool aux = true;
            ListDictionary autos = new ListDictionary();
            Console.WriteLine("Bienvenido al sistema!");

            while (aux)
            {
                Console.Write("Elija una opcion:");
                Console.Write("1 Dar de alta un Tesla");
                Console.Write("2 Eliminar un Tesla");
                Console.Write("3 Mostrar listado de Tesla que necesitan Service");
                Console.Write("4 Reordenar listado por año");
                Console.Write("5 Mostrar Tesla mas viejo.");
                Console.Write("6 Salir");
                int opcion = Console.Read();


                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el nombre y el apellido del duenio del vehiculo: ");
                        string duenio = Console.ReadLine();
                        Console.Write("Ingrese el color del vehiculo: ");
                        string color = Console.ReadLine();
                        Console.Write("Ingrese el modelo: ");
                        string modelo = Console.ReadLine();
                        Console.Write("Ingrese el anio del Vehículo: ");
                        int anio = Console.Read();
                        Console.Write("Ingrese el Kilometraje de su vehiculo: ");
                        int kilometraje_actual = Console.Read();
                        Console.Write("Ingrese el kilometraje de service: ");
                        int kilometraje_service = Console.Read();
                        autos.Add("duenio", duenio);
                        autos.Add("color", color);
                        autos.Add("modelo", modelo);
                        autos.Add("anio", anio);
                        autos.Add("kilometraje_actual", kilometraje_actual);
                        autos.Add("kilometraje_service", kilometraje_service);


                        break;
                    case 2:
                        foreach(valor in autos)
                        {
                            Console.WriteLine(autos.key, autos.value);
                        }
                        Console.WriteLine("Ingrese auto a eliminar:");
                        string borrar = Console.ReadLine();
                        autos.Remove(borrar);
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        aux = false;
                        break;
                    default:
                        break;
                }




            





            

            }
        }

        
    }
  
}
