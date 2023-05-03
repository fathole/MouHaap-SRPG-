using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace WorldScene
{
    public class MidPointCameraManager : MonoBehaviour
    {
        #region Declaration

        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float rotationSpeed = 0.5f;
        [SerializeField] private Transform midPointTransform;

        private CinemachineVirtualCamera cinemachineVirtualCamera;

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
        }

        #endregion

        #region Main Function

        public void MoveMidPoint(float horizontalInput, float verticalInput)
        {
            // Update Vertical
            midPointTransform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * verticalInput);

            // Update Horizontal
            midPointTransform.Translate(Vector3.right * Time.deltaTime * movementSpeed * horizontalInput);
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