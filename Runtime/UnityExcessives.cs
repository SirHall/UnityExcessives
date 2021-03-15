using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Excessives;
using System;

namespace Excessives.Unity {
	public static class UnityExcessives {
		#region Find child by name

		public static GameObject ChildByName(this GameObject fromGameObject, string withName) {
			return FindChildByName(fromGameObject, withName);
		}

		public static GameObject FindChildByName(GameObject fromGameObject, string withName) {
			Transform[] ts =
				fromGameObject.transform.GetComponentsInChildren<Transform>();
			foreach (Transform t in ts)
				if (t.gameObject.name == withName)
					return t.gameObject;
			return null;
		}

		#endregion

		#region Position Snapping

		public static Vector3 SnapToGrid(Vector3 pos) {
			pos.x = Mathf.Round(pos.x);
			pos.y = Mathf.Round(pos.y);
			pos.z = Mathf.Round(pos.z);
			return pos;
		}

		public static Vector3 SnapToNGrid(Vector3 pos, float n) {
			pos.x = MathE.RoundToN(pos.x, n);
			pos.y = MathE.RoundToN(pos.y, n);
			pos.z = MathE.RoundToN(pos.z, n);
			return pos;
		}

		public static Vector3 SnapToNGrid(Vector3 pos, Vector3 n) {
			pos.x = MathE.RoundToN(pos.x, n.x);
			pos.y = MathE.RoundToN(pos.y, n.y);
			pos.z = MathE.RoundToN(pos.z, n.z);
			return pos;
		}

		#endregion

		#region Extensions Methods

		public static float Lerp(this ref float origi, float target, float t) => Mathf.LerpUnclamped(origi, target, t);

		public static float Range(this Vector2 v) => CryptoRand.Range(v.x, v.y);


		#region KeyCode

		public static bool Pressed(this KeyCode k) => Input.GetKeyDown(k);

		public static bool Held(this KeyCode k) => Input.GetKey(k);

		public static bool Lifted(this KeyCode k) => Input.GetKeyUp(k);

		public static bool NotHeld(this KeyCode k) => !Input.GetKey(k);


		#endregion

		#region Transforms

		public static Transform[] GetChildren(this Transform root) {
			Transform[] children = new Transform[root.childCount];

			for (int i = 0; i < children.Length; i++)
				children[i] = root.GetChild(i);

			return children;
		}

		#endregion

		#endregion

		/// <summary>
		/// If k1 matches the criteria, call the k1Act action,
		/// if k2 matches the criteria, call the k2Act action,
		/// if both match, call the both action,
		/// if neither, call the neither action.
		/// </summary>
		/// <param name="k1">K1.</param>
		/// <param name="k2">K2.</param>
		/// <param name="k1Detect">K1 detect.</param>
		/// <param name="k2Detect">K2 detect.</param>
		/// <param name="k1Act">K1 act.</param>
		/// <param name="k2Act">K2 act.</param>
		/// <param name="both">Both.</param>
		/// <param name="neither">Neither.</param>
		public static void IfKeys(
			KeyCode k1, KeyCode k2,
			KeyDetectMode k1Detect, KeyDetectMode k2Detect,
			Action k1Act, Action k2Act, Action both = null, Action neither = null
		) {
			bool isk1 = IsKey(k1, k1Detect), isk2 = IsKey(k2, k2Detect);
			if (isk1 && isk2) { //k1 == true, k2 == true
				if (both != null) both(); //Leave the check on the inside, this will prevent pointless checks
			} else if (isk1 && !isk2) { //k1 == true, k2 == false
				if (k1Act != null) k1Act();
			} else if (!isk1 && isk2) { //k1 == false, k2 == true
				if (k2Act != null) k2Act();
			} else if (!isk1 && !isk2) { //k1 == false, k2 == false
				if (neither != null) neither();
			}
		}

		/// <summary>
		/// Determines if the key input matches the criteria
		/// </summary>
		public static bool IsKey(KeyCode k, KeyDetectMode kDetect) {
			switch (kDetect) {
				case KeyDetectMode.Held:
					return Input.GetKey(k);
				case KeyDetectMode.NotHeld:
					return !Input.GetKey(k);
				case KeyDetectMode.Pressed:
					return Input.GetKeyDown(k);
				case KeyDetectMode.Lifted:
					return Input.GetKeyUp(k);
			}
			return false;
		}


		public static Vector3 FindNormal(Vector3 point1, Vector3 point2, Vector3 point3) =>
			Vector3.Cross(point2 - point1, point3 - point1).normalized;

		public static Vector3 MeanPos(params Vector3[] positions) {
			Vector3 meanPos = Vector3.zero;
			for (int i = 0; i < positions.Length; i++)
				meanPos += positions[i] / positions.Length; //We divide each position by n to avoid losses in precision
			return meanPos;
		}

