using System;
using System.Linq;
using Excessives.LinqE;
using System.Diagnostics;
using System.Security.Cryptography;


namespace Excessives
{
    static class MathE
    {
        #region Constants

        public const double GOLDENRATIO = 1.6180339887498948482;

        public const double PLASTICNUMBER = 1.32471795724474602596;

        public const double TAU = 6.283185307179586;

        public const double SPEEDOFLIGHT = 299792458;

        public const double PLANCKLENGTH = 1.61622938 * (10 * -35);

        public const double PLANCKTIME = 5.3911613 * (10 ^ -44);

        /// <summary>
        /// Note that this is in Kelvin
        /// </summary>
        public const double PLANCKTEMPERATURE = 1.41680833 * (10 ^ 32);

        public const double PLANCKMASS = 4.341 * (10 ^ -9);

        public const double GRAVITATIONALCONSTANT = 6.6740831 * (10 ^ -11);

        public const double PLANCKSCONSTANT = 6.62 * (10 ^ -34);

        /// <summary>
        /// One light year in metres
        /// </summary>
        public const double LIGHTYEAR = 9460730472580800;

        #endregion

        #region Clamp

        public static float Clamp(float current, float min, float max)
        {
            return
                (current < min) ?
                    min
                    :
                    (
                (current > max) ?
                        max
                        :
                        current
            );
        }

        public static int Clamp(int current, int min, int max)
        {
            return
                (current < min) ?
                    min
                    :
                    (
                (current > max) ?
                        max
                        :
                        current
            );
        }

        public static long Clamp(long current, long min, long max)
        {
            return
                (current < min) ?
                    min
                    :
                    (
                (current > max) ?
                        max
                        :
                        current
            );
        }

        public static double Clamp(double current, double min, double max)
        {
            return
                (current < min) ?
                    min
                    :
                    (
                (current > max) ?
                        max
                        :
                        current
            );
        }

        public static ulong Clamp(ulong current, ulong min, ulong max)
        {
            return
                (current < min) ?
                    min
                    :
                    (
                (current > max) ?
                        max
                        :
                        current
            );
        }

        public static uint Clamp(uint current, uint min, uint max)
        {
            return
                (current < min) ?
                    min
                    :
                    (
                (current > max) ?
                        max
                        :
                        current
            );
        }

        public static byte Clamp(byte current, byte min, byte max)
        {
            return
                (current < min) ?
                    min
                    :
                    (
                (current > max) ?
                        max
                        :
                        current
            );
        }

        public static float Clamp(sbyte current, sbyte min, sbyte max)
        {
            return
                (current < min) ?
                    min
                    :
                    (
                (current > max) ?
                        max
                        :
                        current
            );
        }

        #endregion

        #region Add Towards

        #region OverFLow

        public static float AddTowardsOverFlow(float value1, float value2, float target)
        {
            return value1 + (value2 * Math.Sign(target - value1));
        }

        #endregion

        #region Onbstructed

        //Hard to read

        public static float AddTowardsObstructed(float value1, float value2, float target)
        {
            float v = value1 + (value2 * Math.Sign(target - value1));

            return
                (value1 < target) //If we were firstly underneath the target
                ?
                (//Underneath
                (v > target) //v is larger than the target
                    ?
                    target //Clamp to target
                    :
                    v //Else return v
            )
                :
                (//Not firstly underneath
                (value1 > target)//If firstly above
                    ?
                    (
                    (v < target)//If smaller than target
                        ?
                        target //Clamp to target
                        :
                        v //Else return v
                )
                    :
                    ( //Not above and not below, must be exactly equal to target
                    target
                )
            );

        }

        public static int AddTowardsObstructed(int value1, int value2, int target)
        {
            int v = value1 + (value2 * Math.Sign(target - value1));

            return
                (value1 < target) //If we were firstly underneath the target
                ?
                (//Underneath
                (v > target) //v is larger than the target
                    ?
                    target //Clamp to target
                    :
                    v //Else return v
            )
                :
                (//Not firstly underneath
                (value1 > target)//If firstly above
                    ?
                    (
                    (v < target)//If smaller than target
                        ?
                        target //Clamp to target
                        :
                        v //Else return v
                )
                    :
                    ( //Not above and not below, must be exactly equal to target
                    target
                )
            );

        }

