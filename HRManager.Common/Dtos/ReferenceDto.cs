using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRManager.Common.Dtos
{
    public class ReferenceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [RegularExpression(Constants.Regex.Phone, ErrorMessage = "Please enter a valid phone number for this reference.")]
        public string Phone { get; set; }
        public string Relationship { get; set; }
        public string Occupation { get; set; }
    }
}
