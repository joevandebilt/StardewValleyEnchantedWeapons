using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI.Events;
using SVEnchantedWeapons.Helpers;
using StardewValley;
using StardewValley.Tools;

namespace SVEnchantedWeapons
{
    public class SVEWMod : Mod
    {
        public override void Entry(IModHelper helper)
        {
            //Add the hold button event
            helper.Events.Input.ButtonPressed += Input_ButtonPressed;

            //Add the button released event
            helper.Events.Input.ButtonReleased += Input_ButtonReleased;
        }

        private void Input_ButtonReleased(object sender, ButtonReleasedEventArgs e)
        {
            if (Context.IsPlayerFree)
            {
                this.Monitor.Log($"Player released {e.Button}.", LogLevel.Debug);
                if (HolderHelper.CheckReleasedWindow(e.Button, this.Monitor)) {
                    //Fire enchantment
                    this.Monitor.Log($"Player held the button for the required amount of time", LogLevel.Debug);
                }
            }
        }

        private void Input_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (Context.IsPlayerFree)
            {
                this.Monitor.Log($"Player pressed {e.Button}.", LogLevel.Debug);
                if (e.Button == SButton.MouseLeft)
                {
                    if (Game1.player.CurrentItem as MeleeWeapon != null)
                    {
                        this.Monitor.Log($"Player is charging a weapon - {Game1.player.CurrentItem.Name} - isCharging: {Game1.player.isCharging}", LogLevel.Debug);
                        HolderHelper.SetReleaseWindow(e.Button, 1000, this.Monitor);
                    }
                }
            }
        }
    }
}
