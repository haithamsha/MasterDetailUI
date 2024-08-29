using System.ComponentModel.DataAnnotations;

namespace MasterDetailUI.Models
{
    public class Master
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Education Level is required")]
        public string EducationLevel { get; set; }

        [Required(ErrorMessage = "Social Media Accounts is required")]
        public string SocialMediaAccounts { get; set; }

        [Required(ErrorMessage = "Personal Web Site is required")]
        public string PersonalWebSite { get; set; }

        [Required(ErrorMessage = "Years Of Experience is required")]
        [Range(0, 100, ErrorMessage = "Years of Experience must be between 0 and 100")]
        public int YearsOfExperience { get; set; }

        public List<Detail> Details { get; set; } = new List<Detail>();
    }
}
