using System;

// Clase para representar un asteroide con su tamaño y composición.
class Asteroide
{
    public int Tamaño { get; private set; }
    public int[] Composicion { get; private set; }

    public Asteroide(int tamaño)
    {
        Tamaño = tamaño;
        Composicion = GenerarComposicionAleatoria();
    }

    private int[] GenerarComposicionAleatoria()
    {
        int[] composicion = new int[4];
        int totalCarga = 0;

        int[] valoresMin = { 100, 500, 1000, 2500 };
        int[] valoresMax = { 500, 1000, 2500, 5000 };

        Random rand = new Random();

        // Generar valores aleatorios de metales para la composición del asteroide.
        for (int i = 0; i < composicion.Length; i++)
        {
            composicion[i] = rand.Next(valoresMin[Tamaño], valoresMax[Tamaño] + 1);
            totalCarga += composicion[i];
        }

        // Asegurarse de que la carga total sea la especificada para el tamaño del asteroide.
        double factorDeAjuste = (double)ObtenerCargaTamaño(Tamaño) / totalCarga;
        for (int i = 0; i < composicion.Length; i++)
        {
            composicion[i] = (int)(composicion[i] * factorDeAjuste);
        }

        return composicion;
    }

    public string ObtenerNombreTamaño()
    {
        string[] nombres = { "Pequeño", "Mediano", "Grande", "Cataclísmico" };
        return nombres[Tamaño];
    }

    public void ImprimirComposicion()
    {
        string[] nombresMetal = { "Hierro", "Oro", "Platino", "Metales Misceláneos" };
        for (int i = 0; i < Composicion.Length; i++)
        {
            Console.WriteLine($"{Composicion[i]} KG de {nombresMetal[i]}");
        }
    }
}

class Program
{
    static void Main()
    {
        int sistemaActual = 0;
        int totalHierro = 0;
        int totalOro = 0;
        int totalPlatino = 0;
        int totalMetalesMiscelaneos = 0;
        int totalCarga = 0;

        while (true)
        {
            sistemaActual++;
            int asteroidesEnSistema = new Random().Next(1, 11);  

            Console.WriteLine($"EN EL SISTEMA [{sistemaActual}] SE MINARON [{asteroidesEnSistema}] ASTEROIDES");

            for (int i = 0; i < asteroidesEnSistema; i++)
            {
                int tamaño = new Random().Next(0, 4);  // Generar tamaño aleatorio para el asteroide.
                Asteroide asteroide = new Asteroide(tamaño);

                Console.WriteLine($"{asteroide.ObtenerNombreTamaño()} asteroide:");
                asteroide.ImprimirComposicion();

                totalHierro += asteroide.Composicion[(int)TipoMetales.Hierro];
                totalOro += asteroide.Composicion[(int)TipoMetales.Oro];
                totalPlatino += asteroide.Composicion[(int)TipoMetales.Platino];
                totalMetalesMiscelaneos += asteroide.Composicion[(int)TipoMetales.MetalesMisceláneos];
                totalCarga += asteroide.Composicion[(int)TipoMetales.Hierro] +
                            asteroide.Composicion[(int)TipoMetales.Oro] +
                            asteroide.Composicion[(int)TipoMetales.Platino] +
                            asteroide.Composicion[(int)TipoMetales.MetalesMisceláneos];
            }

            Console.WriteLine($"Por un total de {totalCarga} KG de carga.\n");

            Console.WriteLine("¿Desea entrar en otro sistema? (S para sí, cualquier otra tecla para salir del programa): ");
            if (Console.ReadKey().Key != ConsoleKey.S)
            {
                break;
            }

            Console.WriteLine();
        }

        // Resumen de carga al salir del programa.
        Console.WriteLine("RESUMEN TOTAL:");
        Console.WriteLine($"Hierro total: {totalHierro} KG");
        Console.WriteLine($"Oro total: {totalOro} KG");
        Console.WriteLine($"Platino total: {totalPlatino} KG");
        Console.WriteLine($"Metales misceláneos total: {totalMetalesMiscelaneos} KG");
        Console.WriteLine($"Carga total: {totalCarga} KG");
    }

    // Función para obtener la carga específica para un tamaño de asteroide.
    static int ObtenerCargaTamaño(int tamaño)
    {
        int[] cargas = { 1000, 2000, 5000, 10000 };
        return cargas[tamaño];
    }
}

enum TipoMetales { Hierro, Oro, Platino, MetalesMisceláneos }