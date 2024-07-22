using System;
using Operational;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableGate : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private LayoutElement layoutElement;

    private GateInfo gateInfo;

    private bool isDragging = false;

    public Action<GateInfo> OnStartDrag;

    public void Initialize(GateInfo gateInfo)
    {
        this.gateInfo = gateInfo;
        image.sprite = gateInfo.gateSprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        OnStartDrag?.Invoke(gateInfo);
        layoutElement.ignoreLayout = true;
        transform.SetParent(GetComponentInParent<Canvas>().transform);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(transform.position), Vector2.down);
        if (hit.collider != null)
        {
            Debug.Log($"Hit {hit.collider.name}");
        }
        if (hit.collider != null && hit.collider.GetComponent<GateSlot>() != null)
        {
            GateSlot gateSlot = hit.collider.GetComponent<GateSlot>();
            gateSlot.UpdateGate(gateInfo);
        }
        Destroy(gameObject);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            transform.position = eventData.position;
        }
    }
}