﻿using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(Game), nameof(Game.CheatMode), MethodType.Getter)]
    public static class CheatModeOverridePatch
    {
        [HarmonyPostfix]
        public static void CheatMode(ref bool __result)
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.OverrideCheatMode, out var overrideCheatMode))
            {
                __result |= overrideCheatMode;
            }
        }
    }
}