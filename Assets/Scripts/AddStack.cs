using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStack : MonoBehaviour
{
    [SerializeField] private Transform PlayerPiture;
    [SerializeField] private GameObject Stack;
    float heightPlayer = 0.3f,heightStack = .3f;
    public int countStack = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            //When the player adds a stack, the player jumps one space
            Vector3 newPos = PlayerPiture.position;
            newPos.y += heightPlayer;
            PlayerPiture.position = newPos;

            //add stack to Original Player
            Transform t = other.transform;
            t.gameObject.tag = "Untagged";
            t.gameObject.SetActive(false);
            GameObject stacktmp = Instantiate(Stack);
            stacktmp.transform.SetParent(this.transform);
            stacktmp.tag = "Untagged";
            stacktmp.transform.localPosition = new Vector3(0,countStack*heightStack,0);
            countStack++;

        }

        
    }
}
