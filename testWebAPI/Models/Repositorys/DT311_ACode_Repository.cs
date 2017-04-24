using System;
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
            try
            {
                db.DT311_ACode.Add(Acode);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Edit(DT311_ACode Acode)
        {
            try
            {
                DT311_ACode _updateACode = GetByKey(Acode.CODE_TYPE, Acode.CODE).FirstOrDefault();
                if (_updateACode != null)
                {
                    _updateACode.CODE_NAME = Acode.CODE_NAME;
                    _updateACode.CODE_SEQ = Acode.CODE_SEQ;
                    db.Entry(Acode).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Del(IQueryable<DT311_ACode> Acode)
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