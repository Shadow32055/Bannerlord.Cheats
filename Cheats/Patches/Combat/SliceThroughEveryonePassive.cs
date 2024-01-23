using System;
using Cheats.Extensions;
using Cheats.Settings;
using HarmonyLib;
using JetBrains.Annotations;
using SandBox.GameComponents;
using TaleWorlds.MountAndBlade;

namespace Cheats.Patches.Combat
{
    public static class SliceThroughEveryonePassive
    {
        public static void DecidePassiveAttackCollisionReaction(
            ref Agent attacker,
            ref Agent defender,
            ref bool isFatalHit,
            ref MeleeCollisionReaction __result)
        {
            try
            {
                if (attacker.IsPlayer()
                    && SettingsManager.SliceThroughEveryone.IsChanged)
                {
                    __result = MeleeCollisionReaction.SlicedThrough;
                }
            }
            catch (Exception e)
            {
                Cheats.LogError(e, typeof(SliceThroughEveryonePassive));
            }
        }
    }

    [HarmonyPatch(typeof(SandboxAgentApplyDamageModel), nameof(SandboxAgentApplyDamageModel.DecidePassiveAttackCollisionReaction))]
    public static class SliceThroughEveryonePassive_Sandbox
    {
        [UsedImplicitly]
        [HarmonyPostfix]
        public static void DecidePassiveAttackCollisionReaction(
            ref Agent attacker,
            ref Agent defender,
            ref bool isFatalHit,
            ref MeleeCollisionReaction __result)
            => SliceThroughEveryonePassive.DecidePassiveAttackCollisionReaction(
                ref attacker,
                ref defender,
                ref isFatalHit,
                ref __result);
    }
}
