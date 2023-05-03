using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    // modelo, anio, kilometraje actual, kilometraje de service, color y el duenio
    internal class Program
    {
        public struct Auto
        {
            public Auto(string duenio, string color, int anio, int kilometraje_actual, int kilometraje_service) {
            }   
        }

        static void Main(string[] args)
        {
            bool aux = true;
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
                        break;
                    case 2:
                        for(int i = 0; i < lista.Length; i++)
                        {
                            Console.WriteLine(lista[i]);
                        }

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
                }




            





            

            }
        }

        
    }
  
}
