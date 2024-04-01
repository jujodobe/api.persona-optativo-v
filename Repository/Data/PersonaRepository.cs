using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Repository.Data
{
    public class PersonaRepository : IPersona
    {
        private IDbConnection conexionDB;
        public PersonaRepository(string _connectionString)
        {
            conexionDB = new DbConection(_connectionString).dbConnection();
        }
        public bool add(PersonaModel persona)
        {
            try
            {
                if (conexionDB.Execute("Insert into Persona(nombre, apellido, cedula) values(@nombre, @apellido, @cedula)", persona) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public PersonaModel get(PersonaModel persona)
        {
            try
            {
                var query = "SELECT nombre, apellido, cedula FROM Persona WHERE id = @id";
                var resultado = conexionDB.QueryFirstOrDefault<PersonaModel>(query, new { Id = persona.Id });
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool remove(PersonaModel persona)
        {
            try
            {
                if (conexionDB.Execute("DELETE FROM Persona WHERE id = @id)", persona.Id) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(PersonaModel persona)
        {
            try
            {
                if (conexionDB.Execute("UPDATE Persona SET nombre = @nombre, apellido = @apellido, cedula = @cedula WHERE id = @id)", persona.Id) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<PersonaModel> list()
        {
            try
            {
                return conexionDB.Query<PersonaModel>("SELECT * FROM Persona");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


