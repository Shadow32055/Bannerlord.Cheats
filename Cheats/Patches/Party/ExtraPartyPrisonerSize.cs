using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace Cheats.Patches.Party
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), nameof(DefaultPartySizeLimitModel.GetPartyPrisonerSizeLimit))]
    public static class ExtraPartyPrisonerSize
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetPartyPrisonerSizeLimit(ref PartyBase party, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && SettingsManager.ExtraPartyPrisonerSize.IsChanged)
                {
                    __result.Add(SettingsManager.ExtraPartyPrisonerSize.Value);
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(ExtraPartyPrisonerSize));
            }
        }
    }
}
