﻿using UnityEngine;

public class FastUpdateManager : MonoBehaviour {

	static FastUpdateManager _instance;
	public static FastUpdateManager Instance {
		get {
			if (_instance == null)
				_instance = (Instantiate(Resources.Load("FastUpdate")) as GameObject)
					.GetComponent<FastUpdateManager>();
			return _instance;
		}
	}

	public delegate void FastTick();
	public event FastTick OnUpdate, OnFixedUpdate, OnLateUpdate;

	private void Update() {
		if (OnUpdate != null)
			OnUpdate();
	}

	private void FixedUpdate() {
		if (OnFixedUpdate != null)
			OnFixedUpdate();
	}

	private void LateUpdate() {
		if (OnLateUpdate != null)
			OnLateUpdate();
	}
}
