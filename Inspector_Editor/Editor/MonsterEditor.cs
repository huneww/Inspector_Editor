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
        // 원본의 변수와 동기화를 위해 선언해도야함
        serializedObject.Update();

        // PropertyField는 좀더 복잡한 구조를 편집할때 사용하는 것이 좀더 적합함
        // 단순한 변수를 편집할때는 변수 타입에 맞는 필드를 사용하는게 더 간단함

        EditorGUILayout.PropertyField(serializedObject.FindProperty("name"));

        //EditorGUILayout.PropertyField(serializedObject.FindProperty("hp"));
        MonsterBase monsterBase = (MonsterBase)target;
        monsterBase.hp = EditorGUILayout.IntField("Hp", monsterBase.hp);

        //EditorGUILayout.PropertyField(serializedObject.FindProperty("mp"));
        monsterBase.mp = EditorGUILayout.IntField("Mp", monsterBase.mp);

        // Q. Speed, Power는 인스펙터에서 안 나타남
        // A. 현재 이 에디터는 MonsterBase만을 편집하는 것
        //    따라서 A, B의 필드는 찾을수 없는 프로퍼티
        //    A, B 각각 따로 에디터를 생성
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

        // 변경된 변수를 저장해서 인스펙터에 반영
        // 변경된 값을 원본 오브젝트에 전달하여, 인스펙터에 즉시 반영됨
        serializedObject.ApplyModifiedProperties();
        // 프로퍼티 값이 변경시
        if (GUI.changed)
        {
            // 유니티에 target오브젝트가 변경된것을 알림
            // 유니티가 target오브젝트가 변경된것을 인지하고, 다음 저장 시점에 변경사항을 디스크에 저장
            EditorUtility.SetDirty(target);
        }
    }
}
