using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace testWebAPI.Models.Repositorys
{
    public class DT311_ACode_Repository
    {
        protected  TPDBtestEntities db;

        public DT311_ACode_Repository()
        {
            db=new TPDBtestEntities();
        }

        public IEnumerable<DT311_ACode> GetCodeData()
        {
            return db.DT311_ACode.AsEnumerable();
        }

        public DT311_ACode GetByKey(string CODE_TYPE,string CODE)
        {
            return db.DT311_ACode.Find(CODE_TYPE, CODE);
        }

        public void Create(DT311_ACode Acode)
        {
            db.DT311_ACode.Add(Acode);
            db.SaveChanges();
        }

        public void Edit(DT311_ACode Acode)
        {
            db.Entry(Acode).State=EntityState.Modified;
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