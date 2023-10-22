namespace SharpThreadSynchProg
{
    internal class Example01
    {
        private object _locker01 = new object();
        private object _locker02 = new object();

        public void Main(Action action)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(action.Invoke).Start();
            }
        }

        public void Case01()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting..");
            Work();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed..");
        }

        public void Case02()
        {
            lock (_locker01)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting..");
                Work();
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed..");
            }
        }

        public void Case03()
        {
            Monitor.Enter(_locker02);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting..");
            Work();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed..");
            Monitor.Exit(_locker02);
        }

        public void Case04()
        {
            try
            {
                Monitor.Enter(_locker02);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting..");
                Work();
            }catch
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed with exception!");
            }
            finally
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed..");
                Monitor.Exit(_locker02);
            }
        }

        private void Work()
        {
            Thread.Sleep(2000);
            throw new Exception();
        }
    }
}
