namespace ContactApi.Models
{
    public class Contacts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public int JobTitleId { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public Company Company { get; set; }
        public JobTitle JobTitle { get; set; }
    }
}