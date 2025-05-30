using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SingletonManager<T> : MonoBehaviour where T  : MonoBehaviour
{
    private static T instance;
    public static T Instance { get { return instance; } }

    protected virtual void Awake()
    {
        if(instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != this)
                DestroyImmediate(gameObject);
        }
    }
}
