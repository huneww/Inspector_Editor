using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedInteger : MonoBehaviour
{
    private int value;
    public int Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = value;
        }
    }
}
