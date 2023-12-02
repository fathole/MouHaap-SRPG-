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
        homePage.o_LoadGameButton.InitObject(HomePage_O_LoadGameButtonPointerClickCallback);
        homePage.o_ExitGameButton.InitObject(HomePage_O_QuitGameButtonPointerClickCallback);
        homePage.o_StoryModeButton.InitObject(HomePage_O_StoryModeButtonPointerClickCallback);
        homePage.o_ChallengeModeButton.InitObject(HomePage_O_ChallengeModeButtonPointerClickCallback);
        homePage.o_RealisticModeButton.InitObject(HomePage_O_RealisticModeButtonPointerClickCallback);
        homePage.o_GameModeBackButton.InitObject(HomePage_O_GameModeBackButtonPointerClickCallback);        

        // Wait Home Page Fade In Finished
        yield return homePage.FadeInCoroutine();
    }

    private void HomePage_O_NewGameButtonPointerClickCallback()
    {
        Debug.Log(MethodBase.GetCurrentMethod().Name);

        homePage.ShowGameModeButtonList();
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

    private void HomePage_O_StoryModeButtonPointerClickCallback()
    {
        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    private void HomePage_O_ChallengeModeButtonPointerClickCallback()
    {
        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    private void HomePage_O_RealisticModeButtonPointerClickCallback()
    {
        Debug.Log(MethodBase.GetCurrentMethod().Name);
    }

    private void HomePage_O_GameModeBackButtonPointerClickCallback()
    {
        Debug.Log(MethodBase.GetCurrentMethod().Name);

        homePage.ShowMainButtonList();
    }

    #endregion
}
