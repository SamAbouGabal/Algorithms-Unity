using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(Grid))]
    public class GridInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Generate Grid"))
            {
                Debug.Log("Generate Grid Here");
            }
        }
    }
}
