using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.MountAndBlade.View;

namespace ArmourVariationManager
{
    [HarmonyPatch]
    public static class ItemObjectPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(ItemCollectionElementViewExtensions), "GetMultiMesh", typeof(ItemObject), typeof(bool), typeof(bool), typeof(bool))]
        public static void OverrideMetaMesh(ref MetaMesh __result, ItemObject item, bool isFemale, bool hasGloves, bool needBatchedVersion)
        {
            if(__result != null && item.HasArmorComponent && item.HasAdditionalMeshes())
            {
                var data = item.GetVariation();
                if(data != null)
                {
                    var check = __result.HasAnyLods() || __result.HasAnyGeneratedLods();
                    MetaMesh finalMesh = __result;
                    List<MetaMesh> meshes = new List<MetaMesh>();
                    List<MetaMesh> clothMeshes = new List<MetaMesh>();
                    foreach (var mesh in data.AdditionalMeshes)
                    {
                        var copy = MetaMesh.GetCopy(mesh.MeshName, true, false);
                        if (copy.HasClothData())
                        {
                            clothMeshes.Add(copy);
                        }
                        else meshes.Add(copy);
                    }
                    foreach(var mesh in meshes)
                    {
                        finalMesh.MergeMultiMeshes(mesh);
                    }
                    foreach(var mesh in clothMeshes)
                    {
                        finalMesh.MergeMultiMeshes(mesh);
                        finalMesh.AssignClothBodyFrom(mesh);
                    }
                    for (int i = 0; i < finalMesh.MeshCount; i++)
                    {
                        var mesh = finalMesh.GetMeshAtIndex(i);
                        var material = mesh.GetMaterial();
                        material.SetEnableSkinning(true);
                    }
                    check = finalMesh.HasAnyLods() || finalMesh.HasAnyGeneratedLods();
                    __result = finalMesh;
                }
            }
        }
    }
}
