using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class PersonaService
    {
        PersonaRepository personaRepository;

        public PersonaService(string connectionString)
        {
            personaRepository = new PersonaRepository(connectionString);
        }

        public bool add(PersonaModel modelo)
        {
            if (validacionPersona(modelo))
                return personaRepository.add(modelo);
            else
                return false;
        }

        private bool validacionPersona(PersonaModel persona)
        {
            if (persona == null)
                return false;
            if (string.IsNullOrEmpty(persona.nombre))
                return false;
            return true;
        }
    }
}