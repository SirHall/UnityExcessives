using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Excessives;
using System;

namespace Excessives.Unity
{
    public static class UnityExcessives
    {
        #region Find child by name

        public static GameObject ChildByName(this GameObject fromGameObject, string withName)
        {
            return FindChildByName(fromGameObject, withName);
        }

        public static GameObject FindChildByName(GameObject fromGameObject, string withName)
        {
            Transform[] ts =
                fromGameObject.transform.GetComponentsInChildren<Transform>();
            foreach (Transform t in ts)
                if (t.gameObject.name == withName)
                    return t.gameObject;
            return null;
        }

        #endregion

        #region Position Snapping

        public static Vector3 SnapToGrid(Vector3 pos)
        {
            pos.x = Mathf.Round(pos.x);
            pos.y = Mathf.Round(pos.y);
            pos.z = Mathf.Round(pos.z);
            return pos;
        }

        public static Vector3 SnapToNGrid(Vector3 pos, float n)
        {
            pos.x = MathE.RoundToN(pos.x, n);
            pos.y = MathE.RoundToN(pos.y, n);
            pos.z = MathE.RoundToN(pos.z, n);
            return pos;
        }

        public static Vector3 SnapToNGrid(Vector3 pos, Vector3 n)
        {
            pos.x = MathE.RoundToN(pos.x, n.x);
            pos.y = MathE.RoundToN(pos.y, n.y);
            pos.z = MathE.RoundToN(pos.z, n.z);
            return pos;
        }

        #endregion

        #region Extensions Methods

        public static float Lerp(this float origi, float target, float t)
        {
            //Would be really nice if we could recieve a reference
            //to the original here.
            return Mathf.LerpUnclamped(origi, target, t);
        }

        #region KeyCode

        public static bool Pressed(this KeyCode k)
        {
            return Input.GetKeyDown(k);
        }
        public static bool Held(this KeyCode k)
        {
            return Input.GetKey(k);
        }
        public static bool Lifted(this KeyCode k)
        {
            return Input.GetKeyUp(k);
        }
        public static bool NotHeld(this KeyCode k)
        {
            return !Input.GetKey(k);
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
        )
        {
            //k1 == true, k2 == true
            if (IsKey(k1, k1Detect) && IsKey(k2, k2Detect))
            {
                both.InvokeNull();
                return;
            }

            //k1 == true, k2 == false
            if (IsKey(k1, k1Detect) && !IsKey(k2, k2Detect))
            {
                k1Act.InvokeNull();
                return;
            }

            //k1 == false, k2 == true
            if (!IsKey(k1, k1Detect) && IsKey(k2, k2Detect))
            {
                k2Act.InvokeNull();
                return;
            }

            //k1 == false, k2 == false
            if (!IsKey(k1, k1Detect) && !IsKey(k2, k2Detect))
            {
                neither.InvokeNull();
                return;
            }
        }

        /// <summary>
        /// Determines if the key input matches the criteria
        /// </summary>
        public static bool IsKey(KeyCode k, KeyDetectMode kDetect)
        {
            switch (kDetect)
            {
                case KeyDetectMode.Held:
                    return Input.GetKey(k);
                case KeyDetectMode.NotHeld:
                    return !Input.GetKey(k);
                case KeyDetectMode.Pressed:
                    return Input.GetKeyDown(k);
                case KeyDetectMode.Lifted:
                    return Input.GetKeyUp(k);
            }
            return new bool();
        }


        public static Vector3 FindNormal(Vector3 point1, Vector3 point2, Vector3 point3)
        {
            return Vector3.Cross(point2 - point1, point3 - point1).normalized;
        }

        public static Vector3 FindMeanPosition(params Vector3[] positions)
        {
            Vector3 position = Vector3.zero;
            foreach (Vector3 pos in positions)
            {
                position += pos;
            }

            return position / positions.Length;
        }

        #region Vector Modification

        public static Vector3 WithX(this Vector3 v, float newX)
        {
            v.x = newX;
            return v;
        }

        public static Vector3 WithY(this Vector3 v, float newY)
        {
            v.y = newY;
            return v;
        }

        public static Vector3 WithZ(this Vector3 v, float newZ)
        {
            v.z = newZ;
            return v;
        }

        public static Vector2 WithX(this Vector2 v, float newX)
        {
            v.x = newX;
            return v;
        }

        public static Vector2 WithY(this Vector2 v, float newY)
        {
            v.y = newY;
            return v;
        }

        #endregion

        #region Debugging

