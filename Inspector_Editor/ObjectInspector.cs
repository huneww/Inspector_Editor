using System;
using UnityEngine;

public enum EnumFlags
{
    None = 0,
    OptionA = 1 << 0,
    OptionB = 1 << 1,
    OptionC = 1 << 2,
    OptionD = 1 << 3,
    OptionE = 1 << 4,

}

[Serializable]
public class PropertClass
{
    public string name;
    public int hp;
}

public class ObjectInspector : MonoBehaviour
{
    [HideInInspector]
    public Bounds bounds;
    [HideInInspector]
    public BoundsInt boundsInt;
    [HideInInspector]
    public Color color;
    [HideInInspector]
    public AnimationCurve curve;
    [HideInInspector]
    public double delayedDoubleField;
    [HideInInspector]
    public EnumFlags enumFlagsField;
    [HideInInspector]
    public bool toggleField;
    [HideInInspector]
    public int intField;
    [HideInInspector]
    public float floatField;
    [HideInInspector]
    public double doubleField;
    [HideInInspector]
    public long longField;
    [HideInInspector]
    public string textField;
    [HideInInspector, Header("TextArea")]
    public string textArea;
    [HideInInspector]
    public Gradient gradientField = new Gradient();
    [HideInInspector]
    public int layerField;
    [HideInInspector]
    public int maskField;
    [HideInInspector]
    public string passwordField;
    //[HideInInspector]
    public PropertClass propertClassField;
    [HideInInspector]
    public string tagField;
    [HideInInspector]
    public Vector4 vector4Field;
    [SerializeField]
    private int foldInt;
    public int FoldInt
    {
        get
        {
            return foldInt;
        }
        set
        {
            foldInt = value;
        }
    }
    [SerializeField]
    private float foldFloat;
    public float FoldFloat
    {
        get
        {
            return foldFloat;
        }
        set
        {
            foldFloat = value;
        }
    }

    [HideInInspector]
    public int itemCount = 10;


    private void Start()
    {
        Debug.Log(textArea);
    }

}
