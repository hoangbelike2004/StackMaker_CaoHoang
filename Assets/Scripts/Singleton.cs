using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindAnyObjectByType<T>();
                if(instance != null)
                {
                    GameObject NewInstan = new GameObject(typeof(T).Name);
                    instance = NewInstan.AddComponent<T>();
                }
            }
            return instance;
        }
    }
    protected virtual void Awake()
    {
        if (instance == null) //before load scene it will don't destroy 
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else//if exist add a gameobject then will destroy
        {
            Destroy(gameObject);
        }
    }
}
