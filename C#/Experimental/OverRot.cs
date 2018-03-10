
using Excessives;
/// <summary>
/// A rotation form that takes advantage of overflows
/// </summary>
public struct OverRot {

    //public OverRot() {
    //}

    public ulong rot;

    public OverRot(ulong rotation) {
        rot = rotation;
    }

    public OverRot(float deg) {
        rot = 0;//Don't ask, anti error here
        rot = MapDegToRot(deg);
    }

    #region Maths

    #region Mapping
    float MapRotToDeg(ulong rot) {
        return MathE.ReMap(
            rot, 0, ulong.MaxValue, 0, 360);
    }
    ulong MapDegToRot(float deg) {
        return (ulong)MathE.ReMap(
            deg, 0, 360, 0, ulong.MaxValue);
    }
    #endregion

    #region OverRot & OveRot

    public static OverRot operator +(OverRot r1, OverRot r2) {
        return new OverRot(r1.rot + r2.rot);
    }

    public static OverRot operator -(OverRot r1, OverRot r2) {
        return new OverRot(r1.rot - r2.rot);
    }

    public static OverRot operator *(OverRot r1, OverRot r2) {
        return new OverRot(r1.rot * r2.rot);
    }

    public static OverRot operator /(OverRot r1, OverRot r2) {
        return new OverRot(r1.rot + r2.rot);
    }

    public static OverRot operator %(OverRot r1, OverRot r2) {
        return new OverRot(r1.rot % r2.rot);
    }
    #endregion

    #endregion

    #region Casting
    public static OverRot implicit(float v) {
        return new OverRot(v);
    }

    #endregion

    #region Conversions
    public float ToDeg() {
        return MathE.ReMap(
            rot, 0, ulong.MaxValue, 0, 360);
    }

    public float ToRad() {
        return MathE.ReMap(
            rot, 0, ulong.MaxValue, 0, (float)MathE.TAU);
    }
    #endregion


}

