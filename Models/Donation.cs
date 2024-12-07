using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CharityConnect.Models
{
    public class Donation
    {
        public int DonationId { get; set; }
        public string DonorName { get; set; }
        public int Amount { get; set; }
        public string Message { get; set; }
        public int PaymentMethod {  get; set; }


        [ValidateNever]
        public ICollection<CaseDonation>? CaseDonations { get; set; }
        public string Meta { get; set; }
        public bool Hide { get; set; }
        public int Order { get; set; }
        public DateTime DateBegin { get; set; }
    }
}