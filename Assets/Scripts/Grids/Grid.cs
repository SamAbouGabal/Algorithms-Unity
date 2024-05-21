using System;
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
            int i = 0;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Height; x++)
                {
                    if (position.x > x - 0.5f && position.x <= x + 0.5f && position.y > y - 0.5f && position.y <= + 0.5f)
                    {
                        return walkableGrid[i];
                    }

                    i++;
                }
            }
            throw new NotImplementedException();
        }
    }
}