        public static double AddTowardsObstructed(double value1, double value2, double target)
        {
            double v = value1 + (value2 * Math.Sign(target - value1));

            return
                (value1 < target) //If we were firstly underneath the target
                ?
                (//Underneath
                (v > target) //v is larger than the target
                    ?
                    target //Clamp to target
                    :
                    v //Else return v
            )
                :
                (//Not firstly underneath
                (value1 > target)//If firstly above
                    ?
                    (
                    (v < target)//If smaller than target
                        ?
                        target //Clamp to target
                        :
                        v //Else return v
                )
                    :
                    ( //Not above and not below, must be exactly equal to target
                    target
                )
            );

        }

        #endregion

        #region Rebound

        public static float AddTowardsRebound(float value1, float value2, float target)
        {
            float v = value1 + (value2 * Math.Sign(target - value1));

            float offcut = Math.Abs(v - value1);

            return
                (value1 < target) //If we were firstly underneath the target
                ?
                (//Underneath
                (v > target) //v is larger than the target
                    ?
                    target - offcut//Rebound from target
                    :
                    v //Else return v
            )
                :
                (//Not firstly underneath
                (value1 > target)//If firstly above
                    ?
                    (
                    (v < target)//If smaller than target
                        ?
                        target + offcut//Rebound from target
                        :
                        v //Else return v
                )
                    :
                    ( //Not above and not below, must be exactly equal to target
                    target
                )
            );

        }

        public static int AddTowardsRebound(int value1, int value2, int target)
        {
            int v = value1 + (value2 * Math.Sign(target - value1));

            int offcut = Math.Abs(v - value1);

            return
                (value1 < target) //If we were firstly underneath the target
                ?
                (//Underneath
                (v > target) //v is larger than the target
                    ?
                    target - offcut//Rebound from target
                    :
                    v //Else return v
            )
                :
                (//Not firstly underneath
                (value1 > target)//If firstly above
                    ?
                    (
                    (v < target)//If smaller than target
                        ?
                        target + offcut//Rebound from target
                        :
                        v //Else return v
                )
                    :
                    ( //Not above and not below, must be exactly equal to target
                    target
                )
            );

        }

        public static double AddTowardsRebound(double value1, double value2, double target)
        {
            double v = value1 + (value2 * Math.Sign(target - value1));

            double offcut = Math.Abs(v - value1);

            return
                (value1 < target) //If we were firstly underneath the target
                ?
                (//Underneath
                (v > target) //v is larger than the target
                    ?
                    target - offcut//Rebound from target
                    :
                    v //Else return v
            )
                :
                (//Not firstly underneath
                (value1 > target)//If firstly above
                    ?
                    (
                    (v < target)//If smaller than target
                        ?
                        target + offcut//Rebound from target
                        :
                        v //Else return v
                )
                    :
                    ( //Not above and not below, must be exactly equal to target
                    target
                )
            );

        }


        #endregion

        #endregion

        #region ClampWrap

        //Useful for clamping angles
        public static float ClampWrap(float value, float min, float max)
        {
            if (value < min)
                return value + (max * ((value / max) + 1));
            else if (value > max)
                return value - (max * (value / max));
            else
                return value;
        }

        #endregion

        #region ReMap

        public static float ReMap(float value, float inMin, float inMax, float outMin, float outMax)
        {
            return (value - inMin) / (outMin - inMin) * (outMax - inMax) + inMax;
        }

        #endregion

        #region Derivatives Of Position

        public static double PosFromDerivatives(
            double velocity, double acceleration,
            double jerk, double jounce,
            double time)
        {
            return //This is why I love the order of operations
                velocity * time
            +
            acceleration * time * time / 2
            +
            jerk * time * time * time / 6
            +
            jounce * time * time * time * time / 24;

        }

        #endregion

        #region Boolean to Num

        public static float BoolToFloat(bool boolean)
        {
            return boolean ? 1f : 0f;
        }

        public static int BoolToInt(bool boolean)
        {
            return boolean ? 1 : 0;
        }

        #endregion

        #region Bit Play

