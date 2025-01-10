using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An event manager
/// </summary>
public static class EventManager
{
    // FreezerEffectActivated support
    static List<PickupBlock> freezerEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float>> freezerEffectListeners = 
        new List<UnityAction<float>>();

    // speedupEffectActivated support
    static List<PickupBlock> speedupEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float, float>> speedupEffectListeners = 
        new List<UnityAction<float, float>>();

    // pointsAddedEvent support
    static List<Block> pointInvokers = new List<Block>();
    static List<UnityAction<int>> pointsAddedListeners =
        new List<UnityAction<int>>();

    // ballOutOfBoundsEvent support
    static List<Ball> outOfBoundsInvokers = new List<Ball>();
    static List<UnityAction> outOfBoundsListeners =
        new List<UnityAction>();

    // deadBallEvent support
    static List<Ball> deadBallInvokers = new List<Ball>();
    static List<UnityAction> deadBallListeners =
        new List<UnityAction>();

    // lastBallLost support
    static List<HUD> lastBallLostInvokers = new List<HUD>();
    static List<UnityAction> lastBallLostListeners =
        new List<UnityAction>();

    // blockDestroyed support
    static List<Block> blockDestroyedInvokers = new List<Block>();
    static List<UnityAction> blockDestroyedListeners =
        new List<UnityAction>();

    #region Public methods
    /// <summary>
    /// Adds the given script as a freezer effect invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddFreezerEffectInvoker(PickupBlock invoker)
    {
        // add invoker to list and add all listeners to invoker
        freezerEffectInvokers.Add(invoker);
        foreach (UnityAction<float> listener in freezerEffectListeners)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a freezer effect listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddFreezerEffectListener(UnityAction<float> listener)
    {
        // add listener to list and to all invokers
        freezerEffectListeners.Add(listener);
        foreach (PickupBlock invoker in freezerEffectInvokers)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a speedup effect invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddSpeedupEffectInvoker(PickupBlock invoker)
    {
        // add invoker to list and add all listeners to invoker
        speedupEffectInvokers.Add(invoker);
        foreach (UnityAction<float, float> listener in speedupEffectListeners)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a speedup effect listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddSpeedupEffectListener(UnityAction<float, float> listener)
    {
        // add listener to list and to all invokers
        speedupEffectListeners.Add(listener);
        foreach (PickupBlock invoker in speedupEffectInvokers)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a points added event invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddPointsAddedInvoker(Block invoker)
    {
        // add invoker to list and add all listeners to invoker
        pointInvokers.Add(invoker);
        foreach (UnityAction<int> listener in pointsAddedListeners)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as a points added event listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddPointsAddedListener(UnityAction<int> listener)
    {
        // add listener to list and to all invokers
        pointsAddedListeners.Add(listener);
        foreach (Block invoker in pointInvokers)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as an out of bounds invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddOutOfBoundsInvoker(Ball invoker)
    {
        // add invoker to list and add all listeners to invoker
        outOfBoundsInvokers.Add(invoker);
        foreach (UnityAction listener in outOfBoundsListeners)
        {
            invoker.AddOutOfBoundsListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as an out of bounds listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddOutOfBoundsListener(UnityAction listener)
    {
        // add listener to list and to all invokers
        outOfBoundsListeners.Add(listener);
        foreach (Ball invoker in outOfBoundsInvokers)
        {
            invoker.AddOutOfBoundsListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a dead ball invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddDeadBallInvoker(Ball invoker)
    {
        // add invoker to list and add all listeners to invoker
        deadBallInvokers.Add(invoker);
        foreach (UnityAction listener in deadBallListeners)
        {
            invoker.AddDeadBallListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as an out of bounds listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddDeadBallListener(UnityAction listener)
    {
        // add listener to list and to all invokers
        deadBallListeners.Add(listener);
        foreach (Ball invoker in deadBallInvokers)
        {
            invoker.AddDeadBallListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a last ball invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddLastBallInvoker(HUD invoker)
    {
        // add invoker to list and add all listeners to invoker
        lastBallLostInvokers.Add(invoker);
        foreach (UnityAction listener in lastBallLostListeners)
        {
            invoker.AddLastBallListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as an out of bounds listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddLastBallListener(UnityAction listener)
    {
        // add listener to list and to all invokers
        lastBallLostListeners.Add(listener);
        foreach (HUD invoker in lastBallLostInvokers)
        {
            invoker.AddLastBallListener(listener);
        }
    }

    /// <summary>
    /// Adds the given script as a last block destroyed invoker
    /// </summary>
    /// <param name="invoker">invoker</param>
    public static void AddBlockDestroyedInvoker(Block invoker)
    {
        // add invoker to list and add all listeners to invoker
        blockDestroyedInvokers.Add(invoker);
        foreach (UnityAction listener in blockDestroyedListeners)
        {
            invoker.AddBlockDestroyedListener(listener);
        }
    }

    /// <summary>
    /// Adds the given method as an out of bounds listener
    /// </summary>
    /// <param name="listener">listener</param>
    public static void AddBlockDestroyedListener(UnityAction listener)
    {
        // add listener to list and to all invokers
        blockDestroyedListeners.Add(listener);
        foreach (Block invoker in blockDestroyedInvokers)
        {
            invoker.AddBlockDestroyedListener(listener);
        }
    }
    #endregion
}
