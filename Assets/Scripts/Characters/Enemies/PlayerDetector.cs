using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDetector : MonoBehaviour
{
    public LayerMask targetLayers;

    public event UnityAction playerOnSightEvent = delegate {};

    private void OnTriggerStay2D(Collider2D other) {
        if (LayerMaskUtils.CompareLayerMasks(other.gameObject.layer, targetLayers)) {
            playerOnSightEvent.Invoke();
        }
    }
}
