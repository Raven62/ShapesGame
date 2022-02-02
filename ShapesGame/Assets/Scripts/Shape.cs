using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [SerializeField]
    private int size;

    public int Size
    {
        get { return size; }
        set { size = value; }
    }
    


    public void GetSize(int size)
    {

        this.size = size;
        gameObject.transform.localScale = new Vector2(size / 100.0f, size / 100.0f);

    }
   
}
