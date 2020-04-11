using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDatatransactionBD;

namespace MVCDatatransactionWEB.Controllers
{
    public class TransaccionsController : Controller
    {
        private MVCDatatransactionEntities db = new MVCDatatransactionEntities();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetData()
        {
            List<Transaccion> Crud = db.Transaccion.ToList();
            return Json(new { data = Crud }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Json Para Guardar los Registros en la tabla
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public JsonResult PostData(Transaccion data)
        {
            string Respuesta = string.Empty;
            if (data.tra_id > 0)
            {
                Transaccion datTransaccion = new Transaccion();
                if (ModelState.IsValid)
                {
                    datTransaccion = data;
                    db.Entry(datTransaccion).State = EntityState.Modified;
                    db.SaveChanges();
                    Respuesta = "success";
                }
                else
                {
                    Respuesta = "Debe registrar información";
                }
            }
            else
            {
                Transaccion datTransaccion = new Transaccion();
                if (ModelState.IsValid)
                {
                    datTransaccion = data;
                    db.Transaccion.Add(datTransaccion);
                    db.SaveChanges();
                    Respuesta = "success";
                }
                else
                {
                    Respuesta = "Debe registrar información";
                }

            }



            return Json(Respuesta, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        ///Json para eliminar registros
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteRow(int id)
        {
            Transaccion transaccion = db.Transaccion.Find(id);
            db.Transaccion.Remove(transaccion);
            db.SaveChanges();
            return Json("success", JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetEdit(int id)
        {

            Transaccion transaccion = db.Transaccion.Find(id);
            return Json(transaccion, JsonRequestBehavior.AllowGet);
        }



        // GET: Transaccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // GET: Transaccions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tra_id,tra_accountnumber,tra_beneficiaryname,tra_bankname,tra_SWIFTCode,tra_amount,tra_datetime")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Transaccion.Add(transaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transaccion);
        }

        // GET: Transaccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: Transaccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tra_id,tra_accountnumber,tra_beneficiaryname,tra_bankname,tra_SWIFTCode,tra_amount,tra_datetime")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaccion);
        }

        // GET: Transaccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: Transaccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaccion transaccion = db.Transaccion.Find(id);
            db.Transaccion.Remove(transaccion);
            db.SaveChanges();
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
