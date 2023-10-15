//Dynamically adjust the layer and sorting layer properties of GameObjects
// when they exit a designated trigger area.
using UnityEngine;

public class LayerTrigger : MonoBehaviour
{
    public string layer;
    public string sortingLayer;

    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.layer = LayerMask.NameToLayer(layer);

        other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer;
        SpriteRenderer[] srs = other.gameObject.GetComponentsInChildren<SpriteRenderer>(true);
        foreach (SpriteRenderer sr in srs)
        {
            sr.sortingLayerName = sortingLayer;
        }
    }

}