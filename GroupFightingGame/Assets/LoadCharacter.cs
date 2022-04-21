using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public GameObject[] skinPrefabs;
    public Transform parent;
    public Vector3 spawn; 


    void Start()
    {

        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter1");
        int selectedSkin = PlayerPrefs.GetInt("selectedSkin1");

        GameObject prefab = characterPrefabs[selectedCharacter];
        if(selectedSkin == 0)
        {
            prefab = characterPrefabs[selectedCharacter];
        }
        if(selectedSkin == 1)
        {
           prefab = skinPrefabs[selectedCharacter];
        }

        spawn = new Vector3(0f, -.53f,0f); 
        prefab.transform.localPosition = new Vector3(0f, -.53f, 0f);
        Instantiate(prefab, parent); 
    
        
    }

   
}
