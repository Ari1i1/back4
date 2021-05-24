using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System;

namespace Backend4.Services
{
    public class SignUpService : ISignUpService
    {
        private readonly ILogger _logger;
        private readonly List<User> users = new List<User>();
        
        public SignUpService(ILogger<ISignUpService> logger)
        {
            this._logger = logger;
        }

        public Boolean VerifyUser(String name, String surname, Int32 birthDay, Int32 birthMonth, Int32 birthYear, String gender, Boolean isExisting)
        {
            lock (this.users)
            {
                this._logger.LogInformation($"Validating user information: First name {name}, Second name {surname}," +
                                            $"Birth day {birthDay}, Birth month {birthMonth}, Birth year {birthYear}, Gender {gender}, isExisting {isExisting}");
                return this.users.Any(x => x.Name == name && x.Surname == surname && x.BirthDay == birthDay && 
                                           x.BirthMonth == birthMonth && x.BirthYear == birthYear && x.Gender == gender && x.isExisting == isExisting) ;
            }
        }

        public void SaveUser(String name, String surname, Int32 birthDay, Int32 birthMonth, Int32 birthYear,
            String gender, Boolean isExisting)
        {
            lock (this.users)
            {
                this._logger.LogInformation($"Saving user information: First name {name}, Second name {surname}," +
                                            $"Birth day {birthDay}, Birth month {birthMonth}, Birth year {birthYear}, Gender {gender}, isExisting {isExisting}");
                this.users.Add(new User(name, surname, birthDay, birthMonth, birthYear, gender, isExisting));
            }
        }
        private sealed class User
        {
            public User(String name, String surname, Int32 birthDay, Int32 birthMonth, Int32 birthYear, String gender, Boolean isExisting)
            {
                this.Name = name;
                this.Surname = surname;
                this.BirthDay = birthDay;
                this.BirthMonth = birthMonth;
                this.BirthYear = birthYear;
                this.Gender = gender;
                this.isExisting = isExisting;
            }

            public String Name { get; }
            public String Surname { get; }
            public Int32 BirthDay { get; }
            public Int32 BirthMonth { get; }
            public Int32 BirthYear { get; }
            public String Gender { get; }
            public Boolean isExisting { get; }
        }
        
    }

    
}