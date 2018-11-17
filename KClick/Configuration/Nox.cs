

using System;
using System.Collections.Generic;

namespace KClick.Configuration
{
    public class Nox
    {
        public int No { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public IntPtr Handle { get; set; }

        public int Width => 500;
        public int High => 400;

        public int X { get; set; }
        public int Y { get; set; }

        public List<Config> Configs { get; set; } = new List<Config>();

        public bool IsRun { get; set; }
        public List<Action> Actions { get; set; } = new List<Action>();
        public bool IsSelected { get; set; }
    }
}
