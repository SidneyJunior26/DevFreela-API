using System;
namespace DevFreela.Application.ViewModels
{
    public class UpdateProjectInputModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descrition { get; set; }
        public decimal TotalCost { get; set; }
    }
}

