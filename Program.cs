using System;
using System.Collections;
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
        // funcion volverMenu, permite que luego de ingresar los datos por el usuario, pregunte si desea volver o no al menu principal.
        public static bool aux = true;
        
        static void volverMenu()
        {
            Console.Write("Desea volver a ver el menu inicial? Y/N:");
            string volverMenu = Console.ReadLine();
            string[] opciones = new string[] { "y", "Y", "n", "N" };
            while (!opciones.Contains(volverMenu))
            {
                Console.WriteLine("Opcion invalida!");
                Console.Write("Desea volver a ver el menu inicial? Y/N:");
                volverMenu = Console.ReadLine();
            }
            if (volverMenu == "n" || volverMenu == "N")
            {
                aux = false;
            }
        }

        static void Main(string[] args)
        {
            // Menu de opciones, ejecutable por el usuario. (tener en cuanta, que al ingresar por primera vez, no hay datos en el sistema, por eso primero hay que dar
            // de alta por lo menos un Tesla, para luego poder utilizar las otras opciones)

            int tesla = 0;
            List<Dictionary<string, object>> listaAutos = new List<Dictionary<string, object>>();
            Console.WriteLine("       ¡Bienvenido al sistema!");

            while (aux)
            {
                Console.WriteLine("|--------------------------------------------------|");
                Console.WriteLine("| 1. Dar de alta un Tesla                          |");
                Console.WriteLine("| 2. Eliminar un Tesla                             |");
                Console.WriteLine("| 3. Mostrar listado de Tesla que necesitan Service|");
                Console.WriteLine("| 4. Reordenar listado por año                     |");
                Console.WriteLine("| 5. Mostrar Tesla mas viejo.                      |");
                Console.WriteLine("| 6. Salir del Programa                            |");
                Console.WriteLine("|--------------------------------------------------|");
                Console.Write(" Elija una opcion: ");
                int opcion = int.Parse(Console.ReadLine());


                switch (opcion)
                {   // ingeso de datos del nuevo Tesla
                    case 1:
                        Console.Write("Ingrese la patente del Tesla: ");
                        string patente = Console.ReadLine();
                        Console.Write("Ingrese el nombre y el apellido del dueño del Tesla: ");
                        string duenio = Console.ReadLine();
                        Console.Write("Ingrese el color del Tesla: ");
                        string color = Console.ReadLine();
                        Console.Write("Ingrese el modelo: ");
                        string modelo = Console.ReadLine();
                        Console.Write("Ingrese el año del Tesla: ");
                        int anio = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el Kilometraje de su Tesla: ");
                        int kilometraje_actual = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el kilometraje de service: ");
                        int kilometraje_service = int.Parse(Console.ReadLine());
                        tesla++;
                        Console.WriteLine("Tesla ingresado exitosamente!");


                        Dictionary<string, object> nuevoAuto = new Dictionary<string, object>
                        {
                            { "patente", patente },
                            { "duenio", duenio },
                            { "color", color },
                            { "modelo", modelo },
                            { "anio", anio},
                            { "kilometraje_actual", kilometraje_actual },
                            { "kilometraje_service", kilometraje_service },
                            { "tesla", tesla }
                        };
                        listaAutos.Add(nuevoAuto);
                        volverMenu();
                        break;

                    case 2:
                        // eliminar un tesla
                        foreach (Dictionary<string, object> auto in listaAutos)
                        {
                            // Acceder a cada elemento del diccionario utilizando su clave
                            Console.WriteLine($"**********  Tesla {auto["tesla"]} ********************");
                            Console.WriteLine($"Patente: {auto["patente"]}                        ");
                            Console.WriteLine($"Dueño: {auto["duenio"]}                          ");
                            Console.WriteLine($"Color: {auto["color"]}                            ");
                            Console.WriteLine($"Modelo: {auto["modelo"]}                          ");
                            Console.WriteLine($"Año: {auto["anio"]}                               ");
                            Console.WriteLine($"Kilometraje_actual: {auto["kilometraje_actual"]}  ");
                            Console.WriteLine($"Kilometraje_service: {auto["kilometraje_service"]}");
                            Console.WriteLine("*******************************************");
                        }
                        Console.Write("Ingrese Tesla a eliminar:");
                        string vehiculoEliminar = Console.ReadLine();
                        Dictionary<string, object> autoABorrar = listaAutos.FirstOrDefault(t => t.ContainsKey("tesla") && t["tesla"].ToString() == vehiculoEliminar);
                        if (autoABorrar != null)
                        {
                            listaAutos.Remove(autoABorrar);
                            Console.WriteLine("Tesla eliminado con éxito.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningún Tesla con el numero ingresado.");
                        }
                        volverMenu();
                        break;

                    case 3:
                        // mostrar proximo a service
                        List<Dictionary<string, object>> autosService = new List<Dictionary<string, object>>();
                        if (listaAutos.Count > 0)
                        {
                            foreach (Dictionary<string, object> auto in listaAutos)
                            {
                                int resultado = Convert.ToInt32(auto[key: "kilometraje_service"]) - Convert.ToInt32(auto["kilometraje_actual"]);
                                if (resultado <= 1000)
                                {
                                    autosService.Add(auto);
                                }
                            }
                            foreach (Dictionary<string, object> autoService in autosService)
                            {
                                // Acceder a cada elemento del diccionario utilizando su clave
                                Console.WriteLine($" --------------  Tesla {autoService["tesla"]} ------------");
                                Console.WriteLine($"Patente: {autoService["patente"]}");
                                Console.WriteLine($"Dueño: {autoService["duenio"]}");
                                Console.WriteLine($"Color: {autoService["color"]}");
                                Console.WriteLine($"Modelo: {autoService["modelo"]}");
                                Console.WriteLine($"Año: {autoService["anio"]}");
                                Console.WriteLine($"Kilometraje_actual: {autoService["kilometraje_actual"]}");
                                Console.WriteLine($"Kilometraje_service: {autoService["kilometraje_service"]}");
                            }
                            volverMenu();
                        }
                        else
                        {
                            Console.WriteLine("La lista de Teslas esta vacia!");
                            volverMenu();
                        }
                        break;

                    case 4:
                        // reordenar el listado por anio

                        var ordenarLista = listaAutos.OrderBy(auto => (int)auto["anio"]);

                        if (ordenarLista != null) {
                            Console.WriteLine("Teslas ordenados por año");
                            foreach (var auto in ordenarLista)
                            {
                                Console.WriteLine($"Tesla: {auto["tesla"]}, Año: {auto["anio"]}");
                            }
                            volverMenu();
                        }
                        else
                        {
                            Console.WriteLine("La lista de Teslas esta vacia!");
                            volverMenu();
                        }
                        break;

                    case 5:

                        // Mostrar el auto más viejo
                        var autoMasViejo = listaAutos.OrderBy(auto => (int)auto["anio"]).FirstOrDefault();

                        if (autoMasViejo != null)
                        {
                            Console.WriteLine("Tesla más viejo");
                            Console.WriteLine($"Tesla: {autoMasViejo["tesla"]}, Año: {autoMasViejo["anio"]}");
                        }
                        else
                        {
                            Console.WriteLine("La lista de Teslas esta vacia.");
                        }

                        volverMenu();
                        break;


                    // Salir del programa    
                    case 6:
                        aux = false;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Gracias por usar nuestro sistema!");
            Console.ReadLine();
        }


    }

}
