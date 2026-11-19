using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_6_7
{
    public class LineSegment
    {
        private double x;
        private double y;

        public LineSegment()
        {
            x = 0;
            y = 1;
        }

        public LineSegment(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public LineSegment(LineSegment other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            this.x = other.x;
            this.y = other.y;
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public override string ToString()
        {
            return "[" + x + "; " + y + "]";
        }

        public bool Contains(double number)
        {
            double min = Math.Min(x, y);
            double max = Math.Max(x, y);
            return number >= min && number <= max;
        }

        public static double operator !(LineSegment segment)
        {
            if (segment == null) throw new ArgumentNullException(nameof(segment));
            return Math.Abs(segment.y - segment.x);
        }

        public static LineSegment operator ++(LineSegment segment)
        {
            if (segment == null) throw new ArgumentNullException(nameof(segment));
            return new LineSegment(segment.x + 1, segment.y + 1);
        }

        public static explicit operator int(LineSegment segment)
        {
            if (segment == null) throw new ArgumentNullException(nameof(segment));
            return (int)segment.x;
        }

        public static implicit operator double(LineSegment segment)
        {
            if (segment == null) throw new ArgumentNullException(nameof(segment));
            return segment.y;
        }

        public static LineSegment operator +(LineSegment segment, int d)
        {
            if (segment == null) throw new ArgumentNullException(nameof(segment));
            return new LineSegment(segment.x + d, segment.y + d);
        }

        public static LineSegment operator +(int d, LineSegment segment)
        {
            if (segment == null) throw new ArgumentNullException(nameof(segment));
            return new LineSegment(segment.x + d, segment.y + d);
        }

        public static bool operator <(LineSegment segment, int number)
        {
            if (segment == null) throw new ArgumentNullException(nameof(segment));
            return segment.Contains(number);
        }

        public static bool operator >(LineSegment segment, int number)
        {
            if (segment == null) throw new ArgumentNullException(nameof(segment));
            return !segment.Contains(number);
        }

        public static bool operator ==(LineSegment left, LineSegment right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.x == right.x && left.y == right.y;
        }

        public static bool operator !=(LineSegment left, LineSegment right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            return obj is LineSegment other && this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
    }
}
