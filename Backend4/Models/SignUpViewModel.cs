using System;
using System.ComponentModel.DataAnnotations;

namespace Backend4.Models
{
    public class SignUpViewModel
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Surname { get; set; }
        public Int32 BirthDay { get; set; }
        public Int32 BirthMonth { get; set; }
        public Int32 BirthYear { get; set; }
        public String Gender { get; set; }
        public Boolean IsExisting { get; set; }
        public Month[] Months{ get; set; }
    }
}