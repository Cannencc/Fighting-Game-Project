using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager2 : MonoBehaviour
{
     public GameObject[] characters;
    public int selectedCharacter = 0;

    public GameObject[] skins;
    public int selectedSkin = 1;

    public void Next()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true); 
    }

    public void Previous()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true); 
    }

    public void NextSkin()
    {
        selectedSkin++;
        if(selectedSkin > 1)
        {
            selectedSkin = 0;
        }

        if(selectedSkin == 0)
        {
            skins[selectedCharacter].SetActive(false);
            characters[selectedCharacter].SetActive(true); 
        }

        if(selectedSkin == 1)
        {
            skins[selectedCharacter].SetActive(true);
            characters[selectedCharacter].SetActive(false); 
        }


    }

    public void PreviousSkin()
    {
        selectedSkin--;
        if(selectedSkin < 0)
        {
            selectedSkin += 2; 
        }

        if(selectedSkin == 0)
        {
            skins[selectedCharacter].SetActive(false);
            characters[selectedCharacter].SetActive(true); 
        }

        if(selectedSkin == 1)
        {
            skins[selectedCharacter].SetActive(true);
            characters[selectedCharacter].SetActive(false); 
        }
    }

    public void GoToMapSelect()
    {
        PlayerPrefs.SetInt("selectedCharacter2", selectedCharacter);
        PlayerPrefs.SetInt("selectedSkin2", selectedSkin);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
