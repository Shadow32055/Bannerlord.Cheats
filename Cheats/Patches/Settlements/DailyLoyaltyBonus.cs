using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Settlements;

namespace Cheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.LoyaltyChange), MethodType.Getter)]
    public static class DailyLoyaltyBonus
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void LoyaltyChange(ref Town __instance, ref float __result)
        {
            try
            {
                if (__instance.IsPlayerTown()
                    && SettingsManager.DailyLoyaltyBonus.IsChanged)
                {
                    __result += SettingsManager.DailyLoyaltyBonus.Value;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(DailyLoyaltyBonus));
            }
        }
    }
}
