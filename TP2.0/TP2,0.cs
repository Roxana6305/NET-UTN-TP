using System;
using System.Collections.Generic;
using System.Linq;

class Sucursal
{
    public string Codigo { get; }
    public List<Medicamento> Medicamentos { get; } = new List<Medicamento>();

    public Sucursal(string codigo)
    {
        Codigo = codigo;
    }

    public void CatalogarVacuna(Vacuna vacuna)
    {
        Medicamentos.Add(vacuna);
    }

    public void SintetizarVirus()
    {
        if (Medicamentos.Any(m => m is Vacuna))
        {
            Vacuna ultimaVacuna = Medicamentos.OfType<Vacuna>().Last();
            string codigoVirus = $"{ultimaVacuna.Codigo}-V";
            Virus virus = new Virus(codigoVirus, ultimaVacuna.Nombre, ultimaVacuna.Designacion);
            Medicamentos.Add(virus);
        }
        else
        {
            Console.WriteLine("No hay vacunas disponibles para sintetizar un virus.");
        }
    }

    public void DestruirMedicamento(int seleccion)
    {
        if (seleccion >= 0 && seleccion < Medicamentos.Count)
        {
            Medicamento medicamento = Medicamentos[seleccion];
            medicamento.Destruir();
            Console.WriteLine($"El medicamento {medicamento.Nombre} ha sido destruido.");
            Medicamentos.Remove(medicamento);
        }
        else
        {
            Console.WriteLine("Selección inválida.");
        }
    }

    public void DestruirPorTipo(string designacion)
    {
        List<Medicamento> medicamentosADestruir = Medicamentos.Where(m => m.Designacion == designacion).ToList();

        foreach (Medicamento medicamento in medicamentosADestruir)
        {
            medicamento.Destruir();
            Medicamentos.Remove(medicamento);
        }

        Console.WriteLine($"Todos los medicamentos de designación {designacion} han sido destruidos.");
    }

    public void Autodestruccion()
    {
        Medicamentos.Clear();
        Console.WriteLine("Todos los medicamentos han sido destruidos.");
    }
}

abstract class Medicamento
{
    public string Codigo { get; set; }
    public string Nombre { get; }
    public string Designacion { get; }

    public Medicamento(string codigo, string nombre, string designacion)
    {
        Codigo = codigo;
        Nombre = nombre;
        Designacion = designacion;
    }

    public abstract void Destruir();

    public override string ToString()
    {
        return $"{Codigo}: {Nombre} ({Designacion})";
    }
}

class Vacuna : Medicamento
{
    public Vacuna(string codigo, string nombre, string designacion) : base(codigo, nombre, designacion) { }

    public override void Destruir()
    {
        Codigo = "XXX";
    }
}

class Virus : Medicamento
{
    public Virus(string codigo, string nombre, string designacion) : base(codigo, nombre, designacion) { }

    public override void Destruir()
    {
        Codigo = "YYYY";
    }
}


