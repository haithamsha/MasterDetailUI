using System.ComponentModel.DataAnnotations;

namespace MasterDetailUI.Models
{
    public class Detail
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Teaching Type is required")]
        public string TeachingType { get; set; }

        [Required(ErrorMessage = "Accredited Hours is required")]
        [Range(0, 1000, ErrorMessage = "Accredited Hours must be between 0 and 1000")]
        public int AccreditedHours { get; set; }

        [Required(ErrorMessage = "School Location is required")]
        public string SchoolLocation { get; set; }

        [Required(ErrorMessage = "Certificate Date is required")]
        [DataType(DataType.Date)]
        public DateTime CertificateDate { get; set; }

        [Required(ErrorMessage = "School Name is required")]
        public string SchoolName { get; set; }

        [Required(ErrorMessage = "Please enter a valid URL")]
        public string SchoolLink { get; set; }

        public string SchoolSocialMediaAccount { get; set; }

        [DataType(DataType.Upload)]
        public string? CertificateFile { get; set; } // Assume this is for storing the path

        [Required]
        public int MasterId { get; set; }
        public Master? Master { get; set; }
    }
}
