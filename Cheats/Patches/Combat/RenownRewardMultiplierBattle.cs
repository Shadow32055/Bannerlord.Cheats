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
    [HarmonyPatch(typeof(DefaultBattleRewardModel), nameof(DefaultBattleRewardModel.CalculateRenownGain))]
    public static class RenownRewardMultiplierBattle
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateRenownGain(
            ref PartyBase party,
            ref float renownValueOfBattle,
            ref float contributionShare,
            ref ExplainedNumber __result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && SettingsManager.RenownRewardMultiplier.IsChanged)
                {
                    __result.AddMultiplier(SettingsManager.RenownRewardMultiplier.Value);
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(RenownRewardMultiplierBattle));
            }
        }
    }
}
