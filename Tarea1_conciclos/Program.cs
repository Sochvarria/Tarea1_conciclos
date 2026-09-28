using System;

class Program
{
    static void Main(string[] args)
    {
        // Contadores y acumuladores de salarios netos
        int cantOp = 0, cantTec = 0, cantProf = 0;
        double acumOp = 0, acumTec = 0, acumProf = 0;
        char continuar;

        do
        {
            Console.Clear();
            Console.WriteLine("=== CÁLCULO DE SALARIO ===");

            Console.Write("Cédula: ");
            string cedula = Console.ReadLine();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Tipo (1-Operario, 2-Técnico, 3-Profesional): ");
            int tipoEmpleado = Convert.ToInt32(Console.ReadLine());

            Console.Write("Horas trabajadas: ");
            double horas = Convert.ToDouble(Console.ReadLine());

            Console.Write("Precio por hora: ");
            double salarioHora = Convert.ToDouble(Console.ReadLine());

            // Cálculos principales
            double salarioOrdinario = horas * salarioHora;
            double porcentajeAumento = (tipoEmpleado == 1) ? 0.15 : (tipoEmpleado == 2) ? 0.10 : (tipoEmpleado == 3) ? 0.05 : 0;

            if (porcentajeAumento == 0)
            {
                Console.WriteLine("\nTipo de empleado inválido. Presione una tecla...");
                Console.ReadKey();
                continue;
            }

            double aumento = salarioOrdinario * porcentajeAumento;
            double salarioBruto = salarioOrdinario + aumento;
            double deduccionCCSS = salarioBruto * 0.0917;
            double salarioNeto = salarioBruto - deduccionCCSS;

            // Acumular datos
            if (tipoEmpleado == 1) { cantOp++; acumOp += salarioNeto; }
            else if (tipoEmpleado == 2) { cantTec++; acumTec += salarioNeto; }
            else if (tipoEmpleado == 3) { cantProf++; acumProf += salarioNeto; }

            // Resultado individual
            string nombreTipo = (tipoEmpleado == 1) ? "Operario" : (tipoEmpleado == 2) ? "Técnico" : "Profesional";
            Console.WriteLine($"\n--- DETALLE DE {nombreTipo.ToUpper()} ---");
            Console.WriteLine($"Salario Ordinario: ₡{salarioOrdinario:N2}");
            Console.WriteLine($"Aumento: ₡{aumento:N2}");
            Console.WriteLine($"Salario Bruto: ₡{salarioBruto:N2}");
            Console.WriteLine($"Deducción CCSS: ₡{deduccionCCSS:N2}");
            Console.WriteLine($"Salario Neto: ₡{salarioNeto:N2}");

            Console.Write("\n¿Ingresar otro empleado? (S/N): ");
            continuar = Convert.ToChar(Console.ReadLine().ToUpper());

        } while (continuar == 'S');

        // Reporte Estadístico Final
        Console.Clear();
        Console.WriteLine("======================================");
        Console.WriteLine("       RESUMEN GENERAL DE PLANILLA");
        Console.WriteLine("======================================");

        ImprimirResumen("Operario", cantOp, acumOp);
        ImprimirResumen("Técnico", cantTec, acumTec);
        ImprimirResumen("Profesional", cantProf, acumProf);

        Console.WriteLine("--------------------------------------");
        Console.WriteLine($"Total Empleados: {cantOp + cantTec + cantProf}");
        Console.WriteLine($"Total Neto a Pagos: ₡{(acumOp + acumTec + acumProf):N2}");
        Console.WriteLine("======================================");

        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }

    // Método auxiliar para no repetir código de impresión
    static void ImprimirResumen(string tipo, int cantidad, double acumulado)
    {
        double promedio = cantidad > 0 ? acumulado / cantidad : 0;
        Console.WriteLine($"\nTipo: {tipo}");
        Console.WriteLine($"  Cantidad: {cantidad} | Total Neto: ₡{acumulado:N2} | Promedio: ₡{promedio:N2}");
    }
}