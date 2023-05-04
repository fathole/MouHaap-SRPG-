using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSceneOperationValue
{
	public GameManager.GameManager gameManager;
	public Camera mainCamera;
	public ScreenPropertiesData screenPropertiesData;
	public TMPro.TMP_FontAsset fontAsset;

	public Action onEnterSceneModeFinishedCallback;
	public Action onRunSceneModeFinishedCallback;
	public Action<SceneOption> onExitSceneModeFinishedCallback;
}
