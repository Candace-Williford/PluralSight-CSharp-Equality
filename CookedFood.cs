using System;

namespace equality_examples
{
    public sealed class CookedFood : Food, IEquatable<CookedFood> //sealed means nothing else can derive from this class
    {
        private string _cookingMethod;

        public string CookingMethod { get { return _cookingMethod; } }

        public CookedFood(string cookingMethod, string name, FoodGroup group)
            : base(name, group)
        {
            this._cookingMethod = cookingMethod;
        }

        public override string ToString() => $"{_cookingMethod} {Name}";

        public override bool Equals(object obj)
        {
            if(!base.Equals(obj))
                return false;

            CookedFood rhs = obj as CookedFood;
            return this._cookingMethod == rhs._cookingMethod;
        }

        public override int GetHashCode() => base.GetHashCode() ^ _cookingMethod.GetHashCode();

        public bool Equals(CookedFood other) => object.Equals(this, other);

        public static bool operator ==(CookedFood x, CookedFood y) => object.Equals(x, y); 
        public static bool operator !=(CookedFood x, CookedFood y) => !object.Equals(x, y);
    }
}