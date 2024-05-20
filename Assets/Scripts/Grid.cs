using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public bool[] walkableGrid = new bool[100];
    public int width;
    
    public bool isWalkable(int x, int y)
    {
        return walkableGrid[y * width + x];
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
