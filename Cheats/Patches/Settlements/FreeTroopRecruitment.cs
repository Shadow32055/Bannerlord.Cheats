using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;

namespace Cheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultPartyWageModel), nameof(DefaultPartyWageModel.GetTroopRecruitmentCost))]
    public static class FreeTroopRecruitment
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetTroopRecruitmentCost(CharacterObject troop, Hero buyerHero, bool withoutItemCost, ref int __result)
        {
            try
            {
                if (buyerHero.IsPlayer()
                    && SettingsManager.FreeTroopRecruitment.IsChanged)
                {
                    __result = 1;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(FreeTroopRecruitment));
            }
        }
    }
}
