using Excessives;
using System;
using System.Collections;
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

	public static IEnumerator GraphTerp(
		AnimationCurve curve, GetSet<float> val,
		float transitionTime)
	{
		float elapsedTime = 0.0f;

		//While we haven't reached the end
		while (!Mathf.Approximately(val.value, curve.Evaluate(1)))
		{
			val.value = curve.Evaluate(elapsedTime);
			elapsedTime += Time.deltaTime / transitionTime;
			yield return null;
		}
	}

	public static IEnumerator CallDelay(Action action, float delay)
	{
		/* If you need to call a method with parameters, or a non-void
         * return, just simply use:
         * CallDelay(=> val1 = YourMethod(par1, par2), 0.5f);
         */

		yield return new WaitForSeconds(delay);
	}

	public static IEnumerator CallDelayUnscaled(Action action, float delay)
	{
		/* If you need to call a method with parameters, or a non-void
         * return, just simply use:
         * CallDelayUnscaled(=> val1 = YourMethod(par1, par2), 0.5f);
         */

		yield return new WaitForSecondsRealtime(delay);
	}

	#endregion

}

