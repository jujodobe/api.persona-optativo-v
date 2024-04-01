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

        public PersonaModel get(int id)
        {
            try
            {
                return conexionDB.Query<PersonaModel>("select * from Persona where id = @id", new { id }).SingleOrDefault();
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
                return conexionDB.Query<PersonaModel>("select * from Persona");
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
                return conexionDB.Execute("delete from Persona where id = @id", persona) > 0;
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
                return conexionDB.Execute("update Persona set nombre = @nombre, apellido = @apellido, cedula = @cedula where id = @id", persona) > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
