using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Electrodomesticos.Electrodomestico;

namespace Electrodomesticos
{
    public class Electrodomestico
    {
        public string NombreProducto { get; set; }
        public float PrecioProducto { get; set; }
        public int CantidadProducto { get; set; }

        public Electrodomestico(string nombreProducto, float precioProducto, int cantidadProducto)
        {
            NombreProducto = nombreProducto;
            PrecioProducto = precioProducto;
            CantidadProducto = cantidadProducto;
        }

        internal class Refrigerador : Electrodomestico
        {
            public string Capacidad { get; set; }

            public Refrigerador(string nombreProducto, float precioProducto, int cantidadProducto, string capacidad)
                : base(nombreProducto, precioProducto, cantidadProducto)
            {
                Capacidad = capacidad;
            }
        }

        internal class Lavadora : Electrodomestico
        {
            public int CapacidadCarga { get; set; }

            public Lavadora(string nombreProducto, float precioProducto, int cantidadProducto, int capacidadCarga)
                : base(nombreProducto, precioProducto, cantidadProducto)
            {
                CapacidadCarga = capacidadCarga;
            }
        }

        internal class Televisor : Electrodomestico
        {
            public Televisor(string nombreProducto, float precioProducto, int cantidadProducto)
                : base(nombreProducto, precioProducto, cantidadProducto) { }
        }

        internal class Microondas : Electrodomestico
        {
            public Microondas(string nombreProducto, float precioProducto, int cantidadProducto)
                : base(nombreProducto, precioProducto, cantidadProducto) { }
        }

        public static class AdministrarElectrodomesticos
        {
            private static List<Electrodomestico> listaElectrodomestico = new List<Electrodomestico>();

            public static void Agregar(Electrodomestico electrodomesticos)
            {
                listaElectrodomestico.Add(electrodomesticos);
            }

            public static void Mostrar()
            {
                Console.WriteLine("*****************************************************************************\n\n");
                Console.WriteLine("Lista de Electrodomesticos:");
                foreach (var electrodomesticos in listaElectrodomestico)
                {
                    Console.WriteLine($"Nombre: {electrodomesticos.NombreProducto}, Precio: {electrodomesticos.PrecioProducto}, Cantidad: {electrodomesticos.CantidadProducto}");


                    if (electrodomesticos is Refrigerador)
                    {
                        Refrigerador refrigerador = (Refrigerador)electrodomesticos;
                        Console.WriteLine($"Tipo: Refrigerador, Capacidad: {refrigerador.Capacidad}");
                    }

                    else if (electrodomesticos is Lavadora)
                    {
                        Lavadora lavadora = (Lavadora)electrodomesticos;
                        Console.WriteLine($"Tipo: Lavadora, Capacidad de Carga: {lavadora.CapacidadCarga}");
                    }
                    // Verificar si el electrodoméstico es un Televisor y mostrar su tipo si lo es
                    else if (electrodomesticos is Televisor)
                    {
                        Console.WriteLine($"Tipo: Televisor");
                    }
                    // Verificar si el electrodoméstico es un Microondas y mostrar su tipo si lo es
                    else if (electrodomesticos is Microondas)
                    {
                        Console.WriteLine($"Tipo: Microondas");
                    }
                }

            }
            public static void Eliminar(string nombreProducto)
            {
                Electrodomestico electrodomestico = listaElectrodomestico.Find(e => e.NombreProducto == nombreProducto);
                if (electrodomestico != null)
                {
                    listaElectrodomestico.Remove(electrodomestico);
                    Console.WriteLine($"El electrodoméstico '{nombreProducto}' ha sido eliminado.");
                }
                else
                {
                    Console.WriteLine($"No se encontró el electrodoméstico '{nombreProducto}'.");
                }
            }

            public static void Editar(string nombreProducto, float nuevoPrecio, int nuevaCantidad)
            {
                Electrodomestico electrodomestico = listaElectrodomestico.Find(e => e.NombreProducto == nombreProducto);
                if (electrodomestico != null)
                {
                    electrodomestico.PrecioProducto = nuevoPrecio;
                    electrodomestico.CantidadProducto = nuevaCantidad;
                    Console.WriteLine($"El electrodoméstico '{nombreProducto}' ha sido editado.");
                }
                else
                {
                    Console.WriteLine($"No se encontró el electrodoméstico '{nombreProducto}'.");
                }
            }
        }



        public static void ElectrodomesticosMasVendidos()
        {
            Console.WriteLine("Los electrodomésticos más vendidos son: ");
        }


        class Program
        {
            static void Main(string[] args)
            {

                AdministrarElectrodomesticos.Agregar(new Televisor("Televisor Samsung", 499.99f, 10));
                AdministrarElectrodomesticos.Agregar(new Microondas("Microondas LG", 199.99f, 20));
                AdministrarElectrodomesticos.Agregar(new Lavadora("Lavadora Whirlpool", 699.99f, 15, 8));
                AdministrarElectrodomesticos.Agregar(new Refrigerador("Refrigerador GE", 899.99f, 12, "400 litros"));


                IniciarMenu();
            }
            static void IniciarMenu()
            {
                bool continuar = true;

                while (continuar)
                {
                    Console.WriteLine("*****************************************************************************\n\n");
                    Console.WriteLine("Menú de Administración de Electrodomésticos ");
                    Console.WriteLine("\n1. Mostrar Electrodomesticos");
                    Console.WriteLine("2. Agregar Electrodomestico");
                    Console.WriteLine("3. Eliminar Electrodomestico");
                    Console.WriteLine("4. Editar Electrodomestico");
                    Console.WriteLine("5. Salir");
                    Console.Write("Seleccione una opción: ");

                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            AdministrarElectrodomesticos.Mostrar();
                            break;
                        case "2":
                            Console.Write("Ingrese el nombre del electrodoméstico: ");
                            string nombreProducto = Console.ReadLine();
                            Console.Write("Ingrese el precio del electrodoméstico: ");
                            float precioProducto = float.Parse(Console.ReadLine());
                            Console.Write("Ingrese la cantidad del electrodoméstico: ");
                            int cantidadProducto = int.Parse(Console.ReadLine());
                            AdministrarElectrodomesticos.Agregar(new Electrodomestico(nombreProducto, precioProducto, cantidadProducto));
                            Console.WriteLine($"El electrodoméstico '{nombreProducto}' ha sido agregado.");
                            break;
                        case "3":
                            Console.Write("Ingrese el nombre del electrodoméstico que desea eliminar: ");
                            string nombreEliminar = Console.ReadLine();
                            AdministrarElectrodomesticos.Eliminar(nombreEliminar);
                            break;
                        case "4":
                            Console.Write("Ingrese el nombre del electrodoméstico que desea editar: ");
                            string nombreEditar = Console.ReadLine();
                            Console.Write("Ingrese el nuevo precio del electrodoméstico: ");
                            float nuevoPrecio = float.Parse(Console.ReadLine());
                            Console.Write("Ingrese la nueva cantidad del electrodoméstico: ");
                            int nuevaCantidad = int.Parse(Console.ReadLine());
                            AdministrarElectrodomesticos.Editar(nombreEditar, nuevoPrecio, nuevaCantidad);
                            break;
                        case "5":
                            continuar = false;
                            Console.WriteLine("Saliendo del programa.");
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                            break;
                    }
                }
            }
        }
    }
}