using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Excessives.Unity;
using System.Linq;
using Excessives.LinqE;

public class MouseLock : MonoBehaviour
{

	public bool isMouseLocked = true;

	/*
	 * 0 = Playing
	 * 1 = Pause Menu
	 * 2 = In Window (Inventory, Resource Window, etc)
	 * 3 = In Global Interactable (Vehicle, Mounted Gun, Artillery, etc)
	 */
	//public int controlState = 0;

	//	public void SetControlState (int state)
	//	{
	//		controlState = state;
	//	}
	//
	void Start ()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			isMouseLocked = false;
		}

		if (Input.GetMouseButtonDown (0) && !isMouseLocked) {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			isMouseLocked = true;
		}


	}
}
