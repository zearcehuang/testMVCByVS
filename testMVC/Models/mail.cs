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
    
    public partial class mail
    {
        public int mail_id { get; set; }
        public string mail_to { get; set; }
        public string mail_subject { get; set; }
        public string mail_from { get; set; }
        public string mail_body { get; set; }
        public int BodyFormat { get; set; }
        public Nullable<System.DateTime> sendDate { get; set; }
        public string HadSend { get; set; }
    }
}