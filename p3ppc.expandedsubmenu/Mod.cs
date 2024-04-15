using p3ppc.expandedsubmenu.Configuration;
using p3ppc.expandedsubmenu.Template;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using BF.File.Emulator;
using BF.File.Emulator.Interfaces;

namespace p3ppc.expandedsubmenu
{
    /// <summary>
    /// Your mod logic goes here.
    /// </summary>
    public class Mod : ModBase // <= Do not Remove.
    {
        /// <summary>
        /// Provides access to the mod loader API.
        /// </summary>
        private readonly IModLoader _modLoader;

        /// <summary>
        /// Provides access to the Reloaded.Hooks API.
        /// </summary>
        /// <remarks>This is null if you remove dependency on Reloaded.SharedLib.Hooks in your mod.</remarks>
        private readonly IReloadedHooks? _hooks;

        /// <summary>
        /// Provides access to the Reloaded logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Entry point into the mod, instance that created this class.
        /// </summary>
        private readonly IMod _owner;

        /// <summary>
        /// Provides access to this mod's configuration.
        /// </summary>
        private Config _configuration;

        /// <summary>
        /// The configuration of the currently executing mod.
        /// </summary>
        private readonly IModConfig _modConfig;
        private IBfEmulator _bfEmulator;

        public Mod(ModContext context)
        {
            _modLoader = context.ModLoader;
            _hooks = context.Hooks;
            _logger = context.Logger;
            _owner = context.Owner;
            _configuration = context.Configuration;
            _modConfig = context.ModConfig;

            var bfEmulatorController = _modLoader.GetController<IBfEmulator>();
            if (bfEmulatorController == null || !bfEmulatorController.TryGetTarget(out _bfEmulator))
            {
                _logger.WriteLine($"Unable to get controller for BF Emulator, p3ppc.expandedsubmenu won't work :(", System.Drawing.Color.Red);
                return;
            }

            // Set whether mod menu should be shown or hidden
            var modDir = _modLoader.GetDirectoryForModId(_modConfig.ModId);
            var flowFile = Path.Combine(modDir, "BF", $"{(_configuration.ShowModMenu ? "Show" : "Hide")}ModMenu.flow");
            foreach (var flowRoute in Directory.EnumerateFiles(modDir, "h*_*.flow", SearchOption.AllDirectories))
            {
                _logger.WriteLine($"{flowFile}, {Path.GetFileName(flowRoute)}");

                _bfEmulator.AddFile(flowFile, Path.GetFileName(flowRoute));
            }

            _bfEmulator.AddFile(flowFile, "field.flow");
            _bfEmulator.AddFile(flowFile, "scheduler_04.flow");
        }

        #region Standard Overrides
        public override void ConfigurationUpdated(Config configuration)
        {
            // Apply settings from configuration.
            // ... your code here.
            _configuration = configuration;
            _logger.WriteLine($"[{_modConfig.ModId}] Config Updated: Applying");
        }
        #endregion

        #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Mod() { }
#pragma warning restore CS8618
        #endregion
    }
}