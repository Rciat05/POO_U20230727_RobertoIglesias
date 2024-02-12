using System;
using System.Collections.Generic;

namespace TiendaZapatos
{
    public class Zapato
    {
        public string Marca { get; set; }
        public float Precio { get; set; }
        public string Color { get; set; }

        public Zapato(string marca, float precio, string color)
        {
            Marca = marca;
            Precio = precio;
            Color = color;
        }
    }

    public class TiendaZapatos
    {
        private static List<Zapato> inventario = new List<Zapato>();

        public static void AgregarZapato(string marca, float precio, string color)
        {
            inventario.Add(new Zapato(marca, precio, color));
        }

        public static void MostrarInventario()
        {
            Console.WriteLine("*****************************************************************************\n\n");
            Console.WriteLine("Inventario de Zapatos:");
            foreach (var zapato in inventario)
            {
                Console.WriteLine($"Marca: {zapato.Marca}, Precio: {zapato.Precio}, Color: {zapato.Color}");
            }
        }

        public static void EliminarZapato(string marca)
        {
            Zapato zapatoAEliminar = inventario.Find(z => z.Marca == marca);
            if (zapatoAEliminar != null)
            {
                inventario.Remove(zapatoAEliminar);
                Console.WriteLine($"El zapato de marca '{marca}' ha sido eliminado del inventario.");
            }
            else
            {
                Console.WriteLine($"No se encontró un zapato de marca '{marca}' en el inventario.");
            }
        }

        public static void EditarZapato(string marca, float nuevoPrecio, string nuevoColor)
        {
            Zapato zapatoAEditar = inventario.Find(z => z.Marca == marca);
            if (zapatoAEditar != null)
            {
                zapatoAEditar.Precio = nuevoPrecio;
                zapatoAEditar.Color = nuevoColor;
                Console.WriteLine($"El zapato de marca '{marca}' ha sido editado en el inventario.");
            }
            else
            {
                Console.WriteLine($"No se encontró un zapato de marca '{marca}' en el inventario.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TiendaZapatos.AgregarZapato("Nike", 99.99f, "Negro");
            TiendaZapatos.AgregarZapato("Adidas", 79.99f, "Blanco");
            TiendaZapatos.AgregarZapato("Gucci", 199.99f, "Marrón");

            IniciarMenu();
        }

        static void IniciarMenu()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("*****************************************************************************\n\n");
                Console.WriteLine("Menú de Administración de Zapatos ");
                Console.WriteLine("\n1. Mostrar Inventario");
                Console.WriteLine("2. Agregar Zapato");
                Console.WriteLine("3. Eliminar Zapato");
                Console.WriteLine("4. Editar Zapato");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        TiendaZapatos.MostrarInventario();
                        break;
                    case "2":
                        Console.Write("Ingrese la marca del zapato: ");
                        string marca = Console.ReadLine();
                        Console.Write("Ingrese el precio del zapato: ");
                        float precio = float.Parse(Console.ReadLine());
                        Console.Write("Ingrese el color del zapato: ");
                        string color = Console.ReadLine();
                        TiendaZapatos.AgregarZapato(marca, precio, color);
                        Console.WriteLine($"El zapato de marca '{marca}' ha sido agregado al inventario.");
                        break;
                    case "3":
                        Console.Write("Ingrese la marca del zapato que desea eliminar: ");
                        string marcaEliminar = Console.ReadLine();
                        TiendaZapatos.EliminarZapato(marcaEliminar);
                        break;
                    case "4":
                        Console.Write("Ingrese la marca del zapato que desea editar: ");
                        string marcaEditar = Console.ReadLine();
                        Console.Write("Ingrese el nuevo precio del zapato: ");
                        float nuevoPrecio = float.Parse(Console.ReadLine());
                        Console.Write("Ingrese el nuevo color del zapato: ");
                        string nuevoColor = Console.ReadLine();
                        TiendaZapatos.EditarZapato(marcaEditar, nuevoPrecio, nuevoColor);
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
