using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinE : MonoBehaviour
{
    //Always place instance of this in world for it to work!
    public static CoroutinE inst;

    void Awake()
    {
        inst = this;
    }

    /// <summary>
    /// Allows you to run coroutines without having to inherit from monobehavior
    /// </summary>
    public Coroutine BeginCoroutine(IEnumerator coroutine)
    {
        return StartCoroutine(coroutine);
    }

    /// <summary>
    /// Allows you to stop coroutines without having to inherit from monobehavior
    /// </summary>
    public void EndCoroutine(Coroutine coroutine)
    {
        StopCoroutine(coroutine);
    }

    #region For coroutines
    /// <summary>
    /// Will continue the coroutine if the condition is met
    /// </summary>
    /// <param name="condition"></param>
    /// <returns></returns>
    public static IEnumerator ContIf(bool condition)
    {
        while (!condition)
        {
            yield return null;
        }
    }

    public static IEnumerator WaitForAnimEnd(Animation animation,
                                              string animationName)
    {
        while (animation.IsPlaying(animationName))
        {
            yield return null;
        }
    }

    #endregion

}

