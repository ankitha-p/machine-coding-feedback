namespace PubSub;

class Program
{
    static int count = 0;
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        D_Queue d_Queue = new D_Queue();

        Producer p1 = new Producer("Producer1", d_Queue);

        Producer p2 = new Producer("Producer2", d_Queue);

        Consumer c1 = new Consumer("Consumer1", d_Queue);
        Consumer c2 = new Consumer("Consumer2", d_Queue);

        Consumer c3 = new Consumer("Consumer3", d_Queue);

        Consumer c4 = new Consumer("Consumer4", d_Queue);

        Consumer c5 = new Consumer("Consumer5", d_Queue);

        d_Queue.addSubscriberList("Topic1", new List<Consumer>(){c1,c2,c3,c4,c5});
        d_Queue.addSubscriberList("Topic2", new List<Consumer>(){c1,c3,c4});
        d_Queue.addSubscriberList("Topic3", new List<Consumer>(){c5});

        startMultiThreading(new List<Producer>(){p1,p2});
    }

    static void startMultiThreading(List<Producer> producers)
    {
        List<Thread> threads = new List<Thread>();

            foreach (var producer in producers)
            {
                Thread thread = new Thread(() =>
                {
                    DateTime endTime = DateTime.Now.AddSeconds(10);
                    while (DateTime.Now < endTime)
                    {
                        eachThreadJob(producer);
                        Thread.Sleep(1000); // Sleep for 1 second before producing next item
                    }
                });

                thread.Start();
                threads.Add(thread);
            }

            // Wait for all threads to finish
            foreach (var thread in threads)
            {
                thread.Join();
            }

    }

    static void eachThreadJob(Producer p)
    {        
        List<string> topics = getEligibleTopicList(p.Name);
        Random random = new Random();

        // Generate a random index
        int randomIndex = random.Next(0, topics.Count); // Generates a random index between 0 and (l.Count - 1)

        // Get the item at the random index
        string randomItemName = topics[randomIndex];
        p.Produce(randomItemName,getMessage());
    }

    static List<string> getEligibleTopicList(string producerName)
    {
        if(producerName == "Producer1")
            return new List<string>(){"Topic1", "Topic2"};
        //if(producerName == "Producer2")
            return new List<string>(){"Topic1", "Topic2","Topic3"};
    }

    static string getMessage()
    {
        return "This is message"+(++count);
    }
}
