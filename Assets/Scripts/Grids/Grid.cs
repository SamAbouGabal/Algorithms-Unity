using System;
using UnityEngine;

namespace Grids
{
    public class Grid : MonoBehaviour
    {
        public GridCell[] walkableGrid = new GridCell[100];
        public int width = 10;
    
        public bool IsWalkable(int x, int y)
        {
            return walkableGrid[y*width+x].walkable;
        }

        public GridCell GetCellForPosition(Vector3 position)
        {
            // remember: floats are inaccurate, so you can't do position.x == 4
            // how can you calculate the right x and y index for the Vector3 position?
            // then, return the cell at that index of the array
            throw new NotImplementedException();
        }
    }
}