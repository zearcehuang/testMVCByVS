using System.Data.Entity;
using System.Linq;

namespace testWebAPI.Models.Repositorys
{
    public class DT311_ACode_Repository : IDT311_ACode_Repository
    {
        protected TPDBtestEntities db;

        public DT311_ACode_Repository()
        {
            db = new TPDBtestEntities();
        }

        public IQueryable<DT311_ACode> GetCodeData()
        {
            return db.DT311_ACode.AsQueryable().OrderBy(x => x.CODE_TYPE).ThenBy(x => x.CODE_SEQ.Value);
        }

        public IQueryable<DT311_ACode> GetByKey(string CODE_TYPE = "", string CODE = "")
        {
            //return db.DT311_ACode.Find(CODE_TYPE, CODE);
            var codeDataQry = (from c in db.DT311_ACode.AsQueryable()
                               select c);

            if (!string.IsNullOrEmpty(CODE_TYPE) && CODE_TYPE.Length > 0)
                codeDataQry = codeDataQry.AsQueryable().Where(x => x.CODE_TYPE.Equals(CODE_TYPE));
            if (!string.IsNullOrEmpty(CODE) && CODE.Length > 0)
                codeDataQry = codeDataQry.AsQueryable().Where(x => x.CODE.Equals(CODE));

            return codeDataQry;
        }

        public void Create(DT311_ACode Acode)
        {
            db.DT311_ACode.Add(Acode);
            db.SaveChanges();
        }

        public void Edit(DT311_ACode Acode)
        {
            db.Entry(Acode).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Del(DT311_ACode Acode)
        {
            db.Entry(Acode).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}