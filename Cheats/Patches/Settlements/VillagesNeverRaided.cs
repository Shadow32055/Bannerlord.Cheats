using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;

namespace Cheats.Patches.Settlements
{
    [HarmonyPatch(typeof(StartBattleAction), nameof(StartBattleAction.ApplyStartRaid))]
    public static class VillagesNeverRaided
    {
        [UsedImplicitly]
        [HarmonyPrefix]
        public static bool ApplyStartRaid(
            ref MobileParty attackerParty,
            ref Settlement settlement)
        {
            if (settlement.IsPlayerSettlement()
                && SettingsManager.VillagesNeverRaided.IsChanged)
            {
                return false;
            }

            return true;
        }
    }
}