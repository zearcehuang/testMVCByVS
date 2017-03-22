﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
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
        /// GET: CodeData/QueryWebGrid
        /// </summary>
        /// <returns></returns>
        public ActionResult QueryWebGrid()
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

            getCodeTypeDDL(code.CODE_TYPE);

            return View(code);
            //return Content(id + "/" + CodeType);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //[Route("CodeData/Edit/{id}/{codetype}")]
        //public ActionResult Edit([Bind(Include = "CODE_TYPE,CODE,CODE_NAME, CODE_SEQ")]DT311_ACode code)
        //{
        //    var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
        //                        .Select(x => new { x.Key, x.Value.Errors })
        //                        .ToArray();

        //    if (ModelState.IsValid && TryUpdateModel(code))
        //    {
        //        try
        //        {
        //            db.Entry(code).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Random");
        //        }
        //        catch (Exception e)
        //        {
        //            ModelState.AddModelError("", "儲存失敗" + Environment.NewLine + e.ToString());
        //        }
        //        return View(code);
        //    }
        //    else
        //    {
        //        StringBuilder strError = new StringBuilder();
        //        strError.Length = 0;
        //        if (errors.Length > 0)
        //        {
        //            foreach (var error in errors)
        //            {
        //                if (error.Errors.Count > 0)
        //                {
        //                    foreach (var erroritem in error.Errors)
        //                    {
        //                        strError.AppendLine(erroritem.Exception.ToString());
        //                    }
        //                }
        //            }
        //        }

        //        ModelState.AddModelError("Edit", "ErrorMessage");

        //        return Content(strError.ToString().Trim());
        //    }

        //}


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Route("CodeData/Edit/{id}/{codetype}")]
        public ActionResult Edit(string id, string codeType, [Bind(Include = "CODE_NAME, CODE_SEQ")] DT311_ACode code)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                                .Select(x => new { x.Key, x.Value.Errors })
                                .ToArray();

            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (string.IsNullOrEmpty(codeType))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //var _orginCode = (from p in db.DT311_ACode
            //                  where p.CODE == codeType
            //                        && p.CODE == id
            //                  select p).FirstOrDefaultAsync();
            var _orginCode = db.DT311_ACode.Find(codeType, id);

            if (ModelState.IsValid && TryUpdateModel(_orginCode, new string[] { "CODE_NAME", "CODE_SEQ" }))
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
                return View(code);
            }
            else
            {
                StringBuilder strError = new StringBuilder();
                strError.Length = 0;
                if (errors.Length > 0)
                {
                    foreach (var error in errors)
                    {
                        if (error.Errors.Count > 0)
                        {
                            foreach (var erroritem in error.Errors)
                            {
                                strError.AppendLine(erroritem.Exception.ToString());
                            }
                        }
                    }
                }

                ModelState.AddModelError("Edit", "ErrorMessage");

                return Content(strError.ToString().Trim());
            }

        }

        [Route("CodeData/AddCode/")]
        public ActionResult AddCode()
        {
            getCodeTypeDDL();

            return View();
        }


        [HttpPost, ActionName("AddCode")]
        [ValidateAntiForgeryToken]
        [Route("CodeData/AddCode/")]
        public ActionResult AddCode([Bind(Include = "CODE_TYPE,CODE,CODE_NAME, CODE_SEQ")] DT311_ACode code)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                                .Select(x => new { x.Key, x.Value.Errors })
                                .ToArray();

            try
            {
                if (ModelState.IsValid)
                {
                    db.DT311_ACode.Add(code);
                    db.SaveChanges();
                    return RedirectToAction("QueryWebGrid");
                }
                else
                {
                    StringBuilder strError = new StringBuilder();
                    strError.Length = 0;
                    if (errors.Length > 0)
                    {
                        foreach (var error in errors)
                        {
                            if (error.Errors.Count > 0)
                            {
                                foreach (var erroritem in error.Errors)
                                {
                                    strError.Append(erroritem.Exception.ToString() + "\n");
                                }
                            }
                        }
                    }

                    ModelState.AddModelError("Add", "新增失敗" + Environment.NewLine + strError.ToString());
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "新增失敗" + Environment.NewLine + e.ToString());
            }

            return View(code);
        }

        /// <summary>
        /// 代碼類別下拉選單
        /// </summary>
        public void getCodeTypeDDL(string codeType = "")
        {
            var CodeType = new List<CodeType> {
                new CodeType {codeType="D",codeTypeName="請假事由" }
                ,new CodeType {codeType="O",codeTypeName="加班事由" }
                ,new CodeType {codeType="R",codeTypeName="出差事由" }
                ,new CodeType {codeType="L",codeTypeName="出差地點" }
                ,new CodeType {codeType="A",codeTypeName="出國前往地區" }
                ,new CodeType {codeType="F",codeTypeName="未刷卡趕辦內容" }
                ,new CodeType {codeType="P",codeTypeName="公假/公出地點" }
            };

            ViewBag.lstCodeType = new SelectList(
                        items: CodeType
                        , dataTextField: "codeTypeName"
                        , dataValueField: "codeType"
                        , selectedValue: (string.IsNullOrEmpty(codeType) ? "" : codeType)
                );

        }

    }
}