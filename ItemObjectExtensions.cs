using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.ObjectSystem;

namespace ArmourVariationManager
{
    public static class ItemObjectExtensions
    {
        public static bool HasAdditionalMeshes(this ItemObject item)
        {
            var list = ArmourVariationManager.Instance.GetVariationData(item.GetVariationId());
            return list != null && list.AdditionalMeshes != null && list.AdditionalMeshes.Count > 0;
        }

        public static string GetVariationId(this ItemObject item)
        {
            var elements = item.StringId.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (elements.Count() > 1)
            {
                return elements[elements.Length - 1];
            }
            else return string.Empty;
        }

        public static ArmourVariation? GetVariation(this ItemObject item)
        {
            if (item.HasAdditionalMeshes()) return ArmourVariationManager.Instance.GetVariationData(item.GetVariationId());
            else return null;
        }
    }
}
