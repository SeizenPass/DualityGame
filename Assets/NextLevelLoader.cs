using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V20;
using UnityEngine;

public class NextLevelLoader : MonoBehaviour
{
    public LoadEventChannelSO loadEvent;
    public LayerMask layerMask;
    public GameSceneSO[] scenesToLoad;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMaskUtils.CompareLayers(layerMask, other.gameObject.layer))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        loadEvent.RaiseEvent(scenesToLoad, true);
    }
}
