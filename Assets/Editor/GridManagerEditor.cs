using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridManager))]
public class GridManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GridManager gridManager = (GridManager)target;

        if (GUILayout.Button("Generate Grid"))
        {
            while (gridManager.transform.childCount > 0)
            {
                DestroyImmediate(gridManager.transform.GetChild(0).gameObject);
            }

            gridManager.GenerateGrid();
        }

        GUILayout.Label("Match Count: " + gridManager.MatchCount); // Eşleşme sayısını gösterin
    }
}