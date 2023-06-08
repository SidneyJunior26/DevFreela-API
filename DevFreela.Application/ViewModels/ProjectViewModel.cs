using System;
using DevFreela.Core.Enums;

namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, ProjectStatusEnum status)
        {
            Id = id;
            Title = title;
            Status = status;
        }
        public int Id {
            get;
            private set;
        }
        public string Title {
            get;
            private set;
        }
        public ProjectStatusEnum Status { get; private set; }
    }
}

