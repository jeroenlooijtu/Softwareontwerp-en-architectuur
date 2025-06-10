namespace Softwareontwerp_en_architectuur.Domain.Observable
{
    public class Tester : IObserver
    {
        public List<IMessanger> receivedMessages = new List<IMessanger>();

        public string SendNotification(string message)
        {
            return message;
        }
    }
}
