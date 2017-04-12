using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using testWebAPI.Models;
using testWebAPI.Models.Repositorys;

namespace testWebAPI.Controllers.API
{
    /*
    WebApiConfig 類別可能需要其他變更以新增此控制器的路由，請將這些陳述式合併到 WebApiConfig 類別的 Register 方法。注意 OData URL 有區分大小寫。

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using testWebAPI.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<DT311_ACode>("CodeData");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CodeDataController : ODataController
    {
        private TPDBtestEntities db = new TPDBtestEntities();
        private DT311_ACode_Repository _codeDataRepository = new DT311_ACode_Repository();

        // GET: odata/CodeData
        public IQueryable<DT311_ACode> GetCodeData()
        {
            //return db.DT311_ACode;
            return _codeDataRepository.GetCodeData();
        }

        // GET: odata/CodeData(5)
        [EnableQuery]
        
        public IQueryable<DT311_ACode> GetItem(string CODE_TYPE, string CODE)
        {
            IQueryable<DT311_ACode> Acode = _codeDataRepository.GetByKey(CODE_TYPE, CODE);
            if (Acode == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Acode;
        }

    }
}
