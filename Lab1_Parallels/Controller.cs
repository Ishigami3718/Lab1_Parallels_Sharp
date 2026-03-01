using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_Parallels
{
    public class Controller
    {
        private volatile bool[] isRunning;
        int[] times;
        Dictionary<int, int> dict = new Dictionary<int, int>()
        {
            { 0, 3000 },
            { 1, 5000 },
            { 2, 7000 },
            { 3, 10000 },
            { 4, 12000 },
            { 5, 15000 },
        };
        public bool this[int i]
        {
            get { return isRunning[i]; } 
        }
        public Controller(int count) 
        { 
            isRunning = new bool[count];
            times = new int[count]; 
            Random rnd = new();
            for (int i = 0; i < count; i++)
            {
                times[i] = dict[rnd.Next(0,6)];
            }
        }

        public void Start()
        {
            for (int i = 0; i < isRunning.Length; i++)
            {
                int localI = i;
                new Thread(() =>
                {
                    Thread.Sleep(times[localI]);
                    isRunning[localI] = true;
                }).Start();
            }
        }
    }
}
