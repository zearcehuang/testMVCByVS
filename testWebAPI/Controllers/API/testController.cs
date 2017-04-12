using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testWebAPI.Models;
using testWebAPI.Models.Repositorys;

namespace testWebAPI.Controllers.API
{
    public class testController : ApiController
    {
        private DT311_ACode_Repository _codeDataRepository = new DT311_ACode_Repository();

        // GET: api/test
        public IQueryable<DT311_ACode> Get()
        {
            //return new string[] { "value1", "value2" };
            return _codeDataRepository.GetCodeData();
        }

        // GET: api/test/{CODE_TYPE}/{CODE}
        /// <summary>
        /// 取得單項代碼資料
        /// </summary>
        /// <param name="CODE_TYPE">代碼類別</param>
        /// <param name="CODE">代碼</param>
        /// <returns></returns>
        [Route("api/test/{CODE_TYPE}/{CODE}")]
        public IQueryable<DT311_ACode> Get(string CODE_TYPE, string CODE)
        {
            IQueryable<DT311_ACode> Acode = _codeDataRepository.GetByKey(CODE_TYPE, CODE);

            if (Acode == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Acode;
        }

        /// <summary>
        /// 取得單代碼類別資料
        /// </summary>
        /// <param name="CODE_TYPE">代碼類別</param>
        /// <returns></returns>
        [Route("api/test/{CODE_TYPE}")]
        public IEnumerable<DT311_ACode> Get(string CODE_TYPE)
        {
            IQueryable<DT311_ACode> Acode = _codeDataRepository.GetByKey(CODE_TYPE);

            if (Acode == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Acode.OrderBy(x => x.CODE_TYPE).ThenBy(x => x.CODE_SEQ.Value)
                .ToList().Select(x => new DT311_ACode
                {
                    CODE_SEQ = x.CODE_SEQ
                    ,
                    CODE_TYPE = x.CODE_TYPE
                    ,
                    CODE = x.CODE
                    ,
                    CODE_NAME = x.CODE_NAME
                });
        }

        // POST: api/test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/test/5
        public void Delete(int id)
        {
        }
    }
}
