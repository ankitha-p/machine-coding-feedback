namespace PubSub
{
    public class Consumer
    {
        
        public string Name;
        
        public D_Queue d_Queue;

        public Consumer(string name, D_Queue d_Queue)
        {
            this.Name = name;
            this.d_Queue = d_Queue;
        }

        public void subscribeToTopic(string topicName)
        {
            d_Queue.addSubscriber(topicName, this);
        }

        public void getNews(Item item)
        {
            string timestamp = item.dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine($"{timestamp} {Name} Received information on {item.topicName}\t{item.message}");
        }
    }
}