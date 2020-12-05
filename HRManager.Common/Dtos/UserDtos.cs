using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRManager.Common.Dtos
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    
    

    public class MemberAdminReadEditDto
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "first name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "city")]
        public string City { get; set; }
        [Required]
        [RegularExpression(Constants.Regex.PostalCode, ErrorMessage = "Postal code must match one of the following expressions: LNLNLN, LNL-NLN, LNL NLN.")]
        [Display(Name = "postal code")]
        public string PostalCode { get; set; }
        [Required]
        [RegularExpression(Constants.Regex.Phone, ErrorMessage = "Please enter a valid phone number Main.")]
        [Display(Name = "phone number")]
        public string MainPhone { get; set; }
        [RegularExpression(Constants.Regex.Phone, ErrorMessage = "Please enter a valid phone number for Alternate Phone 1.")]
        public string AlternatePhone1 { get; set; }
        [RegularExpression(Constants.Regex.Phone, ErrorMessage = "Please enter a valid phone number for Alternate Phone 2.")]
        public string AlternatePhone2 { get; set; }
        [Required]
        [Display(Name = "birth date")]
        public DateTime Birthdate { get; set; }
        [Required]
        [Display(Name = "emergency full name")]
        public string EmergencyFullName { get; set; }
        [Required]
        [RegularExpression(Constants.Regex.Phone, ErrorMessage = "Please enter a valid phone number for Emergency Phone 1.")]
        [Display(Name = "emergency phone number")]
        public string EmergencyPhone1 { get; set; }
        [RegularExpression(Constants.Regex.Phone, ErrorMessage = "Please enter a valid phone number Emergency Phone 2.")]
        public string EmergencyPhone2 { get; set; }
        [Required]
        [Display(Name = "relationship with this emergency contact")]
        public string EmergencyRelationship { get; set; }
        public bool FoodSafe { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FoodSafeExpiry { get; set; }
        [Display(Name = "Level")]
        public string FirstAidCprLevel { get; set; }
        public bool FirstAidCpr { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FirstAidCprExpiry { get; set; }
        public string OtherCertificates { get; set; }
        public string EducationTraining { get; set; }
        public string SkillsInterestsHobbies { get; set; }
        public string VolunteerExperience { get; set; }
        public string OtherBoards { get; set; }
        public bool VolunteerConfidentiality { get; set; }
        public bool VolunteerEthics { get; set; }
        public bool CriminalRecordCheck { get; set; }
        public bool DrivingAbstract { get; set; }
        public bool ConfirmationOfProfessionalDesignation { get; set; }
        public bool ChildWelfareCheck { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public string DisplayStatus 
        {
            get
            {
                if (IsStaff && ApprovalStatus == ApprovalStatus.Approved)
                {
                    return "Active";
                }
                return Enum.GetName(typeof(ApprovalStatus), ApprovalStatus);
            }
        }
        public IList<ReferenceDto> References { get; set; }
        public IList<WorkExperienceDto> WorkExperiences { get; set; }
        public IList<AvailabilityDto> Availabilities { get; set; }
        public IList<PositionMember> Positions { get; set; }
        public bool IsStaff { get; set; }
    }

    public class MemberMinimalDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullNameWithID { get { return Id + " " + FirstName + " " + LastName; } }
        public ApprovalStatus ApprovalStatus { get; set; }
    }

    public class MemberReadEditDto
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
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
        public IList<Position> Positions { get; set; }
    }
}
