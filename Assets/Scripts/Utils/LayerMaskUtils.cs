using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayerMaskUtils
{
    public static bool CompareLayerMasks(LayerMask firstLayer, LayerMask secondLayer) {
        return CompareLayers(firstLayer.value, secondLayer.value);
    }

    public static bool CompareLayers(int firstLayer, int secondLayer) {
        return (firstLayer & (1 << secondLayer)) > 0;
    }
}
