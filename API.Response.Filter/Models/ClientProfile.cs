namespace API.Response.Filter.Models
{
    public class ClientProfile
    {
        public string? ID { get; set; }
        public string? CertificateNumber { get; set; }
        public string? Surname { get; set; }
        public string? FirstName { get; set; }
        public int? CustomerPhotoType { get; set; }
        public string? CustomerPhoto { get; set; }
        public bool? IsAttained { get; set; }
        public string? DateOfIssue { get; set; }
        public string? DateOfExpiry { get; set; }
        public string? CourseCode { get; set; }
        public string? DOB { get; set; }
    }
}
