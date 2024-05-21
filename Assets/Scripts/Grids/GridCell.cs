using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class GridCell : MonoBehaviour
{
    public bool walkable;
    public SpriteRenderer spriteRenderer;

    private void OnValidate()
    {
        spriteRenderer.color = walkable ? Color.white : Color.black;
    }

    private void Start()
    {
        OnValidate();
    }
}