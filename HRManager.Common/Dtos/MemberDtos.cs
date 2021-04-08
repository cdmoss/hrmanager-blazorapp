using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRManager.Common.Dtos
{
    public class MemberMinimalDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A valid email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "First Name (Required)")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name (Required)")]
        public string LastName { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
    }

    public class MemberEditDto : MemberMinimalDto
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [RegularExpression(Constants.Regex.PostalCode, ErrorMessage = "Postal code must match one of the following expressions: LNLNLN, LNL-NLN, LNL NLN.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [Required]
        [RegularExpression(Constants.Regex.Phone, ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Main Phone Number")]
        public string MainPhone { get; set; }
        [RegularExpression(Constants.Regex.Phone, ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Alternate Phone Number")]
        public string AlternatePhone1 { get; set; }
        [RegularExpression(Constants.Regex.Phone, ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Alternate Phone Number")]
        public string AlternatePhone2 { get; set; }
        [Required]
        [Display(Name = "Emergency Contact Full Name")]
        public string EmergencyFullName { get; set; }
        [Required]
        [RegularExpression(Constants.Regex.Phone, ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Emergency Contact Phone Number")]
        public string EmergencyPhone1 { get; set; }
        [RegularExpression(Constants.Regex.Phone, ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Emergency Contact Phone Number")]
        public string EmergencyPhone2 { get; set; }
        [Required]
        [Display(Name = "Emergency Contact Relationship")]
        public string EmergencyRelationship { get; set; }
        [Display(Name = "Food Safe")]
        public bool FoodSafe { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FoodSafeExpiry { get; set; }
        [Display(Name = "Level")]
        public string FirstAidCprLevel { get; set; }
        [Display(Name = "First Aid/Cpr")]
        public bool FirstAidCpr { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FirstAidCprExpiry { get; set; }
        [Display(Name = "Other Certificates")]
        public string OtherCertificates { get; set; }
        public bool VolunteerConfidentiality { get; set; }
        public bool VolunteerEthics { get; set; }
        public bool CriminalRecordCheck { get; set; }
        public bool DrivingAbstract { get; set; }
        public bool ConfirmationOfProfessionalDesignation { get; set; }
        public bool ChildWelfareCheck { get; set; }
        public byte[] VolunteerConfidentialityData { get; set; }
        public byte[] VolunteerEthicsData { get; set; }
        public byte[] CriminalRecordCheckData { get; set; }
        public byte[] DrivingAbstractData { get; set; }
        public byte[] ConfirmationOfProfessionalDesignationData { get; set; }
        public byte[] ChildWelfareCheckData { get; set; }
        public List<MemberPositionDto> Positions { get; set; } = new List<MemberPositionDto>();
        public Dictionary<DayOfWeek, List<AvailabilityDto>> Availabilities { get; set; } = new Dictionary<DayOfWeek, List<AvailabilityDto>>();
    }

    public class AdminMemberDto : MemberEditDto
    {
        
        [Required]
        [Display(Name = "Birth Date (Required)")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        public string EducationTraining { get; set; }
        [Display(Name = "Skills, interests and hobbies")]
        public string SkillsInterestsHobbies { get; set; }
        [Display(Name = "Previous volunteer experience")]
        public string Experience { get; set; }
        [Display(Name = "Other boards you've appeared on")]
        public string OtherBoards { get; set; }
        public List<ReferenceDto> References { get; set; }
        public List<WorkExperienceDto> WorkExperiences { get; set; }
        public bool IsStaff { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
