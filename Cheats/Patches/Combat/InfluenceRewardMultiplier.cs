using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace Cheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.CalculateInfluenceGain))]
    public static class InfluenceRewardMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateInfluenceGain(
            ref PartyBase party,
            ref float influenceValueOfBattle,
            ref float contributionShare,
            ref ExplainedNumber __result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && SettingsManager.InfluenceRewardMultiplier.IsChanged)
                {
                    __result.AddMultiplier(SettingsManager.InfluenceRewardMultiplier.Value);
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(InfluenceRewardMultiplier));
            }
        }
    }
}
