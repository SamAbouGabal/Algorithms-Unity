using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(Grid))]
    public class GridInspector : UnityEditor.Editor
    {
        private UnityEngine.Object cellPrefab;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            // Display the object field to select the cell prefab
            cellPrefab = EditorGUILayout.ObjectField("Cell Prefab", cellPrefab, typeof(GridCell), false);

            // Only enable the button if a cell prefab is selected
            EditorGUI.BeginDisabledGroup(cellPrefab == null);
            if (GUILayout.Button("Generate Grid"))
            {
                Grid grid = (Grid)target;

                // 1. Check if there are already grid cells and delete them
                foreach (var cell in grid.walkableGrid)
                {
                    if (cell != null)
                    {
                        DestroyImmediate(cell.gameObject);
                    }
                }

                // Initialize the walkableGrid array with the correct size
                grid.walkableGrid = new GridCell[grid.width * (grid.walkableGrid.Length / grid.width)];

                // 2. Iterate through all x coordinates
                for (int x = 0; x < grid.width; x++)
                {
                    // Iterate through all y coordinates
                    for (int y = 0; y < grid.walkableGrid.Length / grid.width; y++)
                    {
                        // Instantiate cell prefab
                        GameObject cellInstance = (GameObject)PrefabUtility.InstantiatePrefab(cellPrefab);

                        // Position the cell correctly
                        cellInstance.transform.position = new Vector3(x, y, 0);
                        cellInstance.transform.SetParent(grid.transform);

                        // Assign the cell to the array at the correct index
                        int index = y * grid.width + x;
                        grid.walkableGrid[index] = cellInstance.GetComponent<GridCell>();
                    }
                }

                // Mark the grid object as dirty to ensure changes are saved
                EditorUtility.SetDirty(grid);
            }
            EditorGUI.EndDisabledGroup();
            
            // Test
            if (GUILayout.Button("Hello"))
            {
                Debug.Log("Hello button clicked!");
            }
        }
    }
}
