using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.View.Map;

namespace Cheats.Patches.General
{
    [HarmonyPatch(typeof(MapScreen), nameof(MapScreen.OpenEncyclopedia))]
    public static class EnableHotkeyTipsEncyclopedia
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OpenEncyclopedia()
        {
            try
            {
                if (SettingsManager.EnableHotkeys.Value
                    && SettingsManager.EnableHotkeyTips.Value)
                {
                    Message.Show("Encyclopedia Screen Cheat Hotkeys:");
                    Message.Show("CTRL + H: Add 1 soldier of the selected troop type to the party.");
                    Message.Show("CTRL + SHIFT + H: Add 10 soldiers of the selected troop type to the party.");
                    Message.Show("CTRL + X: Kill the selected character.");
                    Message.Show("CTRL + H: Change to the selected character.");
                    Message.Show("CTRL + H: Transfer ownership of settlement to you.");
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(EnableHotkeyTipsEncyclopedia));
            }
        }
    }
}
