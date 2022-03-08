using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;


namespace SERVICES
{
    public class UserService
    {
        private static UserService _instance;
        public static UserService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserService();
                }
                return _instance;
            }
        }
        private UserService() { }

        public string Login(string userName, string passWord)
        {
            string result = "";
            using (var context = new BudgetContext())
            {
                var users = context.Users;
                foreach (var user in users)
                {

                    if (user.UserName == userName && VerifyPassword(passWord, user.Password))
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
                    var emailString = @"^[\w-_]+(\.[\w!#$%'*+\/=?\^`{|}]+)*@((([\-\w]+\.)+[a-zA-Z]{2,20})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
                    Match match = Regex.Match(mail, emailString);

                    var account = context.Accounts;
                    var newAccount = new Account() { Name = userName + "'s konto" };


                    int id = newAccount.AccountId;
                    var user = context.Users;
                    var newUser = new User() { UserName = userName, Password = HashPassword(password), Email = mail, Account = newAccount };

                    if (match.Success)
                    {
                        account.Add(newAccount);
                        context.SaveChanges();

                        user.Add(newUser);
                        context.SaveChanges();
                    }
                    if (!match.Success)
                    {
                        return "bad email";
                    }

                }
                return "all good";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "bad bad";
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

        public string ChangePassword(string newPass, string confirmPass, string username)
        {
            using (var context = new BudgetContext())
            {
                try
                {
                    var findUser = context.Users.First(a => a.UserName == username);

                    if (findUser != null && CheckPassword(newPass) == true)
                    {
                        findUser.Password = HashPassword(newPass);
                        context.SaveChanges();
                        return "Ok";
                    }
                    else if (findUser != null && CheckPassword(newPass) == false)
                    {
                        return "Ditt lösenord måste ha minst 12 tecken,en gemen, en storbokstav, en siffra och ett special tecken";
                    }
                    else
                    {
                        return "Not OK";
                    }
                }
                catch (Exception)
                {

                    return "Ok";
                }
            }
        }

        public bool CheckPassword(string password)
        {
            var paswd = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{12,50}$");
            if (paswd.IsMatch(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SendRecoverEmail(string email, string token)
        {
            using (var context = new BudgetContext())
            {
                try
                {
                    var findUser = context.Users.First(a => a.Email == email);
                    var theMail = new MimeMessage();
                    theMail.From.Add(new MailboxAddress("Grupp 5", "orfu21grupp5@gmail.com"));
                    theMail.To.Add(new MailboxAddress(findUser.UserName, email));
                    theMail.Subject = "Recover your password!";
                    theMail.Body = new TextPart("plain")
                    {
                        Text = $"Here is your password recovery link http://127.0.0.1:5500/?token={token}"
                    };

                    using (var smtpClient = new SmtpClient())
                    {
                        smtpClient.Connect("smtp.gmail.com", 465, true);
                        smtpClient.Authenticate("orfu21grupp5@gmail.com", "Admin2Losen**");
                        smtpClient.Send(theMail);
                        smtpClient.Disconnect(true);
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public string GetUser(string email)
        {
            try
            {
                using (var context = new BudgetContext())
                {
                    var user = context.Users.First(a => a.Email == email);
                    return user.UserName;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
