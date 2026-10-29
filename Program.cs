using System;
using System.IO;

namespace Contador
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CONTADOR DE PALABRAS, LÍNEAS Y CARACTERES ===");
            
            string rutaArchivo = string.Empty;

            if (args.Length > 0)
            {
                rutaArchivo = args[0];
            }
            else
            {
                Console.Write("Ingrese la ruta del archivo de texto: ");
                rutaArchivo = Console.ReadLine()?.Trim('"');
            }

            if (string.IsNullOrWhiteSpace(rutaArchivo) || !File.Exists(rutaArchivo))
            {
                Console.WriteLine("Error: El archivo especificado no existe o la ruta es inválida.");
                return;
            }

            try
            {
                string contenido = File.ReadAllText(rutaArchivo);
                string[] lineas = File.ReadAllLines(rutaArchivo);

                int cantidadCaracteres = contenido.Length;
                int cantidadLineas = lineas.Length;

                char[] separadores = new char[] { ' ', '\r', '\n', '\t' };
                string[] palabras = contenido.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
                int cantidadPalabras = palabras.Length;

                Console.WriteLine("\n--- Resultados ---");
                Console.WriteLine($"Líneas:     {cantidadLineas}");
                Console.WriteLine($"Palabras:   {cantidadPalabras}");
                Console.WriteLine($"Caracteres: {cantidadCaracteres}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al leer el archivo: {ex.Message}");
            }
        }
    }
}
