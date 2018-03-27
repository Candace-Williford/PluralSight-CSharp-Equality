using System;

namespace equality_examples
{
    //it is NOT standard practice to implement IComparable<T> on non-primitive types
    //because it is difficult to choose a "natural" comparison. There are usually many
    //natural comparisons that you would want for different situations. It's usually
    //better to just create comparers. But just in case an implementation of
    //IComparable<T> is needed, here it is.

    //strongly recommended to avoid implementing comparisons on non-sealed classes
    public struct CalorieCount : IComparable<CalorieCount>, IEquatable<CalorieCount>, IComparable
    {
        private float _value;

        public float Value { get { return _value; } }

        public CalorieCount(float value)
        {
            this._value = value;
        }

        public override string ToString()
        {
            return _value + " cal";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if(!(obj is CalorieCount))
                return false;
            return _value == ((CalorieCount)obj)._value;
        }

        public int CompareTo(CalorieCount other) => this._value.CompareTo(other._value);
        public static bool operator <(CalorieCount x, CalorieCount y) => x._value < y._value;
        public static bool operator <=(CalorieCount x, CalorieCount y) => x._value <= y._value;
        public static bool operator >(CalorieCount x, CalorieCount y) => x._value > y._value;
        public static bool operator >=(CalorieCount x, CalorieCount y) => x._value >= y._value;
        public static bool operator ==(CalorieCount x, CalorieCount y) => x._value == y._value;
        public static bool operator !=(CalorieCount x, CalorieCount y) => x._value != y._value;
        public override int GetHashCode() => _value.GetHashCode();
        public bool Equals(CalorieCount other) => this._value == other._value;

        public int CompareTo(object obj) //implementation of IComparable non-generic. generally old and no longer used
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            if(!(obj is CalorieCount))
                throw new ArgumentException("Expected CaloriedCount instance", "obj");
            return CompareTo((CalorieCount)obj);

            //it is convention to throw errors here because there's no other logical value you could return
        }
    }
}