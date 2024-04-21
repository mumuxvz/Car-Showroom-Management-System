
namespace CarModelManagement.Controllers
{
    public class DecodedToken
    {
        public string role { get; set; }
        public string id { get; set; }
        public string username { get; set; }
        public DecodedToken(string role, string id, string username)
        {
            this.role = role;
            this.id = id;
            this.username = username;
        }
    }
}