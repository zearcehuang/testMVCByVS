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
    
    public partial class sysmergesubsetfilters
    {
        public string filtername { get; set; }
        public int join_filterid { get; set; }
        public System.Guid pubid { get; set; }
        public System.Guid artid { get; set; }
        public int art_nickname { get; set; }
        public string join_articlename { get; set; }
        public int join_nickname { get; set; }
        public int join_unique_key { get; set; }
        public string expand_proc { get; set; }
        public string join_filterclause { get; set; }
        public byte filter_type { get; set; }
    }
}
