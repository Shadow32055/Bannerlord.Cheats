﻿using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GameComponents;
using TaleWorlds.MountAndBlade;

namespace Cheats.Patches.Combat
{
    [HarmonyPatch(typeof(SandboxBattleMoraleModel), nameof(SandboxBattleMoraleModel.CalculateMoraleChangeToCharacter))]
    public static class EnemiesNoRunningAway
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void CalculateMoraleChangeToCharacter(
            ref Agent agent,
            ref float maxMoraleChange,
            ref float __result)
        {
            try
            {
                if (agent.IsPlayerEnemy()
                    && SettingsManager.EnemiesNoRunningAway.IsChanged)
                {
                    __result = 0.0f;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(EnemiesNoRunningAway));
            }
        }
    }
}
