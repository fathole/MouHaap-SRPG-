using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIManager : SceneManagerBase
{
    public static MainUIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public override void InitScene()
    {
        Debug.Log("--- MainUIManager: InitScene ---");               
    }
}
