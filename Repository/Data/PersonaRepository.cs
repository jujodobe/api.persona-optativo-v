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
                if(conexionDB.Execute("Insert into Persona(nombre, apellido, cedula) values(@nombre, @apellido, @cedula)", persona) > 0)

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
                if (conexionDB.Execute("UPDATE Persona SET " +
                    "nombre=@nombre, " +
                    "apellido=@apellido," +
                    $"cedula=@cedula where id_persona = {persona.Id}" , persona) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool remove(int id)
        {
            try
            {
                if (conexionDB.Execute("Delete from persona where id_persona = 1")>0)
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
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<PersonaModel> list()
        {
            throw new NotImplementedException();
        }
             
    }
}
