using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_Parallels
{
    public class Controller
    {
        private volatile bool[] isRunning;
        (int,int)[] times;
        Dictionary<int, int> dict = new Dictionary<int, int>()
        {
            { 0, 7000 },
            { 1, 5000 },
            { 2, 3000 },
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
            times = new (int,int)[count]; 
            Random rnd = new();
            for (int i = 0; i < count; i++)
            {
                times[i].Item1 = dict[rnd.Next(0,6)];
                times[i].Item2 = i;
            }
        }

        public void Start()
        {
            times = times.OrderBy(times => times.Item1).ToArray();
            Thread.Sleep(times[0].Item1);
            isRunning[times[0].Item2] = true;
            for (int i = 1; i < isRunning.Length; i++)
            {
                Thread.Sleep(times[i].Item1 - times[i - 1].Item1);
                isRunning[times[i].Item2] = true;
            }
        }
    }
}
