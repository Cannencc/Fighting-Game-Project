using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager2 : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;


    public void Next()
    {
        characters[selectedCharacter].SetActive(false);
    }

    public void Previous()
    {

    }

    public void GoToMapSelect()
    {

    }
}
