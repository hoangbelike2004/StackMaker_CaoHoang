using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField] private List<GameObject> Level;
    public int indexLevelMap = 0;
    public delegate void GameControlAction();
    public static GameControlAction GameEvent;
    //private void Awake()
    //{
    //    base.Awake();
    //}

    private void Awake()
    {
        Debug.Log(PlayerPrefs.GetInt("Keylevel"));
        if (indexLevelMap == PlayerPrefs.GetInt("Keylevel"))
            indexLevelMap = 0;
        else
        {
            indexLevelMap = PlayerPrefs.GetInt("Keylevel");
           
            GameEvent?.Invoke();
        }
        
       
      
        
        
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        IUManager.WinEvent += LoadMap;
    }

    private void OnDisable()
    {
        IUManager.WinEvent -= LoadMap;
    }

    void LoadMap()
    {
        Debug.Log("load map");
        indexLevelMap+=1;
        
        GameEvent?.Invoke();

        //Debug.Log("GCT: "+DataManager.Instance.valesLevel);
    }

}
