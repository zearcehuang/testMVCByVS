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
    
    public partial class ACT_HI_ACTINST
    {
        public string ID_ { get; set; }
        public string PROC_DEF_ID_ { get; set; }
        public string PROC_INST_ID_ { get; set; }
        public string EXECUTION_ID_ { get; set; }
        public string ACT_ID_ { get; set; }
        public string TASK_ID_ { get; set; }
        public string CALL_PROC_INST_ID_ { get; set; }
        public string ACT_NAME_ { get; set; }
        public string ACT_TYPE_ { get; set; }
        public string ASSIGNEE_ { get; set; }
        public System.DateTime START_TIME_ { get; set; }
        public Nullable<System.DateTime> END_TIME_ { get; set; }
        public Nullable<decimal> DURATION_ { get; set; }
        public string TENANT_ID_ { get; set; }
    }
}