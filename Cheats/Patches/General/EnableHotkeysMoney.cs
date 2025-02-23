﻿using System;
using Cheats.Extensions;
using Cheats.Localization;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GauntletUI;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.ScreenSystem;

namespace Cheats.Patches.General
{
    [HarmonyPatch(typeof(GameManagerBase), nameof(GameManagerBase.OnTick))]
    public static class EnableHotkeysMoney
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void OnTick(
            ref float dt)
        {
            try
            {
                if (ScreenManager.TopScreen is GauntletInventoryScreen
                    && SettingsManager.EnableHotkeys.Value)
                {
                    if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.LeftShift, InputKey.X))
                    {
                        Hero.MainHero.ChangeHeroGold(100000);

                        Message.Show(string.Format(L10N.GetText("AddGoldMessage"), 100000));
                    }
                    else if (Keys.IsKeyPressed(InputKey.LeftControl, InputKey.X))
                    {
                        Hero.MainHero.ChangeHeroGold(1000);

                        Message.Show(string.Format(L10N.GetText("AddGoldMessage"), 1000));
                    }
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(EnableHotkeysMoney));
            }
        }
    }
}
