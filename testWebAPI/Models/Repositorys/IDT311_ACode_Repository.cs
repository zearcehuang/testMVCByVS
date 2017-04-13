using System.Linq;

namespace testWebAPI.Models.Repositorys
{
    public interface IDT311_ACode_Repository
    {
        IQueryable<DT311_ACode> GetCodeData();
        IQueryable<DT311_ACode> GetByKey(string CODE_TYPE = "", string CODE = "");
        void Create(DT311_ACode Acode);
        void Edit(DT311_ACode Acode);
        void Del(DT311_ACode Acode);
        void Dispose();
    }
}
