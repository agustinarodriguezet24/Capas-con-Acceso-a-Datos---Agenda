using System;
using System.Collections.Generic;
using Agenda.Datos;
using Agenda.Entidades;

namespace Agenda.Negocio
{
    public class PersonaNegocio
    {
        private PersonaDatos datos = new PersonaDatos();

        public bool Agregar(Persona persona)
        {
            if (persona == null)
                return false;

            if (persona.DNI <= 0)
                throw new Exception("El DNI debe ser mayor a 0.");

            if (string.IsNullOrWhiteSpace(persona.APELLIDO))
                throw new Exception("El apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(persona.NOMBRES))
                throw new Exception("El nombre es obligatorio.");

            return datos.Agregar(persona);
        }

        public List<Persona> Buscar(string campo, string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return new List<Persona>();

            return datos.Buscar(campo, valor);
        }

        public bool Modificar(Persona persona)
        {
            if (persona == null)
                return false;

            if (persona.DNI <= 0)
                throw new Exception("El DNI debe ser mayor a 0.");

            if (string.IsNullOrWhiteSpace(persona.APELLIDO))
                throw new Exception("El apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(persona.NOMBRES))
                throw new Exception("El nombre es obligatorio.");

            return datos.Modificar(persona);
        }

        public bool Eliminar(int dni)
        {
            if (dni <= 0)
                return false;

            return datos.Eliminar(dni);
        }
    }
}