using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    /// <summary>
    /// A protected static instance of type T.
    /// </summary>
    protected static T instance;

    /// <summary>
    /// A publicly accessible static property that can be used to staticaly access a non static method on a non static class.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    /// <summary>
    /// Will check to ensure that there is not already an instance of the proposed type saved.
    /// </summary>
    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
