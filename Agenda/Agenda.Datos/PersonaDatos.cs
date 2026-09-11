using System;
using System.Collections.Generic;
using Agenda.Entidades;
using MySql.Data.MySqlClient;

namespace Agenda.Datos
{
    public class PersonaDatos
    {
        private string conexion =
            "Server=localhost;Database=agenda;Uid=root;Pwd=;";

        
        public bool Agregar(Persona persona)
        {
            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = @"INSERT INTO personas
                (DNI, APELLIDO, NOMBRES, CALLE, DEPTO, PISO, CIUDAD, TELEFONO, EMAIL)
                VALUES
                (@DNI, @APELLIDO, @NOMBRES, @CALLE, @DEPTO, @PISO, @CIUDAD, @TELEFONO, @EMAIL)";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@DNI", persona.DNI);
                    cmd.Parameters.AddWithValue("@APELLIDO", persona.APELLIDO);
                    cmd.Parameters.AddWithValue("@NOMBRES", persona.NOMBRES);
                    cmd.Parameters.AddWithValue("@CALLE", persona.CALLE);
                    cmd.Parameters.AddWithValue("@DEPTO", persona.DEPTO);
                    cmd.Parameters.AddWithValue("@PISO", persona.PISO);
                    cmd.Parameters.AddWithValue("@CIUDAD", persona.CIUDAD);
                    cmd.Parameters.AddWithValue("@TELEFONO", persona.TELEFONO);
                    cmd.Parameters.AddWithValue("@EMAIL", persona.EMAIL);

                    int filas = cmd.ExecuteNonQuery();

                    return filas > 0;
                }
            }
        }

        
        public List<Persona> Buscar(string campo, string valor)
        {
            List<Persona> personas = new List<Persona>();

            string[] camposPermitidos =
            {
                "DNI",
                "APELLIDO",
                "NOMBRES",
                "CALLE"
            };

            if (Array.IndexOf(camposPermitidos, campo) == -1)
                throw new Exception("Campo de búsqueda no permitido.");

            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = $"SELECT * FROM personas WHERE {campo} LIKE @valor";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@valor", "%" + valor + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Persona persona = new Persona();

                            persona.DNI = Convert.ToInt32(reader["DNI"]);
                            persona.APELLIDO = reader["APELLIDO"].ToString();
                            persona.NOMBRES = reader["NOMBRES"].ToString();
                            persona.CALLE = reader["CALLE"].ToString();
                            persona.DEPTO = reader["DEPTO"].ToString();
                            persona.PISO = Convert.ToInt32(reader["PISO"]);
                            persona.CIUDAD = reader["CIUDAD"].ToString();
                            persona.TELEFONO = reader["TELEFONO"].ToString();
                            persona.EMAIL = reader["EMAIL"].ToString();

                            personas.Add(persona);
                        }
                    }
                }
            }

            return personas;
        }

        
        public bool Modificar(Persona persona)
        {
            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = @"UPDATE personas SET
                    APELLIDO = @APELLIDO,
                    NOMBRES = @NOMBRES,
                    CALLE = @CALLE,
                    DEPTO = @DEPTO,
                    PISO = @PISO,
                    CIUDAD = @CIUDAD,
                    TELEFONO = @TELEFONO,
                    EMAIL = @EMAIL
                    WHERE DNI = @DNI";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@DNI", persona.DNI);
                    cmd.Parameters.AddWithValue("@APELLIDO", persona.APELLIDO);
                    cmd.Parameters.AddWithValue("@NOMBRES", persona.NOMBRES);
                    cmd.Parameters.AddWithValue("@CALLE", persona.CALLE);
                    cmd.Parameters.AddWithValue("@DEPTO", persona.DEPTO);
                    cmd.Parameters.AddWithValue("@PISO", persona.PISO);
                    cmd.Parameters.AddWithValue("@CIUDAD", persona.CIUDAD);
                    cmd.Parameters.AddWithValue("@TELEFONO", persona.TELEFONO);
                    cmd.Parameters.AddWithValue("@EMAIL", persona.EMAIL);

                    int filas = cmd.ExecuteNonQuery();

                    return filas > 0;
                }
            }
        }

        
        public bool Eliminar(int dni)
        {
            using (MySqlConnection cn = new MySqlConnection(conexion))
            {
                cn.Open();

                string sql = "DELETE FROM personas WHERE DNI = @DNI";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@DNI", dni);

                    int filas = cmd.ExecuteNonQuery();

                    return filas > 0;
                }
            }
        }
    }
}