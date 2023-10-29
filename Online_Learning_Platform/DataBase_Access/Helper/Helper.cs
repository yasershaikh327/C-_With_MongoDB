using DataBase_Access.Mappers.UIMapper.Model;
using DataBase_Access.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace DataBase_Access.Helper
{

    public interface IHelper
    {
        public string Base64Encode(string PlainPassword);
        public int IsUserAuthenticated(Login login);
        public Task UploadFiles(List<IFormFile> files);
        public string GenerateRandomPassword();


    }
    public class Helper : IHelper
    {
        private readonly IConfiguration _configuration;
        public Helper(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //Encrypt Password
        public string Base64Encode(string PlainPassword)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(PlainPassword);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        //Find The User As Admin/Employee
        public int IsUserAuthenticated(Login login)
        {
            var credentials = _configuration.GetSection("SmtpClientSettings:Credentials");
            string username = credentials["Username"].ToString();
            string password = credentials["Password"].ToString();
            if (login.Email.Contains(username) && login.Password.Contains(password))
                return -2;
            return -1;
        }


        //Random Characters Generator
        public string GenerateRandomPassword()
        {
           string CharSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
           Random Random = new Random();
           char[] password = new char[8];
            for (int i = 0; i < 8; i++)
            {
                password[i] = CharSet[Random.Next(CharSet.Length)];
            }
            return new string(password);
        }


        //Save Image
        public async Task UploadFiles(List<IFormFile> files)
        {
            //Loop
            foreach (var file in files)
            {
               
                if (file.Length > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CourseVideos", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
        }
    }
}
