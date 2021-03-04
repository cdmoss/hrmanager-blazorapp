using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRManager.Common.Dtos
{
    public class AdminRegisterDto
    {
        [Required]
        [Display(Name = "First Name (Required)")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name (Required)")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Address (Required)")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "City (Required)")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Postal Code (Required)")]
        [RegularExpression(Constants.Regex.PostalCode, ErrorMessage = "Postal code must match one of the following expressions: LNLNLN, LNL-NLN, LNL NLN.")]
        public string PostalCode { get; set; }
        [Required]
        [Display(Name = "Main phone (Required)")]
        [Phone]
        public string MainPhone { get; set; }
        [Display(Name = "Alternate Phone 1 (Optional)")]
        [Phone]
        public string AlternatePhone1 { get; set; }
        [Display(Name = "Alternate Phone 2 (Optional)")]
        [Phone]
        public string AlternatePhone2 { get; set; }
        [Required]
        [Display(Name = "Birth Date (Required)")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        [Required]
        [Display(Name = "Full Name of Emergency Contact (Required)")]
        public string EmergencyFullName { get; set; }
        [Required]
        [Display(Name = "Emergency Contact Phone 1 (Required)")]
        [Phone]
        public string EmergencyPhone1 { get; set; }
        [Display(Name = "Emergency Contact Phone 2 (Optional)")]
        [Phone]
        public string EmergencyPhone2 { get; set; }
        [Required]
        [Display(Name = "Relationship to Emergency Contact (Required)")]
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
    }

    public class MemberRegisterDto
    {
        public AccountRegisterData Account { get; set; } = new AccountRegisterData();
        public PersonalAndContactData Personal { get; set; } = new PersonalAndContactData{Birthdate = DateTime.Now};
        // string containing ids of selected positions
        public string Positions { get; set; }
        public QualificationsData Qualifications { get; set; } = new QualificationsData();
        public Dictionary<DayOfWeek, List<AvailabilityDto>> Availabilities { get; set; } = new Dictionary<DayOfWeek, List<AvailabilityDto>>();
        public CertificatesData Certificates { get; set; } = new CertificatesData();
    }

    public class IdentityDto
    {
        public int MemberId { get; set; }
        public AccountRegisterData Data { get; set; }
    }

    public class ChangePasswordDto
    {
        [Required]
        public Guid Id { get; set; }
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "A valid password is required")]
        public string NewPassword { get; set; }
        [Required]
        [RegularExpression(Constants.Regex.Password, ErrorMessage = "Your password must be at least 8 characters and contain one uppercase letter, one lowercase letter, one number and one special character")]
        [Compare(nameof(NewPassword), ErrorMessage = "The entered passwords don't match")]
        public string ConfirmNewPassword { get; set; }
    }
}
