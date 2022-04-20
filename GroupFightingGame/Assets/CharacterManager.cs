using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class CharacterManager : MonoBehaviour
{
    public List<Sprite> characters = new List<Sprite>();
    public int selectedCharacter = 0;
    public SpriteRenderer sr;
    public GameObject playerCharacter; 

    public void Next()
    {
        selectedCharacter = selectedCharacter + 1; 
        if(selectedCharacter == characters.Count)
        {
            selectedCharacter = 0;
        }
        sr.sprite = characters[selectedCharacter];
    }

    public void Previous()
    {
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter = characters.Count - 1;
        }
        sr.sprite = characters[selectedCharacter];
    }

    public void goToMapSelect()
    {
        PlayerPrefs.SetInt("Selected Character 1", selectedCharacter);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



}
