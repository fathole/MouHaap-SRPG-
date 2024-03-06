using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectBase : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IBeginDragHandler, IDragHandler, IPointerUpHandler, IPointerClickHandler, IEndDragHandler, IPointerExitHandler
{
	public Action onPointerEnterCallback;
	public Action onPointerDownCallback;
	public Action onBeginDragCallback;
	public Action onDragCallback;
	public Action onPointerUpCallback;
	public Action onPointerClickCallback;
	public Action onEndDragCallback;
	public Action onPointerExitCallback;

	#region Function - Pointer Event

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		onPointerEnterCallback?.Invoke();
	}

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		onPointerDownCallback?.Invoke();
	}

	void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
	{
		onBeginDragCallback?.Invoke();
	}

	void IDragHandler.OnDrag(PointerEventData eventData)
	{
		onDragCallback?.Invoke();
	}

	void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
	{
		onPointerUpCallback?.Invoke();
	}

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		onPointerClickCallback?.Invoke();
	}

	void IEndDragHandler.OnEndDrag(PointerEventData eventData)
	{
		onEndDragCallback?.Invoke();
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		onPointerExitCallback?.Invoke();
	}

	#endregion
}
