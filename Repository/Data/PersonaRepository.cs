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

        public PersonaModel get(PersonaModel personaModel)
        {
            try
            {
                var query = "SELECT * FROM Persona WHERE Id = @Id";
                var persona = conexionDB.QueryFirstOrDefault<PersonaModel>(query, new { personaModel.Id });
                return persona;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);   
            }
        }

        public IEnumerable<PersonaModel> list()
        {
            try
            {
                return conexionDB.Query<PersonaModel>("SELECT * FROM Persona");
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);   
            }
        }

        public String remove(PersonaModel personaModel)
        {
            try
            {
                var query = "DELETE FROM Persona WHERE Id = @Id";
                int result = conexionDB.Execute(query, new { personaModel.Id });
                if (result > 0)
                {
                    return "Registro eliminado";
                }
                else
                {
                    return "Error al eliminar";
                }
            }catch(Exception ex){
                throw new Exception (ex.Message);
            }
        }

        public String update(PersonaModel personaModel)
        {
            try
            {
                var query = "UPDATE Persona set Id WHERE Id = @Id";
                int result = conexionDB.Execute(query, new { Id = personaModel.Id });
                if (result > 0)
                {
                    return "Registro actualizado";
                }
                else
                {
                    return "Error al actualizar";
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
