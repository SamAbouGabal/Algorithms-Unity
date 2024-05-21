using UnityEngine;

namespace Grids
{
    public class Grid : MonoBehaviour
    {
        public GridCell[] walkableGrid = new GridCell[100];
        public int width = 10;

        public int Height => walkableGrid.Length / width;
        
        public bool IsWalkable(int x, int y)
        {
            return walkableGrid[y*width+x].walkable;
        }

        public GridCell GetCellForPosition(Vector3 position)
        {
            int x = Mathf.FloorToInt(position.x + 0.5f);
            int y = Mathf.FloorToInt(position.y + 0.5f);
            return walkableGrid[x + y * width];
        }
    }
}