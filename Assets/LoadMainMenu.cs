using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMainMenu : MonoBehaviour
{
    public GameSceneSO[] menuToLoad;
    public LoadEventChannelSO loadEventChannelSo;

    public void LoadMenu()
    {
        loadEventChannelSo.RaiseEvent(menuToLoad, true);
    }
}
