using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMessage : MonoBehaviour
{
    [SerializeField]
    Text message;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // pause the game when added to the scene
        Time.timeScale = 0;
    }
    /// <summary>
    /// Sets the score of the game
    /// </summary>
    public void SetScore(int score)
    {
        message = GameObject.FindGameObjectWithTag("GameOverScore").GetComponent<Text>();
        message.text = "Score: " + score;
    }
    /// <summary>
    /// Handles the on click event from the Quit button
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        // unpause game, destroy menu, and go to main menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
