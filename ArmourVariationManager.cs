using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TaleWorlds.Library;
using TaleWorlds.ModuleManager;
using TaleWorlds.MountAndBlade;

namespace ArmourVariationManager
{
    public class ArmourVariationManager
    {
        //If you integrate the code to your own mod, change this path to where your xml is
        private readonly string _xmlFilePath = ModuleHelper.GetModuleFullPath("ArmourVariationManager") + "ModuleData/" + "armourvariations.xml";
        private ArmourVariations _armourVariationList { get; set; } = new ArmourVariations();

        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static ArmourVariationManager Instance { get; private set; }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MBReadOnlyList<ArmourVariation> ArmourVariations => new MBReadOnlyList<ArmourVariation>(_armourVariationList);

        public ArmourVariationManager()
        {
            Instance = this;
            LoadXml();
        }

        private void LoadXml()
        {
            XmlSerializer ser = new XmlSerializer(typeof(ArmourVariations));
            if (File.Exists(_xmlFilePath))
            {
                var result = ser.Deserialize(File.OpenRead(_xmlFilePath)) as ArmourVariations;
                if (result != null) _armourVariationList = result;
            }
        }

        public ArmourVariation GetVariationData(string id)
        {
            return ArmourVariations.Where(x => x.VariationId == id).FirstOrDefault();
        }
    }
}
