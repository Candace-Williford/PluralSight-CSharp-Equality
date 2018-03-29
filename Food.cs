using System;

namespace equality_examples
{
    //public enum FoodGroup { Meat, Fruit, Vegetables, Sweets }

    //reference type
    //it is NOT standard practice to implement equality on reference types because it's not generally
    //expected by developers. Devs are usually on comparing specific properties on a type and aren't
    //looking to compare the entire object. However, below is how to do it on the off chance a case
    //does arise where it's needed.
    public class Food //IEquatable<T> isn't useful for reference types
    {
        private readonly string _name;
        private readonly FoodGroup _group;

        public string Name { get{ return _name; } }
        public FoodGroup Group { get{ return _group; } }

        public Food(string name, FoodGroup group)
        {
            this._name = name;
            this._group = group;
        }

        public override string ToString() => $"{_name} ({_group})";

        public override bool Equals(object obj)
        {
            if(obj == null)
                return false;
            if(ReferenceEquals(obj, this))
                return true;
            if(obj.GetType() != this.GetType())
                return false;

            Food rhs = obj as Food;
            return this._name == rhs._name && this._group == rhs._group;
        }

        public override int GetHashCode() => _name.GetHashCode() ^ _group.GetHashCode();
        public static bool operator ==(Food x, Food y)
        {
            return object.Equals(x, y); //object.Equals deals with either item being null. no need to rewrite that implementation
            //this line works because it calls the static object.Equals() calls the virtual one and because
            //it's virtual, it's guaranteed to work

            //return x._name == y._name && x._group == y._group; //this will fail because of inheritance
            //when this check is run, it doesn't know about classes that implement it and therefore doesn't know about other
            //properties that that class may have that would make x and y UNequal
        }
        public static bool operator !=(Food x, Food y) => !object.Equals(x, y);
    }
}