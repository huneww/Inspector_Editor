using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectInspector))]
public class ObjectInspectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // ObjectInspector에 있는 필드들 중 Inspector에서 볼수있는 변수를 표시
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
        // 이렇게 만들면 C가 안보임
        // Width를 특정값밑으로 하면 값을 입력하는 곳이 겹침
        EditorGUILayout.IntField("Test A", 0, GUILayout.Width(250));
        EditorGUILayout.IntField("Test B", 0, GUILayout.Width(250));
        EditorGUILayout.IntField("Test C", 0, GUILayout.Width(250));
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        // 스크롤바를 생성할수있음
        // HorizontalScrollbar(바 위치, 핸들의 크기, 최소값, 최대값)
        //scrollValue = GUILayout.HorizontalScrollbar(scrollValue, 1, 0, 10);

        GUILayout.Space(15f);
        // 수평으로 여러 변수를 놓고 확인할려면 EditorGUILayout.BeginScrollView로 하면됨
        // 끝에는 EndScrollView를 붙여야함 안그러면 이후에 생성되는 것까지 스크롤 영역에 포함됨
        // 지금도 Width를 특정값 밑으로 하면 입력공간이 겹침
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
            // Label과 인풋필드를 따로 생성
            // Label의 길이가 고정되면서 이름이 짤림
            EditorGUILayout.LabelField($"ItemB {i + 1}", GUILayout.Width(70));
            EditorGUILayout.IntField(0, GUILayout.Width(50));
        }
        GUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();

        // 현재 에디터의 모든 레이블의 가로 사이즈를 60으로 변경
        EditorGUIUtility.labelWidth = 60;

        // 크기 자동 조정 됨, 글자 겹침은 그대로 발생
        GUILayout.BeginHorizontal();
        EditorGUILayout.IntField("Test C", 0);
        EditorGUILayout.IntField("Test D", 0);
        EditorGUILayout.IntField("Test E", 0);
        EditorGUILayout.IntField("Test F", 0);
        GUILayout.EndHorizontal();

        GUILayout.Space(15);
        // 글자 겹침은 크기 조절을 직접 해야함
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
        // 클래스처럼 펼쳤다, 접아다할수있음
        fold = EditorGUILayout.Foldout(fold, "FoldOut", true);
        if (fold)
        {
            // 한칸 들여쓰기? 같이 Space와는 다르게 수평으로 이동
            EditorGUI.indentLevel++;
            obj.FoldInt = EditorGUILayout.IntField("FoldInt", obj.FoldInt);
            obj.FoldFloat = EditorGUILayout.FloatField("FoldFLoat", obj.FoldFloat);
        }
    }

    private void GUIButton()
    {
        // 에디터에 버튼을 생성, 뒤에 크기등 다양한 옵션 부가 가능
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
        // 드랍 다운 메뉴를 생성
        // 잘 사용할것 같지는 않음
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
        // 컬러 파라미터
        obj.color = EditorGUILayout.ColorField("Color", obj.color);

        // 애니메이션에있는 커브, 사용할려면 초기화를 시켜야함
        obj.curve = EditorGUILayout.CurveField("Curve", obj.curve);

        // 그라디언트 필드, 사용할려면 초기화를 시켜야함
        obj.gradientField = EditorGUILayout.GradientField("GradientFIeld", obj.gradientField);
    }

    private void TagLayer(ObjectInspector obj)
    {
        // 레이어 마스크처럼 비트값을 이용해서 여러 값을 선택할수있는 필드
        obj.enumFlagsField = (EnumFlags)EditorGUILayout.EnumFlagsField("EnumFlagsField", obj.enumFlagsField);
        // 더이상 사용되지 않음
        //EditorGUILayout.EnumMaskField("EnumMaskField");

        // 레이어 설정 필드
        obj.layerField = EditorGUILayout.LayerField("LayerField", obj.layerField);

        // MaskField에서 선택할 옵션
        string[] maskOptions = new string[]
        {
            "OptionA",
            "OptionB",
            "OptionC",
        };
        // EnumFlags처럼 비트 값으로 여러 값을 선택할수 있음
        obj.maskField = EditorGUILayout.MaskField("MaskField", obj.maskField, maskOptions);

        // tag값 필드
        obj.tagField = EditorGUILayout.TagField("TagField", obj.tagField);
    }

    private void DelayField(ObjectInspector obj)
    {
        // 기본 Field는 변경되는 즉시 값이 반영되지만
        // DelayedField는 사용자가 값을 변경이 끝날때까지 값이 변경되지 않음
        // 유저가 입력후 클릭, 엔터를 누르기 전까지 GUI.changed가 true로 변경되지 않음
        obj.delayedDoubleField = EditorGUILayout.DelayedDoubleField("DelayedDoubleField", obj.delayedDoubleField);
        //EditorGUILayout.DelayedFloatField("DelayedFloatField", 0);
        //EditorGUILayout.DelayedIntField("DelayedIntField", 0);
        //EditorGUILayout.DelayedTextField("DelayedTextField");
    }

    private void Vector(ObjectInspector obj)
    {
        // Rect 위치를 지정
        //EditorGUILayout.RectField(new Rect());
        //EditorGUILayout.RectIntField(new RectInt());

        // Vector값 필드
        //EditorGUILayout.Vector2Field("Vector2Field", new Vector2());
        //EditorGUILayout.Vector2IntField("Vector2IntField", new Vector2Int());
        //EditorGUILayout.Vector3Field("Vector3Field", new Vector3());
        //EditorGUILayout.Vector3IntField("Vector3IntField", new Vector3Int());
        obj.vector4Field = EditorGUILayout.Vector4Field("Vector4Field", obj.vector4Field);
    }

    private void VariableField(ObjectInspector obj)
    {
        // 각종 변수 필드
        obj.toggleField = EditorGUILayout.Toggle("ToggleField", obj.toggleField);
        EditorGUILayout.Space();
        obj.intField = EditorGUILayout.IntField("IntField", obj.intField);
        // 필드들 간의 간격 조정
        EditorGUILayout.Space();
        obj.floatField = EditorGUILayout.FloatField("FloatField", obj.floatField);
        EditorGUILayout.Space();
        obj.doubleField = EditorGUILayout.DoubleField("DoubleField", obj.doubleField);
        EditorGUILayout.Space();
        obj.longField = EditorGUILayout.LongField("LongField", obj.longField);
        EditorGUILayout.Space(10f);
        // 라벨를 표시해줌
        obj.textField = EditorGUILayout.TextField("TextField", obj.textField);
        EditorGUILayout.Space(10f);
        // 사용자가 여러줄의 텍스트를 사용할때 사용하는 필드
        EditorGUILayout.LabelField("TextArea");
        obj.textArea = EditorGUILayout.TextArea(obj.textArea, GUILayout.Height(50));
        // strginField와 유사하지만 값 입력시 *로 표시됨
        obj.passwordField = EditorGUILayout.PasswordField("PassWordField", obj.passwordField);
    }

    private void Bounds(ObjectInspector obj)
    {
        // 콜라이더에있는 bounds속성과 동일
        obj.bounds = EditorGUILayout.BoundsField("Bounds", obj.bounds);

        // 기존의 bounds는 소숫점을 획득할수있지만, 정수만을 받음
        obj.boundsInt = EditorGUILayout.BoundsIntField("BoundsInt", obj.boundsInt);
    }
}
