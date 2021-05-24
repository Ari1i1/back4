using System;
using Backend4.Models.Controls;

namespace Backend4.Models
{
    public class SignUpViewModel
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public Int32 BirthDay { get; set; }
        public Int32 BirthMonth { get; set; }
        public Int32 BirthYear { get; set; }
        public String Gender { get; set; }
        public Boolean isExisting { get; set; }
        public Month[] Months{ get; set; }
    }
}