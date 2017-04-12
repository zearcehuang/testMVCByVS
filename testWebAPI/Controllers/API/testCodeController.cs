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
        //private DT311_ACode_Repository _codeDataRepository;
        private IDT311_ACode_Repository _codeDataRepository;


        testCodeController()
        {
            _codeDataRepository = new DT311_ACode_Repository();
        }

        // GET: api/testCode
        public IQueryable<DT311_ACode> GetAll()
        {
            //return db.DT311_ACode;
            return _codeDataRepository.GetCodeData();
        }

        // GET: api/testCode/5
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
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDT311_ACode(string id, DT311_ACode dT311_ACode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dT311_ACode.CODE_TYPE)
            {
                return BadRequest();
            }

            db.Entry(dT311_ACode).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DT311_ACodeExists(id))
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
                if (DT311_ACodeExists(dT311_ACode.CODE_TYPE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dT311_ACode.CODE_TYPE }, dT311_ACode);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DT311_ACodeExists(string id)
        {
            return db.DT311_ACode.Count(e => e.CODE_TYPE == id) > 0;
        }
    }
}