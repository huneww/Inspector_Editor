using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MonsterBase))]
public class MonsterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        // ������ ������ ����ȭ�� ���� �����ص�����
        serializedObject.Update();

        // PropertyField�� ���� ������ ������ �����Ҷ� ����ϴ� ���� ���� ������
        // �ܼ��� ������ �����Ҷ��� ���� Ÿ�Կ� �´� �ʵ带 ����ϴ°� �� ������

        EditorGUILayout.PropertyField(serializedObject.FindProperty("name"));

        //EditorGUILayout.PropertyField(serializedObject.FindProperty("hp"));
        MonsterBase monsterBase = (MonsterBase)target;
        monsterBase.hp = EditorGUILayout.IntField("Hp", monsterBase.hp);

        //EditorGUILayout.PropertyField(serializedObject.FindProperty("mp"));
        monsterBase.mp = EditorGUILayout.IntField("Mp", monsterBase.mp);

        // Q. Speed, Power�� �ν����Ϳ��� �� ��Ÿ��
        // A. ���� �� �����ʹ� MonsterBase���� �����ϴ� ��
        //    ���� A, B�� �ʵ�� ã���� ���� ������Ƽ
        //    A, B ���� ���� �����͸� ����
        //if (target is MonsterA)
        //{
        //    EditorGUILayout.PropertyField(serializedObject.FindProperty("monsterASpeed"));
        //    EditorGUILayout.PropertyField(serializedObject.FindProperty("monsterAPower"));
        //}
        //else if (target is MonsterB)
        //{
        //    EditorGUILayout.PropertyField(serializedObject.FindProperty("monsterBSpeed"));
        //    EditorGUILayout.PropertyField(serializedObject.FindProperty("monsterBPower"));
        //}

        // ����� ������ �����ؼ� �ν����Ϳ� �ݿ�
        // ����� ���� ���� ������Ʈ�� �����Ͽ�, �ν����Ϳ� ��� �ݿ���
        serializedObject.ApplyModifiedProperties();
        // ������Ƽ ���� �����
        if (GUI.changed)
        {
            // ����Ƽ�� target������Ʈ�� ����Ȱ��� �˸�
            // ����Ƽ�� target������Ʈ�� ����Ȱ��� �����ϰ�, ���� ���� ������ ��������� ��ũ�� ����
            EditorUtility.SetDirty(target);
        }
    }
}
