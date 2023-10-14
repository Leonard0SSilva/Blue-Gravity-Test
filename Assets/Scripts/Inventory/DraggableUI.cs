// Allows a UI element to be dragged within the canvas
// And snap back to its original position and size when released.
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(RectTransform))]
public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parent;
    [SerializeField]
    private Image image;
    [SerializeField]
    private RectTransform rectTransform;
    private Vector2 initialLocalPosition, initialSize;
    private int siblingIndex;

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialLocalPosition = rectTransform.localPosition;
        initialSize = rectTransform.sizeDelta;

        parent = transform.parent;
        siblingIndex = transform.GetSiblingIndex();
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parent);
        transform.SetSiblingIndex(siblingIndex);

        // Set back the initial local position and size
        rectTransform.anchoredPosition = initialLocalPosition;
        rectTransform.sizeDelta = initialSize;
        image.raycastTarget = true;
    }
}