        //Good for packing 8 bools (8 bytes) into 1
        public static byte BoolArrayToBinaryByte(bool[] boolArray)
        {
            return (byte)(
                (boolArray[0] ? 1 : 0) << 7 |
                (boolArray[1] ? 1 : 0) << 6 |
                (boolArray[2] ? 1 : 0) << 5 |
                (boolArray[3] ? 1 : 0) << 4 |
                (boolArray[4] ? 1 : 0) << 3 |
                (boolArray[5] ? 1 : 0) << 2 |
                (boolArray[6] ? 1 : 0) << 1 |
                (boolArray[7] ? 1 : 0)
            );
        }

        //Unpacks one byte back into an array of 8 bools
        public static bool[] BinaryByteToBool(byte binary)
        {
            return new bool[] {
                (binary & 1) > 0,
                (binary & 2) > 0,
                (binary & 4) > 0,
                (binary & 8) > 0,
                (binary & 16) > 0,
                (binary & 32) > 0,
                (binary & 64) > 0,
                (binary & 128) > 0
            };
        }

        //Will return a string showing all the byte values for the byte sent in
        public static string BinaryToString(byte _byte)
        {
            string byteString = "";

            byteString += ((_byte & 128) > 0) ? "1" : "0";
            byteString += ((_byte & 64) > 0) ? "1" : "0";
            byteString += ((_byte & 32) > 0) ? "1" : "0";
            byteString += ((_byte & 16) > 0) ? "1" : "0";
            byteString += ((_byte & 8) > 0) ? "1" : "0";
            byteString += ((_byte & 4) > 0) ? "1" : "0";
            byteString += ((_byte & 2) > 0) ? "1" : "0";
            byteString += ((_byte & 1) > 0) ? "1" : "0";


            return byteString;
        }

        //Same as previous, just allows for entire arrays to be processed in one go
        public static string BinaryToString(byte[] bytes)
        {
            string byteString = "";

            bytes.ForEachBack(n => byteString += BinaryToString(n)); //Quite a handy extension method I'd say

            return byteString;
        }

        //Get a bit at any point
        public static bool GetBit(byte bitList, int position)
        {
            return (bitList & (1 << position)) > 0;
        }

        //Get a bit at any point
        public static bool GetBit(byte[] bitList, ulong position)
        {
            return
                GetBit(
                bitList[(int)Math.Floor((decimal)position / 8)],
                (int)position % 8
            );
        }

        #endregion

        #region Rounding

        #region Double

        /// <summary>
        /// Rounds to the nearest multiple of 'n'.
        /// </summary>
        /// <param name="val">Value.</param>
        /// <param name="n">N.</param>
        public static double RoundToN(double val, double n)
        {
            return n * Math.Round(val / n);
        }

        /// <summary>
        /// Rounds up to the nearest multiple of 'n'.
        /// </summary>
        /// <param name="val">Value.</param>
        /// <param name="n">N.</param>
        public static double CeilToN(double val, double n)
        {
            return n * Math.Ceiling(val / n);
        }

        /// <summary>
        /// Rounds down to the nearest multiple of 'n'.
        /// </summary>
        /// <param name="val">Value.</param>
        /// <param name="n">N.</param>
        public static double FloorToN(double val, double n)
        {
            return n * Math.Floor(val / n);
        }

        #endregion

        #region Float

        /// <summary>
        /// Rounds to the nearest multiple of 'n'.
        /// </summary>
        /// <param name="val">Value.</param>
        /// <param name="n">N.</param>
        public static float RoundToN(float val, float n)
        {
            return n * Round(val / n);
        }

        /// <summary>
        /// Rounds up to the nearest multiple of 'n'.
        /// </summary>
        /// <param name="val">Value.</param>
        /// <param name="n">N.</param>
        public static float CeilToN(float val, float n)
        {
            return n * Ceil(val / n);
        }

        /// <summary>
        /// Rounds down to the nearest multiple of 'n'.
        /// </summary>
        /// <param name="val">Value.</param>
        /// <param name="n">N.</param>
        public static float FloorToN(float val, float n)
        {
            return n * Floor(val / n);
        }

        #endregion

        #endregion