        public static void Log<T>(this T instance)
        {
            Debug.Log(instance);
        }

        //		public static bool Draw (this )
        //		{
        //
        //		}

        #endregion

        #region Locking
        /* Warning:
         * These three lock methods convert from euler to quaternion
         * rotation systems, and therefore are not 100% reliable
         */


        public static Quaternion LockXRotation(this Quaternion quat, float x)
        {
            return Quaternion.Euler(
                x,
                quat.eulerAngles.y,
                quat.eulerAngles.z
            );
        }

        public static Quaternion LockYRotation(this Quaternion quat, float y)
        {

            return Quaternion.Euler(
                quat.eulerAngles.x,
                y,
                quat.eulerAngles.z
            );

        }

        public static Quaternion LockZRotation(this Quaternion quat, float z)
        {
            return Quaternion.Euler(
                quat.eulerAngles.x,
                quat.eulerAngles.y,
                z
            );
        }

        #endregion

        #region Pos Rot offsets

        //Position from Rotation and Radius
        public static Vector3 PosFromRotAndRadius(float rotation, float radius)
        {
            return new Vector3(
                radius * Mathf.Sin(rotation * Mathf.Deg2Rad),
                0,
                radius * Mathf.Cos(rotation * Mathf.Deg2Rad)
            );
        }

        #endregion

        public static T GetComponentExpected<T>(this GameObject g)
        {
            T component = g.GetComponent<T>();

            if (component.NotNull())
            {
                return component;
            }

            //{TODO} Re-enable
            //Debug.LogError(
            //    "Please attach "
            //    + nameof(T) +
            //    " component to humanoid gameobject: " + g);

            return default(T);
        }

        #region Array Logging
        public static void LogArrayElements<TSource>(
       this IEnumerable<TSource> enumerable,
       string splitter = ", ")
        {
            ExtensionsE.ToElementsString(enumerable, splitter).Log();
        }

        public static void LogLineArrayElements<TSource>(
       this IEnumerable<TSource> enumerable,
       string splitter = ", ")
        {
            LogArrayElements(enumerable, splitter);
        }
        #endregion

    }


    public class AnimVarFloat
    {
        Animator anim;
        int hash;

        public float val
        {
            get { return anim.GetFloat(hash); }
            set { anim.SetFloat(hash, value); }
        }

        #region Constructors

        public AnimVarFloat(Animator anim, int hash)
        {
            this.hash = hash;
            this.anim = anim;
        }

        public AnimVarFloat(Animator anim, string varName)
        {
            this.hash = Animator.StringToHash(varName);
            this.anim = anim;
        }

        #endregion

        #region Overloads

        public static implicit operator float(AnimVarFloat v)
        {
            return v.val;
        }



        public static AnimVarFloat operator +(AnimVarFloat a, float b)
        {
            a.val += b;
            return a;
        }

        public static AnimVarFloat operator -(AnimVarFloat a, float b)
        {
            a.val -= b;
            return a;
        }

        public static AnimVarFloat operator *(AnimVarFloat a, float b)
        {
            a.val *= b;
            return a;
        }

        public static AnimVarFloat operator /(AnimVarFloat a, float b)
        {
            a.val /= b;
            return a;
        }

        #endregion

        public void Lerp(float target, float t)
        {
            this.val = Mathf.Lerp(val, target, t);
        }

    }

    public class AnimVarInt
    {
        Animator anim;
        int hash;

        public int val
        {
            get { return anim.GetInteger(hash); }
            set { anim.SetInteger(hash, value); }
        }

        #region Constructors

        public AnimVarInt(Animator anim, int hash)
        {
            this.hash = hash;
            this.anim = anim;
        }

        public AnimVarInt(Animator anim, string varName)
        {
            this.hash = Animator.StringToHash(varName);
            this.anim = anim;
        }

        #endregion

        #region Overloads

        public static implicit operator int(AnimVarInt v)
        {
            return v.val;
        }

        public static AnimVarInt operator +(AnimVarInt a, int b)
        {
            a.val += b;
            return a;
        }

        public static AnimVarInt operator -(AnimVarInt a, int b)
        {
            a.val -= b;
            return a;
        }

        public static AnimVarInt operator *(AnimVarInt a, int b)
        {
            a.val *= b;
            return a;
        }

        public static AnimVarInt operator /(AnimVarInt a, int b)
        {
            a.val /= b;
            return a;
        }

        #endregion

    }
}

public enum KeyDetectMode
{
    Held,
    NotHeld,
    Pressed,
    Lifted
}
