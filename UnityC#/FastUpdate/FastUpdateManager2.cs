using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Excessives.ReflectionE;
using System;

//{TODO} Finish

/// <summary>
/// The rewrite of FastUpdateManager
/// </summary>
public class FastUpdateManager2 : MonoBehaviour
{
	List<CustomTicker> tickers = new List<CustomTicker>();

	void RegisterNewTicker(CustomTicker ticker)
	{
		tickers.Add(ticker);
	}

	void RegisterMethod(EventHandler<float> action)
	{
		for (int i = 0; i < tickers.Count; i++)
		{
			if (action.GetMethodInfo().Name == tickers[i].RequiredMethodName)
			{
				//tickers[i].Tick += action;
			}
		}
	}
}

public class CustomTicker
{
	public delegate void OnUpdate(float dt);
	public event OnUpdate Tick;

	public virtual string RequiredMethodName => "NotSet";

	#region Runs

	public virtual void Run(float normalDeltaTime) { }
	public virtual void LateRun(float normalDeltaTime) { }
	public virtual void FixedRun(float normalDeltaTime) { }

	#endregion

	protected virtual void TriggerUpdate(float deltaTime)
	{
		if (Tick != null)
			Tick(deltaTime);
	}

}

#region Unity Specific

public class UpdateTicker : CustomTicker
{
	public override string RequiredMethodName => "FastUpdate";

	public override void Run(float normalDeltaTime)
	{
		TriggerUpdate(normalDeltaTime);
	}
}

public class LateUpdateTicker : CustomTicker
{
	public override string RequiredMethodName => "FastLateUpdate";

	public override void LateRun(float normalDeltaTime)
	{
		TriggerUpdate(normalDeltaTime);
	}
}

public class FixedTicker : CustomTicker
{
	public override string RequiredMethodName => "FastFixedUpdate";

	public override void FixedRun(float normalDeltaTime)
	{
		TriggerUpdate(normalDeltaTime);
	}
}

#endregion

public class CustomUpdateTimer : CustomTicker
{


	/// <summary>
	/// Inverse of the desired delta time
	/// </summary>
	float ticksPerSecond { get; set; } = 0.1f;
	/// <summary>
	/// Is multiplied with the deltaTime used to calculate when to trigger each subscriber.
	/// </summary>
	float updateTimeScale { get; set; } = 1.0f;
	/// <summary>
	/// Is multiplied with the timescale handed to each subscriber,
	/// does not affect the ticks per second.
	/// </summary>
	float timeScale { get; set; } = 1.0f;

	#region BookKeeping

	float timeSinceLastTrigger = 0.0f;

	#endregion

	public override void Run(float normalDeltaTime)
	{
		timeSinceLastTrigger += normalDeltaTime;
		if (timeSinceLastTrigger >= (1.0f / ticksPerSecond))
		{
			TriggerUpdate(timeSinceLastTrigger);
			timeSinceLastTrigger -= (1.0f / ticksPerSecond);
		}
	}
}

