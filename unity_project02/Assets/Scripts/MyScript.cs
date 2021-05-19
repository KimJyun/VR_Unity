using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    public GameObject MyCube1;


    void Start()
    {
        
    }

    
    void Update()
    {
        MyCube1.transform.Rotate(0, -0.5f, 0);

    }
}
