using StardewModdingAPI;
using StardewModdingAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVEnchantedWeapons.Helpers
{
    public static class HolderHelper
    {
        private static Dictionary<SButton, DateTime> keyPresses = new Dictionary<SButton, DateTime>();

        public static void SetReleaseWindow(SButton button, double releaseWindowMs, IMonitor monitor)
        {
            var releaseTime = DateTime.Now.AddMilliseconds(releaseWindowMs);
            if (keyPresses.ContainsKey(button))
            {
                monitor.Log($"Button {button} is already in dictionary - adding it with a release time of {releaseTime}");
                keyPresses[button] = releaseTime;
            }
            else
            {
                monitor.Log($"Button {button} is not in dictionary - adding it with a release time of {releaseTime}");
                keyPresses.Add(button, releaseTime);
            }
        }

        public static bool CheckReleasedWindow(SButton button, IMonitor monitor)
        {
            if (keyPresses.ContainsKey(button))
            {
                var now = DateTime.Now;
                var resolved = (keyPresses[button] <= now);
                monitor.Log($"Button {button} is in dictionary target is {keyPresses[button]} and it is currently {now} - Charge Resolved: {resolved}");

                return resolved;
            }
            return false;
        }
    }
}
