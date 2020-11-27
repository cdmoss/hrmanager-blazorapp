using System;
using System.ComponentModel.DataAnnotations;

namespace HRManager.Common.Dtos
{
    public class WorkExperienceDto
    {
        public int Id { get; set; }
        [Display(Name = "Employer Name")]
        public string EmployerName { get; set; }
        [Display(Name = "Employer Address")]
        public string EmployerAddress { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        [Display(Name = "Employer Phone")]
        [RegularExpression(Constants.Regex.phone, ErrorMessage = "Please enter a valid phone number for this employer.")]
        public string EmployerPhone { get; set; }
        [Display(Name = "Contact Name")]
        public string ContactPerson { get; set; }
        [Display(Name = "Position Worked")]
        public string PositionWorked { get; set; }
        public bool CurrentJob { get; set; }
    }
}
