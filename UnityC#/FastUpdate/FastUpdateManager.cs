using Excessives.LinqE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastUpdateManager : MonoBehaviour
{
	#region Singleton
	public static FastUpdateManager instance { get; private set; }

	public FastUpdateManager()
	{
		instance = this;
	}

	#endregion

	#region List of Subscribers

	LinkedList<IFastUpdateable> subscribed = new LinkedList<IFastUpdateable>();

	public void Subscribe(IFastUpdateable subscriber)
	{
		subscribed.AddLast(subscriber);
	}

	public void UnSubscribe(IFastUpdateable subscriber)
	{
		subscribed.Remove(subscriber);
	}
	#endregion

	#region Public Updates
	void Update()
	{
		subscribed.ForEach(n => n.FastUpdate());
	}

	void LateUpdate()
	{
		subscribed.ForEach(n => n.FastLateUpdate());
	}

	void FixedUpdate()
	{
		subscribed.ForEach(n => n.FastFixedUpdate());
	}
	#endregion

	void Awake()
	{
		GameObject.DontDestroyOnLoad(gameObject);
	}
}

public interface IFastUpdateable
{
	void FastUpdate();
	void FastLateUpdate();
	void FastFixedUpdate();
}