namespace SharpThreadSynchProg
{
    internal class Example03
    {
        private AutoResetEvent _are = new AutoResetEvent(true);

        public void Main()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(WriteTask).Start();
            }
        }

        public void WriteTask()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Write task wating..");
            _are.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Write task doing..");
            WriteJob();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Write task completed..");
            _are.Set();
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

