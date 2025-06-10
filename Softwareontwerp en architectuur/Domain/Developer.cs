using Softwareontwerp_en_architectuur.Domain.Observable;

namespace Softwareontwerp_en_architectuur.Domain
{
    public class Developer: IObserver
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public Developer()
        {
        }

        public List<IMessanger> receivedMessages = new List<IMessanger>();

        public string SendNotification(string message)
        {
            return message;
        }
    }
}