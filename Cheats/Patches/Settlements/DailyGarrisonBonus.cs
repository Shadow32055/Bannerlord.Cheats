using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Settlements;

namespace Cheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.GarrisonChange), MethodType.Getter)]
    public static class DailyGarrisonBonus
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GarrisonChange(ref Town __instance, ref int __result)
        {
            try
            {
                if (__instance.IsPlayerTown()
                    && SettingsManager.DailyGarrisonBonus.IsChanged)
                {
                    __result += SettingsManager.DailyGarrisonBonus.Value;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(DailyGarrisonBonus));
            }
        }
    }
}
