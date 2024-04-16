using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStack : MonoBehaviour
{
    [SerializeField] private Transform Player;
    float heightPlayer = 0.45f,heightStack = .45f;
    int countStack = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            //When the player adds a stack, the player jumps one space
            Vector3 newPos = Player.position;
            newPos.y += heightPlayer;
            Player.position = newPos;

            //add stack to Original Player
            Transform t = other.transform;
            t.gameObject.tag = "Untagged";
            t.SetParent(this.transform);
            t.localPosition = new Vector3(0,countStack*heightStack,0);
            countStack++;

        }
    }
}
