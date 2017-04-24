using System.Linq;

namespace testWebAPI.Models.Repositorys
{
    public interface IDT311_ACode_Repository
    {
        /// <summary>
        /// �����d�ߵ��G
        /// </summary>
        /// <returns></returns>
        IQueryable<DT311_ACode> GetCodeData();
        /// <summary>
        /// �浧�d�ߵ��G
        /// </summary>
        /// <param name="CODE_TYPE">�N�X���O</param>
        /// <param name="CODE">�N�X</param>
        /// <returns></returns>
        IQueryable<DT311_ACode> GetByKey(string CODE_TYPE = "", string CODE = "");
        /// <summary>
        /// �s�W
        /// </summary>
        /// <param name="Acode"></param>
        void Create(DT311_ACode Acode);
        /// <summary>
        /// �ק�
        /// </summary>
        /// <param name="Acode"></param>
        void Edit(DT311_ACode Acode);
        /// <summary>
        /// �R��
        /// </summary>
        /// <param name="Acode"></param>
        void Del(IQueryable<DT311_ACode> Acode);
        /// <summary>
        /// ����귽
        /// </summary>
        void Dispose();
    }
}