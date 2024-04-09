using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Logica;

namespace api.personas.Controllers
{
    //[ApiController]
    //[Route("/Api/v1/")]
    public class PersonaController : Controller
    {
        private PersonaService personaService;
        public PersonaController(IConfiguration configuracion)
        {
            personaService = new PersonaService(configuracion.GetConnectionString("postgres"));
        }
        // GET: PersonaController/Create
        [HttpPost("Add")]
        public ActionResult Add(Repository.Data.PersonaModel persona)
        {
            personaService.add(persona);
            return Ok(new { message = $"La persona con nombre {persona.nombre} fue insertado correctamente!!!"});
        }

        // POST: PersonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
