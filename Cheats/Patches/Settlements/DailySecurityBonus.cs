using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Settlements;

namespace Cheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.SecurityChange), MethodType.Getter)]
    public static class DailySecurityBonus
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void SecurityChange(ref Town __instance, ref float __result)
        {
            try
            {
                if (__instance.IsPlayerTown()
                    && SettingsManager.DailySecurityBonus.IsChanged)
                {
                    __result += SettingsManager.DailySecurityBonus.Value;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(DailySecurityBonus));
            }
        }
    }
}
