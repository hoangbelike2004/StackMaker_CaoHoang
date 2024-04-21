using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform PlayerPos;

    // Update is called once per frame


    private void LateUpdate()
    {
        transform.position = new Vector3( PlayerPos.transform.position.x, 20f,PlayerPos.transform.position.z-20f);
    }
}
