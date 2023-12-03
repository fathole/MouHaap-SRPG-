using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup),typeof(Animator))]
public class PanelBase : MonoBehaviour
{
    #region Declaration

    [Header("Animation")]
    [SerializeField] private Animator animator;

    #endregion

    #region Function - Init

    public virtual void InitPanel()
    {
        // Init Component
        if(animator == null)
            animator = GetComponent<Animator>();    
    }

    #endregion

    #region Function - Fade Animation

    public virtual IEnumerator FadeInCoroutine()
    {
        // Active GameObject
        gameObject.SetActive(true);

        // Play Animation
        animator.Play("MoveIn");

        // Wait Animation Finished
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("MoveIn"));
        yield return new WaitForSecondsRealtime(animator.GetCurrentAnimatorStateInfo(0).length);
    }

    public virtual IEnumerator FadeOutCoroutine()
    {        
        // Play Animation
        animator.Play("MoveOut");

        // Wait Animation Finished
        yield return new WaitUntil(()=>animator.GetCurrentAnimatorStateInfo(0).IsName("MoveOut"));
        yield return new WaitForSecondsRealtime(animator.GetCurrentAnimatorStateInfo(0).length);

        // Inactive Object
        gameObject.SetActive(false);
    }

    #endregion
}
