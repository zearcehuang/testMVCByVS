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
    
    public partial class ACT_GE_BYTEARRAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACT_GE_BYTEARRAY()
        {
            this.ACT_PROCDEF_INFO = new HashSet<ACT_PROCDEF_INFO>();
            this.ACT_RU_JOB = new HashSet<ACT_RU_JOB>();
            this.ACT_RE_MODEL = new HashSet<ACT_RE_MODEL>();
            this.ACT_RE_MODEL1 = new HashSet<ACT_RE_MODEL>();
            this.ACT_RU_VARIABLE = new HashSet<ACT_RU_VARIABLE>();
        }
    
        public string ID_ { get; set; }
        public Nullable<int> REV_ { get; set; }
        public string NAME_ { get; set; }
        public string DEPLOYMENT_ID_ { get; set; }
        public byte[] BYTES_ { get; set; }
        public Nullable<byte> GENERATED_ { get; set; }
    
        public virtual ACT_RE_DEPLOYMENT ACT_RE_DEPLOYMENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACT_PROCDEF_INFO> ACT_PROCDEF_INFO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACT_RU_JOB> ACT_RU_JOB { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACT_RE_MODEL> ACT_RE_MODEL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACT_RE_MODEL> ACT_RE_MODEL1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACT_RU_VARIABLE> ACT_RU_VARIABLE { get; set; }
    }
}