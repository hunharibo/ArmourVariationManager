using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArmourVariationManager
{
    [Serializable]
    public class ArmourVariation
    {
        [XmlAttribute]
        public string VariationId { get; set; } = string.Empty;
        public List<AdditionalMesh> AdditionalMeshes = new List<AdditionalMesh>();
    }

    [Serializable]
    [XmlRoot("ArmourVariations")]
    public class ArmourVariations : List<ArmourVariation> { }
}
