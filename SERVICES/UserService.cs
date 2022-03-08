using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace SERVICES
{
    public class UserService
    {
        private static UserService _instance;
        public static UserService Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new UserService();
                }
                return _instance;
            }
        }
        private UserService() { }

        public string Login(string userName,string passWord)
        {
            string result = "";
            using(var context = new BudgetContext())
            {
                var users = context.Users;
                foreach(var user in users)
                {

                    if(user.UserName == userName && VerifyPassword(passWord, user.Password))
                    {
                        return user.UserName;

                    }
                }
            }
            return result;
        }

        public string RegisterNewAccount(string userName, string password, string mail)

        {
            
            try
            {
                using (var context = new BudgetContext())
                {
                    var checkusers = context.Users;
                    foreach (var userexist in checkusers)
                    {

                        if (userexist.UserName == userName )
                        {

                            throw new Exception("User already exists");

                        }
                    }
                    var account = context.Accounts;
                    var newAccount = new Account() { Name = userName + "'s konto" };


                    int id = newAccount.AccountId;
                    var user = context.Users;
                    var newUser = new User() { UserName = userName, Password = HashPassword(password), Email = mail, Account = newAccount };



                    account.Add(newAccount);
                    context.SaveChanges();
                    user.Add(newUser);
                    context.SaveChanges();

                }
                return "true";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }




        }
        private string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];

            using var rng = RandomNumberGenerator.Create();

            rng.GetNonZeroBytes(salt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 13000,
            numBytesRequested: 256 / 8));
            hashed = hashed + "@" + Convert.ToBase64String(salt);

            //Console.WriteLine(hashed);

            return hashed;
        }
        private bool VerifyPassword(string userEnteredPassword, string dbPasswordHash)
        {
            string salt = dbPasswordHash.Split('@')[1];
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: userEnteredPassword,
                salt: System.Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 13000,
                numBytesRequested: 256 / 8));

            return dbPasswordHash == (hashedPassword + "@" + salt);

        }


    }
}
