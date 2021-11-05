using System;

namespace MonefyTest
{
    interface IGo
    {
        public void Go();
    }
    class Warrior : IGo
    {
        public string Name { get; set; }

        public int AllPath { get; set; } = 0;
        public void Go()
        {
            AllPath += 10;
        }
    }
    class PogWor
    {
        public IGo go;
        public PogWor(IGo g)
        {
            go = g;

        }
        public void GO()
        {
            go.Go();
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            //PogWor pogWor = new();
            
        }
    }
}
