using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public LayerMask targetLayers;

    private void OnTriggerStay2D(Collider2D other) {
        if (LayerMaskUtils.CompareLayerMasks(other.gameObject.layer, targetLayers)) {
            Debug.Log("Player!");
        }
    }
}
