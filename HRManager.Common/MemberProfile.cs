using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Common
{
    [Serializable]
    public class MemberProfile
    {
        // doesn't contain email so there's no way to have discontinuity with associated identity account
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email (Required)")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "First name (Required)")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name (Required)")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Address (Required)")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "City (Required)")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Postal code (Required)")]
        public string PostalCode { get; set; }
        [Required]
        [RegularExpression(Constants.Regex.Phone, ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Main phone (Required)")]
        [Phone]
        public string MainPhone { get; set; }
        [Display(Name = "Alternate phone 1 (Optional)")]
        [RegularExpression(Constants.Regex.Phone, ErrorMessage = "Please enter a valid phone number.")]
        [Phone]
        public string AlternatePhone1 { get; set; }
        [Display(Name = "Alternate phone 2 (Optional)")]
        [RegularExpression(Constants.Regex.Phone, ErrorMessage = "Please enter a valid phone number.")]
        [Phone]
        public string AlternatePhone2 { get; set; }
        [Required]
        [Display(Name= "Birth date (Required)")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        [Required]
        [Display(Name = "Full name of emergency contact (Required)")]
        public string EmergencyFullName { get; set; }
        [Required]
        [RegularExpression(Constants.Regex.Phone, ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Emergency contact phone 1 (Required)")]
        [Phone]
        public string EmergencyPhone1 { get; set; }
        [Display(Name = "Emergency contact phone 2 (Optional)")]
        [Phone]
        public string EmergencyPhone2 { get; set; }
        [Required]
        [Display(Name = "Relationship to emergency contact (Required)")]
        public string EmergencyRelationship { get; set; }
        [Display(Name = "Food safe")]
        public bool FoodSafe { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FoodSafeExpiry { get; set; }
        [Display(Name = "Level")]
        public string FirstAidCprLevel { get; set; }
        [Display(Name = "First aid")]
        public bool FirstAidCpr { get; set; }
        [DataType(DataType.Date)]
        public DateTime? FirstAidCprExpiry { get; set; }
        [Display(Name = "Other Certificates")] 
        public string OtherCertificates { get; set; }
        [Display(Name = "Education and training")]
        public string EducationTraining { get; set; }
        [Display(Name = "Skills, interests and hobbies")]
        public string SkillsInterestsHobbies { get; set; }
        [Display(Name = "Previous volunteer experience")]
        public string Experience { get; set; }
        [Display(Name = "Other boards you've appeared on")]
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
        public List<Reference> References { get; set; }
        public List<WorkExperience> WorkExperiences { get; set; }
        public List<Shift> Shifts { get; set; }
        public List<Availability> Availabilities { get; set; }
        public List<MemberPosition> Positions { get; set; }
        public List<Alert> Alerts { get; set; }
        public List<TimeEntry> TimeEntries { get; set; }
        public bool IsStaff { get; set; }
    }
}
