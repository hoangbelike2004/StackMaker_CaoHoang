using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Level;
    private void Start()
    {
        Level[/*GameController.Instance.indexLevelMap*/2].SetActive(true);
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
        if (GameController.Instance.indexLevelMap > 0)
        {
            Level[GameController.Instance.indexLevelMap - 1].SetActive(false);
        }
    }
}
