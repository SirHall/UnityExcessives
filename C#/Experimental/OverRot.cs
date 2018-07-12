
using Excessives;
/// <summary>
/// A rotation form that takes advantage of overflows
/// </summary>
//{TODO} Get rid of this
[System.Obsolete]
public struct OverRot
{
	public ulong rot;

	public OverRot(ulong rotation)
	{
		rot = rotation;
	}

	public OverRot(double deg)
	{
		rot = 0;//Don't ask, anti error here
		rot = MapDegToRot(deg);
	}

	#region Maths

	#region Mapping
	double MapRotToDeg(ulong rot)
	{
		return MathE.ReMap(
			rot, 0.0, ulong.MaxValue, 0.0, 360.0);
	}
	ulong MapDegToRot(double deg)
	{
		return (ulong)MathE.ReMap(
			deg, 0.0, 360.0, 0.0, ulong.MaxValue);
	}
	#endregion

	#region OverRot & OverRot

	public static OverRot operator +(OverRot r1, OverRot r2)
	{
		return new OverRot(r1.rot + r2.rot);
	}

	public static OverRot operator -(OverRot r1, OverRot r2)
	{
		return new OverRot(r1.rot - r2.rot);
	}

	public static OverRot operator *(OverRot r1, OverRot r2)
	{
		return new OverRot(r1.rot * r2.rot);
	}

	public static OverRot operator /(OverRot r1, OverRot r2)
	{
		return new OverRot(r1.rot + r2.rot);
	}

	public static OverRot operator %(OverRot r1, OverRot r2)
	{
		return new OverRot(r1.rot % r2.rot);
	}
	#endregion

	#endregion

	#region Casting
	public static implicit operator OverRot(double v)
	{
		//The double passed to the constructor will remap the double
		return new OverRot(v);
	}

	public static implicit operator double(OverRot v)
	{
		return v.ToDeg();
	}

	#endregion

	#region Conversions
	public double ToDeg()
	{
		return MathE.ReMap(
			rot, 0, ulong.MaxValue, 0, 360);
	}

	public double ToRad()
	{
		return MathE.ReMap(
			rot, 0, ulong.MaxValue, 0, (double)MathE.TAU);
	}
	#endregion
}

