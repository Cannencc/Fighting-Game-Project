using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelectMenu : MonoBehaviour
{
    public void Map1 ()
    {
        AudioManager.audioManagerInst.GetComponent<AudioSource>().Pause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        battleMusic.instance.GetComponent<AudioSource>().Play();
    }

    public void Map2()
    {
        AudioManager.audioManagerInst.GetComponent<AudioSource>().Pause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        battleMusic.instance.GetComponent<AudioSource>().Play();

    }

    public void Map3()
    {
        AudioManager.audioManagerInst.GetComponent<AudioSource>().Pause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        battleMusic.instance.GetComponent<AudioSource>().Play();
    }
}
