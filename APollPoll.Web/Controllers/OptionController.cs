using APollPoll.Services.Options.Models;
using APollPoll.Services.Options.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace APollPoll.Web.Controllers
{
    public class OptionController : Controller
    {
        private readonly IOptionService _service;
        public OptionController(IOptionService service)
        {
            _service = service;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(OptionCreate model)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            if (await _service.CreateAsync(model))
                return RedirectToAction("Details", "Question", new { id = model.QuestionId });

            ModelState.AddModelError("Save Failed", "Could not save the answer.");
            return View(model);
        }


    }
}