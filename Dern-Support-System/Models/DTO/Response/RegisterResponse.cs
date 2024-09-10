namespace Dern_Support_System.Models.DTO.Response
{
    public class RegisterResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public AppUser User { get; set; }
    }
}
