using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using testMVC.Models;

namespace testMVC.Controllers
{
    public class CodeDataController : Controller
    {

        private TPDBtestEntities db = new TPDBtestEntities();
        /// <summary>
        /// GET: CodeData/Random
        /// </summary>
        /// <returns></returns>
        public ActionResult Random()
        {
            return View(db.DT311_ACode.ToList());
        }

        /// <summary>
        /// 明細
        /// </summary>
        /// <param name="id"></param>
        /// <param name="codeType"></param>
        /// <returns></returns>
        [Route("CodeData/Edit/{id}/{codetype}")]
        public ActionResult Edit(string id, string codeType)
        {
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (string.IsNullOrEmpty(codeType))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            DT311_ACode code = db.DT311_ACode.Find(codeType, id);
            if (code == null)
            {
                return HttpNotFound();
            }

            return View(code);
            //return Content(id + "/" + CodeType);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Route("CodeData/Edit/{id}/{codetype}")]
        public ActionResult Edit([Bind(Include = "CODE_TYPE,CODE,CODE_NAME, CODE_SEQ:int")]DT311_ACode code)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                                .Select(x => new { x.Key, x.Value.Errors })
                                .ToArray();

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(code).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Random");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "儲存失敗" + Environment.NewLine + e.ToString());
                }
            }

            return View(code);
        }


    }
}