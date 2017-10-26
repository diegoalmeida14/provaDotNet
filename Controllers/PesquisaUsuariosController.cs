using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class PesquisaUsuariosController : Controller
    {
        private PesquisaModels db = new PesquisaModels();

        // GET: PesquisaUsuarios
        public async Task<ActionResult> Index()
        {
            return View(await db.PesquisaUsuario.ToListAsync());
        }

        // GET: PesquisaUsuarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesquisaUsuario pesquisaUsuario = await db.PesquisaUsuario.FindAsync(id);
            if (pesquisaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(pesquisaUsuario);
        }

        // GET: PesquisaUsuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PesquisaUsuarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nome,nota")] PesquisaUsuario pesquisaUsuario)
        {
            if (ModelState.IsValid)
            {
                db.PesquisaUsuario.Add(pesquisaUsuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pesquisaUsuario);
        }

        // GET: PesquisaUsuarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesquisaUsuario pesquisaUsuario = await db.PesquisaUsuario.FindAsync(id);
            if (pesquisaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(pesquisaUsuario);
        }

        // POST: PesquisaUsuarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nome,nota")] PesquisaUsuario pesquisaUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pesquisaUsuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pesquisaUsuario);
        }

        // GET: PesquisaUsuarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesquisaUsuario pesquisaUsuario = await db.PesquisaUsuario.FindAsync(id);
            if (pesquisaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(pesquisaUsuario);
        }

        // POST: PesquisaUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PesquisaUsuario pesquisaUsuario = await db.PesquisaUsuario.FindAsync(id);
            db.PesquisaUsuario.Remove(pesquisaUsuario);
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
