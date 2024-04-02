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
        public bool update(PersonaModel persona int id)
        {
            try
            {
                if (conexionDB.Execute("UPDATE Persona SET " +
                    "nombre=@nombre, " +
                    "apellido=@apellido," +
                    $"cedula=@cedula) where id_persona = {id}", persona) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                public PersonaModel get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonaModel> list()
        {
            throw new NotImplementedException();
        }

        public bool remove(PersonaModel persona)
        {
            throw new NotImplementedException();
        }

        public bool update(PersonaModel persona)
        {
            throw new NotImplementedException();
        }
    }
}
