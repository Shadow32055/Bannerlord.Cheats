﻿using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GameComponents;
using TaleWorlds.MountAndBlade;

namespace Cheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxAgentStatCalculateModel), nameof(SandboxAgentStatCalculateModel.UpdateAgentStats))]
    public static class InstantCrossbowReload
    {
        [UsedImplicitly]
        [HarmonyPrefix]
        public static void UpdateAgentStats(
            ref Agent agent,
            ref AgentDrivenProperties agentDrivenProperties)
        {
            try
            {
                if (agent.IsPlayer()
                    && SettingsManager.InstantCrossbowReload.IsChanged)
                {
                    agentDrivenProperties.ReloadSpeed = 10f;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(InstantCrossbowReload));
            }
        }
    }
}
