using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject StartPos;

    // Start is called before the first frame update
    void Start()
    {
        Player.transform.position = StartPos.transform.position;
        Debug.Log(Player.transform.position);
    }

}
