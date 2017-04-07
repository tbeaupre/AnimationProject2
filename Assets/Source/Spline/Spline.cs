using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The spline class contains all of the math functions related to splines.
public class Spline{
	public List<Vector3> poss;
	public List<Vector3> tans;
	public List<Quaternion> quats;
	public int numCtrlPts;

	public Spline (int numCtrlPts) {
		this.numCtrlPts = numCtrlPts;
		poss = new List<Vector3>(numCtrlPts);
		quats = new List<Quaternion>(numCtrlPts);
	}

	public void Init()
	{
		CalcSplineTans();
	}
		
	public void CalcSplineTans()
	{
		if (numCtrlPts < 2)
		{
			// Just a point
		} else
		{
			// Do the normal calculations
			tans = new List<Vector3>();
			tans.Add(new Vector3(0, 0, 0));
			for (int i = 1; i < numCtrlPts - 1; i++)
			{
				tans.Add(((poss[i+1] - poss[i]) + (poss[i] - poss[i-1])) / 2);
			}
			tans.Add(new Vector3(0, 0, 0));
		}
	}

	public Quaternion CalcQuatAtTime(float t)
	{
		// Check to make sure the time is valid.
		if (t > 1 || t < 0)
		{
			return new Quaternion(0, 0, 0, 0);
		}
		// Check corner cases for 0 and 1.
		if (t == 1)
		{
			return quats[numCtrlPts - 1];
		}
		if (t == 0)
		{
			return quats[0];
		}

		float u = t * (numCtrlPts - 1); // u is now a value between 0 and the last control point.
		int i = Mathf.FloorToInt(u); // i now represents the subsection of the spline to use.
		u = u - i; // u now represents the u of the subsection of the spline.

		Quaternion q1 = quats[i];
		Quaternion q2 = quats[i + 1];

		return Quaternion.Slerp(q1, q2, u);
	}

	// Calculates the position at the time t along the spline. 0 <= t <= 1
	public Vector3 CalcPosAtTime(float t)
	{
		// Do some checks for empty or single-point splines.
		if (numCtrlPts == 0)
		{
			return new Vector3(0, 0, 0);
		}
		if (numCtrlPts == 1)
		{
			return poss[0];
		}

		// Check to make sure the time is valid.
		if (t > 1 || t < 0)
		{
			return new Vector3(0, 0, 0);
		}
		// Check corner cases for 0 and 1.
		if (t == 1)
		{
			return poss[numCtrlPts - 1];
		}
		if (t == 0)
		{
			return poss[0];
		}

		float u = t * (numCtrlPts - 1); // u is now a value between 0 and the last control point.
		int i = Mathf.FloorToInt(u); // i now represents the subsection of the spline to use.
		u = u - i; // u now represents the u of the subsection of the spline.
		float u2 = u * u;
		float u3 = u * u * u;


		Vector3 Pi = poss[i];		// The position of control point i
		Vector3 Pi1 = poss[i + 1];	// The position of control point i+1
		Vector3 Di = tans[i];		// The tangent(derivative) of control point i
		Vector3 Di1 = tans[i + 1];	// The tangent(derivative) of control point i+1

		// Uses the Hermite Basis Functions defined just below
		return (
		    Pi * h1(u2, u3) +
		    Pi1 * h2(u2, u3) +
		    Di * h3(u, u2, u3) +
		    Di1 * h4(u2, u3)
		);
	}

	// HERMITE BASIS FUNCTIONS
	public float h1(float s2, float s3)
	{
		return ((2*s3) - (3*s2) + 1);
	}
	public float h2(float s2, float s3)
	{
		return ((-2*s3) + (3*s2));
	}
	public float h3(float s, float s2, float s3)
	{
		return (s3 - (2*s2) + s);
	}
	public float h4(float s2, float s3)
	{
		return (s3 - s2);
	}
}
