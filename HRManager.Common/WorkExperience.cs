using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Common
{
    [Serializable]
    public class WorkExperience
    {
        public int Id { get; set; }
        public MemberProfile Member { get; set; }
        [Display(Name = "Employer Name")]
        public string EmployerName { get; set; }
        [Display(Name = "Employer Address")]
        public string EmployerAddress { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Display(Name = "Employer Phone")]
        [Phone]
        public string EmployerPhone { get; set; }
        [Display(Name = "Contact Name")]
        public string ContactPerson { get; set; }
        [Display(Name = "Position Worked")]
        public string PositionWorked { get; set; }
        public bool CurrentJob { get; set; }
    }
}
