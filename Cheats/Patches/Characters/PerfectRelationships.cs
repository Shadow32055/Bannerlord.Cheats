﻿using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem;

namespace Cheats.Patches.Characters
{
    [HarmonyPatch(typeof(Hero), nameof(Hero.GetRelation))]
    public static class PerfectRelationships
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetRelation(Hero otherHero, ref Hero __instance, ref int __result)
        {
            try
            {
                if ((__instance.IsPlayer() || otherHero.IsPlayer())
                    && SettingsManager.PerfectRelationships.IsChanged)
                {
                    __result = 100;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(PerfectRelationships));
            }
        }
    }
}
