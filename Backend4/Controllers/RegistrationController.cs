using System;
using System.Globalization;
using System.Linq;
using Backend4.Models;
using Backend4.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend4.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ISignUpService _signUpService;

        public RegistrationController(ISignUpService signUpService)
        {
            this._signUpService = signUpService;
        }

        public IActionResult SignUp()
        {
            var model = new SignUpViewModel
            {
                Months = GetAllMonths()
            };
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(SignUpViewModel model)
        {
            model.Months = GetAllMonths();
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            if (!this._signUpService.VerifyUser(model.Name, model.Surname, model.BirthDay, model.BirthMonth,
                model.BirthYear, model.Gender, model.IsExisting))
            {
                return this.View("SignUpCredentials", new SignUpContinueViewModel
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    BirthDay = model.BirthDay,
                    BirthMonth = model.BirthMonth,
                    BirthYear = model.BirthYear,
                    Gender = model.Gender,
                    IsExisting = model.IsExisting
                });
            }
            model.IsExisting = true;
            return this.View("SignUpAlreadyExists", model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult SignUpAlreadyExists(SignUpViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            return this.View("SignUpCredentials", new SignUpContinueViewModel
            {
                Name = model.Name,
                Surname = model.Surname,
                BirthDay = model.BirthDay,
                BirthMonth = model.BirthMonth,
                BirthYear = model.BirthYear,
                Gender = model.Gender,
                IsExisting = model.IsExisting
            });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult SignUpCredentials(SignUpContinueViewModel model)
        {

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            this._signUpService.SaveUser(model.Name, model.Surname, model.BirthDay, model.BirthMonth,
                model.BirthYear, model.Gender, model.IsExisting);
            model.Months = GetAllMonths();
            return this.View("SignUpResult", model);

        }
        private Month[] GetAllMonths()
        {
            return CultureInfo.InvariantCulture.DateTimeFormat.MonthNames
                .Select((x, i) => new Month { Id = i + 1, Name = x })
                .Where(x => !String.IsNullOrEmpty(x.Name))
                .ToArray();
        }

    }
}