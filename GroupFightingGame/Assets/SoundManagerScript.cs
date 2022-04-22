using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip roundEnd;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        roundEnd = Resources.Load<AudioClip>("roundEnd");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "roundEnd":
                audioSource.PlayOneShot(roundEnd);
                break;
        }
    }
}
