using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SelectedInteger))]
public class SelectedIntegerEditor : Editor
{
    private int intRandomMin = int.MinValue;
    private int intRandomMax = int.MaxValue;

    public override void OnInspectorGUI()
    {
        SelectedInteger selected = (SelectedInteger)target;

        selected.Value = EditorGUILayout.IntField("Value", selected.Value);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Int ÃÖ¼Ò°ª"))
        {
            selected.Value = int.MinValue;
        }
        if (GUILayout.Button("0"))
        {
            selected.Value = 0;
        }
        if (GUILayout.Button("Int ÃÖ´ë°ª"))
        {
            selected.Value = int.MaxValue;
        }
        if (GUILayout.Button("·£´ý °ª"))
        {
            selected.Value = Random.Range(intRandomMin, intRandomMax);
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        //intRandomMin = EditorGUILayout.IntField("·£´ý ÃÖ¼Ú°ª", intRandomMin);
        //intRandomMax = EditorGUILayout.IntField("·£´ý ÃÖ´ë°ª", intRandomMax);
        EditorGUILayout.LabelField("·£´ý ÃÖ¼Ú°ª", GUILayout.Width(150));
        intRandomMin = EditorGUILayout.IntField(intRandomMin);
        EditorGUILayout.LabelField("·£´ý ÃÖ´ë°ª", GUILayout.Width(150));
        intRandomMax = EditorGUILayout.IntField(intRandomMax);

        GUILayout.EndHorizontal();
    }
}
