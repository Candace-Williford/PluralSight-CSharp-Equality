using System;

namespace equality_examples
{
    public enum FoodGroup { Meat, Fruit, Vegetables, Sweets }

    //value type
    public struct FoodItem : IEquatable<FoodItem>
    {
        private readonly string _name;
        private readonly FoodGroup _group;

        public string Name { get{ return _name; } }
        public FoodGroup Group { get{ return _group; } }

        public FoodItem(string name, FoodGroup group)
        {
            this._name = name;
            this._group = group;
        }

        public override string ToString()
        {
            return _name;
        }

        public bool Equals(FoodItem other) => this._name == other._name && this._group == other._group;
        public static bool operator ==(FoodItem lhs, FoodItem rhs) => lhs.Equals(rhs);
        public static bool operator !=(FoodItem lhs, FoodItem rhs) => !lhs.Equals(rhs);
        public override int GetHashCode() => _name.GetHashCode() ^ _group.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj is FoodItem)
                return Equals((FoodItem)obj);
            else
                return false;
        }


        //if you provide an equality operator overload, you MUST provide the unequals operator as well - required by C#
        //good practice when overriding .Equals() to override GetHashCode() as well - this is because hashtables require 
        //  that if 2 values are equal, then they must return the same hashcode
        //this procedure is only good for implementing VALUE TYPE equality
    }
}
