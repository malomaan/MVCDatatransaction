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
        /// <summary>
        /// Muesta la plantilla principal de List y Create Update
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Obtiene los Datos para llenar el List
        /// </summary>
        /// <returns></returns>
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
        [HttpPost]
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


        /// <summary>
        /// Obtiene los datos del registro Editado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpGet]
        public ActionResult GetEdit(int id)
        {

            Transaccion transaccion = db.Transaccion.Find(id);
            return Json(transaccion, JsonRequestBehavior.AllowGet);
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
