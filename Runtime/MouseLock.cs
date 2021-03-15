using Excessives.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour {

	public bool lockOnStart = false;

	public bool controlSelf = true;

	static bool _mouseLock = false;

	public static bool IsMouseLocked {
		get { return _mouseLock; }
		set {
			if (_mouseLock == value) return;
			_mouseLock = value;
			Cursor.visible = !value;
			Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}

	void Start() => IsMouseLocked = lockOnStart;

	private void Update() {
		if (controlSelf) {
			if (KeyCode.Escape.Pressed())
				IsMouseLocked = false;
			else if (KeyCode.Mouse0.Pressed())
				IsMouseLocked = true;
		}
	}

	public static Vector2 MouseDelta {
		get {
			return IsMouseLocked
				?
				new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"))
				:
				Vector2.zero;
		}
	}

	public static float MouseDeltaX { get { return IsMouseLocked ? Input.GetAxis("Mouse X") : 0.0f; } }

	public static float MouseDeltaY { get { return IsMouseLocked ? Input.GetAxis("Mouse Y") : 0.0f; } }

}
