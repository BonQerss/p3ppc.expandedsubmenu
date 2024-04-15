using System.ComponentModel;
using p3ppc.expandedsubmenu.Template.Configuration;
using Reloaded.Mod.Interfaces.Structs;

namespace p3ppc.expandedsubmenu.Configuration
{
    public class Config : Configurable<Config>
    {
        /*
            User Properties:
                - Please put all of your configurable properties here.
    
            By default, configuration saves as "Config.json" in mod user config folder.    
            Need more config files/classes? See Configuration.cs
    
            Available Attributes:
            - Category
            - DisplayName
            - Description
            - DefaultValue

            // Technically Supported but not Useful
            - Browsable
            - Localizable

            The `DefaultValue` attribute is used as part of the `Reset` button in Reloaded-Launcher.
        */



        [DisplayName("Show Mod Menu")]
        [Description("If enabled you will be able to access the Mod Menu (make sure to also enable Mod Menu in the in-game options).\nThe Mod Menu is for mod developers and dataminers - it is NOT a \"cheats menu\" for players!\nIf you use it and break your save, you won't get help!")]
        [DefaultValue(false)]
        public bool ShowModMenu { get; set; } = false;
    }

    /// <summary>
    /// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
    /// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
    /// </summary>
    public class ConfiguratorMixin : ConfiguratorMixinBase
    {
        // 
    }
}
