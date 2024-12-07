namespace CharityConnect.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string? Link { get; set; } = ""; 
        public string Meta { get; set; }
        public bool Hide { get; set; }
        public int Order { get; set; }
        public DateTime DateBegin { get; set; } = DateTime.Now;
    }
}
