using System;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;

namespace Cheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DefaultDiplomacyModel), nameof(DefaultDiplomacyModel.GetRelationCostOfDisbandingArmy))]
    public static class NoRelationshipLossOnDecisionArmyDisband
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetRelationCostOfDisbandingArmy(bool isLeaderParty, ref int __result)
        {
            try
            {
                if (SettingsManager.NoRelationshipLossOnDecision.IsChanged)
                {
                    __result = 0;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(NoRelationshipLossOnDecisionArmyDisband));
            }
        }
    }
}
