using System;
using Cheats.Settings;
using HarmonyLib;
using System.Linq;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Election;

namespace Cheats.Patches.Kingdom
{
    [HarmonyPatch(typeof(DecisionOutcome), nameof(DecisionOutcome.TotalSupportPoints), MethodType.Getter)]
    public static class KingdomDecisionWeightMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void Getter(ref DecisionOutcome __instance, ref float __result)
        {
            try
            {
                if (__instance.SupporterList.Any(x => x.IsPlayer)
                    && SettingsManager.KingdomDecisionWeightMultiplier.IsChanged)
                {
                    __result *= SettingsManager.KingdomDecisionWeightMultiplier.Value;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(KingdomDecisionWeightMultiplier));
            }
        }
    }
}
