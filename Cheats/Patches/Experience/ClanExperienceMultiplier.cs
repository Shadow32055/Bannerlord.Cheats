﻿using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;

namespace Cheats.Patches.Experience
{
    [HarmonyPatch(typeof(HeroDeveloper), nameof(HeroDeveloper.AddSkillXp))]
    public static class ClanExperienceMultiplier
    {
        [UsedImplicitly]
        [HarmonyPrefix]
        public static void AddSkillXp(
            ref SkillObject skill,
            ref float rawXp,
            ref bool isAffectedByFocusFactor,
            ref bool shouldNotify,
            ref HeroDeveloper __instance)
        {
            if (__instance.Hero.IsPlayerClan()
                && !__instance.Hero.IsPlayer()
                && !__instance.Hero.IsPlayerCompanion()
                && SettingsManager.ClanExperienceMultiplier.IsChanged)
            {
                rawXp *= SettingsManager.ClanExperienceMultiplier.Value;
            }
        }
    }
}