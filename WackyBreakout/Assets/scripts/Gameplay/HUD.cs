using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// The HUD for the game
/// </summary>
public class HUD : MonoBehaviour
{
	#region Fields

	// score support
	Text scoreText;
	int score = 0;
    const string ScorePrefix = "Score: ";

    // balls left support
    Text ballsLeftText;
    int ballsLeft;
    const string BallsLeftPrefix = "Balls Left: ";

    // Last ball invoker
    LastBallLost lastBallLost = new LastBallLost();

    // Last block invoker
    BlockDestroyed blockDestroyed = new BlockDestroyed();
    #endregion
    public int Score 
    { 
        get 
        { 
            return score; 
        } 
    }
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
		// initialize score text
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
		scoreText.text = ScorePrefix + score;

        // initialize balls left value and text
        ballsLeft = ConfigurationUtils.BallsPerGame;
        ballsLeftText = GameObject.FindGameObjectWithTag("BallsLeftText").GetComponent<Text>();
        ballsLeftText.text = BallsLeftPrefix + ballsLeft;

        // Add Event Listeners
        EventManager.AddPointsAddedListener(AddPoints);
        EventManager.AddOutOfBoundsListener(ReduceBallsLeft);

        // Add event Invoker
        EventManager.AddLastBallInvoker(this);
    }

	#region Public methods

	/// <summary>
	/// Updates the score
	/// </summary>
	/// <param name="points">points to add</param>
	void AddPoints(int points)
    {
		score += points;
		scoreText.text = ScorePrefix + score;
	}

    /// <summary>
    /// Updates the balls left
    /// </summary>
    void ReduceBallsLeft()
    {
        ballsLeft--;
        ballsLeftText.text = BallsLeftPrefix + ballsLeft;
        if(ballsLeft <= 0)
        {
            lastBallLost.Invoke();
        }
    }

    public void AddLastBallListener(UnityAction listener)
    {
        lastBallLost.AddListener(listener);
    }
    #endregion
}
