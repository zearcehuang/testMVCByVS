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
    
    public partial class ACT_RE_PROCDEF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACT_RE_PROCDEF()
        {
            this.ACT_PROCDEF_INFO = new HashSet<ACT_PROCDEF_INFO>();
            this.ACT_RU_IDENTITYLINK = new HashSet<ACT_RU_IDENTITYLINK>();
            this.ACT_RU_EXECUTION = new HashSet<ACT_RU_EXECUTION>();
            this.ACT_RU_TASK = new HashSet<ACT_RU_TASK>();
        }
    
        public string ID_ { get; set; }
        public Nullable<int> REV_ { get; set; }
        public string CATEGORY_ { get; set; }
        public string NAME_ { get; set; }
        public string KEY_ { get; set; }
        public int VERSION_ { get; set; }
        public string DEPLOYMENT_ID_ { get; set; }
        public string RESOURCE_NAME_ { get; set; }
        public string DGRM_RESOURCE_NAME_ { get; set; }
        public string DESCRIPTION_ { get; set; }
        public Nullable<byte> HAS_START_FORM_KEY_ { get; set; }
        public Nullable<byte> HAS_GRAPHICAL_NOTATION_ { get; set; }
        public Nullable<byte> SUSPENSION_STATE_ { get; set; }
        public string TENANT_ID_ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACT_PROCDEF_INFO> ACT_PROCDEF_INFO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACT_RU_IDENTITYLINK> ACT_RU_IDENTITYLINK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACT_RU_EXECUTION> ACT_RU_EXECUTION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACT_RU_TASK> ACT_RU_TASK { get; set; }
    }
}
