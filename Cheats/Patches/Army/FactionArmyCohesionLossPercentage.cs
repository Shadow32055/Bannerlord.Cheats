using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using ArmyObj = TaleWorlds.CampaignSystem.Army;

namespace Cheats.Patches.Army
{
    [HarmonyPatch(typeof(ArmyObj), nameof(ArmyObj.DailyCohesionChange), MethodType.Getter)]
    public static class FactionArmyCohesionLossPercentage
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CohesionChange(ref ArmyObj __instance, ref float __result)
        {
            try
            {
                if (__instance.IsOfPlayerKingdom()
                    && !__instance.IsPlayerArmy()
                    && SettingsManager.FactionArmyCohesionLossPercentage.IsChanged)
                {
                    var factor = SettingsManager.FactionArmyCohesionLossPercentage.Value / 100f;

                    __result *= factor;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(FactionArmyCohesionLossPercentage));
            }
        }
    }
}
