namespace SharpThreadSynchProg
{
    public static class Program
    {

        public static void Main(string[] args)
        {
            var example01 = new Example01();
            //example01.Main(example01.Case01);
            //example01.Main(example01.Case02);
            //example01.Main(example01.Case03);
            //example01.Main(example01.Case04);
            
            var example02 = new Example02();
            example02.Main();
            
            Console.ReadLine();
        }
    }
}