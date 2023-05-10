using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

namespace ChessScene
{
    public class ChessController : MonoBehaviour
    {
        #region Declaration

        #region Declaration - Enum

        private enum ControllerModeOption
        {
            None = 0,
            EnterSceneMode = 1,
            RunSceneMode = 2,
            ExitSceneMode = 3,
        }

        #endregion

        #region Declaration - Variable

        [Header("MVC")]
        [SerializeField] private ChessView view;
        public static ChessController instance;
        private GameManager.GameManager gameManager = null;        

        [Header("Controller Manager")]
        [SerializeField] private TextManager textManager;
        [SerializeField] private MidPointCameraManager midPointCameraManager;

        [Header("Font and Text")]
        private TMP_FontAsset fontAsset = null;
        private TextContentBase textContent = null;

        [Header("Camera And Canvas")]
        private Camera mainCamera = null;
        private ScreenPropertiesData screenPropertiesData = null;

        [Header("Game Manager Callback Function, Variable")]
        public Action gameManagerOnEnterSceneModeFinishedCallback = null;
        public Action gameManagerOnRunSceneModeFinishedCallback = null;
        public Action<SceneOption> gameManagerOnExitSceneModeFinishedCallback = null;

        [Header("Camera Control Variable")]
        // Drag        
        [SerializeField] private float dragCameraThresholder = 200f;
        private Vector3 dragCameraPreviousPosition;
        private bool isCameraDrag;
        private CameraFacingOption cameraFacingOption;

        [Header("Scene Mode")]
        // Scene Mode
        private ControllerModeOption currentMode = ControllerModeOption.None;
        // Enter Scene Mode
        private ChessSceneOperationValue operationValue = null;// Won't Use, Get From GameManager.cs Update Variable
        // Run Scene Mode
        private bool isEnableUserInput = false;
        // Exit Scene Mode
        private bool isSceneFinished = false;
        private SceneOption nextScene = SceneOption.None;

        [Header("Chess")]
        public Vector2 cursorPosition;

        [Header("Cursor")]
        public GameObject cursor;
        // Movement
        private int cursorHorizontalInput;
        private int cursorVerticalInput;

        #endregion

        #endregion

        #region Init Stage

        private void Awake()
        {
            instance = this;
        }

        private void InitScene()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            InitController();

            view.InitView();
        }

