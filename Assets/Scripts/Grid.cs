using System;
using System.Collections;
using System.Collections.Generic;
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



public class Grid : MonoBehaviour
{

    public GridCell[] walkableGrid = new GridCell[100];
    public int width;
    
    public bool isWalkable(int x, int y)
    {
        return walkableGrid[y * width + x].walkable;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
