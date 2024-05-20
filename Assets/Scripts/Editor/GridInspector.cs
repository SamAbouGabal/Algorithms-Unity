using Codice.Client.BaseCommands.Import;
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
            cellPrefab = EditorGUILayout.ObjectField("Cell prefab", cellPrefab, typeof(GridCell));
            EditorGUI.BeginDisabledGroup(cellPrefab != null);
            if (GUILayout.Button("Generate Grid"))
            {
                Grid grid = target as Grid;
                EditorUtility.SetDirty(grid);

                for (int x = 0; x < grid.walkableGrid.Length; x++)
                {
                    for (int y = 0; y < grid.walkableGrid.Length; y++)
                    {
                        if (grid.walkableGrid != null)
                        {
                            Destroy(grid);
                        }
                    }
                }
            
            }
            EditorGUI.EndDisabledGroup();
            GUI.enabled = true;
            GUILayout.Button("Hello");
        }
    }
}
