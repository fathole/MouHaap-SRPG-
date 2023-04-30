using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenSafeAreaBase : MonoBehaviour
{
    #region Declaration

    // Comment: Nothing declaration

    #endregion

    #region Init Stage

    // Comment: Nothing init

    #endregion

    #region Setup Stage

    // Comment: Nothing setup

    #endregion

    #region Main Function

    #region Main

    protected RectTransform SetupSafeAreaRectTransform(RectTransform safeAreaRectTransform, ScreenProperties cameraScreen, ScreenProperties targetScreen, ScreenProperties deviceScreen)
    {
        // Convert Device Screen Size into Camera Screen Size
        Rect cameraScreenSafeArea = GetCameraScreenSafeArea(Screen.safeArea, cameraScreen, targetScreen, deviceScreen);

        // Convert cameraScreenSafeArea Rect to center anchoredPosition
        Vector2 centeredCameraScreenSafeAreaPosition = Vector2.zero;
        centeredCameraScreenSafeAreaPosition.x = (cameraScreenSafeArea.x + cameraScreenSafeArea.width / 2) - (cameraScreen.width / 2);
        centeredCameraScreenSafeAreaPosition.y = (cameraScreenSafeArea.y + cameraScreenSafeArea.height / 2) - (cameraScreen.height / 2);

        safeAreaRectTransform.anchoredPosition = new Vector2(centeredCameraScreenSafeAreaPosition.x, centeredCameraScreenSafeAreaPosition.y);
        safeAreaRectTransform.sizeDelta = new Vector2(cameraScreenSafeArea.width, cameraScreenSafeArea.height);

        return safeAreaRectTransform;
    }

    private Rect GetCameraScreenSafeArea(Rect safeArea, ScreenProperties cameraScreen, ScreenProperties targetScreen, ScreenProperties deviceScreen)
    {
        Debug.Log("<color=cyan>--- CameraSreenSafeArea _ GetCameraScreenSafeArea() ---</color>");

        //SafeAreaProperties cameraScreenSafeArea = new SafeAreaProperties();
        float safeAreaX = safeArea.x;
        float safeAreaY = safeArea.y;
        float safeAreaW = safeArea.width;
        float safeAreaH = safeArea.height;


        // Symmetrical adjustment
        if (safeAreaW < deviceScreen.width)
        {
            float leftOffset = safeAreaX;
            float rightOffset = deviceScreen.width - safeAreaW - safeAreaX;
            if (leftOffset != rightOffset)
            {
                float symmetricalOffset = Mathf.Max(leftOffset, rightOffset);
                safeAreaX = symmetricalOffset;
                safeAreaW = deviceScreen.width - (symmetricalOffset * 2);
            }
        }

        // In Pillarbox, Safe Area > Target Screen, adjust the Safe Area to fit Target Screen
        if ((deviceScreen.width / deviceScreen.height) >= (targetScreen.aspectRatio.ratioWidth / targetScreen.aspectRatio.ratioHeight))
        {
            if (safeAreaW > targetScreen.width)
            {
                safeAreaX = ((deviceScreen.width - targetScreen.width) / 2);
                safeAreaW = targetScreen.width;
            }
        }
        // In Letterbox, Safe Area > Target Screen , adjust the Safe Area to fit Target Screen
        else
        {
            // Top Black Bar
            float safeAreaHeightPosY = safeAreaY + safeAreaH;
            float targetScreenHeightPosY = deviceScreen.height - ((deviceScreen.height - targetScreen.height) / 2);
            if (safeAreaHeightPosY > targetScreenHeightPosY)
            {
                float topBlackBarHeight = safeAreaHeightPosY - targetScreenHeightPosY;
                safeAreaH -= topBlackBarHeight;
            }

            // Bottom Black Bar
            float targetScreenYPosY = ((deviceScreen.height - targetScreen.height) / 2);
            if (targetScreenYPosY > safeAreaY)
            {
                float bottomBlackBarHeight = targetScreenYPosY - safeAreaY;
                safeAreaY += bottomBlackBarHeight;
                safeAreaH -= bottomBlackBarHeight;
            }
        }

        //Convert Safe Area from device screen domain to target screen domain
        //(present the safe area using target screen coordinate)
        //(that chop the black bars on device screen)
        safeAreaX = safeAreaX - ((deviceScreen.width - targetScreen.width) / 2);
        safeAreaY = safeAreaY - ((deviceScreen.height - targetScreen.height) / 2);

        //Convert adjusted Safe Area into Camera Screen Safe Area
        Rect cameraScreenSafeArea = new Rect();
        cameraScreenSafeArea.x = safeAreaX * (cameraScreen.width / targetScreen.width);
        cameraScreenSafeArea.y = safeAreaY * (cameraScreen.height / targetScreen.height);
        cameraScreenSafeArea.width = safeAreaW * (cameraScreen.width / targetScreen.width);
        cameraScreenSafeArea.height = safeAreaH * (cameraScreen.height / targetScreen.height);

        Debug.Log("Device Screen Width: " + deviceScreen.width);
        Debug.Log("Device Screen Height: " + deviceScreen.height);
        Debug.Log("");
        Debug.Log("Safe Area X: " + safeArea.x);
        Debug.Log("Safe Area Y: " + safeArea.y);
        Debug.Log("Safe Area W: " + safeArea.width);
        Debug.Log("Safe Area H: " + safeArea.height);
        Debug.Log("");
        Debug.Log("Camera Screen W: " + cameraScreen.width);
        Debug.Log("Camera Screen H: " + cameraScreen.height);
        Debug.Log("");
        Debug.Log("Camera Safe Area X: " + cameraScreenSafeArea.x);
        Debug.Log("Camera Safe Area Y: " + cameraScreenSafeArea.y);
        Debug.Log("Camera Safe Area W: " + cameraScreenSafeArea.width);
        Debug.Log("Camera Safe Area H: " + cameraScreenSafeArea.height);
        //Samsung Galaxy Z Fold3: 2208 x 1768
        Debug.Log("");
        Debug.Log("Resize Device Safe Area X: " + Screen.safeArea.x * (cameraScreen.width / deviceScreen.width));
        Debug.Log("Resize Device Safe Area Y: " + Screen.safeArea.y * (cameraScreen.width / deviceScreen.width));
        Debug.Log("Resize Device Safe Area W: " + Screen.safeArea.width * (cameraScreen.width / deviceScreen.width));
        Debug.Log("Resize Device Safe Area H: " + Screen.safeArea.height * (cameraScreen.width / deviceScreen.width));

        Debug.Log("<color=cyan>--- CameraSreenSafeArea _ GetCameraScreenSafeArea() ---</color>");
        return cameraScreenSafeArea;
    }

    #endregion

    #endregion
}
