namespace PubSub
{
    public class Item
    {
        //public Topic topic;

        public string topicName;

        public string message;

        public DateTime dateTime;

        public Item(string tName, string msg)
        {
            topicName = tName;
            message = msg;
            dateTime = DateTime.Now;
        } 
        
    }
}