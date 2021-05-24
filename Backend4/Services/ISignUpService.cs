using System;

namespace Backend4.Services
{
    public interface ISignUpService
    {
        Boolean VerifyUser(String name, String surname, Int32 birthDay, Int32 birthMonth, Int32 birthYear, String gender, Boolean isExisting);
        void SaveUser(String name, String surname, Int32 birthDay, Int32 birthMonth, Int32 birthYear, String gender, Boolean isExisting);
    }
}