﻿using System;
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
                if (conexionDB.Execute("INSERT into Persona(nombre, apellido, cedula) values(@nombre, @apellido, @cedula)", persona) > 0)
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
                return conexionDB.QueryFirstOrDefault<PersonaModel>("SELECT * FROM Persona WHERE Id = @Id", new { Id = id });
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

        public bool remove(PersonaModel persona)
        {
            try
            {
                if (conexionDB.Execute("DELETE * FROM Persona WHERE Id = @id", persona.Id) > 0)
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
                if (conexionDB.Execute("UPDATE Persona set nombre = @nombre, apellido = @apellido, cedula = @cedula where Id = @id)", persona.Id) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
