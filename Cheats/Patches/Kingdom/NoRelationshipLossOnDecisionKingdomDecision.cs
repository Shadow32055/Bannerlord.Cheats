using Cheats.Settings;
using HarmonyLib;
using System;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Election;

namespace Cheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(KingdomElection), nameof(KingdomElection.GetRelationChangeWithSponsor))]
    public static class NoRelationshipLossOnDecisionKingdomDecision
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetRelationChangeWithSponsor(Supporter.SupportWeights supportWeight, bool isOpposingSides, ref int __result)
        {
            try
            {
                if (SettingsManager.NoRelationshipLossOnDecision.IsChanged)
                {
                    __result = Math.Max(__result, 0);
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(NoRelationshipLossOnDecisionKingdomDecision));
            }
        }
    }
}
