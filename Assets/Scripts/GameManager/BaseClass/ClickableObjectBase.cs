using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObjectBase : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerExitHandler
{
	#region Declaration

	/* ----- Declaration - Variable ----- */

	[Header("Audio")]
	public AudioSource audioSource;
	public AudioClip audioSFXPointerClick;

	[Header("Animation")]
	public Animator animator;
	private bool isPointerDowned;

	// Action
	public Action onPointerEnterCallback;
	public Action onPointerDownCallback;
	public Action onPointerUpCallback;
	public Action onPointerClickCallback;
	public Action onPointerExitCallback;

	#endregion

	#region Init Stage

	// Comment: Nothing init

	#endregion

	#region Setup Stage

	// Comment: Nothing setup

	#endregion

	#region Main Function

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		// If isPointerDowned, play pointer down animation
		if (isPointerDowned && animator != null)
		{
			animator.CrossFade("PointerDown", 0f, 1);
		}

		// Invoke onPointerEnterCallback
		onPointerEnterCallback?.Invoke();
	}

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		// Set isPointerDowned = true, play pointer down animation
		isPointerDowned = true;
		if (animator != null)
		{
			animator.CrossFade("PointerDown", 0f, 1);
		}

		// Invoke onPointerDownCallback
		onPointerDownCallback?.Invoke();
	}

	void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
	{
		// Set isPointerDowned = false, play pointer up animation
		isPointerDowned = false;
		if (animator != null)
		{
			animator.CrossFade("PointerUp", 0f, 1);
		}

		// Invoke onPointerUpCallback
		onPointerUpCallback?.Invoke();
	}

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		// Play pointer click animation
		if (animator != null)
		{
			animator.CrossFade("PointerClick", 0f, 2);
		}

		//Play pointerClick SFX
		if (audioSource != null && audioSFXPointerClick != null)
		{
			audioSource.PlayOneShot(audioSFXPointerClick);
		}

		// Invoke onPointerClickCallback
		onPointerClickCallback?.Invoke();
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		// If isPointerDowned, play pointer up animation
		if (isPointerDowned && animator != null)
		{
			animator.CrossFade("PointerUp", 0f, 1);
		}

		// Invoke onPointerExitCallback
		onPointerExitCallback?.Invoke();
	}

    #endregion
}
