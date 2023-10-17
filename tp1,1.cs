using System;
// Sandra Statuto

class Program
{
    // Enum de asteroides y metales.
    enum TamañoAsteroides { Pequeño, Mediano, Grande, Cataclísmico }
    enum TipoMetales { Hierro, Oro, Platino, MetalesMisceláneos }

    static void Main()
    {
        Random rand = new Random();
        int sistemaActual = 0;
        int totalHierro = 0, totalOro = 0, totalPlatino = 0, totalMetalesMisceláneos = 0, totalCarga = 0;

        while (true)
        {
            sistemaActual++;
            int asteroidesEnSistema = rand.Next(1, 11); // Generacion aleatoria de asteroides (entre 1 y 10).

            Console.WriteLine($"EN EL SISTEMA [{sistemaActual}] SE MINARON [{asteroidesEnSistema}] ASTEROIDES");

            for (int i = 0; i < asteroidesEnSistema; i++)
            {
                // Generador aleatorio para el asteroide.
                TamañoAsteroides tamaño = (TamañoAsteroides)rand.Next(0, 4);

                // Generador aleatoria para lacomposicion del asteroide.
                int[] composicion = GenerarComposicionAleatoria(tamaño, rand);

                Console.WriteLine($"{ObtenerNombreTamaño(tamaño)} asteroide:");
                ImprimirComposicion(composicion);

                // Actualizacion de la carga.
                totalHierro += composicion[(int)TipoMetales.Hierro];
                totalOro += composicion[(int)TipoMetales.Oro];
                totalPlatino += composicion[(int)TipoMetales.Platino];
                totalMetalesMisceláneos += composicion[(int)TipoMetales.MetalesMisceláneos];
                totalCarga += composicion[(int)TipoMetales.Hierro] +
                            composicion[(int)TipoMetales.Oro] +
                            composicion[(int)TipoMetales.Platino] +
                            composicion[(int)TipoMetales.MetalesMisceláneos];
            }

            Console.WriteLine($"Por un total de {totalCarga} KG de carga.");
            Console.WriteLine();

            Console.WriteLine("¿Desea entrar en otro sistema? (S para sí, cualquier otra tecla para salir del programa)");
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
        Console.WriteLine($"Metales misceláneos total: {totalMetalesMisceláneos} KG");
        Console.WriteLine($"Carga total: {totalCarga} KG");
    }

    // Nombre del asteroide por tameño en función del valor enum.
    static string ObtenerNombreTamaño(TamañoAsteroides tamaño)
    {
        string[] nombres = { "Pequeño", "Mediano", "Grande", "Cataclísmico" };
        return nombres[(int)tamaño];
    }

    // Composición aleatoria para un asteroide en función de su tamaño.
    static int[] GenerarComposicionAleatoria(TamañoAsteroides tamaño, Random rand)
    {
        int[] composicion = new int[4];
        int totalCarga = 0;

        // Valores para los diferentes tamaños de asteroides.
        int[] valoresMin = { 100, 500, 1000, 2500 };
        int[] valoresMax = { 500, 1000, 2500, 5000 };

        // Valores aleatorios de metales.
        for (int i = 0; i < composicion.Length; i++)
        {
            composicion[i] = rand.Next(valoresMin[(int)tamaño], valoresMax[(int)tamaño] + 1);
            totalCarga += composicion[i];
        }

        // Asegurarse de que la carga total sea la especificada para el tamaño del asteroide.
        if (totalCarga != ObtenerCargaTamaño(tamaño))
        {
            // Ajustar de metales para que sume la carga correcta.
            double factorDeAjuste = (double)ObtenerCargaTamaño(tamaño) / totalCarga;
            for (int i = 0; i < composicion.Length; i++)
            {
                composicion[i] = (int)(composicion[i] * factorDeAjuste);
            }
        }

        return composicion;
    }

    // Carga total específica para un tamaño de asteroide.
    static int ObtenerCargaTamaño(TamañoAsteroides tamaño)
    {
        int[] cargas = { 1000, 2000, 5000, 10000 };
        return cargas[(int)tamaño];
    }

    // Salida por pantalla de la composición de un asteroide.
    static void ImprimirComposicion(int[] composicion)
    {
        string[] nombresMetales = { "Hierro", "Oro", "Platino", "Metales Misceláneos" };
        for (int i = 0; i < composicion.Length; i++)
        {
            Console.WriteLine($"{composicion[i]} KG de {nombresMetales[i]}");
        }
    }
}