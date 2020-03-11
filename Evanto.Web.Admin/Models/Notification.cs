namespace Evanto.Web.Admin.Models
{
    public class Notification
    {
        public string Message { get; set; }
        public string Status { get; set; } = "succes";
        public string Position { get; set; } = "top-right";
    }
}