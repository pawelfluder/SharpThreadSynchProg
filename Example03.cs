namespace SharpThreadSynchProg
{
    internal class Example03
    {
        private AutoResetEvent _are = new AutoResetEvent(true);
        private Mutex _mutex = new Mutex();

        public void Main(Action action)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(action.Invoke).Start();
            }

            //_are.Set();
            //_mutex.ReleaseMutex();
        }

        public void Case01()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Write task wating..");
            _are.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Write task doing..");
            WriteJob();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Write task completed..");
            _are.Set();
        }

        public void Case02()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Write task wating..");
            _mutex.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Write task doing..");
            WriteJob();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Write task completed..");
            _mutex.ReleaseMutex();
        }

        private void WriteJob()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Write job started..");
            Thread.Sleep(5 * 1000);
            //throw new Exception();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Write job completed..");
        }
    }
}

