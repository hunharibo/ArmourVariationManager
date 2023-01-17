using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArmourVariationManager
{
    [Serializable]
    public class AdditionalMesh
    {
        [XmlAttribute]
        public string MeshName { get; set; } = string.Empty;
        [XmlAttribute]
        public string MaterialName { get; set; } = string.Empty;
    }
}
