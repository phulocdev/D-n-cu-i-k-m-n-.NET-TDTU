using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CharityConnect.Models
{
    public class Case
    {
        public Case()
        {
            CaseDonations = new List<CaseDonation>();
        }
        public int CaseId { get; set; }

        [DisplayName("Tiêu đề")]
        public string Title { get; set; }

        [DisplayName("Mô tả")]
        [AllowHtml] // Cho phép HTML
        public string Description { get; set; }

        [DisplayName("Khu vực")]
        public string Location { get; set; }

        [DisplayName("Loại hoàn cảnh")]
        public int CategoryId { get; set; }

        [ValidateNever]
        public Category? Category { get; set; } // A Case belongs to category


        [ValidateNever]
        public ICollection<CaseDonation>? CaseDonations { get; set; } // A case can have many donation

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string ImageUrl { get; set; } = "https://via.placeholder.com/150";
        public string Meta { get; set; }
        public bool Hide { get; set; }
        public int Order { get; set; }
        public DateTime DateBegin { get; set; }
    }
}
