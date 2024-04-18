using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public interface IPersona
    {
        bool add(PersonaModel persona);
        bool remove(int id);
        bool update(PersonaModel persona);
        PersonaModel get(int id);
        IEnumerable<PersonaModel> list();
    }
}
