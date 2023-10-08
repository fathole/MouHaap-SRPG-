using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace ChessScene
{
    public class MidPointCameraManager : MonoBehaviour
    {
        #region Declaration

        [Header("Camera")]
        private CinemachineVirtualCamera cinemachineVirtualCamera;
        [SerializeField] private Transform midPointTransform;

        [Header("Move")]
        [SerializeField] private float movementSpeed = 10f;

        [Header("Rotate")]
        [SerializeField] private float rotationSpeed = 0.5f;

        [Header("Zoom")]
        [SerializeField] private float zoomTime = 20f;
        [SerializeField] private float followOffsetMin = 3f;
        [SerializeField] private float followOffsetMax = 15f;
        [HideInInspector]public Vector3 followOffset;        

        #endregion

        #region Init Stage

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            // Comment: Nothing Init
        }

        #endregion

        #region Setup Stage

        public void SetupManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
            followOffset = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
        }

        #endregion

        #region Main Function

        public void MoveMidPoint(float horizontalInput, float verticalInput)
        {
            // Update Vertical
            midPointTransform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * verticalInput);

            // Update Horizontal
            midPointTransform.Translate(Vector3.right * Time.deltaTime * movementSpeed * horizontalInput);

            // Update Virtual Camera Z Offset Accordint To Terrain Height;
            Vector3 pos = midPointTransform.position;
            //pos.y = Terrain.activeTerrain.SampleHeight(midPointTransform.position);

            if (midPointTransform.position.y < pos.y)
            {
                midPointTransform.Translate(Vector3.up * Time.deltaTime * movementSpeed * 1);
            }
            else if (midPointTransform.position.y > pos.y)
            {
                midPointTransform.Translate(Vector3.down * Time.deltaTime * movementSpeed * 1);
            }
        }

        public void MoveMidPoint(Vector3 playerPosition)
        {
            // Update Mid Point Position To Player Position
            midPointTransform.position = playerPosition;
        }

        public void RotateMidPoint(float difference)
        {
            midPointTransform.Rotate(new Vector3(midPointTransform.rotation.x, difference * rotationSpeed , 0f));
            midPointTransform.rotation = Quaternion.Euler(midPointTransform.rotation.x, midPointTransform.rotation.eulerAngles.y , 0f);
        }

        public void ZoomCamera(Vector3 zoomDirection)
        {
            if (followOffset.magnitude < followOffsetMin)
            {
                followOffset = zoomDirection * followOffsetMin;
            }
            if (followOffset.magnitude > followOffsetMax)
            {
                followOffset = zoomDirection * followOffsetMax;
            }

            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset, followOffset, Time.deltaTime * zoomTime);
        }

        public void ZoomInMidPoint()
        {
            if(cinemachineVirtualCamera.m_Lens.FieldOfView >10)
            {
                cinemachineVirtualCamera.m_Lens.FieldOfView--;
            }
        }

        public void ZoomOutMidPoint()
        {
            if (cinemachineVirtualCamera.m_Lens.FieldOfView < 40)
            {
                cinemachineVirtualCamera.m_Lens.FieldOfView++;
            }
        }

        #endregion
    }
}