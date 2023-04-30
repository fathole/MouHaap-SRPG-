using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBase : CameraScreenSafeAreaBase
{
    #region Declaration 

    /* ----- Declaration - Variable ----- */

    private Canvas canvas;
    private CanvasScaler canvasScaler;

    /* ----- Declaration - Struct ----- */

    public struct CanvasProperties
    {
        // Canvas
        public RenderMode renderMode;
        public bool pixelPerfect;
        public Camera worldCamera;
        public int planeDistance;
        public SortingLayerOption sortingLayer;
        public int sortingOrder;
        public AdditionalCanvasShaderChannels additionalShaderChannels;

        // Canvas Scaler
        public CanvasScaler.ScaleMode uiScaleMode;
        public Vector2 referenceResolution;
        public CanvasScaler.ScreenMatchMode screenMatchMode;
        public float matchWidthOrHeight;
        public int referencePixelsPerUnit;
    }
    private CanvasProperties canvasSetting;

    #endregion

    #region Init Stage

    private void Awake()
    {
        this.Init();
    }

    protected void Init()
    {
        canvas = GetComponent<Canvas>();
        canvasScaler = GetComponent<CanvasScaler>();
        canvasSetting = GetCanvasDefaultSetting();
    }

    #endregion

    #region Setup Stage

    // Comment: Nothing setup

    #endregion

    #region Main Function

    private CanvasProperties GetCanvasDefaultSetting()
    {
        CanvasProperties canvasSetting = new CanvasProperties();

        canvasSetting.renderMode = RenderMode.ScreenSpaceCamera;
        canvasSetting.pixelPerfect = false;
        //canvasSetting.worldCamera
        canvasSetting.planeDistance = 100;
        //canvasSetting.sortingLayerName
        canvasSetting.sortingOrder = 0;
        canvasSetting.additionalShaderChannels = AdditionalCanvasShaderChannels.None;

        canvasSetting.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasSetting.referencePixelsPerUnit = 100;
        //canvasSetting.referenceResolution
        canvasSetting.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        //canvasSetting.matchWidthOrHeight

        return canvasSetting;
    }

    private CanvasProperties GetCanvasSetting(CanvasProperties canvasSetting, Camera appCamera, ScreenProperties cameraScreen, SortingLayerOption sortingLayer)
    {
        Debug.Log("--- CanvasBase _ GetCanvasSetting() ---");


        // Letterbox
        float match = 0f;
        // Pillarbox
        if (cameraScreen.aspectRatio.ratioWidth / cameraScreen.aspectRatio.ratioHeight >= 16 / 9)
        {
            match = 1f;
        }

        canvasSetting.worldCamera = appCamera;
        //canvasSetting.sortingLayerName = !string.IsNullOrWhiteSpace(sortingLayer) ? sortingLayer : canvas.sortingLayerName;
        canvasSetting.sortingLayer = sortingLayer;
        canvasSetting.referenceResolution = new Vector2((float)cameraScreen.width, (float)cameraScreen.height);
        canvasSetting.matchWidthOrHeight = match;

        return canvasSetting;
    }

    public void SetupCanvas(Camera appCamera, ScreenProperties cameraScreen, SortingLayerOption sortingLayer)
    {
        Debug.Log("--- CanvasBase _ SetupCanvas() ---");

        canvasSetting = GetCanvasSetting(canvasSetting, appCamera, cameraScreen, sortingLayer);

        // Canvas
        canvas.renderMode = canvasSetting.renderMode;
        canvas.pixelPerfect = canvasSetting.pixelPerfect;
        canvas.worldCamera = canvasSetting.worldCamera;
        canvas.planeDistance = canvasSetting.planeDistance;
        canvas.sortingLayerName = canvasSetting.sortingLayer.ToString();
        canvas.sortingOrder = canvasSetting.sortingOrder;
        canvas.additionalShaderChannels = canvasSetting.additionalShaderChannels;

        // Canvas Scaler
        canvasScaler.uiScaleMode = canvasSetting.uiScaleMode;
        canvasScaler.referenceResolution = canvasSetting.referenceResolution;
        canvasScaler.screenMatchMode = canvasSetting.screenMatchMode;
        canvasScaler.matchWidthOrHeight = canvasSetting.matchWidthOrHeight;
        canvasScaler.referencePixelsPerUnit = canvasSetting.referencePixelsPerUnit;

        if(canvas.sortingLayerName != canvasSetting.sortingLayer.ToString())
        {
            Debug.Log("<color=red>Sorting Layer is Default</color>");

            Debug.Log("<color=Magenta>" + canvasSetting.sortingLayer + "</color>" + "<color=red> unable to set as a sorting layer!</color>");
        }
    }

    #endregion
}
