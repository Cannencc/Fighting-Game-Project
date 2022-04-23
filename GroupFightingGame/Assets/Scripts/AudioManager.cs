using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManagerInst;
    private AudioSource musicSource;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (audioManagerInst == null)
            audioManagerInst = this;
        else
            Destroy(gameObject);

    }

  

}
