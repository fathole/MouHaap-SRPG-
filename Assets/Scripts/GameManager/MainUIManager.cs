using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainUI;

public class MainUIManager : SceneManagerBase
{
    #region Declaration

    public static MainUIManager instance;

    public HomePage homePage;

    #endregion

    #region Function - Unity Event

    private void Awake()
    {
        instance = this;        
    }

    #endregion

    #region Function - Init

    public override void InitScene()
    {
        Debug.Log("--- MainUIManager: InitScene ---");

        // Init Page
        homePage.InitPage();

        // Move In First Page
        StartCoroutine(homePage.FadeInCoroutine());
    }

    #endregion
}
