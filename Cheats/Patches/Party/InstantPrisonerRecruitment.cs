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
    [HarmonyPatch(typeof(DefaultPrisonerRecruitmentCalculationModel), nameof(DefaultPrisonerRecruitmentCalculationModel.CalculateRecruitableNumber))]
    public static class InstantPrisonerRecruitment
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void  CalculateRecruitableNumber(ref PartyBase party, ref CharacterObject character, ref int __result)
        {
            try
            {
                if (party.IsPlayerParty()
                    && !character.IsHero()
                    && SettingsManager.InstantPrisonerRecruitment.IsChanged)
                {
                    __result = party.PrisonRoster.GetTroopCount(character);
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(InstantPrisonerRecruitment));
            }
        }
    }
}
