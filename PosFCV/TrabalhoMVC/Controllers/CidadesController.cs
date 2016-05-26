using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrabalhoMVC.Contexts;
using TrabalhoMVC.Models;
using Microsoft.AspNet.SignalR;
using TrabalhoMVC.Hubs;

namespace TrabalhoMVC.Controllers
{
    public class CidadesController : Controller
    {
        private Context db = new Context();

        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

        // GET: Cidades
        public async Task<ActionResult> Index()
        {
            var cidades = db.Cidades.Include(c => c.Estado);
            return View(await cidades.ToListAsync());
        }

        // GET: Cidades/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = await db.Cidades.FindAsync(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // GET: Cidades/Create
        public ActionResult Create()
        {
            ViewBag.CodigoEstado = new SelectList(db.Estados, "Codigo", "Nome");
            return View();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Codigo,Nome,CodigoEstado")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Cidades.Add(cidade);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoEstado = new SelectList(db.Estados, "Codigo", "Nome", cidade.CodigoEstado);
            return View(cidade);
        }

        // GET: Cidades/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = await db.Cidades.FindAsync(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoEstado = new SelectList(db.Estados, "Codigo", "Nome", cidade.CodigoEstado);
            return View(cidade);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Codigo,Nome,CodigoEstado")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoEstado = new SelectList(db.Estados, "Codigo", "Nome", cidade.CodigoEstado);
            return View(cidade);
        }

        // GET: Cidades/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidade cidade = await db.Cidades.FindAsync(id);
            if (cidade == null)
            {
                return HttpNotFound();
            }
            return View(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cidade cidade = await db.Cidades.FindAsync(id);
            db.Cidades.Remove(cidade);
            await db.SaveChangesAsync();
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
