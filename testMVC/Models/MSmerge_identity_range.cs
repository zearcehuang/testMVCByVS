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
    
    public partial class MSmerge_identity_range
    {
        public System.Guid subid { get; set; }
        public System.Guid artid { get; set; }
        public Nullable<decimal> range_begin { get; set; }
        public Nullable<decimal> range_end { get; set; }
        public Nullable<decimal> next_range_begin { get; set; }
        public Nullable<decimal> next_range_end { get; set; }
        public bool is_pub_range { get; set; }
        public Nullable<decimal> max_used { get; set; }
    }
}
