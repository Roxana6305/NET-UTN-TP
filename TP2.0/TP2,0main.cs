class Program
{
    static void Main(string[] args)
    {
        // Crear sucursales
        Sucursal[] sucursales = { new Sucursal("ABC"), new Sucursal("DEF"), new Sucursal("GHI") };

        while (true)
        {
            Console.WriteLine("Lista de códigos de sucursales:");
            foreach (var sucursal in sucursales)
            {
                Console.WriteLine(sucursal.Codigo);
            }

            Console.Write("Ingrese el código de la sucursal (o 'SALIR' para terminar): ");
            string codigoSucursal = Console.ReadLine();

            if (codigoSucursal.ToUpper() == "SALIR")
                break;

            Sucursal sucursalSeleccionada = sucursales.FirstOrDefault(s => s.Codigo == codigoSucursal);
            if (sucursalSeleccionada == null)
            {
                Console.WriteLine("Código de sucursal inválido.");
                continue;
            }

            while (true)
            {
                Console.WriteLine($"Sucursal {sucursalSeleccionada.Codigo}");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Catalogar nueva vacuna");
                Console.WriteLine("2. Sintetizar virus");
                Console.WriteLine("3. Destruir medicamento");
                Console.WriteLine("4. Destruir por tipo");
                Console.WriteLine("5. Activar sistema de autodestrucción");
                Console.WriteLine("6. Activar sistema de autodestrucción global");
                Console.WriteLine("7. Salir");
                Console.Write("Opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    if (opcion == 1)
                    {
                        Console.Write("Ingrese el nombre de la vacuna: ");
                        string nombreVacuna = Console.ReadLine();
                        Console.Write("Ingrese la designación de la vacuna (ALFA, BETA, GAMA, EPSILON, OMEGA, TAU): ");
                        string designacionVacuna = Console.ReadLine().ToUpper();

                        if (Enum.IsDefined(typeof(Designacion), designacionVacuna))
                        {
                            Vacuna vacuna = new Vacuna(Guid.NewGuid().ToString().Substring(0, 3), nombreVacuna, designacionVacuna);
                            sucursalSeleccionada.CatalogarVacuna(vacuna);
                            Console.WriteLine($"Vacuna catalogada con éxito. Código: {vacuna.Codigo}");
                        }
                        else
                        {
                            Console.WriteLine("Designación de vacuna inválida.");
                        }
                    }
                    else if (opcion == 2)
                    {
                        sucursalSeleccionada.SintetizarVirus();
                        Console.WriteLine("Virus sintetizado con éxito.");
                    }
                    else if (opcion == 3)
                    {
                        Console.WriteLine("Lista de medicamentos disponibles:");
                        for (int i = 0; i < sucursalSeleccionada.Medicamentos.Count; i++)
                        {
                            Console.WriteLine($"{i}. {sucursalSeleccionada.Medicamentos[i]}");
                        }

                        Console.Write("Elija el número del medicamento a destruir (o -1 para cancelar): ");
                        if (int.TryParse(Console.ReadLine(), out int seleccion))
                        {
                            if (seleccion == -1)
                            {
                                Console.WriteLine("Operación cancelada.");
                            }
                            else
                            {
                                sucursalSeleccionada.DestruirMedicamento(seleccion);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Selección inválida.");
                        }
                    }
                    else if (opcion == 4)
                    {
                        Console.Write("Ingrese la designación del tipo a destruir: ");
                        string designacionTipo = Console.ReadLine().ToUpper();
                        if (Enum.IsDefined(typeof(Designacion), designacionTipo))
                        {
                            sucursalSeleccionada.DestruirPorTipo(designacionTipo);
                        }
                        else
                        {
                            Console.WriteLine("Designación de tipo inválida.");
                        }
                    }
                    else if (opcion == 5)
                    {
                        sucursalSeleccionada.Autodestruccion();
                        Console.WriteLine("Sistema de autodestrucción activado. Todos los medicamentos han sido destruidos.");
                    }
                    else if (opcion == 6)
                    {
                        Console.Write("¿Está seguro de que desea activar el sistema de autodestrucción global? (Sí/No): ");
                        string respuesta = Console.ReadLine().ToUpper();
                        if (respuesta == "SI" || respuesta == "S")
                        {
                            foreach (var suc in sucursales)
                            {
                                suc.Autodestruccion();
                            }
                            Console.WriteLine("Sistema de autodestrucción global activado. Todas las sucursales han sido destruidas.");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Operación cancelada.");
                        }
                    }
                    else if (opcion == 7)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida.");
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida.");
                }
            }
        }
    }
}