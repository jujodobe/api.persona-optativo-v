using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public interface IPersona
    {
        bool add(PersonaModel personaModel);
        String remove(PersonaModel personaModel);
        String update(PersonaModel personaModel);
        PersonaModel get(PersonaModel personaModel);
        IEnumerable<PersonaModel> list();
    }
}
