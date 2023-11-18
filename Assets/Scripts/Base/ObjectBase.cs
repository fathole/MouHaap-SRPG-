using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectBase : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IBeginDragHandler, IDragHandler, IPointerUpHandler, IPointerClickHandler, IEndDragHandler, IPointerExitHandler
{
	#region Declaration

	[Header("Audio")]
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip onPointerClickSFX;

	[Header("Animation")]
	[SerializeField] private Animator animator;    

	[Header("Action")]
	private Action onPointerEnterCallback;
	private Action onPointerDownCallback;
	private Action onBeginDragCallback;
	private Action onDragCallback;
	private Action onPointerUpCallback;
	private Action onPointerClickCallback;
	private Action onEndDragCallback;
	private Action onPointerExitCallback;

	#endregion

	#region Function - Init

	public virtual void InitObject()
    {
		// Init Audio Sourece
		if(audioSource == null && GetComponent<AudioSource>())
			audioSource = GetComponent<AudioSource>();

		// Init Animator
		if(animator == null && GetComponent<Animator>())
			animator = GetComponent<Animator>();
    }

    #endregion

    #region Function - Pointer Event	

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		// Invoke Action
		onPointerEnterCallback?.Invoke();
	}

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		// Invoke Action
		onPointerDownCallback?.Invoke();
	}

	void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
	{
		// Invoke Action
		onBeginDragCallback?.Invoke();
	}

	void IDragHandler.OnDrag(PointerEventData eventData)
	{
		// Invoke Action
		onDragCallback?.Invoke();
	}

	void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
	{
		// Invoke Action
		onPointerUpCallback?.Invoke();
	}

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		// Play Animation
		if (animator != null)
			animator.CrossFade("PointerClick", 0f, 2);

		// Play Audio
		if (audioSource != null && onPointerClickSFX != null)
			audioSource.PlayOneShot(onPointerClickSFX);

		// Invoke Action
		onPointerClickCallback?.Invoke();
	}

	void IEndDragHandler.OnEndDrag(PointerEventData eventData)
	{
		// Invoke Action
		onEndDragCallback?.Invoke();
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		// Invoke Action
		onPointerExitCallback?.Invoke();
	}

    #endregion
}