		#region Vector Modification

		public static Vector3 WithX(this Vector3 v, float newX) {
			v.x = newX;
			return v;
		}

		public static Vector3 WithY(this Vector3 v, float newY) {
			v.y = newY;
			return v;
		}

		public static Vector3 WithZ(this Vector3 v, float newZ) {
			v.z = newZ;
			return v;
		}

		public static Vector2 WithX(this Vector2 v, float newX) {
			v.x = newX;
			return v;
		}

		public static Vector2 WithY(this Vector2 v, float newY) {
			v.y = newY;
			return v;
		}

		#endregion

		#region Debugging

		public static T Log<T>(this T instance) {
			Debug.Log(instance);
			return instance;
		}

		public static void LogArrayElements<TSource>(
	   this IEnumerable<TSource> enumerable,
	   string splitter = ", ") {
			ExtensionsE.ToElementsString(enumerable, splitter).Log();
		}

		public static void LogLineArrayElements<TSource>(
	   this IEnumerable<TSource> enumerable,
	   string splitter = ", ") {
			LogArrayElements(enumerable, splitter);
		}

		#region Dictionary Debugging
		/// <summary>
		/// Writes elements to the console
		/// </summary>
		public static void WriteElements<TSource1, TSource2>(
			this Dictionary<TSource1, TSource2> dict,
			string keyValueSeparator = " => ",
			string elementSeparator = "\n") {
			ExtensionsE
				.ToElementsString(dict, keyValueSeparator, elementSeparator)
				.Log();
		}
		#endregion

		//		public static bool Draw (this )
		//		{
		//
		//		}

		#endregion

		#region Rotation Locking
		/* Warning:
		 * These three lock methods convert from euler to quaternion
		 * rotation systems, and therefore are not 100% reliable
		 */

		public static Quaternion LockXRotation(this Quaternion quat, float x) {
			return Quaternion.Euler(
				x,
				quat.eulerAngles.y,
				quat.eulerAngles.z
			);
		}

		public static Quaternion LockYRotation(this Quaternion quat, float y) {

			return Quaternion.Euler(
				quat.eulerAngles.x,
				y,
				quat.eulerAngles.z
			);

		}

		public static Quaternion LockZRotation(this Quaternion quat, float z) {
			return Quaternion.Euler(
				quat.eulerAngles.x,
				quat.eulerAngles.y,
				z
			);
		}

		#endregion

		#region Pos Rot offsets

		//Position from Rotation and Radius
		public static Vector3 PosFromRotAndRadius(float rotation, float radius) {
			return new Vector3(
				radius * Mathf.Sin(rotation * Mathf.Deg2Rad),
				0,
				radius * Mathf.Cos(rotation * Mathf.Deg2Rad)
			);
		}

		#endregion
	}

	#region Animation Variables

	public class AnimVar<T> {
		protected Animator anim;
		protected int hash;

		#region Constructors

		public AnimVar(Animator anim, string varName) {
			this.anim = anim;
			this.hash = Animator.StringToHash(varName);
		}

		public AnimVar(Animator anim, int hash) {
			this.hash = hash;
			this.anim = anim;
		}

		#endregion

		public virtual T Val {
			get { return default(T); }
			set { }
		}

	}

	public class AnimVarFloat : AnimVar<float> {
		public AnimVarFloat(Animator anim, string varName) : base(anim, varName) { }
		public AnimVarFloat(Animator anim, int hash) : base(anim, hash) { }
		public override float Val {
			get => anim.GetFloat(hash);
			set => anim.SetFloat(hash, value);
		}
	}

	public class AnimVarInt : AnimVar<int> {
		public AnimVarInt(Animator anim, string varName) : base(anim, varName) { }
		public AnimVarInt(Animator anim, int hash) : base(anim, hash) { }
		public override int Val {
			get => anim.GetInteger(hash);
			set => anim.SetInteger(hash, value);
		}
	}

	public class AnimVarBool : AnimVar<bool> {
		public AnimVarBool(Animator anim, string varName) : base(anim, varName) { }
		public AnimVarBool(Animator anim, int hash) : base(anim, hash) { }
		public override bool Val {
			get => anim.GetBool(hash);
			set => anim.SetBool(hash, value);
		}
	}

	public class AnimVarTrigger {
		Animator anim;
		int hash;

		#region Constructors

		public AnimVarTrigger(Animator anim, string varName) {
			this.anim = anim;
			this.hash = Animator.StringToHash(varName);
		}

		public AnimVarTrigger(Animator anim, int hash) {
			this.hash = hash;
			this.anim = anim;
		}

		#endregion

		public void Trigger() => anim.SetTrigger(hash);
		public void ResetTrigger() => anim.ResetTrigger(hash);
	}
	#endregion
}

public enum KeyDetectMode {
	Held,
	NotHeld,
	Pressed,
	Lifted
}
