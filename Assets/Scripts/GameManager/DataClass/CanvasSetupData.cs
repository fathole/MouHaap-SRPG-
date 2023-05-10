using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPropertiesData
{
    public ScreenProperties cameraScreen;
    public ScreenProperties deviceScreen;
    public ScreenProperties targetScreen;
}

public struct AspectRatioProperties
{
    public float ratioWidth;
    public float ratioHeight;
}

public struct ScreenProperties
{
    public float width;
    public float height;
    public AspectRatioProperties aspectRatio;
}
