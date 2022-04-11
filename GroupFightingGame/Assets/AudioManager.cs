using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager audioManagerInst;
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
