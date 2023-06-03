using System;
using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence;

public class DevFreelaDbContext
{
    public DevFreelaDbContext()
    {
        Projects = new List<Project> {
            new Project("Meu projeto em ASP.NET Core", "Minha descrição do Projeto", 1, 1, 10000),
            new Project("Meu projeto em ASP.NET Core 2", "Minha descrição do Projeto 2", 1, 1, 20000),
            new Project("Meu projeto em ASP.NET Core 3", "Minha descrição do Projeto 3", 1, 1, 30000)
        };

        Users = new List<User> {
            new User("Sidney Junior", "sidneyjunior26@gmail.com", new DateTime(1996, 7, 10)),
            new User("Sidney Junior 2", "sidneyjunior262@gmail.com", new DateTime(1996, 7, 10))
        };

        Skils = new List<Skill> {
            new Skill(".NET Core"),
            new Skill("SQL"), 
            new Skill("Angular"),
        };
    }

    public List<Project> Projects { get; set; }
    public List<User> Users { get; set; }
    public List<Skill> Skils { get; set; }
}

