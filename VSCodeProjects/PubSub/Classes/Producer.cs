namespace PubSub
{
    public class Producer
    {
        public string Name;

        D_Queue d_Queue;

        public Producer(string Name, D_Queue d_Queue)
        {
            this.Name = Name;
            this.d_Queue = d_Queue;
        }

        public void Produce(string tName, string message)
        {
            Console.WriteLine($"{Name} producing {message} on {tName}");
            d_Queue.pushItem(new Item(tName,message));
        }
        
    }
}