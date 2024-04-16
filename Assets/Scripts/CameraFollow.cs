using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform PlayerPos;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        transform.position = new Vector3( PlayerPos.transform.position.x-0.17f, 15f,PlayerPos.transform.position.z-7.5f);
    }
}
