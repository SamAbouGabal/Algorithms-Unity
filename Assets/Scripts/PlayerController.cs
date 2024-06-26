using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Collections;
using Grids;
using UnityEngine;
using Grid = Grids.Grid;

public class PlayerController : MonoBehaviour
{
    public GameObject goal;
    // Start is called before the first frame update
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
            var path = FindPath_Dijkstra(grid, start, end);
            foreach (var node in path)
            {
                node.spriteRenderer.color = Color.green;
            }

            StartCoroutine(Co_WalkPath(path));
        }
    }

    IEnumerator Co_WalkPath(IEnumerable<GridCell> path)
    {
        foreach (var cell in path)
        {
            while (Vector2.Distance(transform.position, cell.transform.position) > 0.001f)
            {
                Vector3 targetPosition = Vector2.MoveTowards(transform.position, cell.transform.position, Time.deltaTime);
                targetPosition.z = transform.position.z;
                transform.position = targetPosition;
                yield return null;
            }
        }
    }

    // Find Depth First Function
    static IEnumerable<GridCell> FindPathDepthFirst(Grid grid, GridCell start, GridCell end)
    {
        Stack<GridCell> path = new Stack<GridCell>();
        HashSet<GridCell> visited = new HashSet<GridCell>();
        path.Push(start);
        visited.Add(start);

        while (path.Count > 0)
        {
            bool foundNextNode = false;
            foreach (var neighbor in grid.GetWalkableNeighborsForCell(path.Peek()))
            {
                if (visited.Contains(neighbor)) continue;
                path.Push(neighbor);
                visited.Add(neighbor);
                neighbor.spriteRenderer.color = Color.cyan;
                if (neighbor == end) return path.Reverse();
                foundNextNode = true;
                break;
            }

            if (!foundNextNode)
                path.Pop();
        }

        return null;
    }
    
    
    //Find breadth first function
    static IEnumerable<GridCell> FindPathBreadthFirst(Grid grid, GridCell start, GridCell end)
    {
        Queue<GridCell> todo = new Queue<GridCell>();
        HashSet<GridCell> visited = new HashSet<GridCell>();
        Dictionary<GridCell, GridCell> previous = new();
        todo.Enqueue(start);
        visited.Add(start);

        while (todo.Count > 0)
        {
            var current = todo.Dequeue();
            foreach (var neighbor in grid.GetWalkableNeighborsForCell(current))
            {
                if (visited.Contains(neighbor)) continue;
                todo.Enqueue(neighbor);
                previous[neighbor] = current;
                visited.Add(neighbor);
                neighbor.spriteRenderer.color = Color.cyan;
                if (neighbor == end) return TracePath(neighbor, previous).Reverse();
            }
        }

        return null;
    }
    
    
    static IEnumerable<GridCell> FindPath_Dijkstra(Grid grid, GridCell start, GridCell end)
    {
        PriorityQueue<GridCell> todo = new();
        todo.Enqueue(start, 0);
        Dictionary<GridCell, int> costs = new()
        {
            [start] = 0
        };
        Dictionary<GridCell, GridCell> previous = new();

        while (todo.Count > 0)
        {
            var current = todo.Dequeue();
            if (current == end) return TracePath(current, previous).Reverse();
            
            foreach (var neighbor in grid.GetWalkableNeighborsForCell(current))
            {
                int newNeighbourCosts = costs[current] + neighbor.Costs;
                if (costs.TryGetValue(neighbor, out int neighbourCosts) && neighbourCosts <= newNeighbourCosts) continue;
                
                todo.Enqueue(neighbor, newNeighbourCosts);
                previous[neighbor] = current;
                costs[neighbor] = newNeighbourCosts;
                neighbor.spriteRenderer.color = Color.cyan;
            }
        }

        return null;
    }

    private static IEnumerable<GridCell> TracePath(GridCell neighbor, Dictionary<GridCell, GridCell> previous)
    {
        while (true)
        {
            yield return neighbor;
            if (!previous.TryGetValue(neighbor, out neighbor))
            {
                yield break;
            }
        }
    }
}

