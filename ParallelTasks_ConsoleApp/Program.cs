class Program
{
    static void Main(string[] args)
    {
        //var t1 = new Task(() => doWork(1, 1000));
        //t1.Start();
        //var t2 = new Task(() => doWork(2, 3000));
        //t2.Start();
        //var t3 = new Task(() => doWork(3, 1500));
        //t3.Start();

        //Console.WriteLine("Press any key to exit....!!");
        //Console.ReadKey();

        //Task t1 = Task.Factory.StartNew(() => doWork(1, 1000));
        //Task t2 = Task.Factory.StartNew(() => doWork(2, 2500));
        //Task t3 = Task.Factory.StartNew(() => doWork(3, 1500));

        //Console.ReadKey();

        try
        {
            Task t1 = Task.Factory.StartNew(() => doWork(1, 1000)).ContinueWith((prev) => doOtherWork(1, 2000));
            Task t2 = Task.Factory.StartNew(() => doWork(2, 2500)).ContinueWith((prev) => doOtherWork(2, 3500));
            Task t3 = Task.Factory.StartNew(() => doWork(3, 1500)).ContinueWith((prev) => doOtherWork(3, 4000));
            Task t4 = Task.Factory.StartNew(() => doWork(4, 3000)).ContinueWith((prev) => doOtherWork(4, 5000));

            Task.WaitAll(t1, t2, t3, t4);
        }
        catch (AggregateException ex)
        {
            ex.Handle(e =>
            {

                Console.WriteLine("Exception time");
                return true;
            }

            );
        }

        Task t1 = Task.Factory.StartNew(() => doWork(1, 1000)).ContinueWith((prev) => doOtherWork(1, 2000));
        Task t2 = Task.Factory.StartNew(() => doWork(2, 2500)).ContinueWith((prev) => doOtherWork(2, 3500));
        Task t3 = Task.Factory.StartNew(() => doWork(3, 1500)).ContinueWith((prev) => doOtherWork(3, 4000));
        Task t4 = Task.Factory.StartNew(() => doWork(4, 3000)).ContinueWith((prev) => doOtherWork(4, 5000));

        Console.ReadKey();
    }

    private static void doWork(int id, int sleep)
    {
        Console.WriteLine("Task {0} is beginning", id);
        Thread.Sleep(sleep);
        Console.WriteLine("Task {0} is Completed", id);

    }
    private static void doOtherWork(int id, int sleep)
    {
        Console.WriteLine("Other Task {0} is beginning", id);
        Thread.Sleep(sleep);
        Console.WriteLine("Other Task {0} is Completed", id);

    }
}
