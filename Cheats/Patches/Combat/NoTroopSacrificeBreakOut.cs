using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Siege;

namespace Cheats.Patches.Combat
{
    [HarmonyPatch(typeof(DefaultTroopSacrificeModel), nameof(DefaultTroopSacrificeModel.GetLostTroopCountForBreakingOutOfBesiegedSettlement))]
    public static class NoTroopSacrificeBreakOut
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetLostTroopCountForBreakingOutOfBesiegedSettlement(MobileParty party, SiegeEvent siegeEvent, ref int __result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && SettingsManager.NoTroopSacrifice.IsChanged)
                {
                    __result = 0;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(NoTroopSacrificeBreakOut));
            }
        }
    }
}
