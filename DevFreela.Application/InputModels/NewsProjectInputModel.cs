using System;
namespace DevFreela.Application.ViewModels
{
    public class NewsProjectInputModel
    {
        public string Title { get; set; }
        public string Descrition { get; set; }
        public int IdClient { get; set; }
        public int IdFreelancer { get; set; }
        public decimal TotalCost { get; set; }
    }
}

