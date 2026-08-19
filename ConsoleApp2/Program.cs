using System;
using System.Collections.Generic;

namespace MiniTienda
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Producto> productos = new List<Producto>
            {
                new Producto("Mouse", 50000),
                new Producto("Teclado", 80000),
                new Producto("Audífonos", 60000)
            };

            List<Producto> carrito = new List<Producto>();
            int opcion;

            do
            {
                Console.WriteLine("=== MINI TIENDA ===");
                Console.WriteLine("1. Ver productos");
                Console.WriteLine("2. Agregar producto al carrito");
                Console.WriteLine("3. Ver carrito");
                Console.WriteLine("4. Finalizar compra");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("PRODUCTOS ===");
                        for (int i = 0; i < productos.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {productos[i].Nombre} - ${productos[i].Precio}");
                        }
                        break;

                    case 2:
                        Console.Write("Ingrese el número del producto: ");
                        int num = int.Parse(Console.ReadLine());
                        if (num > 0 && num <= productos.Count)
                        {
                            carrito.Add(productos[num - 1]);
                            Console.WriteLine($"{productos[num - 1].Nombre} agregado al carrito.");
                        }
                        else
                        {
                            Console.WriteLine("Producto inválido.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("CARRITO ===");
                        int total = 0;
                        foreach (var p in carrito)
                        {
                            Console.WriteLine($"{p.Nombre} - ${p.Precio}");
                            total += p.Precio;
                        }
                        Console.WriteLine($"Total: ${total}");
                        break;

                    case 4:
                        int suma = 0;
                        foreach (var p in carrito) suma += p.Precio;
                        Console.WriteLine($"Total a pagar: ${suma}");
                        Console.Write("¿Confirmar compra? (S/N): ");
                        string confirm = Console.ReadLine();
                        if (confirm.ToUpper() == "S")
                        {
                            Console.WriteLine("Compra realizada correctamente.");
                            carrito.Clear();
                        }
                        break;
                }

                Console.WriteLine();
            } while (opcion != 5);
        }
    }

    class Producto
    {
        public string Nombre { get; set; }
        public int Precio { get; set; }

        public Producto(string nombre, int precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
    }
}