using System.ComponentModel;
using p3ppc.expandedsubmenu.Template.Configuration;
namespace p3ppc.expandedsubmenu.Configuration
{
 public class Config : Configurable<Config>
 {
  [DisplayName("Mod Menu")][Description("Makes the Mod Menu available in the in game options.")][DefaultValue(false)] public bool ShowModMenu { get; set; } = false;
 }
 public class ConfiguratorMixin : ConfiguratorMixinBase { }
}
