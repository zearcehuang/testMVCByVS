using System.Linq;

namespace testWebAPI.Models.Repositorys
{
    public interface IDT311_ACode_Repository
    {
        /// <summary>
        /// 全部查詢結果
        /// </summary>
        /// <returns></returns>
        IQueryable<DT311_ACode> GetCodeData();
        /// <summary>
        /// 單筆查詢結果
        /// </summary>
        /// <param name="CODE_TYPE">代碼類別</param>
        /// <param name="CODE">代碼</param>
        /// <returns></returns>
        IQueryable<DT311_ACode> GetByKey(string CODE_TYPE = "", string CODE = "");
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="Acode"></param>
        void Create(DT311_ACode Acode);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Acode"></param>
        void Edit(DT311_ACode Acode);
        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="Acode"></param>
        void Del(IQueryable<DT311_ACode> Acode);
        /// <summary>
        /// 釋放資源
        /// </summary>
        void Dispose();
    }
}