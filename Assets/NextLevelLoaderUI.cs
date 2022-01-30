using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelLoaderUI : MonoBehaviour
{
    public LoadEventChannelSO loadEvent;
    public GameSceneSO[] scenesToLoad;
    public void LoadNextLevel()
    {
        loadEvent.RaiseEvent(scenesToLoad, true);
    }
}
