using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup),typeof(Animator))]
public class PageBase : MonoBehaviour
{
    #region Declaration

    [Header("Animation")]
    [SerializeField] private Animator animator;

    #endregion

    #region Function - Init

    public void InitPage()
    {
        // Init Component
        if(animator == null)
            animator = GetComponent<Animator>();    
    }

    #endregion

    #region Function - Fade Animation

    public virtual IEnumerator FadeInCoroutine()
    {
        animator.Play("MoveIn");
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("MoveIn"));
        yield return new WaitForSecondsRealtime(animator.GetCurrentAnimatorStateInfo(0).length);
    }

    public virtual IEnumerator FadeOutCoroutine()
    {        
        animator.Play("MoveOut");
        yield return new WaitUntil(()=>animator.GetCurrentAnimatorStateInfo(0).IsName("MoveOut"));
        yield return new WaitForSecondsRealtime(animator.GetCurrentAnimatorStateInfo(0).length);
    }

    #endregion
}