        #region Lerps

        #region Double

        /// <summary>
        /// Lerp
        /// </summary>
        public static double Lerp(double a, double b, double t)
        {
            return ((b - a) * t) + a;
        }


        /// <summary>
        /// Quadratic Lerp
        /// </summary>
        public static double QuadLerp(double a, double b, double t)
        {
            return ((b - a) * t * t) + a;
        }

        /// <summary>
        /// A Sine Lerp
        /// </summary>
        public static double SineLerp(double a, double b, double t)
        {
            return ((b - a) * Math.Sin(t * Math.PI / 2)) + a;
        }

        //Finds the 't' used to lerp between two numbers
        public static double UnLerp(double a, double b, double lerped)
        {
            //Lerp function: lerped = ((b-a) * t) + a
            //Solve for t
            //t = (lerped - a) / (b - a)

            return (lerped - a) / (b - a);
        }

        public static double UnQuadLerp(double a, double b, double lerped)
        {
            //Lerp function: lerped = ((b-a) * t * t) + a
            //Solve for t
            //t = Sqrt((lerped - a) / (b - a))
            return Math.Sqrt((lerped - a) / (b - a));
        }

        #endregion

        #region Float

        /// <summary>
        /// Lerp
        /// </summary>
        public static float Lerp(float a, float b, float t)
        {
            return ((b - a) * t) + a;
        }


        /// <summary>
        /// Quadratic Lerp
        /// </summary>
        public static float QuadLerp(float a, float b, float t)
        {
            return ((b - a) * t * t) + a;
        }

        /// <summary>
        /// A Sine Lerp
        /// </summary>
        public static float SineLerp(float a, float b, float t)
        {
            return ((b - a) * (float)Math.Sin((double)(t * Math.PI / 2))) + a;
        }

        //Finds the 't' used to lerp between two numbers
        public static float UnLerp(float a, float b, float lerped)
        {
            //Lerp function: lerped = ((b-a) * t) + a
            //Solve for t
            //t = (lerped - a) / (b - a)

            return (lerped - a) / (b - a);
        }

        public static float UnQuadLerp(float a, float b, float lerped)
        {
            //Lerp function: lerped = ((b-a) * t * t) + a
            //Solve for t
            //t = Sqrt((lerped - a) / (b - a))
            return (float)Math.Sqrt((double)(lerped - a) / (double)(b - a));
        }

        #endregion

        #endregion

        #region Arrays

        //public static T[] Merge<T>(this T[] array, params T[] addative)
        //{
        //    return array;
        //}

        #endregion

        #region Float Wrappers
        public static float Round(float val)
        {
            return (float)Math.Round((double)val);
        }

        public static float Floor(float val)
        {
            return (float)Math.Floor((double)val);
        }

        public static float Ceil(float val)
        {
            return (float)Math.Ceiling((double)(val));
        }

        #endregion
    }

    static class CryptoRand
    {
        static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        /// <summary>
        /// Gets an array of random bytes.
        /// </summary>
        /// <returns>The byte array.</returns>
        /// <param name="byteCount">Length of byte array.</param>
        public static byte[] GetBytes(int byteCount)
        {
            byte[] randBytes = new byte[byteCount];

            rng.GetBytes(randBytes);

            return randBytes;
        }

        public static byte[] GetBytes(byte[] byteArray)
        {
            rng.GetBytes(byteArray);
            return byteArray;
        }

        /// <summary>
        /// Returns a random double from 0-1
        /// </summary>
        public static double Range()
        {
            //double randNum = Mathf.Abs (BitConverter.ToDouble (GetBytes (8)));

            return double.MaxValue / Math.Abs(BitConverter.ToDouble(GetBytes(8), 0));

        }

        public static double Range(double min, double max)
        {
            return ((max - min) * Range()) + min;
        }

        public static float Range(float min, float max)
        {
            return ((max - min) * (float)Range()) + min;
        }

        /// <summary>
        /// Picks a random element from the parameters passed.
        /// </summary>
        /// <param name="array">Array.</param>
        /// <typeparam name="T">The type parameter.</typeparam>
        public static T Pick<T>(params T[] array)
        {
            return array[(int)((array.Length - 1) * Range())];
        }


    }

