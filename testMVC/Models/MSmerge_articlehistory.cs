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
    
    public partial class MSmerge_articlehistory
    {
        public int session_id { get; set; }
        public Nullable<int> phase_id { get; set; }
        public string article_name { get; set; }
        public System.DateTime start_time { get; set; }
        public Nullable<int> duration { get; set; }
        public int inserts { get; set; }
        public int updates { get; set; }
        public int deletes { get; set; }
        public int conflicts { get; set; }
        public int rows_retried { get; set; }
        public decimal percent_complete { get; set; }
        public Nullable<int> estimated_changes { get; set; }
        public decimal relative_cost { get; set; }
    }
}
