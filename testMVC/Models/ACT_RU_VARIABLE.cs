//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace testMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ACT_RU_VARIABLE
    {
        public string ID_ { get; set; }
        public Nullable<int> REV_ { get; set; }
        public string TYPE_ { get; set; }
        public string NAME_ { get; set; }
        public string EXECUTION_ID_ { get; set; }
        public string PROC_INST_ID_ { get; set; }
        public string TASK_ID_ { get; set; }
        public string BYTEARRAY_ID_ { get; set; }
        public Nullable<double> DOUBLE_ { get; set; }
        public Nullable<decimal> LONG_ { get; set; }
        public string TEXT_ { get; set; }
        public string TEXT2_ { get; set; }
    
        public virtual ACT_GE_BYTEARRAY ACT_GE_BYTEARRAY { get; set; }
        public virtual ACT_RU_EXECUTION ACT_RU_EXECUTION { get; set; }
        public virtual ACT_RU_EXECUTION ACT_RU_EXECUTION1 { get; set; }
    }
}
