﻿using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GameComponents;
using StoryMode.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace Cheats.Patches.Combat
{
    public static class FriendlyLordsKnockoutOrKilled
    {
        public static void GetAgentStateProbability(
            ref Agent affectorAgent,
            ref Agent effectedAgent,
            ref DamageTypes damageType,
            ref float useSurgeryProbability,
            ref float __result)
        {
            try
            {
                if (effectedAgent.IsHero
                    && effectedAgent.IsPlayerAlly()
                    && effectedAgent.Origin.TryGetParty(out var party)
                    && !party.IsPlayerParty()
                    && SettingsManager.FriendlyLordsKnockoutOrKilled.IsChanged)
                {
                    if (SettingsManager.FriendlyLordsKnockoutOrKilled.Value == KnockoutOrKilled.Killed)
                    {
                        __result = 1.0f;
                    }
                    else if (SettingsManager.FriendlyLordsKnockoutOrKilled.Value == KnockoutOrKilled.Knockout)
                    {
                        __result = 0.0f;
                    }
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(FriendlyLordsKnockoutOrKilled));
            }
        }
    }

    [HarmonyPatch(typeof(DefaultAgentDecideKilledOrUnconsciousModel), nameof(DefaultAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class FriendlyLordsKnockoutOrKilled_Default
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
            => FriendlyLordsKnockoutOrKilled.GetAgentStateProbability(ref affectorAgent, ref effectedAgent, ref damageType, ref useSurgeryProbability, ref __result);
    }

    [HarmonyPatch(typeof(SandboxAgentDecideKilledOrUnconsciousModel), nameof(SandboxAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class FriendlyLordsKnockoutOrKilled_Sandbox
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
            => FriendlyLordsKnockoutOrKilled.GetAgentStateProbability(ref affectorAgent, ref effectedAgent, ref damageType, ref useSurgeryProbability, ref __result);
    }

    [HarmonyPatch(typeof(StoryModeAgentDecideKilledOrUnconsciousModel), nameof(StoryModeAgentDecideKilledOrUnconsciousModel.GetAgentStateProbability))]
    public static class FriendlyLordsKnockoutOrKilled_StoryMode
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void GetAgentStateProbability(Agent affectorAgent, Agent effectedAgent, DamageTypes damageType, float useSurgeryProbability, ref float __result)
            => FriendlyLordsKnockoutOrKilled.GetAgentStateProbability(ref affectorAgent, ref effectedAgent, ref damageType, ref useSurgeryProbability, ref __result);
    }
}