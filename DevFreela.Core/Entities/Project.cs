﻿using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {
        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;

            CreatedAt = DateTime.Now;
            Status = ProjectStatusEnum.Created;
            Comments = new List<ProjectComment>();
        }

        public string Title {
            get;
            private set;
        }
        public string Description { get; set; }
        public int IdClient {
            get;
            private set;
        }
        public User Client {
            get;
            private set;
        }
        public int IdFreelancer {
            get;
            private set;
        }
        public User Freelancer {
            get;
            private set;
        }
        public decimal TotalCost {
            get;
            private set;
        }
        public DateTime CreatedAt {
            get;
            private set;
        }
        public DateTime? StartedAt {
            get;
            private set;
        }
        public DateTime? FinishedAt {
            get;
            private set;
        }
        public ProjectStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; set; }

        public void CancelProject() {
            if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Created)
                Status = ProjectStatusEnum.Cancelled;
        }

        public void FinishProject() {
            if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Created) {
                Status = ProjectStatusEnum.Finished;
                FinishedAt = DateTime.Now;
            }
        }

        public void StartProject() {
            if (Status == ProjectStatusEnum.Created) {
                Status = ProjectStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }
        }

        public void Update(string title, string description, decimal totalCost) {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }
    }
}

