using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Events;

public class CharacterSelection : MonoBehaviour
{
    private int selectedCharacterIndex;
    private Color desiredColor;

    public GameObject girl;
    public GameObject boy;
    public GameObject girlCamera;
    public GameObject boyCamera;



    [Header("List of characters")]
    [SerializeField] private List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private Image characterSplash;
    [SerializeField] private Image backgroundColor;

    [Header("Sounds")]
    [SerializeField] private AudioClip arrowClickSFX;
    [SerializeField] private AudioClip characterSelectMusic;

    private void Start()
    {        
        UpdateCharacterSelectionUI();
    }

    public void LeftArrow()
    {
        selectedCharacterIndex--;
        if (selectedCharacterIndex < 0)
        {
            selectedCharacterIndex = characterList.Count - 1;
        }
        UpdateCharacterSelectionUI();
    }

    public void RightArrow()
    {
        selectedCharacterIndex++;
        if (selectedCharacterIndex == characterList.Count)
        {
            selectedCharacterIndex = 0;
        }
        UpdateCharacterSelectionUI();
    }

    public void Confirm()
    {

        Debug.Log(string.Format("Character {0}:{1} has been chosen", selectedCharacterIndex, characterList[selectedCharacterIndex].characterName));
        if (selectedCharacterIndex == 0)
        {
            girl.SetActive(true);
            girlCamera.SetActive(true);
        }
        else
        {
            boy.SetActive(true);
            boyCamera.SetActive(true);
        }

    }

    private void UpdateCharacterSelectionUI ()
    {
        //Update Splash, Name, Desired Color
        characterSplash.sprite = characterList[selectedCharacterIndex].splash;
        characterName.text = characterList[selectedCharacterIndex].characterName;
        backgroundColor.color = characterList[selectedCharacterIndex].characterColor;
        desiredColor = characterList[selectedCharacterIndex].characterColor;
    }

    [System.Serializable]
    public class CharacterSelectObject
    {
        public Sprite splash;
        public string characterName;
        public Color characterColor;
    }


}

