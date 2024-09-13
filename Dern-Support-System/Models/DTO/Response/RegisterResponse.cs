namespace Dern_Support_System.Models.DTO.Response
{
    public class RegisterResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public IList<string> Roles { get; set; }
    }
}
