﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
    // move delay timer
    Timer moveTimer;

    // death timer
    Timer deathTimer;

    // speedup effect support
    Rigidbody2D rb2d;
    Timer speedupTimer;
    float speedupFactor;

    // Dead ball events support
    OutOfBoundsEvent outOfBoundsEvent = new OutOfBoundsEvent();
    DeadBallEvent deadBallEvent = new DeadBallEvent();

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
        // start move timer
        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.Duration = 1;
        moveTimer.AddTimerFinishedEventListener(StartMoving);
        moveTimer.Run();

        // start death timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifeSeconds;
        deathTimer.AddTimerFinishedEventListener(SpawnReplacementBall);
        deathTimer.Run();

        // speedup effect support
        speedupTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedupEffectListener(HandleSpeedupEffectActivatedEvent);
        speedupTimer.AddTimerFinishedEventListener(ReturnToNormalSpeed);
        rb2d = GetComponent<Rigidbody2D>();

        // out of bounds support
        EventManager.AddOutOfBoundsInvoker(this);
        EventManager.AddDeadBallInvoker(this);

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
	{

	}

    /// <summary>
    /// spawn new ball and destroy self
    /// </summary>
    void SpawnReplacementBall()
    {
        deadBallEvent.Invoke();
        Destroy(gameObject);
    }

    /// <summary>
    /// return to normal speed as appropriate
    /// </summary>
    void ReturnToNormalSpeed()
    {
        AudioManager.Play(AudioClipName.SpeedupEffectDeactivated);
        rb2d.velocity *= 1 / speedupFactor;
    }
    /// <summary>
    /// Spawn new ball and destroy self when out of game
    /// </summary>
    void OnBecameInvisible()
    {
        // death timer destruction is in Update
        if (!deathTimer.Finished)
        {
            // only spawn a new ball if below screen
            float halfColliderHeight = 
                gameObject.GetComponent<BoxCollider2D>().size.y / 2;
            if (transform.position.y - halfColliderHeight < ScreenUtils.ScreenBottom)
            {
                outOfBoundsEvent.Invoke();
            }
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Starts the ball moving
    /// </summary>
    void StartMoving()
    {
        // calculate force to apply
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));

        // adjust as necessary if speedup effect is active
        if (EffectUtils.SpeedupEffectActive)
        {
            StartSpeedupEffect(EffectUtils.SpeedupEffectSecondsLeft,
                EffectUtils.SpeedupFactor);
            force *= speedupFactor;
        }

        // get ball moving
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    /// <summary>
    /// Sets the ball direction to the given direction
    /// </summary>
    /// <param name="direction">direction</param>
    public void SetDirection(Vector2 direction)
    {
        // get current rigidbody speed
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }

    /// <summary>
    /// Handles the speedup effect activated event
    /// </summary>
    /// <param name="duration">duration of the speedup effect</param>
    /// <param name="speedupFactor">the speedup factor</param>
    void HandleSpeedupEffectActivatedEvent(float duration, float speedupFactor)
    {
        // speed up ball and run or add time to timer
        if (!speedupTimer.Running)
        {
            AudioManager.Play(AudioClipName.SpeedupEffectActivated);
            StartSpeedupEffect(duration, speedupFactor);
            rb2d.velocity *= speedupFactor;
        }
        else
        {
            speedupTimer.AddTime(duration);
        }
    }

    /// <summary>
    /// Starts the speedup effect
    /// </summary>
    /// <param name="duration">duration of the speedup effect</param>
    /// <param name="speedupFactor">the speedup factor</param>
    void StartSpeedupEffect(float duration, float speedupFactor)
    {
        this.speedupFactor = speedupFactor;
        speedupTimer.Duration = duration;
        speedupTimer.Run();
    }

    /// <summary>
    /// Adds listener for when the ball goes out of bounds
    /// </summary>
    /// <param name="listener"></param>
    public void AddOutOfBoundsListener(UnityAction listener)
    {
        outOfBoundsEvent.AddListener(listener);
    }

    /// <summary>
    /// Adds listener for when the ball goes out of bounds
    /// </summary>
    /// <param name="listener"></param>
    public void AddDeadBallListener(UnityAction listener)
    {
        deadBallEvent.AddListener(listener);
    }
}