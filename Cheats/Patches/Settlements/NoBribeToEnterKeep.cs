using System;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;

namespace Cheats.Patches.Settlements
{
    [HarmonyPatch(typeof(DefaultBribeCalculationModel), nameof(DefaultBribeCalculationModel.IsBribeNotNeededToEnterKeep))]
    public static class NoBribeToEnterKeep
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void IsBribeNotNeededToEnterKeep(Settlement settlement, ref bool __result)
        {
            try
            {
                if (SettingsManager.NoBribeToEnterKeep.IsChanged)
                {
                    __result = true;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(NoBribeToEnterKeep));
            }
        }
    }
}
