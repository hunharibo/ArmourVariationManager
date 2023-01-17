using HarmonyLib;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;


namespace ArmourVariationManager
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            _ = new ArmourVariationManager();
            Harmony harmony = new Harmony("mod.harmony.armourvariationmanager");
            harmony.PatchAll();
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            InformationManager.DisplayMessage(new InformationMessage(string.Format("Loaded {0} armour variations.", ArmourVariationManager.Instance.ArmourVariations.Count)));
        }
    }
}