using System.Reflection;
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
        StartCoroutine(MoveInHomePage());
    }

    #endregion

    #region Function - HomePage

    private IEnumerator MoveInHomePage()
    {
        // Init Page
        homePage.InitPage();

        // Init Page Element
        homePage.o_NewGameButton.InitObject(HomePage_O_NewGameButtonPointerClickCallback);

        // Wait Home Page Fade In Finished
        yield return homePage.FadeInCoroutine();
    }

    private void HomePage_O_NewGameButtonPointerClickCallback()
    {
        Debug.Log(MethodBase.GetCurrentMethod().Name);

        // ToDo:
    }

    private void HomePage_O_LoadGameButtonPointerClickCallback()
    {
        Debug.Log(MethodBase.GetCurrentMethod().Name);

        // ToDo:
    }

    private void HomePage_O_QuitGameButtonPointerClickCallback()
    {
        Debug.Log(MethodBase.GetCurrentMethod().Name);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    #endregion
}
