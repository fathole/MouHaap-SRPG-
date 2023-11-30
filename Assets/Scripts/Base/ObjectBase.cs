using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public class ObjectBase : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IBeginDragHandler, IDragHandler, IPointerUpHandler, IPointerClickHandler, IEndDragHandler, IPointerExitHandler
{
	#region Declaration

	[Header("Audio")]
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip onPointerClickSFX;

	[Header("Animation")]
	[SerializeField] private Animator animator;
	private bool isPointerDowned;

	[Header("Action")]
	public Action onPointerEnterCallback;
	public Action onPointerDownCallback;
	public Action onBeginDragCallback;
	public Action onDragCallback;
	public Action onPointerUpCallback;
	public Action onPointerClickCallback;
	public Action onEndDragCallback;
	public Action onPointerExitCallback;

	#endregion

	#region Function - Init

	public void InitObject()
	{
		// Init Component
		if (audioSource == null)
			audioSource = GetComponent<AudioSource>();
		if (animator == null)
			animator = GetComponent<Animator>();
	}

	#endregion

	#region Function - Pointer Event	

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		// Play Animation
		if (isPointerDowned == true)
			animator.CrossFade("PointerEnter", 0f, 1);

		// Invoke Action
		onPointerEnterCallback?.Invoke();
	}

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		isPointerDowned = true;

		// Play Animation	
		animator.CrossFade("PointerEnter", 0f, 1);

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
		isPointerDowned = false;

		// Play Animation
		animator.CrossFade("PointerExit", 0f, 1);

		// Invoke Action
		onPointerUpCallback?.Invoke();
	}

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		// Play Animation		
		animator.CrossFade("PointerClick", 0f, 2);

		// Play Audio
		if (onPointerClickSFX != null)
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
		// Play Animation
		if (isPointerDowned == true)
			animator.CrossFade("PointerExit", 0f, 1);

		// Invoke Action
		onPointerExitCallback?.Invoke();
	}

    #endregion
}
