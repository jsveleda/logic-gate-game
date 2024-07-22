using System;
using System.Collections;
using System.Collections.Generic;
using Operational;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drawer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private float closedHeight = 200;
    [SerializeField]
    private float openHeight = 500;

    [SerializeField]
    private float animateSpeed = 1;

    [SerializeField]
    private DraggableGate draggableGatePrefab;
    [SerializeField]
    private Transform draggableGatesParent;

    private List<GateInfo> options;

    private float middleHeight;

    private bool isAnimating = false;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        middleHeight = (openHeight + closedHeight) / 2;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isAnimating)
        {
            StopAllCoroutines();
        }

        if (rectTransform.sizeDelta.y < middleHeight)
        {
            StartCoroutine(Animate(openHeight, animateSpeed));
        }
        else
        {
            Close();
        }
    }

    private IEnumerator Animate(float newHeight, float speed = 1)
    {
        float i = 0;
        isAnimating = true;

        while (isAnimating)
        {
            i += speed * Time.deltaTime;
            float height = Mathf.Lerp(rectTransform.sizeDelta.y, newHeight, i);
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);

            if (i >= 0.9)
            {
                isAnimating = false;
            }

            yield return null;
        }
    }

    public void SetDrawerOptions(List<GateInfo> drawerOptions)
    {
        options = drawerOptions;
        
        foreach (GateInfo gateInfo in drawerOptions)
        {
            DraggableGate draggableGate = Instantiate(draggableGatePrefab, draggableGatesParent);
            draggableGate.Initialize(gateInfo);
            draggableGate.OnStartDrag += OnStartDrag;
        }
    }

    private void OnStartDrag(GateInfo gateInfo)
    {
        DraggableGate draggableGate = Instantiate(draggableGatePrefab, draggableGatesParent);
        draggableGate.Initialize(gateInfo);
        draggableGate.OnStartDrag += OnStartDrag;

        Close();
    }

    public void Close()
    {
        StartCoroutine(Animate(closedHeight, animateSpeed));
    }
}
