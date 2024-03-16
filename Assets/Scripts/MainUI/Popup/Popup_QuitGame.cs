using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainUI
{
    public class Popup_QuitGame : MonoBehaviour
    {
        #region Declaration

        [Header("Object")]
        public Common_Button o_CrossButton;

        [Header("Animator")]
        public Animator animator;

        #endregion

        #region Function - InitView

        public void InitView()
        {
            // Nothing Init
        }

        #endregion

        #region Function - Public

        public IEnumerator ShowPopupCoroutine()
        {                        
            gameObject.SetActive(true);

            // Wait Animation Finish (Animation Auto Play When Active)
            yield return new WaitForEndOfFrame();
            yield return new WaitWhile(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Popup_active") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1);
        }

        public IEnumerator ClosePopupCoroutine()
        {
            // Play Animation
            animator.Play("Popup_end");

            // Wait Animation Finish (Animation Auto Play When Active)
            yield return new WaitForEndOfFrame();
            yield return new WaitWhile(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Popup_end") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1);

            // Inactive Object
            gameObject.SetActive(false);
        }

        #endregion
    }
}