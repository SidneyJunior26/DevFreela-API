using System;
namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, string password, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            BirthDate = birthDate;
            CreatedAt = DateTime.Now;
            Active = true;

            Skills = new List<UserSkill>();
            OwnedProjects = new List<Project>();
            FreelanceProjects = new List<Project>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; private set; }
        public List<UserSkill> Skills { get; set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }
        public List<ProjectComment> Comments {
            get;
            private set;
        }
    }
}

