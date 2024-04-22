using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Level;
    private void Start()
    {
        
        Level[GameController.Instance.indexLevelMap].SetActive(true);
    }
    private void OnEnable()
    {
        GameController.GameEvent += LoadLevel;
    }
    private void OnDisable()
    {
        GameController.GameEvent -= LoadLevel;
    }

    void LoadLevel()
    {

        Level[GameController.Instance.indexLevelMap].SetActive(true);
        for (int i = 0; i < GameController.Instance.indexLevelMap; i++) {
            if (Level[i].activeSelf == true)
            {
                Level[i].SetActive(false);
            }
        }
        
    }
}
