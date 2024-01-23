using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.Settlements;

namespace Cheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Village), nameof(Village.HearthChange), MethodType.Getter)]
    public static class DailyHearthsBonus
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void HearthChange(ref Village __instance, ref float __result)
        {
            try
            {
                if (__instance.IsPlayerVillage()
                    && SettingsManager.DailyHearthsBonus.IsChanged)
                {
                    __result += SettingsManager.DailyHearthsBonus.Value;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(DailyHearthsBonus));
            }
        }
    }
}
