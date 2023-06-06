using System;
using DevFreela.Core.Enums;

namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(string title, string description, ProjectStatusEnum status)
        {
            Title = title;
            Description = description;
            Status = status;
        }

        public string Title {
            get;
            private set;
        }
        public string Description {
            get;
            private set;
        }
        public ProjectStatusEnum Status { get; private set; }
    }
}

