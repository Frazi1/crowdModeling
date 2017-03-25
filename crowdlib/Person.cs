using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace crowdlib
{
    public class Person
    {
        public Cell CurrentCell { get; set; }
        public int ID { get; set; }

        private World world;

        private Thread thread;

        public Thread Thread
        {
            get { return thread; }
            private set { thread = value; }
        }

    }
}
