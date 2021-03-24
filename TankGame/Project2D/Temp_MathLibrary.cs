using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Placeholder Matrix3, Vector2, and Color class. Remove these after you've added your own.


public struct Vector2
{
	public float x;
	public float y;

	public float Magnitude()
	{
		return (float)Math.Sqrt((x * x) + (y * y));
	}
}

