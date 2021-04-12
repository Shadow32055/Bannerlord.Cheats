﻿using BannerlordCheats.Extensions;
using BannerlordCheats.Localization;
using BannerlordCheats.Settings;
using HarmonyLib;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine.Screens;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace BannerlordCheats.Patches.General
{
    [HarmonyPatch(typeof(Module), "OnApplicationTick")]
    public static class InfluenceCheatPatch
    {
        [HarmonyPostfix]
        public static void OnApplicationTick()
        {
            if (BannerlordCheatsSettings.TryGetModifiedValue(x => x.EnableHotkeys, out var enableHotkeys)
                && enableHotkeys
                && ScreenManager.TopScreen is GauntletClanScreen
                && Keys.IsKeyPressed(InputKey.LeftControl, InputKey.X))
            {
                Hero.MainHero.AddInfluenceWithKingdom(1000);

                InformationManager.DisplayMessage(new InformationMessage(L10N.GetText("AddInfluenceMessage"), Color.White));
            }
        }
    }
}
