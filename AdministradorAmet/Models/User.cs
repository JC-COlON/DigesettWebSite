using System;

namespace AdministradorAmet.Models
{
    public class User
    {

        public int userId { get; set; }
        public string Cedula { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? email { get; set; }
        public string? Phone { get; set; }
        public string? profileImg { get; set; }
        public string? nacionality { get; set; }
        public string? Gender { get; set; }
        public string? bloodType { get; set; }
        public string? workLocation { get; set; }
        public string? civilStatus { get; set; }
        public string? Role { get; set; }
        public string? status { get; set; }
        public string? birthdate { get; set; }
        public double? height { get; set; }
        public string? NoAgente { get; set; }
        public string FullName => $"{Name} {LastName}";

    }
}

