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

        if (GUILayout.Button("Int �ּҰ�"))
        {
            selected.Value = int.MinValue;
        }
        if (GUILayout.Button("0"))
        {
            selected.Value = 0;
        }
        if (GUILayout.Button("Int �ִ밪"))
        {
            selected.Value = int.MaxValue;
        }
        if (GUILayout.Button("���� ��"))
        {
            selected.Value = Random.Range(intRandomMin, intRandomMax);
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        //intRandomMin = EditorGUILayout.IntField("���� �ּڰ�", intRandomMin);
        //intRandomMax = EditorGUILayout.IntField("���� �ִ밪", intRandomMax);
        EditorGUILayout.LabelField("���� �ּڰ�", GUILayout.Width(150));
        intRandomMin = EditorGUILayout.IntField(intRandomMin);
        EditorGUILayout.LabelField("���� �ִ밪", GUILayout.Width(150));
        intRandomMax = EditorGUILayout.IntField(intRandomMax);

        GUILayout.EndHorizontal();
    }
}
