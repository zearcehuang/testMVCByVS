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
    
    public partial class MSrepl_errors
    {
        public int id { get; set; }
        public System.DateTime time { get; set; }
        public Nullable<int> error_type_id { get; set; }
        public Nullable<int> source_type_id { get; set; }
        public string source_name { get; set; }
        public string error_code { get; set; }
        public string error_text { get; set; }
        public byte[] xact_seqno { get; set; }
        public Nullable<int> command_id { get; set; }
        public Nullable<int> session_id { get; set; }
    }
}