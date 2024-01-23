using Cheats.Extensions;
using Cheats.Localization;
using HarmonyLib;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.ModuleManager;
using TaleWorlds.MountAndBlade;

namespace Cheats {
    [UsedImplicitly]
    public class Cheats : MBSubModuleBase
    {
        private static bool PatchesApplied = false;

        public override void OnGameInitializationFinished(Game game)
        {
            base.OnGameInitializationFinished(game);

            if (!(game.GameType is Campaign) || Cheats.PatchesApplied)
            {
                return;
            }

            var harmony = new Harmony("BannerlordCheats");

            var assembly = typeof(Cheats).Assembly;

            var types = AccessTools.GetTypesFromAssembly(assembly);

            var failedPatches = new List<string>();

            foreach (var type in types)
            {
                try
                {
                    new PatchClassProcessor(harmony, type).Patch();
                }
                catch (HarmonyException)
                {
                    failedPatches.Add(type.Name);
                }
            }

            Cheats.PatchesApplied = true;

            if (failedPatches.Any())
            {
                InformationManager.ShowInquiry(new InquiryData(
                    L10N.GetText("ModFailedLoadWarningTitle"),
                    L10N.GetTextFormat("ModFailedLoadWarningMessage", string.Join(Environment.NewLine, failedPatches)),
                    true,
                    false,
                    L10N.GetText("ModWarningMessageConfirm"),
                    null,
                    null,
                    null));
            }
        }

        internal static void LogError(Exception e, Type type)
        {
            string errorFilePath;

            try
            {
                errorFilePath = Cheats.CreateErrorFile(e, type);
            }
            catch
            {
                return;
            }

            try
            {
                InformationManager.ShowInquiry(new InquiryData(
                    L10N.GetText("ModExceptionTitle"),
                    L10N.GetTextFormat("ModExceptionMessage", errorFilePath),
                    true,
                    false,
                    L10N.GetText("ModWarningMessageConfirm"),
                    null,
                    null,
                    null));
            }
            catch
            {
                try
                {
                    Message.Show(L10N.GetTextFormat("ModExceptionMessage", errorFilePath), Colors.Red);
                }
                catch
                {
                    // If this fails everything is lost anyways
                }
            }
        }

        private static string CreateErrorFile(Exception e, Type type = null)
        {
            var errorFileName = $"Error-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.txt";

            var assemblyLocation = Assembly.GetAssembly(typeof(Cheats)).Location;

            var location = Path.GetDirectoryName(assemblyLocation);

            var errorFilePath = Path.Combine(location, errorFileName);

            var errorMessage = new StringBuilder();

            errorMessage.AppendLine("Thanks a lot for helping to improve this mod!");
            errorMessage.AppendLine("You could drop the contents of this file into https://pastebin.com/ and post a link to the file");
            errorMessage.AppendLine("in the NexusMods posts page at https://www.nexusmods.com/mountandblade2bannerlord/mods/1839?tab=posts");

            errorMessage.AppendLine();
            errorMessage.AppendLine("Modules:");

            foreach (var module in ModuleHelper.GetModules())
            {
                errorMessage.AppendLine($"{module.Name} {module.Version}");
            }

            if (type != null)
            {
                errorMessage.AppendLine();
                errorMessage.AppendLine("Harmony Patch:");

                var patch = type.GetCustomAttribute<HarmonyPatch>();

                errorMessage.AppendLine($"Type: {type.FullName}");
                errorMessage.AppendLine($"Declaring Type: {patch.info.declaringType.FullName}");
                errorMessage.AppendLine($"Method: {patch.info.methodName}");
            }

            errorMessage.AppendLine();
            errorMessage.AppendLine("Exception:");
            errorMessage.AppendLine(e.ToString());

            File.WriteAllText(errorFilePath, errorMessage.ToString());

            return errorFilePath;
        }
    }
}
