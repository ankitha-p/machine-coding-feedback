namespace PubSub
{
    public class D_Queue
    {
        private Queue<Item> d_queue;

        private Dictionary<string,List<Consumer>> subscriberList;

        public D_Queue()
        {
            d_queue = new Queue<Item>();
            subscriberList = new Dictionary<string, List<Consumer>>();
        }

        public void pushItem(Item item)
        {
            d_queue.Enqueue(item);
            string topicName = item.topicName;
            List<Consumer> consumers = subscriberList[topicName];
            foreach(Consumer consumer in consumers)
            {
                consumer.getNews(item);
            }
        }

        public void addSubscriber(string topicName, Consumer c)
        {
            if (subscriberList.ContainsKey(topicName))
            {
                subscriberList[topicName].Add(c);
            }
            else
            {
                subscriberList[topicName] = new List<Consumer> (){c};
            }            
        }

        public void addSubscriberList(string topicName, List<Consumer> consumers)
        {
            subscriberList[topicName] = consumers;
        }
    }
}