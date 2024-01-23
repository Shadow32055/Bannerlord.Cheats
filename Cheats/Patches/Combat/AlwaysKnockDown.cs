using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace Cheats.Patches.Combat
{
    public static class AlwaysKnockDown
    {
        public static void DecideAgentKnockedByBlow(
            ref Agent attackerAgent,
            ref Agent victimAgent,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData attackerWeapon,
            ref Blow blow)
        {
            try
            {
                if (attackerAgent.IsPlayer()
                    && SettingsManager.AlwaysKnockDown.IsChanged)
                {
                    blow.BlowFlag &= ~BlowFlags.ShrugOff;
                    blow.BlowFlag |= BlowFlags.KnockDown;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(AlwaysKnockDown));
            }
        }
    }

    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.DecideAgentKnockedDownByBlow))]
    public static class AlwaysKnockDown_Sandbox
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void DecideAgentKnockedByBlow(
            ref Agent attackerAgent,
            ref Agent victimAgent,
            ref AttackCollisionData collisionData,
            ref WeaponComponentData attackerWeapon,
            ref Blow blow)
            => AlwaysKnockDown.DecideAgentKnockedByBlow(
                ref attackerAgent,
                ref victimAgent,
                ref collisionData,
                ref attackerWeapon,
                ref blow);
    }
}
