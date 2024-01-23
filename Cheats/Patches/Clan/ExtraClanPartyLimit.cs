using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;

namespace Cheats.Patches.Clan
{
    [HarmonyPatch(typeof(DefaultClanTierModel), nameof(DefaultClanTierModel.GetPartyLimitForTier))]
    public static class ExtraClanPartyLimit
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetPartyLimitForTier(TaleWorlds.CampaignSystem.Clan clan, int clanTierToCheck, ref int __result)
        {
            try
            {
                if (clan.IsPlayerClan()
                    && SettingsManager.ExtraClanPartyLimit.IsChanged)
                {
                    __result += SettingsManager.ExtraClanPartyLimit.Value;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(ExtraClanPartyLimit));
            }
        }
    }
}
