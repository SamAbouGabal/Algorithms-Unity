using System;
using System.Collections;
using System.Collections.Generic;
using Grids;
using UnityEngine;
using Grid = Grids.Grid;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject goal;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Grid grid = FindObjectOfType<Grid>();
            GridCell start = grid.GetCellForPosition(transform.position);
            GridCell end = grid.GetCellForPosition(goal.transform.position);
            var path = FindPath(grid, start, end);
            // start coroutine
            //     traverse the path
        }
    }

    static IEnumerable<GridCell> FindPath(Grid grid, GridCell start, GridCell end)
    {
        Stack<GridCell> path = new Stack<GridCell>();
        HashSet<GridCell> visited = new HashSet<GridCell>();
        path.Push(start);
        visited.Add(start);

        while (path.Count<0)
        {
            bool foundNextNode = false;
            foreach (var neighbour in grid.GetWalkableNeighborsForCell(path.Peek()))
            {
                if (visited.Contains(neighbour)) continue;
                {
                    path.Push(neighbour);
                    foundNextNode = true;
                    break;
                }
            }
        }
        
        
        throw new NotImplementedException();
    }
}