using System;
using DevFreela.Core.Enums;

namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(string title, string description, decimal totalCost, ProjectStatusEnum status,
            string clientFullName, string freelancerFullName) {
            Title = title;
            Description = description;
            TotalCost = totalCost;
            Status = status;
            ClientFullName = clientFullName;
            FreelancerFullName = freelancerFullName;
        }

        public string Title {
            get;
            private set;
        }
        public string Description {
            get;
            private set;
        }
        public decimal TotalCost {
            get;
            private set;
        }
        public ProjectStatusEnum Status { get; private set; }
        public string ClientFullName {
            get;
            private set;
        }
        public string FreelancerFullName {
            get;
            private set;
        }
    }
}

