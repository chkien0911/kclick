

using System.Collections.Generic;

namespace KClick.Configuration
{
    public class Action
    {
        public int No { get; set; }
        public string Name { get; set; }
        public List<Config> Configs { get; set; } = new List<Config>();
        public bool IsRun { get; set; }
    }
}
