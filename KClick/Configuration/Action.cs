

using System;
using System.Collections.Generic;

namespace KClick.Configuration
{
    public class Action
    {
        public int No { get; set; }
        public string Name { get; set; }
        public List<Config> Configs { get; set; } = new List<Config>();
        public bool IsRun { get; set; }

        public List<Config> GetAdjustedConfigs(bool adjustedAuto = false, int newX = 0, int newY = 0)
        {
            if (adjustedAuto == false || (newX == 0 && newY == 0))
            {
                return Configs;
            }

            var configs = new List<Config>();
            foreach (var config in Configs)
            {
                var adjustedConfig = (Config)config.Clone();
                adjustedConfig.XPos += newX;
                adjustedConfig.YPos += newY;

                adjustedConfig.X2Pos += newX;
                adjustedConfig.Y2Pos += newY;

                adjustedConfig.XPosMoved += newX;
                adjustedConfig.YPosMoved += newY;

                adjustedConfig.XPosIgnored += newX;
                adjustedConfig.YPosIgnored += newY;

                configs.Add(adjustedConfig);
            }

            return configs;
        }

        public List<BoostTime> BoostTime { get; set; } = new List<BoostTime>();
    }

    public class BoostTime
    {
        public int No { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }

    }
}
