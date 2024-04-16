using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveStack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Chay");
            Transform Game = transform.GetChild(1).transform;
            Debug.Log(Game);
        }
    }
}
