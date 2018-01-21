using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class MonoLink<T>
{

	public T type1{ get; set; }

	public T type2{ get; set; }

	bool typesEqual;

	public MonoLink (
		T instance1, T instance2,
		ref MonoLink<T> var1, ref MonoLink<T> var2
	)
	{
		this.type1 = instance1;
		this.type2 = instance2;

		var1 = this;
		var2 = this;

	}


	public delegate void LinkDelegate ();

	public event LinkDelegate OnDestroy;

	public T GetOther (T instance)
	{
		return instance.Equals (type1)
			?
			type2
			:
			type1;
	}

	public void ChangeFirst (
		T newInstance,
		ref MonoLink<T> var1, ref MonoLink<T> var2
	)
	{
		this.type1 = newInstance;
		var1 = this;
		var2 = this;
	}

	public void ChangeSecond (
		T newInstance,
		ref MonoLink<T> var1, ref MonoLink<T> var2
	)
	{
		this.type2 = newInstance;
		var1 = this;
		var2 = this;
	}

	public bool IsThisFirst (T instance)
	{
		return this.type1.Equals (instance);
	}

	public bool IsThisSecond (T instance)
	{
		return this.type2.Equals (instance);
	}

	public void Destroy (
		ref MonoLink<T> var1, ref MonoLink<T> var2
	)
	{
		var1 = null;
		var2 = null;

		if (OnDestroy != null) {
			OnDestroy ();
		}
	}
}

[System.Serializable]
public class DualLink<T1, T2>
{
	public T1 type1{ get; set; }

	public T2 type2{ get; set; }


	public DualLink (
		T1 instance1, T2 instance2,
		ref DualLink<T1, T2> var1, ref DualLink<T1, T2> var2
	)
	{
		this.type1 = instance1;
		this.type2 = instance2;

		var1 = this;
		var2 = this;

		if (typeof(T1) == typeof(T2)) {
			throw new Exception ("Both types cannot be equal, use MonoLink instead.");
		}
	}

	public delegate void LinkDelegate ();

	public event LinkDelegate OnDestroy;

	public T2 GetOther (T1 instance)
	{
		return type2;
	}

	public T1 GetOther (T2 instance)
	{
		return type1;
	}

	public void ChangeFirst (
		T1 newInstance,
		ref DualLink<T1, T2> var1, ref DualLink<T1, T2> var2
	)
	{
		this.type1 = newInstance;
		var1 = this;
		var2 = this;
	}

	public void ChangeSecond (
		T2 newInstance,
		ref DualLink<T1, T2> var1, ref DualLink<T1, T2> var2
	)
	{
		this.type2 = newInstance;
		var1 = this;
		var2 = this;
	}

	public bool IsThisFirst (T1 instance)
	{
		return this.type1.Equals (instance);
	}

	public bool IsThisSecond (T2 instance)
	{
		return this.type2.Equals (instance);
	}

	public void Destroy (
		ref DualLink<T1, T2> var1, ref DualLink<T1, T2> var2
	)
	{
		var1 = null;
		var2 = null;

		if (OnDestroy != null) {
			OnDestroy ();
		}

	}



}
