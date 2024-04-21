using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveStack : MonoBehaviour
{
    [SerializeField] Transform PlayerPicture;
    [SerializeField] Transform PlayerParent;
    public delegate void FinishDelegate();
    public static FinishDelegate FinishEvent;
    int index=0;
    public AddStack AddStack;
    //[SerializeField] List<GameObject> stack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UnBrick"))//when  touch line then remove brick
        {
            AddStack.countStack--;
           
            other.transform.tag = "Untagged";
            index++;
            Vector3 newPos = PlayerPicture.position;
            newPos.y -= 0.45f;
            PlayerPicture.position = newPos;


            PlayerParent.GetChild(PlayerParent.childCount - 1).gameObject.SetActive(false);
            PlayerParent.GetChild(PlayerParent.childCount - 1).SetParent(null);

        }
        if (other.gameObject.CompareTag("Finish"))//when win then will remove all brick and take player about default
        {
            Vector3 newPos = PlayerPicture.position;
            newPos.y = 0;
            newPos.z = 0f;
            PlayerPicture.position = newPos;

           
            AddStack.countStack =0;
            for(int i = 0; i < PlayerParent.childCount; i++)
            {
                if(PlayerParent.GetChild(PlayerParent.childCount-1).gameObject.name== "Brick(Clone)")
                {
                    PlayerParent.GetChild(PlayerParent.childCount - 1).gameObject.SetActive(false);
                    PlayerParent.GetChild(PlayerParent.childCount - 1).SetParent(null);
                }    
            }
            Invoke(nameof(InvokeEvenWinGame), 3f);
         
        }
    }

    private void InvokeEvenWinGame()
    {
        FinishEvent?.Invoke();
    }

}
