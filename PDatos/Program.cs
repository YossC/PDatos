using System;
using System.IO;

class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public void MostrarInfo()
    {
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Edad: " + Edad);
    }

    // Método para guardar la información de la persona en un archivo
    public void GuardarInfo(string archivo)
    {
        using (StreamWriter sw = new StreamWriter(archivo, true))
        {
            sw.WriteLine(Nombre);
            sw.WriteLine(Edad);
        }
    }

    // Método estático para cargar la información desde un archivo
    public static Persona CargarInfo(StreamReader sr)
    {
        Persona persona = new Persona();
        persona.Nombre = sr.ReadLine();
        persona.Edad = int.Parse(sr.ReadLine());
        return persona;
    }
}

class Program
{
    static void Main()
    {
        string archivo = "personas.txt";

        // Cargar y mostrar la información de personas guardadas en el archivo
        if (File.Exists(archivo))
        {
            using (StreamReader sr = new StreamReader(archivo))
            {
                while (!sr.EndOfStream)
                {
                    Persona persona = Persona.CargarInfo(sr);
                    persona.MostrarInfo();
                }
            }
        }
        else
        {
            Console.WriteLine("No hay datos guardados.");
        }

        // Crear y guardar nueva información de personas
        Persona persona1 = new Persona();
        persona1.Nombre = "Juan";
        persona1.Edad = 30;
        persona1.GuardarInfo(archivo);

        Persona persona2 = new Persona();
        persona2.Nombre = "María";
        persona2.Edad = 25;
        persona2.GuardarInfo(archivo);
    }
}
