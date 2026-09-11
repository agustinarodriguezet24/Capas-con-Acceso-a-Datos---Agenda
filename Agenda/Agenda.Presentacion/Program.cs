using System;
using System.Collections.Generic;
using Agenda.Entidades;
using Agenda.Negocio;

PersonaNegocio negocio = new PersonaNegocio();

int opcion;

do
{
    Console.Clear();

    Console.WriteLine("=================================");
    Console.WriteLine("             AGENDA");
    Console.WriteLine("=================================");
    Console.WriteLine("1. Agregar");
    Console.WriteLine("2. Buscar");
    Console.WriteLine("3. Modificar");
    Console.WriteLine("4. Eliminar");
    Console.WriteLine("5. Salir");
    Console.WriteLine("=================================");
    Console.Write("Opción: ");

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.WriteLine("Opción inválida.");
        Console.ReadLine();
        continue;
    }

    try
    {
        switch (opcion)
        {
            case 1:
                Agregar();
                break;

            case 2:
                Buscar();
                break;

            case 3:
                Modificar();
                break;

            case 4:
                Eliminar();
                break;

            case 5:
                Console.WriteLine("Programa finalizado.");
                break;

            default:
                Console.WriteLine("Opción incorrecta.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("ERROR: " + ex.Message);
    }

    if (opcion != 5)
    {
        Console.WriteLine();
        Console.WriteLine("Presione ENTER para continuar...");
        Console.ReadLine();
    }

} while (opcion != 5);




int LeerEntero(string mensaje)
{
    int valor;

    Console.Write(mensaje);

    while (!int.TryParse(Console.ReadLine(), out valor))
    {
        Console.Write("Valor inválido. Ingrese un número: ");
    }

    return valor;
}




void Agregar()
{
    Console.Clear();

    Console.WriteLine("===== AGREGAR PERSONA =====");

    Persona persona = new Persona();

    persona.DNI = LeerEntero("DNI: ");

    Console.Write("Apellido: ");
    persona.APELLIDO = Console.ReadLine();

    Console.Write("Nombres: ");
    persona.NOMBRES = Console.ReadLine();

    Console.Write("Calle: ");
    persona.CALLE = Console.ReadLine();

    Console.Write("Depto: ");
    persona.DEPTO = Console.ReadLine();

    persona.PISO = LeerEntero("Piso: ");

    Console.Write("Ciudad: ");
    persona.CIUDAD = Console.ReadLine();

    Console.Write("Teléfono: ");
    persona.TELEFONO = Console.ReadLine();

    Console.Write("Email: ");
    persona.EMAIL = Console.ReadLine();

    bool resultado = negocio.Agregar(persona);

    if (resultado)
        Console.WriteLine("\nPersona agregada correctamente.");
    else
        Console.WriteLine("\nNo se pudo agregar la persona.");
}




void Buscar()
{
    Console.Clear();

    Console.WriteLine("===== BUSCAR PERSONA =====");
    Console.WriteLine("1. DNI");
    Console.WriteLine("2. Apellido");
    Console.WriteLine("3. Nombres");
    Console.WriteLine("4. Calle");
    Console.WriteLine();

    int opcionBusqueda = LeerEntero("Buscar por: ");

    string campo = "";

    switch (opcionBusqueda)
    {
        case 1:
            campo = "DNI";
            break;

        case 2:
            campo = "APELLIDO";
            break;

        case 3:
            campo = "NOMBRES";
            break;

        case 4:
            campo = "CALLE";
            break;

        default:
            Console.WriteLine("Opción incorrecta.");
            return;
    }

    Console.Write("Ingrese el dato a buscar: ");
    string valor = Console.ReadLine();

    List<Persona> personas = negocio.Buscar(campo, valor);

    Console.WriteLine();

    if (personas.Count == 0)
    {
        Console.WriteLine("No se encontraron personas.");
        return;
    }

    foreach (Persona persona in personas)
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("DNI: " + persona.DNI);
        Console.WriteLine("Apellido: " + persona.APELLIDO);
        Console.WriteLine("Nombres: " + persona.NOMBRES);
        Console.WriteLine("Calle: " + persona.CALLE);
        Console.WriteLine("Depto: " + persona.DEPTO);
        Console.WriteLine("Piso: " + persona.PISO);
        Console.WriteLine("Ciudad: " + persona.CIUDAD);
        Console.WriteLine("Teléfono: " + persona.TELEFONO);
        Console.WriteLine("Email: " + persona.EMAIL);
        Console.WriteLine("--------------------------------");
    }
}




void Modificar()
{
    Console.Clear();

    Console.WriteLine("===== MODIFICAR PERSONA =====");

    Persona persona = new Persona();

    persona.DNI = LeerEntero("DNI de la persona a modificar: ");

    Console.Write("Nuevo apellido: ");
    persona.APELLIDO = Console.ReadLine();

    Console.Write("Nuevos nombres: ");
    persona.NOMBRES = Console.ReadLine();

    Console.Write("Nueva calle: ");
    persona.CALLE = Console.ReadLine();

    Console.Write("Nuevo depto: ");
    persona.DEPTO = Console.ReadLine();

    persona.PISO = LeerEntero("Nuevo piso: ");

    Console.Write("Nueva ciudad: ");
    persona.CIUDAD = Console.ReadLine();

    Console.Write("Nuevo teléfono: ");
    persona.TELEFONO = Console.ReadLine();

    Console.Write("Nuevo email: ");
    persona.EMAIL = Console.ReadLine();

    bool resultado = negocio.Modificar(persona);

    if (resultado)
        Console.WriteLine("\nPersona modificada correctamente.");
    else
        Console.WriteLine("\nNo se encontró una persona con ese DNI.");
}




void Eliminar()
{
    Console.Clear();

    Console.WriteLine("===== ELIMINAR PERSONA =====");

    int dni = LeerEntero("DNI de la persona a eliminar: ");

    bool resultado = negocio.Eliminar(dni);

    if (resultado)
        Console.WriteLine("\nPersona eliminada correctamente.");
    else
        Console.WriteLine("\nNo se encontró una persona con ese DNI.");
}