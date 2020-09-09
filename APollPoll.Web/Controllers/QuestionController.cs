using APollPoll.Services.Questions.Models;
using APollPoll.Services.Questions.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace APollPoll.Web.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _service;
        public QuestionController(IQuestionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var questions = await _service.GetAllAsync();
            return View(questions);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(QuestionCreate model)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            if (await _service.CreateAsync(model))
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("Save Failed", "Could not save the question.");
            return View(ModelState);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();

            var detail = await _service.GetByIdAsync(id.Value);

            if (detail is null)
                return HttpNotFound();

            return View(detail);
        }
    }
}