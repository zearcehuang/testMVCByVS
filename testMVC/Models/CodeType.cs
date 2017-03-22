using System.ComponentModel.DataAnnotations;

namespace testMVC.Models
{
    public class CodeType
    {
        [Required]
        [StringLength(2)]
        public string codeType { get; set; }
        [Required]
        [StringLength(20)]
        public string codeTypeName { get; set; }
    }
}