        private void InitController()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            InitControllerManager();
        }

        private void InitControllerManager()
        {
            textManager.InitManager();
            midPointCameraManager.InitManager();
        }

        #endregion

        #region Setup Stage

        private void SetupScene()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            SetupController();

            view.SetupView(mainCamera, screenPropertiesData);
        }

        private void SetupController()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            SetupByOperationValue();

            SetupControllerManager();
        }

        private void SetupByOperationValue()
        {
            gameManager = operationValue.gameManager;
            mainCamera = operationValue.mainCamera;
            screenPropertiesData = operationValue.screenPropertiesData;
            fontAsset = operationValue.fontAsset;
            gameManagerOnEnterSceneModeFinishedCallback = operationValue.onEnterSceneModeFinishedCallback;
            gameManagerOnRunSceneModeFinishedCallback = operationValue.onRunSceneModeFinishedCallback;
            gameManagerOnExitSceneModeFinishedCallback = operationValue.onExitSceneModeFinishedCallback;
        }

        private void SetupControllerManager()
        {
            textManager.SetupManager();
            midPointCameraManager.SetupManager();
        }

        #endregion

        #region Main Function

        private void Main()
        {
            if (currentMode == ControllerModeOption.EnterSceneMode)
            {
                StartCoroutine(EnterSceneMode(EnterSceneModeFinishCallback));
            }
            else if (currentMode == ControllerModeOption.RunSceneMode)
            {
                StartCoroutine(RunSceneMode(RunSceneModeFinishCallback));
            }
            else if (currentMode == ControllerModeOption.ExitSceneMode)
            {
                StartCoroutine(ExitSceneMode(ExitSceneModeFinishCallback));
            }
        }

        #region Main - Enter Scene Mode

        private IEnumerator EnterSceneMode(Action finishCallback)
        {
            Debug.Log("----- Home Controller: Enter Scene Mode -----");

            InitScene();

            SetupScene();

            ReadyScene();

            yield return null;

            finishCallback?.Invoke();
        }

        private void EnterSceneModeFinishCallback()
        {
            gameManagerOnEnterSceneModeFinishedCallback?.Invoke();
        }

        private void ReadyScene()
        {
            // Setup Text Content
            textContent = textManager.GetTextContent(gameManager.GetDisplayLanguageOption());

            // Get Camera Facing
            cameraFacingOption = midPointCameraManager.GetCameraFacing();
            Debug.Log(cameraFacingOption);
        }

        #endregion

        #region Main - Run Scene Mode

        private IEnumerator RunSceneMode(Action finishCallback)
        {
            Debug.Log("----- Home Controller: Run Scene Mode -----");

            isEnableUserInput = true;

            yield return new WaitUntil(() => isSceneFinished == true);

            isEnableUserInput = false;

            finishCallback?.Invoke();
        }

        private void RunSceneModeFinishCallback()
        {
            gameManagerOnRunSceneModeFinishedCallback?.Invoke();
        }

        #endregion

        #region Main - Exit Scene Mode

        private IEnumerator ExitSceneMode(Action finishCallback)
        {
            Debug.Log("----- Home Controller: Exit Scene Mode -----");

            yield return null;

            finishCallback?.Invoke();
        }

        private void ExitSceneModeFinishCallback()
        {
            gameManagerOnExitSceneModeFinishedCallback?.Invoke(nextScene);
        }

        #endregion

        #region Update  - Camera Handling

        private void CameraHandle()
        {
            CameraRotateHandle();

            CameraZoomHandle();
        }

        private void CameraRotateHandle()
        {
            // Get Previous Position Of Drag
            if (Input.GetMouseButtonDown(2))
            {
                dragCameraPreviousPosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(2))
            {
                if (isCameraDrag != true)
                {
                    float differenceX = (Input.mousePosition - dragCameraPreviousPosition).x;

                    if (Math.Abs(differenceX) > dragCameraThresholder)
                    {
                        isCameraDrag = true;
                        dragCameraPreviousPosition = Input.mousePosition;
                    }
                }
                else
                {
                    Vector3 currentPosition = Input.mousePosition;

                    float differenceXPosition = (dragCameraPreviousPosition - currentPosition).x;

                    midPointCameraManager.RotateMidPoint(differenceXPosition);

                    dragCameraPreviousPosition = currentPosition;
                }
            }

            if (Input.GetMouseButtonUp(2))
            {
                cameraFacingOption = midPointCameraManager.GetCameraFacing();
                isCameraDrag = false;
            }

        }

        private void CameraZoomHandle()
        {
            if (isCameraDrag != true)
            {
                Vector3 zoomDirection = midPointCameraManager.followOffset.normalized;

                if (Input.mouseScrollDelta.y > 0)
                {
                    midPointCameraManager.followOffset -= zoomDirection;
                }
                if (Input.mouseScrollDelta.y < 0)
                {
                    midPointCameraManager.followOffset += zoomDirection;
                }

                midPointCameraManager.ZoomCamera(zoomDirection);
            }
        }

        #endregion

        #region Update - Cursor Handling

        private void CursorHandle()
        {
            CursorMoveHandle();

            CursorSelectHandle();
        }

        private void CursorMoveHandle() 
        {
            if (Input.GetKeyDown(KeyCode.W))
            {

            }
            if (Input.GetKeyDown(KeyCode.A))
            {

            }
            if (Input.GetKeyDown(KeyCode.S))
            {

            }
            if (Input.GetKeyDown(KeyCode.D))
            {

            }
        }

        private void CursorSelectHandle() 
        {
        
        }

        #endregion

        #endregion

        #region Game Manager Helper Function

        public void RunEnterSceneMode(ChessSceneOperationValue operationValue)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            // Get Operation Value
            this.operationValue = operationValue;

            currentMode = ControllerModeOption.EnterSceneMode;
            Main();
        }

        public void RunExitSceneMode()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            currentMode = ControllerModeOption.ExitSceneMode;
            Main();
        }

        public void RunRunSceneMode()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            currentMode = ControllerModeOption.RunSceneMode;
            Main();
        }

        #endregion

        private void Update()
        {
            if (isEnableUserInput)
            {
                CameraHandle();

                CursorHandle();
            }
        }

        #region DEV Function

        public void DEVHomeSceneButtonPointerClickCallback()
        {
            nextScene = SceneOption.GameScene02_Home;
            isSceneFinished = true;
        }

        public void DevWorldSceneButtonPointerClickCallback()
        {
            nextScene = SceneOption.GameScene03_World;
            isSceneFinished = true;
        }

        #endregion
    }

    public enum CameraFacingOption
    {
        None = 0,
        North = 1,
        East = 2,
        South = 3,
        West = 4,
    }
}