using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleMusic : MonoBehaviour
{
    public static battleMusic instance;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
