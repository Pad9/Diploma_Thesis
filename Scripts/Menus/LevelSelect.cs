using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public int LevelID;

    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + LevelID); //Select whatever level the player wants
    }

}
