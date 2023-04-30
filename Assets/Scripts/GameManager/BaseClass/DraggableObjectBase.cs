using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObjectBase : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IBeginDragHandler, IDragHandler, IPointerUpHandler, IPointerClickHandler, IEndDragHandler, IPointerExitHandler
{
	#region Declaration

	/* ----- Declaration - Variable ----- */

	[Header("Audio")]
	public AudioSource audioSource;
	public AudioClip audioSFXPointerClick;

	[Header("Animation")]
	public Animator animator;
	private bool isPointerDowned;
	private bool isDragged;

	// Action
	public Action onPointerEnterCallback;
	public Action onPointerDownCallback;
	public Action<Vector2> onBeginDragCallback;
	public Action<Vector2> onDraggingCallback;
	public Action onPointerUpCallback;
	public Action onPointerClickCallback;
	public Action<Vector2> onEndDragCallback;
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

	void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
	{
		// Set isDragged = true
		isDragged = true;

		// Invoke onBeginDragCallback
		onBeginDragCallback?.Invoke(eventData.position);
	}

	void IDragHandler.OnDrag(PointerEventData eventData)
	{
		// Invoke onDraggingCallback
		onDraggingCallback?.Invoke(eventData.position);
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
		if(isDragged == false)
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
	}

	void IEndDragHandler.OnEndDrag(PointerEventData eventData)
	{
		// Set isDragged = false
		isDragged = false;

		// Invoke onEndDragCallback
		onEndDragCallback?.Invoke(eventData.position);
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
