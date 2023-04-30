using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace GameManager
{
	public class CameraManager : MonoBehaviour
	{
        #region Declaration

        #region Declaration - Variable

        private UniversalAdditionalCameraData universalAdditionalCameraData;
		private Camera mainCamera;

        #endregion

        #region Declaration - Struct

        public struct CameraProperties
		{
			// Transform
			public Vector3 position;
			public Quaternion rotation;
			public Vector3 scale;
			// Camera
			public CameraRenderType renderType;
			// Projection
			public bool orthographic;
			public float orthographicSize;
			public float nearClipPlane;
			public float farClipPlane;
			public float fieldOfView;
			// Renderer
			public int scriptableRendererIndex; //Renderer index
			public bool renderPostProcessing;
			public AntialiasingMode antialiasing;
			public AntialiasingQuality antialiasingQuality;
			public bool stopNaN;
			public bool dithering;
			public bool renderShadows;
			public float depth; //Priority
			public CameraOverrideOption requiresColorOption; //Opaque Texture
			public CameraOverrideOption requiresDepthOption; //Depth Texture
			public int cullingMask;
			public bool useOcclusionCulling;
			// Envirnment
			public CameraClearFlags clearFlags; //Background Type
			public Color backgroundColor;
			public LayerMask volumeLayerMask; //Volumn Mask
			public Transform volumeTrigger;
			// Output
			public RenderTexture targetTexture;
			public bool allowHDR;
			public bool allowMSAA;
			public Rect rect; //Viewport Rect
			public bool allowDynamicResolution;
			public int targetDisplay;
			public StereoTargetEyeMask stereoTargetEye; //Target Eye
														// Stack
			public List<Camera> cameraStack;
			// Hidden Properties
			public float aspect;
		}
		private CameraProperties cameraDefaultSetting;
		public CameraProperties cameraSetting { get; private set; }

        #endregion

        #endregion

        #region Init Stage

        public void InitManager()
		{
			Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

			mainCamera = GetComponent<Camera>();
			universalAdditionalCameraData = GetComponent<UniversalAdditionalCameraData>();
			cameraSetting = new CameraProperties();
			cameraDefaultSetting = InitCameraDefaultSetting();
		}

		private CameraProperties InitCameraDefaultSetting()
		{
			CameraProperties cameraSetting = new CameraProperties();

			// Transform
			cameraSetting.position = new Vector3(0, 0, -100);
			cameraSetting.rotation = new Quaternion(0, 0, 0, 0);
			cameraSetting.scale = Vector3.one;
			// Camera
			cameraSetting.renderType = CameraRenderType.Base;
			// Projection
			cameraSetting.orthographic = true;
			cameraSetting.orthographicSize = 10.8f;
			cameraSetting.nearClipPlane = 0.3f;
			cameraSetting.farClipPlane = 1000;
			// Renderer
			cameraSetting.scriptableRendererIndex = 0;
			cameraSetting.renderPostProcessing = false;
			cameraSetting.antialiasing = AntialiasingMode.None;
			cameraSetting.stopNaN = false;
			cameraSetting.dithering = false;
			cameraSetting.renderShadows = true;
			cameraSetting.depth = -1; //Priority
			cameraSetting.requiresColorOption = CameraOverrideOption.UsePipelineSettings;
			cameraSetting.requiresDepthOption = CameraOverrideOption.UsePipelineSettings;
			cameraSetting.cullingMask = -1; //Everything
			cameraSetting.useOcclusionCulling = true;
			// Envirnment
			cameraSetting.clearFlags = CameraClearFlags.SolidColor; //Background Type
			cameraSetting.backgroundColor = Color.black;//Color.black;
			cameraSetting.volumeLayerMask = LayerMask.GetMask("Default");
			cameraSetting.volumeTrigger = null;
			// Output
			cameraSetting.targetTexture = null;
			cameraSetting.allowHDR = mainCamera.allowHDR;
			cameraSetting.allowMSAA = mainCamera.allowMSAA;
			cameraSetting.rect = new Rect(0f, 0f, 1f, 1f);
			cameraSetting.allowDynamicResolution = false;
			cameraSetting.targetDisplay = 0;
			cameraSetting.stereoTargetEye = StereoTargetEyeMask.Both;
			// Stack
			cameraSetting.cameraStack = new List<Camera>();
			// Hidden Properties
			cameraSetting.aspect = (float)(16.0 / 9.0);

			return cameraSetting;
		}

		#endregion

		#region Setup Stage

		public void SetupManager()
		{
			Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

			// Comment: Nothing setup
		}

        #endregion

        #region Main Function

        #region Main

        public Camera AdjustCameraSetting(ScreenProperties cameraScreen, ScreenProperties targetScreen, ScreenProperties deviceScreen)
		{
			Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

			// Setup mainCamera
			deviceScreen = GetDeviceScreen();
			targetScreen = GetTargetScreen(deviceScreen);
			cameraScreen = GetCameraScreen(targetScreen);
			cameraSetting = GetCameraSetting(cameraScreen, targetScreen, deviceScreen, cameraDefaultSetting);
			mainCamera = GetCamera(cameraSetting);

            return mainCamera;
		}

        #endregion

        #region Unit Function

        private ScreenProperties GetDeviceScreen()
		{
			ScreenProperties deviceScreen = new ScreenProperties();
			deviceScreen.width = Screen.width;
			deviceScreen.height = Screen.height;
			deviceScreen.aspectRatio.ratioWidth = Screen.width;
			deviceScreen.aspectRatio.ratioHeight = Screen.height;

			return deviceScreen;
		}

		private ScreenProperties GetTargetScreen(ScreenProperties deviceScreen)
		{
			ScreenProperties targetScreen = new ScreenProperties();
			float deviceScreenWidth = deviceScreen.width;
			float deviceScreenHight = deviceScreen.height;
			float deviceScreenAspect = deviceScreen.aspectRatio.ratioWidth / deviceScreen.aspectRatio.ratioHeight;

			AspectRatioProperties targetScreenAspectRatio = GetTargetScreenAspectRatio(deviceScreen);

			if ((targetScreenAspectRatio.ratioWidth / targetScreenAspectRatio.ratioHeight) < (16.0f / 9.0f))
			{
				targetScreen.width = deviceScreenWidth;
				targetScreen.height = deviceScreenWidth / (targetScreenAspectRatio.ratioWidth / targetScreenAspectRatio.ratioHeight);
			}
			else
			{
				targetScreen.height = deviceScreenHight;
				targetScreen.width = (targetScreenAspectRatio.ratioWidth / targetScreenAspectRatio.ratioHeight) * deviceScreenHight;
			}
			targetScreen.aspectRatio = targetScreenAspectRatio;


			return targetScreen;
		}

		private ScreenProperties GetCameraScreen(ScreenProperties targetScreen)
		{
			ScreenProperties cameraScreen = new ScreenProperties();
			float targetScreenAspectRatioWidth = targetScreen.aspectRatio.ratioWidth;
			float targetScreenAspectRatioHeight = targetScreen.aspectRatio.ratioHeight;

			// 21:9 < deviceScreenAspectRatio
			// 2.333 333 333 < deviceScreenAspect
			if ((targetScreenAspectRatioWidth / targetScreenAspectRatioHeight) > 21.0f / 9.0f)
			{
				cameraScreen.width = 5040f;
				cameraScreen.height = 2160f;
				cameraScreen.aspectRatio.ratioWidth = targetScreenAspectRatioWidth;
				cameraScreen.aspectRatio.ratioHeight = targetScreenAspectRatioHeight;
			}

			// 16:9 <= deviceScreenAspectRatio <= 21:9
			// 1.777 777 778 <= deviceScreenAspect <= 2.333 333 333
			else if (((targetScreenAspectRatioWidth / targetScreenAspectRatioHeight) <= (21.0f / 9.0f)) && ((targetScreenAspectRatioWidth / targetScreenAspectRatioHeight) >= (16.0f / 9.0f)))
			{
				//cameraScreen.width = 2160f * (targetScreenAspectRatioWidth / targetScreenAspectRatioHeight);
				float width = 2160f * (targetScreenAspectRatioWidth / targetScreenAspectRatioHeight);
				cameraScreen.width = (float)Math.Round((double)width, 1);
				cameraScreen.height = 2160f;
				cameraScreen.aspectRatio.ratioWidth = targetScreenAspectRatioWidth;
				cameraScreen.aspectRatio.ratioHeight = targetScreenAspectRatioHeight;
			}
			// 4:3 <= deviceScreenAspectRatio < 16:9
			// 1.333 333 333 <= deviceScreenAspect < 1.777 777 778 
			else if (((targetScreenAspectRatioWidth / targetScreenAspectRatioHeight) <= (16.0f / 9.0f)) && ((targetScreenAspectRatioWidth / targetScreenAspectRatioHeight) >= (4.0f / 3.0f)))
			{
				cameraScreen.width = 3840f;
				//cameraScreen.height = 3840f / (targetScreenAspectRatioWidth / targetScreenAspectRatioHeight);
				float height = 3840f / (targetScreenAspectRatioWidth / targetScreenAspectRatioHeight);
				cameraScreen.height = (float)Math.Round((double)height, 1);
				cameraScreen.aspectRatio.ratioWidth = targetScreenAspectRatioWidth;
				cameraScreen.aspectRatio.ratioHeight = targetScreenAspectRatioHeight;
			}

			// deviceScreenAspectRatio < 4:3
			// deviceScreenAspect < 1.333 333 333
			else if ((targetScreenAspectRatioWidth / targetScreenAspectRatioHeight) < (4.0f / 3.0f))
			{
				cameraScreen.width = 3840f;
				cameraScreen.height = 2880f;
				cameraScreen.aspectRatio.ratioWidth = targetScreenAspectRatioWidth;
				cameraScreen.aspectRatio.ratioHeight = targetScreenAspectRatioHeight;
			}

			return cameraScreen;
		}

		private CameraProperties GetCameraSetting(ScreenProperties cameraScreen, ScreenProperties targetScreen, ScreenProperties deviceScreen, CameraProperties cameraDefaultSetting)
		{
			CameraProperties cameraSetting = cameraDefaultSetting;

			cameraSetting.rect = GetViewportRect(deviceScreen, targetScreen);

			cameraSetting.orthographicSize = cameraScreen.height / 2f / 100f;

			cameraSetting.aspect = cameraScreen.width / cameraScreen.height;

			return cameraSetting;
		}

		private Camera GetCamera(CameraProperties cameraSetting)
		{
			// Transform
			mainCamera.transform.position = cameraSetting.position;
			mainCamera.transform.rotation = cameraSetting.rotation;
			mainCamera.transform.localScale = cameraSetting.scale;
			// Camera
			universalAdditionalCameraData.renderType = cameraSetting.renderType;
			// Projection
			mainCamera.orthographic = cameraSetting.orthographic;
			mainCamera.orthographicSize = cameraSetting.orthographicSize;
			mainCamera.nearClipPlane = cameraSetting.nearClipPlane;
			mainCamera.farClipPlane = cameraSetting.farClipPlane;
			mainCamera.fieldOfView = cameraSetting.fieldOfView;
			// Renderer
			universalAdditionalCameraData.SetRenderer(cameraSetting.scriptableRendererIndex);
			universalAdditionalCameraData.renderPostProcessing = cameraSetting.renderPostProcessing;
			universalAdditionalCameraData.antialiasing = cameraSetting.antialiasing;
			universalAdditionalCameraData.antialiasingQuality = cameraSetting.antialiasingQuality;
			universalAdditionalCameraData.stopNaN = cameraSetting.stopNaN;
			universalAdditionalCameraData.dithering = cameraSetting.dithering;
			universalAdditionalCameraData.renderShadows = cameraSetting.renderShadows;
			mainCamera.depth = cameraSetting.depth;
			universalAdditionalCameraData.requiresColorOption = cameraSetting.requiresColorOption;
			universalAdditionalCameraData.requiresDepthOption = cameraSetting.requiresDepthOption;
			mainCamera.cullingMask = cameraSetting.cullingMask;
			mainCamera.useOcclusionCulling = cameraSetting.useOcclusionCulling;
			// Envirnment
			mainCamera.clearFlags = cameraSetting.clearFlags;
			mainCamera.backgroundColor = cameraSetting.backgroundColor;
			universalAdditionalCameraData.volumeLayerMask = cameraSetting.volumeLayerMask;
			universalAdditionalCameraData.volumeTrigger = cameraSetting.volumeTrigger;
			// Output
			mainCamera.targetTexture = cameraSetting.targetTexture;
			mainCamera.allowHDR = cameraSetting.allowHDR;
			mainCamera.allowMSAA = cameraSetting.allowMSAA;
			mainCamera.rect = cameraSetting.rect;
			mainCamera.allowDynamicResolution = cameraSetting.allowDynamicResolution;
			mainCamera.targetDisplay = cameraSetting.targetDisplay;
			// Stack
			mainCamera.stereoTargetEye = cameraSetting.stereoTargetEye;
			// Hidden Properties
			mainCamera.aspect = cameraSetting.aspect;

			return mainCamera;
		}

		private AspectRatioProperties GetTargetScreenAspectRatio(ScreenProperties deviceScreen)
		{
			float interval = 0.01f;
			AspectRatioProperties nearestTargetDeviceScreenRatio = new AspectRatioProperties();

			float deviceScreenWidth = deviceScreen.width;
			float deviceScreenHeight = deviceScreen.height;

			// 21:9 < deviceScreenRatio
			// 2.333 333 333 < deviceScreenAspect
			if ((double)(deviceScreenWidth / deviceScreenHeight) > (21.0 / 9.0))
			{
				nearestTargetDeviceScreenRatio.ratioWidth = 21f;
				nearestTargetDeviceScreenRatio.ratioHeight = 9f;
			}


			// 16:9 <= deviceScreenRatio <= 21:9
			// 1.777 777 778 <= deviceScreenAspect <= 2.333 333 333
			else if (((double)(deviceScreenWidth / deviceScreenHeight) <= (21.0 / 9.0)) && ((double)(deviceScreenWidth / deviceScreenHeight) >= (16.0 / 9.0)))
			{
				float minDifference = float.MaxValue;
				int loop = (int)((21f - 16f) / interval);

				//Loop from width = 16f to widht = 21f
				for (int i = 0; i <= loop; i++)
				{
					float width = 16f + (float)(i * interval);
					float difference = (deviceScreenWidth / deviceScreenHeight) - (width / 9f);
					if (difference >= 0 && difference < minDifference)
					{
						minDifference = difference;
						//Debug.Log("minDifference: " + minDifference);
						//Debug.Log("Width: " + width);
						//nearestTargetDeviceScreenRatio.ratioWidth = width;
						nearestTargetDeviceScreenRatio.ratioWidth = (float)Math.Round((double)width, 2);
						nearestTargetDeviceScreenRatio.ratioHeight = 9f;
					}
				}

			}

			// 4:3 <= deviceScreenRatio < 16:9
			// 1.333 333 333 <= deviceScreenAspect < 1.777 777 778 
			else if (((double)(deviceScreenWidth / deviceScreenHeight) < 16.0 / 9.0) && ((double)(deviceScreenWidth / deviceScreenHeight) >= 4.0 / 3.0))
			{
				Debug.Log("Called");
				float minDifference = float.MaxValue;
				int loop = (int)((12f - 9f) / interval);

				//Loop from height = 12f to height = 9.01f if interval = 0.01
				for (int i = loop; i > 0; i--)
				{
					float height = 9f + (float)(i * interval);
					float difference = (16f / height) - (deviceScreenWidth / deviceScreenHeight);
					if (difference >= 0 && difference < minDifference)
					{
						minDifference = difference;
						nearestTargetDeviceScreenRatio.ratioWidth = 16f;
						//nearestTargetDeviceScreenRatio.ratioHeight = height;
						nearestTargetDeviceScreenRatio.ratioHeight = (float)Math.Round((double)height, 2);
						//Debug.Log("minDifference: " + minDifference);
						//Debug.Log("Height: " + height);
					}
				}
			}

			// deviceScreenRatio < 4:3
			// deviceScreenAspect < 1.333 333 333
			else if ((double)(deviceScreenWidth / deviceScreenHeight) < (4.0 / 3.0))
			{
				nearestTargetDeviceScreenRatio.ratioWidth = 16f;
				nearestTargetDeviceScreenRatio.ratioHeight = 12f;
			}

			return nearestTargetDeviceScreenRatio;
		}

		private Rect GetViewportRect(ScreenProperties deviceScreen, ScreenProperties targetDeviceScreen)
		{
			Rect rect = new Rect();
			float deviceScreenAspect = (float)Screen.width / (float)Screen.height;
			float targetDeviceScreenAspect = targetDeviceScreen.aspectRatio.ratioWidth / targetDeviceScreen.aspectRatio.ratioHeight;

			// Pillarbox
			if (deviceScreenAspect >= targetDeviceScreenAspect)
			{
				rect.x = (1f - (float)((targetDeviceScreen.width) / Screen.width)) / 2;
				rect.y = 0f;
				rect.width = (float)((targetDeviceScreen.width) / Screen.width);
				rect.height = 1f;
			}
			// Letterbox
			else
			{
				rect.x = 0f;
				rect.y = (1f - (float)(targetDeviceScreen.height / Screen.height)) / 2;
				rect.width = 1f;
				rect.height = (float)(targetDeviceScreen.height / Screen.height);
			}

			return rect;
		}

		#endregion

		#endregion
	}
}