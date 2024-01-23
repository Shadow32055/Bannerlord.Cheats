using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Party;

namespace Cheats.Patches.Experience
{
    [HarmonyPatch(typeof(DefaultCombatXpModel), nameof(DefaultCombatXpModel.GetXpFromHit))]
    public static class TroopExperienceMultiplier
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetXpFromHit(
            ref CharacterObject attackerTroop,
            ref CharacterObject captain,
            ref CharacterObject attackedTroop,
            ref PartyBase party,
            ref int damage,
            ref bool isFatal,
            ref CombatXpModel.MissionTypeEnum missionType,
            ref int xpAmount)
        {
            try
            {
                if (party.IsPlayerParty()
                    && !attackerTroop.IsPlayer()
                    && SettingsManager.TroopExperienceMultiplier.IsChanged)
                {
                    xpAmount = (int) Math.Round(xpAmount * SettingsManager.TroopExperienceMultiplier.Value);
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(TroopExperienceMultiplier));
            }
        }
    }
}
