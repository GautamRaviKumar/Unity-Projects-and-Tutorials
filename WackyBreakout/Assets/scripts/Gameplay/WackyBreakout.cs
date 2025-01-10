using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game manager
/// </summary>
public class WackyBreakout : MonoBehaviour
{
    int score;
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // Add event listeners
        EventManager.AddLastBallListener(Lose);
        EventManager.AddBlockDestroyedListener(Win);
    }
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // pause game on escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }
    /// <summary>
    /// Even for when the game Ends
    /// </summary>
    void GameOver()
    {
        score = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>().Score;
        // instantiate prefab
        GameObject gameOver = Object.Instantiate(Resources.Load("GameOverMessage")) as GameObject;
        gameOver.GetComponent<GameOverMessage>().SetScore(score);
    }

    /// <summary>
    /// Event for when balls left are 0
    /// </summary>
    void Lose()
    {
        //play loss audio
        AudioManager.Play(AudioClipName.GameLost);
        GameOver();
    }

    /// <summary>
    /// Event for when All blocks are destroyed
    /// </summary>
    void Win()
    {
        if (GameObject.FindGameObjectsWithTag("Block").Length == 1)
        {
            GameOver();
        }
    }
}
