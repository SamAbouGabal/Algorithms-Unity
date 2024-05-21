using UnityEngine;

namespace Grids
{
    [RequireComponent(typeof(SpriteRenderer))]

    public class GridCell : MonoBehaviour
    {
        public bool walkable;
        public SpriteRenderer spriteRenderer;

        private void OnValidate()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = walkable ? Color.white : Color.black;
        }

        private void Start()
        {
            OnValidate();
        }
    }
}