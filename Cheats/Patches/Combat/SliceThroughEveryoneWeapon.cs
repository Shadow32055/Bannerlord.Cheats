using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using TaleWorlds.MountAndBlade;

namespace Cheats.Patches.Combat
{
    [HarmonyPatch(typeof(Mission), "DecideWeaponCollisionReaction")]
    public static class SliceThroughEveryoneWeapon
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void DecideWeaponCollisionReaction(
            ref Blow registeredBlow,
            ref AttackCollisionData collisionData,
            ref Agent attacker,
            ref Agent defender,
            ref MissionWeapon attackerWeapon,
            ref bool isFatalHit,
            ref bool isShruggedOff,
            ref MeleeCollisionReaction colReaction)
        {
            try
            {
                if (attacker.IsPlayer()
                    && SettingsManager.SliceThroughEveryone.IsChanged)
                {
                    colReaction = MeleeCollisionReaction.SlicedThrough;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(SliceThroughEveryoneWeapon));
            }
        }
    }
}
