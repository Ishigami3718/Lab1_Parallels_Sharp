using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_Parallels
{
    public class Controller
    {
        private volatile bool isRunning = false;
        public bool IsRunning => isRunning;
        public Controller() { }

        public void Start()
        {
            Thread.Sleep(3000);
            isRunning = true;
        }
    }
}
