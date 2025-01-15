using System;

namespace AdministradorAmet.Models
{
    public class Users
    {

        public int userId { get; set; }
        public string cedula { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? profileImg { get; set; }
        public string? nacionality { get; set; }
        public string? gender { get; set; }
        public string? bloodType { get; set; }
        public string? workLocation { get; set; }
        public string? civilStatus { get; set; }
        public string? role { get; set; }
        public string? status { get; set; }
        public string? birthdate { get; set; }
        public double? height { get; set; }
        public string? noAgente { get; set; }
        public string FullName => $"{name} {lastName}";

    }
}

