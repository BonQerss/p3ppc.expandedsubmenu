using BF.File.Emulator.Interfaces;
using p3ppc.expandedsubmenu.Configuration;
using p3ppc.expandedsubmenu.Template;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;

namespace p3ppc.expandedsubmenu
{
    public class Mod : ModBase
    {
        private readonly IModLoader _modLoader = null!;
        private readonly ILogger _logger = null!;
        private Config _configuration = null!;
        private readonly IModConfig _modConfig = null!;
        private IBfEmulator? _bfEmulator;

        public Mod(ModContext context)
        {
            _modLoader = context.ModLoader;
            _logger = context.Logger;
            _configuration = context.Configuration;
            _modConfig = context.ModConfig;

            var controller = _modLoader.GetController<IBfEmulator>();
            if (controller == null || !controller.TryGetTarget(out var bfEmulator))
            {
                _logger.WriteLine("expanded submenu could not get bf emulator");
                return;
            }

            _bfEmulator = bfEmulator;
            _modLoader.ModLoaded += ModLoaded;

            RefreshRoutes();

            var modDir = _modLoader.GetDirectoryForModId(_modConfig.ModId);
            _bfEmulator.AddDirectory(Path.Combine(modDir, "FEmulator", "BF", "OtherMods", "DungeonMods", "RareChestTargets"));
        }

        private bool HasMod(string id)
        {
            return _modLoader.GetActiveMods().Any(x => x.Generic.ModId == id);
        }

        private void RefreshRoutes()
        {
            if (_bfEmulator == null)
                return;

            var modDir = _modLoader.GetDirectoryForModId(_modConfig.ModId);
            var flowFile = Path.Combine(modDir, "BF", _configuration.ShowModMenu ? "ShowModMenu.flow" : "HideModMenu.flow");

            foreach (var route in Directory.EnumerateFiles(modDir, "h*_*.flow", SearchOption.AllDirectories))
                _bfEmulator.AddFile(flowFile, Path.GetFileName(route));

            _bfEmulator.AddFile(flowFile, "field.flow");
            _bfEmulator.AddFile(flowFile, "scheduler_04.flow");

            if (HasMod("p3ppc.kotonecutscenes"))
            {
                _logger.WriteLine("found kotone cutscenes project");
                _bfEmulator.AddDirectory(Path.Combine(modDir, "BF", "KCP"));
            }
            else
            {
                _bfEmulator.AddDirectory(Path.Combine(modDir, "BF", "Stock"));
            }

            if (HasMod("p3ppc.nighttimestripmall"))
            {
                _logger.WriteLine("found night time strip mall");
                _bfEmulator.AddDirectory(Path.Combine(modDir, "BF", "NightStripMall"));
            }
        }

        private void ModLoaded(IModV1 mod, IModConfigV1 config)
        {
            if (config.ModId == "p3ppc.kotonecutscenes" || config.ModId == "p3ppc.nighttimestripmall")
                RefreshRoutes();
        }

        public override void ConfigurationUpdated(Config configuration)
        {
            _configuration = configuration;
            RefreshRoutes();
        }

        public Mod() { }
    }
}
