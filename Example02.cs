namespace SharpThreadSynchProg
{
    internal class Example02
    {
        private ManualResetEvent _mre = new ManualResetEvent(false);

        public void Main()
        {
            new Thread(WriteTask).Start();

            for (int i = 0; i < 5; i++)
            {
                new Thread(ReadTask).Start();
            }
        }

        public void WriteTask()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Write task started..");
            _mre.Reset();
            WriteJob();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Write task completed..");
            _mre.Set();
        }

        public void ReadTask()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Read task wating..");
            _mre.WaitOne();
            ReadJob();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Read task completed..");
        }

        private void ReadJob()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Read job started..");
            Thread.Sleep(2 * 1000);
            //throw new Exception();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Read job completed..");
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

