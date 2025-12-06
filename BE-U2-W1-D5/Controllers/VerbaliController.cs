using BE_U2_W1_D5.Models.Entity;
using BE_U2_W1_D5.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE_U2_W1_D5.Controllers
{
    public class VerbaliController : Controller
    {
        private readonly VerbaleService _verbaleService;
        private readonly AnagraficaService _anagraficaService;
        public VerbaliController(VerbaleService verbaleService, AnagraficaService anagraficaService)
        {
            _verbaleService = verbaleService;
            _anagraficaService = anagraficaService;
        }
        public IActionResult Index()
        {
            var ListaVerbali = _verbaleService.GetAll();
            var ListaAnagrafiche = _anagraficaService.GetAll();
            ViewBag.Verbali = ListaVerbali;
            ViewBag.Anagrafiche = ListaAnagrafiche;
            return View();
        }

        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Verbale verbale)
        {
            var isSaved = _verbaleService.SaveVerbale(verbale);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int Id)
        {
            var verbale = _verbaleService.GetVerbaleByID(Id);
            return View(verbale);
        }

        [HttpPost]
        public IActionResult Update(Verbale verbale)
        {
            if (verbale.IDVerbale == null)
                return BadRequest("ID non valido.");


            var verbaleFromDb = _verbaleService.GetVerbaleByID(verbale.IDVerbale);
            if (verbaleFromDb == null)
                return NotFound();


            verbaleFromDb.DataViolazione = verbale.DataViolazione;
            verbaleFromDb.IndirizzoViolazione = verbale.IndirizzoViolazione;
            verbaleFromDb.NominativoAgente = verbale.NominativoAgente;
            verbaleFromDb.DataTrascrizioneVerbale = verbale.DataTrascrizioneVerbale;
            verbaleFromDb.Importo = verbale.Importo;
            verbaleFromDb.DecurtamentoPunti = verbale.DecurtamentoPunti;
            _verbaleService.UpdateVerbale(verbaleFromDb);

            return RedirectToAction("Index");

        }

        [HttpPost]

        public IActionResult Delete(int Id)
        {
            var isDeleted = _verbaleService.DeleteVerbale(Id);
            return RedirectToAction("Index");
        }

    }
}
