using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int lives;
    public int totalpizza;
    
    public string currentScene;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI missingPizza;
    
    public GameObject respawnPosition;
    public GameObject gameOver;
    public GameObject endGame;
    
    public BoxCollider endGameBarrier;
    public BoxCollider endGameBarrier2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameOver.SetActive(false);
        currentScene = SceneManager.GetActiveScene().name;



    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = lives.ToString();
        scoreText.text = score.ToString() + "/" + totalpizza.ToString();

        if(score == totalpizza)
        {
            missingPizza.gameObject.SetActive(false);
        }
        if (score == 100)
        {
            endGameBarrier2.enabled = false;
        }
    
    }

    public void RestartButton()
    {
        if (currentScene == "Level 1")
        {
            SceneManager.LoadScene("Level 1");
        }

        if (currentScene == "Level 2")
        {
            SceneManager.LoadScene("Level 1");
        }
        if (currentScene == "Level 3")
        {
            SceneManager.LoadScene("Level 2");
        }

    }
     public void QuitButton()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
