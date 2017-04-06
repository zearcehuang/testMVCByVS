using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace testMVC.Models
{

    [MetadataType(typeof(DT311_ACode_MetaData))]
    public partial class DT311_ACode
    {
        sealed class DT311_ACode_MetaData
        {
            [DisplayName("代碼類別")]
            [Required(ErrorMessage = "代碼類別不能為空")]
            [StringLength(1)]
            public string CODE_TYPE { get; set; }

            [DisplayName("代碼")]
            [Required(ErrorMessage = "代碼不能為空")]
            public string CODE { get; set; }

            [DisplayName("代碼名稱")]
            [Required(ErrorMessage = "代碼名稱不能為空")]
            public string CODE_NAME { get; set; }

            [DisplayName("順序")]
            [Required(ErrorMessage = "順序不能為空")]
            [Range(1, 99)]
            [RegularExpression(@"^\+?[1-9][0-9]*$", ErrorMessage = "請輸入正整數")]
            public int? CODE_SEQ { get; set; }
        }
    }
}