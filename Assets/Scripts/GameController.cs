using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField] private List<GameObject> Level;
    public int indexLevelMap;
    public delegate void GameControlAction();
    public static GameControlAction GameEvent;
    //private void Awake()
    //{
    //    base.Awake();
    //}

    private void Start()
    {
        indexLevelMap = 0;
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
        indexLevelMap+=1;
        GameEvent?.Invoke();
    }

}
