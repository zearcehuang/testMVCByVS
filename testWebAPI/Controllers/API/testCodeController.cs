using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using testWebAPI.Models;
using testWebAPI.Models.Repositorys;

namespace testWebAPI.Controllers.API
{
    public class testCodeController : ApiController
    {
        private TPDBtestEntities db = new TPDBtestEntities();
        private IDT311_ACode_Repository _codeDataRepository;

        //使用autofac DI設定
        //testCodeController()
        //{
        //    _codeDataRepository = new DT311_ACode_Repository();
        //}

        public testCodeController(IDT311_ACode_Repository r)
        {
            this._codeDataRepository = r;
        }


        // GET: api/testCode
        /// <summary>
        /// 全部查詢結果
        /// </summary>
        /// <returns></returns>
        public IQueryable<DT311_ACode> GetAll()
        {
            //return db.DT311_ACode;
            return _codeDataRepository.GetCodeData();
        }

        // GET: api/testCode/5
        /// <summary>
        /// 單筆查詢結果
        /// </summary>
        /// <param name="CODE_TYPE"></param>
        /// <param name="CODE"></param>
        /// <returns></returns>
        [Route("api/testCode/{CODE_TYPE}/{CODE}")]
        [ResponseType(typeof(DT311_ACode))]
        public IHttpActionResult GetItem(string CODE_TYPE, string CODE)
        {
            //DT311_ACode dT311_ACode = db.DT311_ACode.Find(id);
            //if (dT311_ACode == null)
            //{
            //    return NotFound();
            //}

            //return Ok(dT311_ACode);
            IQueryable<DT311_ACode> Acode = _codeDataRepository.GetByKey(CODE_TYPE, CODE);

            if (Acode == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Ok(Acode);
        }

        // GET: api/testCode/5
        /// <summary>
        /// 單代碼類別查詢結果
        /// </summary>
        /// <param name="CODE_TYPE"></param>
        /// <returns></returns>
        [Route("api/testCode/{CODE_TYPE}")]
        [ResponseType(typeof(DT311_ACode))]
        public IHttpActionResult GetItem(string CODE_TYPE)
        {
            IQueryable<DT311_ACode> Acode = _codeDataRepository.GetByKey(CODE_TYPE);

            if (Acode == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Ok(Acode);
        }

        // PUT: api/testCode/5
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="CODE_TYPE"></param>
        /// <param name="CODE"></param>
        /// <param name="dT311_ACode"></param>
        /// <returns></returns>
        [Route("api/testCode/{CODE_TYPE}/{CODE}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDT311_ACode(string CODE_TYPE, string CODE, DT311_ACode dT311_ACode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (CODE_TYPE != dT311_ACode.CODE_TYPE && CODE != dT311_ACode.CODE)
            {
                return BadRequest();
            }

            DT311_ACode _updateACode = _codeDataRepository.GetByKey(CODE_TYPE, CODE).FirstOrDefault();

            if (_updateACode != null)
            {
                _updateACode.CODE_NAME = dT311_ACode.CODE_NAME;
                _updateACode.CODE_SEQ = dT311_ACode.CODE_SEQ;
            }

            db.Entry(_updateACode).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DT311_ACodeExists(CODE_TYPE, CODE))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/testCode
        [ResponseType(typeof(DT311_ACode))]
        public IHttpActionResult PostDT311_ACode(DT311_ACode dT311_ACode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DT311_ACode.Add(dT311_ACode);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DT311_ACodeExists(dT311_ACode.CODE_TYPE, dT311_ACode.CODE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { CODE_TYPE = dT311_ACode.CODE_TYPE, CODE = dT311_ACode.CODE }, dT311_ACode);
        }

        // DELETE: api/testCode/5
        [ResponseType(typeof(DT311_ACode))]
        public IHttpActionResult DeleteDT311_ACode(string id)
        {
            DT311_ACode dT311_ACode = db.DT311_ACode.Find(id);
            if (dT311_ACode == null)
            {
                return NotFound();
            }

            db.DT311_ACode.Remove(dT311_ACode);
            db.SaveChanges();

            return Ok(dT311_ACode);
        }

        /// <summary>
        /// 釋放資源
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 資料是否存在
        /// </summary>
        /// <param name="CODE_TYPE">代碼類別</param>
        /// <param name="CODE">代碼</param>
        /// <returns></returns>
        private bool DT311_ACodeExists(string CODE_TYPE, string CODE)
        {
            //return db.DT311_ACode.Count(e => e.CODE_TYPE == id) > 0;

            return _codeDataRepository.GetByKey(CODE_TYPE, CODE).Any();
        }
    }
}