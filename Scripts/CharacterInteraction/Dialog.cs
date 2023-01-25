using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;

    public bool isInRange;

    private bool conversationTrigger = false;


        void Start()
        {

        }
   

        //Start the conversation between the player and the npc cowboy
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isInRange = true;
                Debug.Log("Player is in range with the cowboy");
                if (conversationTrigger == false) //We want to trigger the conversation only once when we enter the right area (close to the cowboy)
                {
                    StartCoroutine(Type());
                    conversationTrigger = true;

                }
                
                
            }


        }
        
    
        
        
   

    void Update()
    {
        if(textDisplay.text == sentences[index])    //Right time to activate the "Continue" Button
        {
            continueButton.SetActive(true);
        }
    }


    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray()) //Show a letter at a time of the sentence
        {
            textDisplay.text += letter; 
            yield return new WaitForSeconds(typingSpeed); //Wait a few miliseconds before showing the next letter
        }

    }

    public void NextSentence()  //Start next sentence in line
    {
        continueButton.SetActive(false);

        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";  //End of the dialog
            continueButton.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Move to the quiz scene
        }
    }
   
}
