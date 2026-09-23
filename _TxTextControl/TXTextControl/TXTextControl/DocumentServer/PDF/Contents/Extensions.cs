using System;
using System.Drawing;

namespace DocumentServer.PDF.Contents
{
	internal static class Extensions
	{
		public static bool IsInsideCircle(this RectangleF rectangle, PointF position, float radius)
		{
			if (rectangle.Location.IsInsideCircle(position, radius) && rectangle.GetTopRight().IsInsideCircle(position, radius) && rectangle.GetBottomLeft().IsInsideCircle(position, radius))
			{
				return rectangle.GetBottomRight().IsInsideCircle(position, radius);
			}
			return false;
		}

		public static bool IntersectsWithCircle(this RectangleF rectangle, PointF position, float radius)
		{
			if (rectangle.Contains(position))
			{
				return true;
			}
			if (position.X < rectangle.Left && position.Y < rectangle.Top)
			{
				return rectangle.Location.IsInsideCircle(position, radius);
			}
			if (position.X > rectangle.Right && position.Y < rectangle.Top)
			{
				return rectangle.GetTopRight().IsInsideCircle(position, radius);
			}
			if (position.X > rectangle.Right && position.Y > rectangle.Bottom)
			{
				return rectangle.GetBottomRight().IsInsideCircle(position, radius);
			}
			if (position.X < rectangle.Left && position.Y > rectangle.Bottom)
			{
				return rectangle.GetBottomLeft().IsInsideCircle(position, radius);
			}
			if (position.Y < rectangle.Top)
			{
				return rectangle.Top - position.Y < radius;
			}
			if (position.X > rectangle.Right)
			{
				return position.X - rectangle.Right < radius;
			}
			if (position.Y > rectangle.Bottom)
			{
				return position.Y - rectangle.Bottom < radius;
			}
			if (position.X >= rectangle.Left)
			{
				throw new Exception("Non-Euclidian universe detected.");
			}
			return rectangle.Left - position.X < radius;
		}

		public static bool IsInsideCircle(this PointF point, PointF position, float radius)
		{
			float num = point.X - position.X;
			float num2 = point.Y - position.Y;
			return num * num + num2 * num2 <= radius * radius;
		}

		public static PointF GetTopRight(this RectangleF rectangle)
		{
			return new PointF(rectangle.Right, rectangle.Top);
		}

		public static PointF GetBottomRight(this RectangleF rectangle)
		{
			return new PointF(rectangle.Right, rectangle.Bottom);
		}

		public static PointF GetBottomLeft(this RectangleF rectangle)
		{
			return new PointF(rectangle.Left, rectangle.Bottom);
		}
	}
}
