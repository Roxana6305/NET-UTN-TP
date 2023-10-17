using System;
using System.Text;
// Autor: Sandra Roxana Statuto
// Se pueden agregar más frases al arreglo frases_criollo 
class Program
{
    static void Main()
    {
        string[] frasesCriollo = {
            "Hola, amigo",
            "Esto es una prueba",
            "Vocal",
            "Perros",
            "Nave"
        };

        string[] frasesTraducidas = new string[frasesCriollo.Length];

        for (int i = 0; i < frasesCriollo.Length; i++)
        {
            frasesTraducidas[i] = Traducir(frasesCriollo[i]);
        }

        Console.WriteLine("Texto en español criollo y su traducción a castellano profundo:");
        for (int i = 0; i < frasesCriollo.Length; i++)
        {
            Console.WriteLine($"{frasesCriollo[i]} -> {frasesTraducidas[i]}");
        }
    }

    static string Traducir(string palabra)
    {
        palabra = palabra.ToLower();
        StringBuilder traduccion = new StringBuilder();
        bool primeraVocalDuplicada = false;

        for (int i = 0; i < palabra.Length; i++)
        {
            char letra = palabra[i];
            if (EsVocal(letra))
            {
                if (!primeraVocalDuplicada || (i > 0 && !EsVocal(palabra[i - 1])))
                {
                    traduccion.Append(letra);
                    traduccion.Append(letra);
                    primeraVocalDuplicada = true;
                }
                else
                {
                    traduccion.Append(letra);
                }
            }
            else
            {
                traduccion.Append(letra);
            }
        }

        if (traduccion.Length > 6)
        {
            traduccion.Insert(0, "an");
        }

        char ultimaLetra = traduccion[traduccion.Length - 1];
        if (ultimaLetra == 'n' || ultimaLetra == 's' || EsVocal(ultimaLetra))
        {
            traduccion.Append(ultimaLetra == 'o' ? "so" : "sten");
        }

        return traduccion.ToString();
    }

    static bool EsVocal(char letra)
    {
        return "aeiou".Contains(letra);
    }
}
