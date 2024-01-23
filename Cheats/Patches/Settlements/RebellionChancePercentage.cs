using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Settlements;

namespace Cheats.Patches.Settlements
{
    [HarmonyPatch(typeof(RebellionsCampaignBehavior), "CheckRebellionEvent")]
    public static class RebellionChancePercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CheckRebellionEvent(
            ref Settlement settlement,
            ref bool __result)
        {
            try
            {
                if (settlement.IsPlayerSettlement()
                    && SettingsManager.SettlementsNeverRebel.IsChanged)
                {
                    __result = false;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(RebellionChancePercentage));
            }
        }
    }
}
