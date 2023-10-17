using System;
class Program
{
    static void Main()
    {
        // Inicialización de variables
        double dineroEnCaja = 1000.0; // Iniciar con 1000 pesos en caja
        double comidaGatosEnStock = 100.0; // Iniciar con 100 kg de comida para gatos en stock
        double comidaPerrosEnStock = 100.0; // Iniciar con 100 kg de comida para perros en stock

        Console.WriteLine("Selecciona una empleada (1: Andurias, 2: Asterios, 3: Penurias):");
        int opcion = int.Parse(Console.ReadLine());

        if (opcion == 1)
        {
            // Andurias puede modificar el dinero en la caja
            Console.WriteLine("Introduce la cantidad de dinero que deseas modificar (positiva para aumentar, negativa para reducir):");
            double cantidadModificar = double.Parse(Console.ReadLine());
            dineroEnCaja += cantidadModificar;
        }
        else if (opcion == 2)
        {
            // Asterios puede reducir la cantidad de comida para gatos o perros en stock
            Console.WriteLine("Selecciona el tipo de comida para reducir (1: Gatos, 2: Perros):");
            int tipoComida = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce la cantidad de kilos a reducir:");
            double cantidadReducir = double.Parse(Console.ReadLine());

            if (tipoComida == 1)
            {
                comidaGatosEnStock -= cantidadReducir;
            }
            else if (tipoComida == 2)
            {
                comidaPerrosEnStock -= cantidadReducir;
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }
        }
        else if (opcion == 3)
        {
            // Penurias puede comprar comida para gatos o perros, reduciendo el dinero en la caja
            Console.WriteLine("Selecciona el tipo de comida para comprar (1: Gatos, 2: Perros):");
            int tipoComida = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce la cantidad de kilos a comprar:");
            double cantidadComprar = double.Parse(Console.ReadLine());

            if (tipoComida == 1)
            {
                double costoCompra = cantidadComprar * 50.0;
                if (dineroEnCaja >= costoCompra)
                {
                    comidaGatosEnStock += cantidadComprar;
                    dineroEnCaja -= costoCompra;
                }
                else
                {
                    Console.WriteLine("No hay suficiente dinero en la caja para realizar la compra.");
                }
            }
            else if (tipoComida == 2)
            {
                double costoCompra = cantidadComprar * 50.0;
                if (dineroEnCaja >= costoCompra)
                {
                    comidaPerrosEnStock += cantidadComprar;
                    dineroEnCaja -= costoCompra;
                }
                else
                {
                    Console.WriteLine("No hay suficiente dinero en la caja para realizar la compra.");
                }
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }
        }
        else
        {
            Console.WriteLine("Opción no válida. Por favor, selecciona 1, 2 o 3.");
        }

        // Mostrar el estado actual de stock y dinero en caja
        Console.WriteLine($"Stock de comida para gatos: {comidaGatosEnStock} kg");
        Console.WriteLine($"Stock de comida para perros: {comidaPerrosEnStock} kg");
        Console.WriteLine($"Dinero en caja: {dineroEnCaja} pesos");
    }
}