    static class StatementsE
    {
        public static void Repeat(ulong cycles, Action action)
        {
            if (cycles == 0)
            {
                return;
            }

            for (ulong i = 0; i < cycles; i++)
            {
                action();
            }
        }

        /// <summary>
        /// A 'foreach' with a 'for' backbone
        /// Look at source for example
        /// </summary>
        public static void ForEach<T>(T[] objects, Action<T> action)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                action(objects[i]);
            }

            //Example
            /* ForEach(myArray,
             * (arrayElement) =>{
             *      //Do something with arrayElement
             * });
             */
        }

        /// <summary>
        /// Times how long the action took to complete and returns that time in milliseconds.
        /// </summary>
        public static long SpeedTest(Action action)
        {
            Stopwatch watch = Stopwatch.StartNew();
            action();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Times how long the action took to complete and returns that time in milliseconds.
        /// </summary>
        public static long PerfTestInvoke(this Action action)
        {
            Stopwatch watch = Stopwatch.StartNew();
            action();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public static void IfConditions(
            bool condition1, bool condition2,
            Action only1, Action only2,
            Action both = null, Action neither = null
            )
        {
            if (condition1 && !condition2)
                only1();
            if (!condition1 && condition2)
                only2();
            if (condition1 && condition2)
                both();
            if (!condition1 && !condition2)
                neither();
        }

    }

    public class PID
    {
        public double kP { get; set; }

        public double kI { get; set; }

        public double kD { get; set; }

        public double P { get; set; }

        public double I { get; set; }

        public double D { get; set; }

        public PID(double kP, double kI, double kD)
        {
            this.kP = kP;
            this.kI = kI;
            this.kD = kD;
        }

        public double Step(double error)
        {
            I += error; //Integral
            D = P - error; //Derivative
            P = error; //Proportional

            //Return the resultant
            return (P * kP) + (I * kI) + (D * kD);
        }

    }

    public class ColorHex
    {
        public class Hia
        {
            public const string lol = "Mate";
        }

        public static string
            Aqua = "#00ffffff", Black = "#000000ff", Brown = "#a52a2aff",
            DarkBlue = "#0000a0ff", Magenta = "#ff00ffff", Green = "#008000ff",
            Grey = "#808080ff", LightBlue = "#add8e6ff", Lime = "#00ff00ff",
            Maroon = "#800000ff", Navy = "#000080ff", Olive = "#808000ff",
            Orange = "#ffa500ff", Purple = "#800080ff", Red = "#ff0000ff",
            Silver = "#c0c0c0ff", Teal = "#008080ff", White = "#ffffffff",
            Yellow = "#ffff00ff";

    }

    static class ExtensionsE
    {
        #region Conditions

        public static bool IsNull<T>(this T instance)
        {
            return instance == null;
        }

        public static bool NotNull<T>(this T instance)
        {
            return instance != null;
        }


        public static bool IsNull<T>(this T instance, Action<T> actionIfNull)
        {
            if (instance == null)
            {
                actionIfNull(instance);
                return true;
            }
            return false;
        }

        public static bool NotNull<T>(this T instance, Action<T> actionIfNotNull)
        {
            if (instance != null)
            {
                actionIfNotNull(instance);
                return true;
            }
            return false;
        }

        #endregion

        #region Action/Func

        /// <summary>
        /// Invokes the action if it isn't null, if it is null then just ignores it.
        /// </summary>
        /// <param name="action">Action.</param>
        public static void InvokeNull(this Action action)
        {
            if (action != null)
            {
                action();
            }
        }

        /// <summary>
        /// Invokes the action if it isn't null, if it is null then inoke the 'ifNull' action
        /// </summary>
        /// <param name="action">Action.</param>
        /// <param name="ifNull">If null.</param>
        public static void InvokeNull(this Action action, Action ifNull)
        {
            if (action == null)
            {
                ifNull();
                return;
            }
            else
            {
                action();
            }
        }



        #endregion


    }

    sealed class Ref<T>
    {

        T val;

        public Ref(T value)
        {
            this.val = value;
        }


        public T Value
        {
            get { return val; }
            set { val = value; }
        }
    }

}