using System;
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

            var codeDataQry = (from c in db.DT311_ACode.AsQueryable()
                               select new
                               {
                                   CODE_TYPE_Name = c.CODE_TYPE == "D"
                                       ? "請假事由"
                                       : c.CODE_TYPE == "O"
                                           ? "加班事由"
                                           : c.CODE_TYPE == "R"
                                               ? "出差事由"
                                               : c.CODE_TYPE == "L"
                                                   ? "出差地點"
                                                   : c.CODE_TYPE == "A"
                                                       ? "出國前往地區"
                                                       : c.CODE_TYPE == "F"
                                                           ? "未刷卡趕辦內容"
                                                           : c.CODE_TYPE == "P" ? "公假/公出地點" : "",
                                   c.CODE,
                                   c.CODE_TYPE,
                                   c.CODE_NAME,
                                   c.CODE_SEQ
                               }).OrderBy(x => x.CODE_TYPE).ThenBy(d => d.CODE_SEQ.Value).ToList()
                                .Select(x => new CodeData()
                                {
                                    Code_Type = x.CODE_TYPE,
                                    Code_Type_Name = x.CODE_TYPE_Name,
                                    Code = x.CODE,
                                    Code_Name = x.CODE_NAME,
                                    Code_Seq = x.CODE_SEQ
                                });

            List<CodeData> lst = new List<CodeData>();        //為了接收自定查詢欄位用，使用一個model接收然後在前端呈現
            lst.AddRange(codeDataQry);

            return View(lst);
            //return View(db.DT311_ACode.ToList());     //測試回傳整個ETF物件用
        }

        /// <summary>
        /// 明細
        /// 備註：get的route可不設，如果要設，則有post也須設定，才不會找不到相同預設路徑
        /// 備註：Entity宣告的名稱不可與該Entity欄位名稱一樣，否則會導致Entity binding錯誤
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

            getCodeTypeDDL(code.CODE_TYPE);     //取得下拉選單

            //return View(code);                   //回傳包含主頁及該頁的view
            //return PartialView(code);           //回傳該頁的view
            if (Request.IsAjaxRequest())
            {   //視窗頁
                return PartialView("_Edit", code);
            }
            else
            {       //包含主頁
                return View(code);
            }
            //return Content(id + "/" + CodeType);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Route("CodeData/Edit/{id}/{codetype}")]
        public ActionResult Edit(string id, string codeType, DT311_ACode Acode)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                                .Select(x => new { x.Key, x.Value.Errors })
                                .ToArray();

            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (string.IsNullOrEmpty(codeType))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //此方法好像存檔太快會一直跳出要等非同步資料完成
            //var _orginCode = (from p in db.DT311_ACode.AsQueryable()
            //                  where p.CODE == codeType
            //                        && p.CODE == id
            //                  select p).FirstOrDefaultAsync();

            var _orginCode = db.DT311_ACode.AsQueryable().Where(a => a.CODE_TYPE == codeType && a.CODE == id);

            //以下方式儲存會失敗，似乎即時查詢追蹤導致錯誤

            //var _orginCode = db.DT311_ACode.Find(codeType, id);

            if (ModelState.IsValid && TryUpdateModel(_orginCode, new string[] { "CODE_NAME", "CODE_SEQ" }))
            {
                try
                {
                    db.Entry(Acode).State = EntityState.Modified;
                    int intSuccess = db.SaveChanges();
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "儲存失敗" + Environment.NewLine + e.ToString());
                    return Json(new { success = false, MessageAlert = "儲存失敗!" + Environment.NewLine + e.ToString() });
                }
                getCodeTypeDDL();
                //return View(Acode);
                return Json(new { success = true, MessageAlert = "儲存成功!" });
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
                                strError.AppendLine(!string.IsNullOrEmpty(erroritem.ErrorMessage.ToString())
                                    ? erroritem.ErrorMessage.ToString()
                                    : erroritem.Exception.ToString());
                            }
                        }
                    }
                }

                ModelState.AddModelError("Edit", "ErrorMessage" + Environment.NewLine + strError.ToString().Trim());

                //return Content(strError.ToString().Trim());
                return Json(new { success = false, MessageAlert = "儲存失敗!" + Environment.NewLine + strError.ToString().Trim() });
            }

        }

        /// <summary>
        /// 新增頁
        /// </summary>
        /// <returns></returns>
        [Route("CodeData/AddCode/")]
        public ActionResult AddCode()
        {
            getCodeTypeDDL();     //取得下拉選單

            if (Request.IsAjaxRequest())
            {   //視窗頁
                return PartialView("_AddCode");
            }
            else
            {       //包含主頁
                return View();
            }

        }

        /// <summary>
        /// 新增頁儲存
        /// </summary>
        /// <param name="Acode"></param>
        /// <returns></returns>
        [HttpPost, ActionName("AddCode")]
        [ValidateAntiForgeryToken]
        [Route("CodeData/AddCode/")]
        public ActionResult AddCode(DT311_ACode Acode)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                                .Select(x => new { x.Key, x.Value.Errors })
                                .ToArray();
            
            try
            {
                var _orginCode = db.DT311_ACode.AsQueryable().Where(a => a.CODE_TYPE == Acode.CODE_TYPE && a.CODE == Acode.CODE);
                getCodeTypeDDL();

                if (_orginCode.Count() > 0)
                    return Json(new { success = false, MessageAlert = "儲存失敗!" + Environment.NewLine + "已有該代碼資料!" });

                if (ModelState.IsValid)
                {
                    db.DT311_ACode.Add(Acode);
                    db.SaveChanges();
                    //return RedirectToAction("QueryWebGrid");

                    return Json(new { success = true, MessageAlert = "儲存成功!" });
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
                                    strError.AppendLine(!string.IsNullOrEmpty(erroritem.ErrorMessage.ToString())
                                    ? erroritem.ErrorMessage.ToString()
                                    : erroritem.Exception.ToString());
                                }
                            }
                        }
                    }

                    ModelState.AddModelError("Add", "新增失敗" + Environment.NewLine + strError.ToString());
                    return Json(new { success = false, MessageAlert = "新增失敗!" + Environment.NewLine + strError.ToString() });
                }
            }


            catch (Exception e)
            {
                ModelState.AddModelError("", "新增失敗" + Environment.NewLine + e.ToString());
                return Json(new { success = false, MessageAlert = "新增失敗!" + Environment.NewLine + e.ToString() });
            }


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