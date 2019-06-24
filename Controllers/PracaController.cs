using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControlePracas.DAL;
using ControlePracas.Models;

namespace ControlePracas.Controllers
{
    public class PracaController : Controller
    {
        private PracaContext db = new PracaContext();

        // GET: Praca
        public ActionResult Index()
        {
            

            return View(db.Pracas.ToList());
        }

        // GET: Praca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Praca praca = db.Pracas.Find(id);
            if (praca == null)
            {
                return HttpNotFound();
            }
            return View(praca);
        }

        // GET: Praca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Praca/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Sigla,UF")] Praca praca)
        {
           
            try {

                if (ModelState.IsValid)
                {
                    //Verifica se ja existe praça e UF iguais
                    if(!db.Pracas.Any(o=> o.Nome == praca.Nome && o.UF == praca.UF)) { 
                        db.Pracas.Add(praca);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Praça ja cadastrada");
                    }
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Erro na hora de salvar");
            }
            

            return View(praca);
        }

        // GET: Praca/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Praca praca = db.Pracas.Find(id);
            if (praca == null)
            {
                return HttpNotFound();
            }
            return View(praca);
        }

        // POST: Praca/Edit/5

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pracaToUpdate = db.Pracas.Find(id);
            if (TryUpdateModel(pracaToUpdate, "",
               new string[] { "Nome", "Sigla", "UF" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException)
                {

                    ModelState.AddModelError("", "Erro na hora de salvar");
                }
            }
            return View(pracaToUpdate);
        }
    

    // GET: Praca/Delete/5
    public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Praca praca = db.Pracas.Find(id);
            if (praca == null)
            {
                return HttpNotFound();
            }
            return View(praca);
        }

        // POST: Praca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (db.Pracas.Count() > 5)
            {
                Praca praca = db.Pracas.Find(id);
                db.Pracas.Remove(praca);
                db.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("", "Numero de praças menor que 5");
            }
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
