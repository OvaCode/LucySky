using System;
using System.Collections.Generic;
using LucySkyAdmin.Models.AdminViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LucySkyAdmin.Controllers
{
    [Authorize]
    public class AdminController: Controller
    {
        private INerAnalyzer _analyzer;

        public AdminController()
        {
            _analyzer = new NerAnalyzer();
            //_analyzer = new NerFakeAnalyzer();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddSentence()
        {
            SentenceViewModel model = new SentenceViewModel();

            var m = model;

            return View(model);
            // here is the change
        }

        [HttpPost]
        public ActionResult AddSentence(SentenceViewModel model)
        {
            model.Entities = _analyzer.Analyze(model.Sentence);

            foreach(NerEntity ent in model.Entities)
            {
                DateTimeTranslator translator = new DateTimeTranslator();

                if(ent.Class == "@date")
                {
                    ent.Value = translator.Translate(ent.Value);
                }
            }

            return View(model);
        }
    }
}
