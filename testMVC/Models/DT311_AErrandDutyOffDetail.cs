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
    
    public partial class DT311_AErrandDutyOffDetail
    {
        public string EFORMSN { get; set; }
        public int SN { get; set; }
        public string ERRAND_EFORMSN { get; set; }
        public string START_DATE { get; set; }
        public string END_DATE { get; set; }
        public Nullable<decimal> TOTAL_DAY_HOURS { get; set; }
        public Nullable<decimal> ABLE_DUTYOFF_DAY_HOURS { get; set; }
        public Nullable<decimal> ALR_DUTYOFF_DAY_HOURS { get; set; }
        public Nullable<decimal> WANT_DUTYOFF_DAY_HOURS { get; set; }
        public string DUTYOFF_DL { get; set; }
        public string YN_POSTPONE_DUTYOFF { get; set; }
    }
}
