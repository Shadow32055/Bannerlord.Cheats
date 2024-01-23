using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Settlements;

namespace Cheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.ProsperityChange), MethodType.Getter)]
    public static class DailyProsperityBonus
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void ProsperityChange(ref Town __instance, ref float __result)
        {
            try
            {
                if (__instance.IsPlayerTown()
                    && SettingsManager.DailyProsperityBonus.IsChanged)
                {
                    __result += SettingsManager.DailyProsperityBonus.Value;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(DailyProsperityBonus));
            }
        }
    }
}
