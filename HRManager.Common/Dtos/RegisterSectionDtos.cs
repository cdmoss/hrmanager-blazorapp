using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRManager.Common.Dtos
{
    public abstract class RegisterSectionData
    {
        public virtual void AddSectionToMainDto(MemberRegisterDto mainDto)
        {

        }
    }
    public class AccountData : RegisterSectionData
    {
        [Required(ErrorMessage = "A valid email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "A valid password is required")]
        public string Password { get; set; }
        [Required]
        [RegularExpression(Constants.Regex.Password, ErrorMessage = "Your password must be at least 8 characters and contain one uppercase letter, one lowercase letter, one number and one special character")]
        [Compare(nameof(Password), ErrorMessage = "The entered passwords don't match")]
        public string ConfirmPassword { get; set; }

        public override void AddSectionToMainDto(MemberRegisterDto mainDto)
        {
            mainDto.Email = Email;
            mainDto.Password = Password;
            mainDto.ConfirmPassword = ConfirmPassword;
        }
    }

    public class PersonalAndContactData : RegisterSectionData
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
        [Display(Name = "Main Phone (Required)")]
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
        public DateTime? Birthdate { get; set; }
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

        public override void AddSectionToMainDto(MemberRegisterDto mainDto)
        {
            mainDto.FirstName = FirstName;
            mainDto.LastName = LastName;
            mainDto.Address = Address;
            mainDto.City = City;
            mainDto.MainPhone = MainPhone;
            mainDto.AlternatePhone1 = AlternatePhone1;
            mainDto.AlternatePhone2 = AlternatePhone2;
            mainDto.EmergencyPhone1 = EmergencyPhone2;
            mainDto.EmergencyRelationship = EmergencyRelationship;
            mainDto.EmergencyFullName = EmergencyFullName;
            mainDto.PostalCode = PostalCode;
        }
    }

    public class PreferredPositionsData : RegisterSectionData
    {
        public IList<Position> Positions { get; set; } = new List<Position>();

        public override void AddSectionToMainDto(MemberRegisterDto mainDto)
        {
            mainDto.Positions = Positions;
        }
    }

    public class QualificationsData : RegisterSectionData
    {
        [Display(Name = "Education and Training")]
        public string EducationTraining { get; set; }
        [Display(Name = "Skills, Interests and Hobbies")]
        public string SkillsInterestsHobbies { get; set; }
        [Display(Name = "Previous Volunteer Experience")]
        public string Experience { get; set; }
        [Display(Name = "Other Boards You've Appeared On")]
        public string OtherBoards { get; set; }
        public IList<WorkExperienceDto> WorkExperiences { get; set; } = new List<WorkExperienceDto>();

        public override void AddSectionToMainDto(MemberRegisterDto mainDto)
        {
            mainDto.EducationTraining = EducationTraining;
            mainDto.Experience = Experience;
            mainDto.SkillsInterestsHobbies = SkillsInterestsHobbies;
            mainDto.OtherBoards = OtherBoards;
            mainDto.WorkExperiences = WorkExperiences;
        }
    }

    public class CertificatesData : RegisterSectionData
    {
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

        public override void AddSectionToMainDto(MemberRegisterDto mainDto)
        {
            mainDto.FirstAidCpr = FirstAidCpr;
            mainDto.FirstAidCprExpiry = FirstAidCprExpiry;
            mainDto.FirstAidCprLevel = FirstAidCprLevel;
            mainDto.FoodSafe = FoodSafe;
            mainDto.FoodSafeExpiry = FoodSafeExpiry;
            mainDto.OtherCertificates = OtherCertificates;
        }
    }

    public class AvailabilitiesData : RegisterSectionData
    {
        public IList<AvailabilityDto> Availabilities { get; set; }

        public override void AddSectionToMainDto(MemberRegisterDto mainDto)
        {
            mainDto.Availabilities = Availabilities;
        }
    }
}
