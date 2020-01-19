using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool hasKey = false;

    public bool HasKey 
    {
        get { return hasKey; }
    }

    public void GetKey() 
    {
        hasKey = true;
    }
}
