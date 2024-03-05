using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectInspector))]
public class ObjectInspectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // ObjectInspector�� �ִ� �ʵ�� �� Inspector���� �����ִ� ������ ǥ��
        //base.OnInspectorGUI();

        ObjectInspector obj = (ObjectInspector)target;

        Bounds(obj);
        VariableField(obj);
        DelayField(obj);
        Vector(obj);
        TagLayer(obj);
        Other(obj);
        DropDown();
        GUIButton();
        FoldOut(obj);

        HorizontalScrollView(obj);

    }

    private Vector2 scrollValue;
    private Vector2 scrollValue2;
    private Vector2 scrollValue3;

    private void HorizontalScrollView(ObjectInspector obj)
    {
        GUILayout.Space(25f);
        GUILayout.Label("GUILayout");
        GUILayout.Space(15f);
        GUILayout.BeginHorizontal();
        // �̷��� ����� C�� �Ⱥ���
        // Width�� Ư���������� �ϸ� ���� �Է��ϴ� ���� ��ħ
        EditorGUILayout.IntField("Test A", 0, GUILayout.Width(250));
        EditorGUILayout.IntField("Test B", 0, GUILayout.Width(250));
        EditorGUILayout.IntField("Test C", 0, GUILayout.Width(250));
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        // ��ũ�ѹٸ� �����Ҽ�����
        // HorizontalScrollbar(�� ��ġ, �ڵ��� ũ��, �ּҰ�, �ִ밪)
        //scrollValue = GUILayout.HorizontalScrollbar(scrollValue, 1, 0, 10);

        GUILayout.Space(15f);
        // �������� ���� ������ ���� Ȯ���ҷ��� EditorGUILayout.BeginScrollView�� �ϸ��
        // ������ EndScrollView�� �ٿ����� �ȱ׷��� ���Ŀ� �����Ǵ� �ͱ��� ��ũ�� ������ ���Ե�
        // ���ݵ� Width�� Ư���� ������ �ϸ� �Է°����� ��ħ
        scrollValue = EditorGUILayout.BeginScrollView(scrollValue);
        GUILayout.BeginHorizontal();
        for (int i = 0; i < 100; i++)
        {
            EditorGUILayout.IntField($"Item {i + 1}", i, GUILayout.Width(230));
        }
        GUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();

        GUILayout.Space(15f);

        scrollValue2 = EditorGUILayout.BeginScrollView(scrollValue2);
        GUILayout.BeginHorizontal();
        for (int i = 0; i < 100; i++)
        {
            // Label�� ��ǲ�ʵ带 ���� ����
            // Label�� ���̰� �����Ǹ鼭 �̸��� ©��
            EditorGUILayout.LabelField($"ItemB {i + 1}", GUILayout.Width(70));
            EditorGUILayout.IntField(0, GUILayout.Width(50));
        }
        GUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();

        // ���� �������� ��� ���̺��� ���� ����� 60���� ����
        EditorGUIUtility.labelWidth = 60;

        // ũ�� �ڵ� ���� ��, ���� ��ħ�� �״�� �߻�
        GUILayout.BeginHorizontal();
        EditorGUILayout.IntField("Test C", 0);
        EditorGUILayout.IntField("Test D", 0);
        EditorGUILayout.IntField("Test E", 0);
        EditorGUILayout.IntField("Test F", 0);
        GUILayout.EndHorizontal();

        GUILayout.Space(15);
        // ���� ��ħ�� ũ�� ������ ���� �ؾ���
        EditorGUIUtility.labelWidth = 80;
        obj.itemCount = EditorGUILayout.IntField("Item Count", obj.itemCount);
        scrollValue3 = EditorGUILayout.BeginScrollView(scrollValue3);
        GUILayout.BeginHorizontal();
        for (int i = 0; i < obj.itemCount; i++)
        {
            EditorGUILayout.IntField($"TestAA {i + 1} ", 0);
        }
        GUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();

    }

    bool fold;

    private void FoldOut(ObjectInspector obj)
    {
        // Ŭ����ó�� ���ƴ�, ���ƴ��Ҽ�����
        fold = EditorGUILayout.Foldout(fold, "FoldOut", true);
        if (fold)
        {
            // ��ĭ �鿩����? ���� Space�ʹ� �ٸ��� �������� �̵�
            EditorGUI.indentLevel++;
            obj.FoldInt = EditorGUILayout.IntField("FoldInt", obj.FoldInt);
            obj.FoldFloat = EditorGUILayout.FloatField("FoldFLoat", obj.FoldFloat);
        }
    }

    private void GUIButton()
    {
        // �����Ϳ� ��ư�� ����, �ڿ� ũ��� �پ��� �ɼ� �ΰ� ����
        if (GUILayout.Button("Test Button", GUILayout.Height(50f), GUILayout.Width(150f)))
        {
            Debug.Log("Push Button");
        }
    }

    private string dropdownText = "DropdownButtoin";
    private bool optionA = false;
    private bool optionB = false;

    private void DropDown()
    {
        // ��� �ٿ� �޴��� ����
        // �� ����Ұ� ������ ����
        if (EditorGUILayout.DropdownButton(new GUIContent(dropdownText), FocusType.Passive))
        {
            GenericMenu menu = new GenericMenu();
            menu.AddItem(new GUIContent("Option A"), optionA,
            () => {
                Debug.Log("Option A"); 
                optionA = !optionA;
                dropdownText = "Option A";
            });
            menu.AddItem(new GUIContent("Option B"), optionB,
            () => {
                Debug.Log("Option B");
                optionB = !optionB;
                dropdownText = "Option B";
            });
            menu.ShowAsContext();
        }
    }

    private void Other(ObjectInspector obj)
    {
        // �÷� �Ķ����
        obj.color = EditorGUILayout.ColorField("Color", obj.color);

        // �ִϸ��̼ǿ��ִ� Ŀ��, ����ҷ��� �ʱ�ȭ�� ���Ѿ���
        obj.curve = EditorGUILayout.CurveField("Curve", obj.curve);

        // �׶���Ʈ �ʵ�, ����ҷ��� �ʱ�ȭ�� ���Ѿ���
        obj.gradientField = EditorGUILayout.GradientField("GradientFIeld", obj.gradientField);
    }

    private void TagLayer(ObjectInspector obj)
    {
        // ���̾� ����ũó�� ��Ʈ���� �̿��ؼ� ���� ���� �����Ҽ��ִ� �ʵ�
        obj.enumFlagsField = (EnumFlags)EditorGUILayout.EnumFlagsField("EnumFlagsField", obj.enumFlagsField);
        // ���̻� ������ ����
        //EditorGUILayout.EnumMaskField("EnumMaskField");

        // ���̾� ���� �ʵ�
        obj.layerField = EditorGUILayout.LayerField("LayerField", obj.layerField);

        // MaskField���� ������ �ɼ�
        string[] maskOptions = new string[]
        {
            "OptionA",
            "OptionB",
            "OptionC",
        };
        // EnumFlagsó�� ��Ʈ ������ ���� ���� �����Ҽ� ����
        obj.maskField = EditorGUILayout.MaskField("MaskField", obj.maskField, maskOptions);

        // tag�� �ʵ�
        obj.tagField = EditorGUILayout.TagField("TagField", obj.tagField);
    }

    private void DelayField(ObjectInspector obj)
    {
        // �⺻ Field�� ����Ǵ� ��� ���� �ݿ�������
        // DelayedField�� ����ڰ� ���� ������ ���������� ���� ������� ����
        // ������ �Է��� Ŭ��, ���͸� ������ ������ GUI.changed�� true�� ������� ����
        obj.delayedDoubleField = EditorGUILayout.DelayedDoubleField("DelayedDoubleField", obj.delayedDoubleField);
        //EditorGUILayout.DelayedFloatField("DelayedFloatField", 0);
        //EditorGUILayout.DelayedIntField("DelayedIntField", 0);
        //EditorGUILayout.DelayedTextField("DelayedTextField");
    }

    private void Vector(ObjectInspector obj)
    {
        // Rect ��ġ�� ����
        //EditorGUILayout.RectField(new Rect());
        //EditorGUILayout.RectIntField(new RectInt());

        // Vector�� �ʵ�
        //EditorGUILayout.Vector2Field("Vector2Field", new Vector2());
        //EditorGUILayout.Vector2IntField("Vector2IntField", new Vector2Int());
        //EditorGUILayout.Vector3Field("Vector3Field", new Vector3());
        //EditorGUILayout.Vector3IntField("Vector3IntField", new Vector3Int());
        obj.vector4Field = EditorGUILayout.Vector4Field("Vector4Field", obj.vector4Field);
    }

    private void VariableField(ObjectInspector obj)
    {
        // ���� ���� �ʵ�
        obj.toggleField = EditorGUILayout.Toggle("ToggleField", obj.toggleField);
        EditorGUILayout.Space();
        obj.intField = EditorGUILayout.IntField("IntField", obj.intField);
        // �ʵ�� ���� ���� ����
        EditorGUILayout.Space();
        obj.floatField = EditorGUILayout.FloatField("FloatField", obj.floatField);
        EditorGUILayout.Space();
        obj.doubleField = EditorGUILayout.DoubleField("DoubleField", obj.doubleField);
        EditorGUILayout.Space();
        obj.longField = EditorGUILayout.LongField("LongField", obj.longField);
        EditorGUILayout.Space(10f);
        // �󺧸� ǥ������
        obj.textField = EditorGUILayout.TextField("TextField", obj.textField);
        EditorGUILayout.Space(10f);
        // ����ڰ� �������� �ؽ�Ʈ�� ����Ҷ� ����ϴ� �ʵ�
        EditorGUILayout.LabelField("TextArea");
        obj.textArea = EditorGUILayout.TextArea(obj.textArea, GUILayout.Height(50));
        // strginField�� ���������� �� �Է½� *�� ǥ�õ�
        obj.passwordField = EditorGUILayout.PasswordField("PassWordField", obj.passwordField);
    }

    private void Bounds(ObjectInspector obj)
    {
        // �ݶ��̴����ִ� bounds�Ӽ��� ����
        obj.bounds = EditorGUILayout.BoundsField("Bounds", obj.bounds);

        // ������ bounds�� �Ҽ����� ȹ���Ҽ�������, �������� ����
        obj.boundsInt = EditorGUILayout.BoundsIntField("BoundsInt", obj.boundsInt);
    }
}
