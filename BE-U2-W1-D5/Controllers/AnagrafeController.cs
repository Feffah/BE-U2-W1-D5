using Microsoft.AspNetCore.Mvc;
using BE_U2_W1_D5.Services;
using BE_U2_W1_D5.Models.Entity;
namespace BE_U2_W1_D5.Controllers
{
    public class AnagrafeController : Controller
    {
        private readonly AnagraficaService _anagraficaService;
        public AnagrafeController(AnagraficaService anagraficaService)
        {
            _anagraficaService = anagraficaService;
        }
        public IActionResult Index()
        {
            var ListaAnagrafica = _anagraficaService.GetAll();
            return View(ListaAnagrafica);
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Anagrafica anagrafica)
        {
            var isSaved = _anagraficaService.SaveAnagrafica(anagrafica);
            return RedirectToAction("Index");
        }   
        public IActionResult Update(int Id)
        {
            var anagrafica = _anagraficaService.GetAnagraficaByID(Id);
            return View(anagrafica);
        }

        [HttpPost]
        public IActionResult Update(Anagrafica anagrafica) {
            if (anagrafica.IDAnagrafica == null)
                return BadRequest("ID non valido.");


            var anagrafeFromDb = _anagraficaService.GetAnagraficaByID(anagrafica.IDAnagrafica);
            if (anagrafeFromDb == null)
                return NotFound();


            anagrafeFromDb.Cognome = anagrafica.Cognome;
            anagrafeFromDb.Nome = anagrafica.Nome;
            anagrafeFromDb.Indirizzo = anagrafica.Indirizzo;
            anagrafeFromDb.Citta = anagrafica.Citta;
            anagrafeFromDb.CAP = anagrafica.CAP;
            anagrafeFromDb.CodiceFiscale = anagrafica.CodiceFiscale;
            _anagraficaService.UpdateAnagrafica(anagrafeFromDb);

            return RedirectToAction("Index");

        }

        [HttpPost]

        public IActionResult Delete(int Id)
        {
            var isDeleted = _anagraficaService.DeleteAnagrafica(Id);
            return RedirectToAction("Index");
        }


    }
}

