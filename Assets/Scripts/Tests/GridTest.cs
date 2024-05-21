using Grids;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using Grid = Grids.Grid;

namespace Tests
{
    public class GridTest
    {
        private Grid grid;

        [SetUp]
        public void SetUp()
        {
            var gridGameObject = new GameObject("Grid");
            grid = gridGameObject.AddComponent<Grid>();
            grid.width = 3;
            int height = 3;
            grid.walkableGrid = new GridCell[9];
            int i = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < grid.width; x++)
                {
                    var cellGameObject = new GameObject("GridCell");
                    cellGameObject.transform.SetParent(grid.transform);
                    cellGameObject.transform.position = new Vector3(x, y, 0);
                    cellGameObject.AddComponent<SpriteRenderer>();
                    var cell = cellGameObject.AddComponent<GridCell>();
                    grid.walkableGrid[i++] = cell;
                }
            }
        }

        [TearDown]

        public void TearDown()
        {
            GameObject.DestroyImmediate(grid);
            grid = null;
        }

        [Test]
        public void GridTestSimplePasses()
        {
            
        }
    }
}