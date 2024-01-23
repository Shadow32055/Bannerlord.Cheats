using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace Cheats.Patches.Clan
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), nameof(DefaultPartySizeLimitModel.GetPartyMemberSizeLimit))]
    public static class ExtraClanPartySize
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetPartyMemberSizeLimit(ref PartyBase party, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            try
            {
                if (party.IsPlayerClan()
                    && !party.IsPlayerParty()
                    && SettingsManager.ExtraClanPartySize.IsChanged)
                {
                    __result.Add(SettingsManager.ExtraClanPartySize.Value);
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(ExtraClanPartySize));
            }
        }
    }
}
