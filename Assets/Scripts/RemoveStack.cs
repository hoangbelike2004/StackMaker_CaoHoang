using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveStack : MonoBehaviour
{
    [SerializeField] Transform PlayerPicture;
    [SerializeField] Transform PlayerParent;
    public delegate void FinishDelegate();
    public static FinishDelegate FinishEvent;
    public delegate void ParticleDelegate();
    public static FinishDelegate ParticleEvent;
    //[SerializeField] private ParticleSystem _particle1;
    //[SerializeField] private ParticleSystem _particle2;
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
            newPos.y -= 0.3f;
            PlayerPicture.position = newPos;


            PlayerParent.GetChild(PlayerParent.childCount - 1).gameObject.SetActive(false);
            PlayerParent.GetChild(PlayerParent.childCount - 1).SetParent(null);

        }
        if (other.gameObject.CompareTag("Finish"))//when win then will remove all brick and take player about default
        {
           
            Vector3 newPos = PlayerPicture.position;
            newPos.y = 0;
            PlayerPicture.position = newPos;

           
            AddStack.countStack =0;
            for(int i = 0; i < PlayerParent.childCount; i++)
            {
                if(PlayerParent.GetChild(PlayerParent.childCount -1).gameObject.name== "Brick(Clone)")
                {
                    PlayerParent.GetChild(PlayerParent.childCount  - 1).gameObject.SetActive(false);
                    PlayerParent.GetChild(PlayerParent.childCount - 1).SetParent(null);
                }    
            }

            for (int i = 0; i < PlayerParent.childCount; i++)
            {
                if (PlayerParent.GetChild(PlayerParent.childCount-1).gameObject.name == "Brick(Clone)")
                {
                    PlayerParent.GetChild(PlayerParent.childCount - 1).gameObject.SetActive(false);
                    PlayerParent.GetChild(PlayerParent.childCount - 1).SetParent(null);
                }
            }
            ParticleEvent?.Invoke();
            //_particle1.Play();
            //_particle2.Play();

            Invoke(nameof(InvokeEvenWinGame), 3f);
         
        }
    }

    private void InvokeEvenWinGame()
    {
        FinishEvent?.Invoke();
    }

}
