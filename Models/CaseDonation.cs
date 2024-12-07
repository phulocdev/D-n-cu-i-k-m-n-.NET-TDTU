namespace CharityConnect.Models
{
    public class CaseDonation
    {
        public int CaseId { get; set; }
        public Case Case { get; set; }
        public int DonationId { get; set; }
        public Donation Donation { get; set; }
    }
}

