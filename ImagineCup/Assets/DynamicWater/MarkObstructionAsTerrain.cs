using UnityEngine;

#if !UNITY_3_5
namespace LostPolygon.DynamicWaterSystem {
#endif
    /// <summary>
    /// This class does nothing, it's presence just marks that the object
    /// it is attached to must be be processed for obstruction mask
    /// in a special way.
    /// </summary>
    public class MarkObstructionAsTerrain : MonoBehaviour {
    }
#if !UNITY_3_5
}
#endif