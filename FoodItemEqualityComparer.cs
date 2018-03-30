using System;
using System.Collections.Generic;

namespace equality_examples
{
    //can cause problems with inheritance. might be best to only implement on a sealed type
    class FoodItemEqualityComparer : EqualityComparer<FoodItem> //implementing the abstract class EqualityComparer<FoodItem> makes it where you only have one implementation that includes the generic AND non-generic interfaces IEqualityComparer
    {
        private static FoodItemEqualityComparer _instance = new FoodItemEqualityComparer();

        public static FoodItemEqualityComparer Instance { get { return _instance; } } //makes this comparer a singleton which is useful and provides better performance if you need it in more than one place

        private FoodItemEqualityComparer() { }

        public override bool Equals(FoodItem x, FoodItem y)
        {
            // return x.Name.ToUpperInvariant() == y.Name.ToUpperInvariant()
            //     && x.Group == y.Group;

            return StringComparer.OrdinalIgnoreCase.Equals(x.Name, y.Name) && x.Group == y.Group;
        }

        public override int GetHashCode(FoodItem obj)
        {
            //return obj.Name.ToUpperInvariant().GetHashCode() ^ obj.Group.GetHashCode();

            return StringComparer.OrdinalIgnoreCase.GetHashCode(obj.Name) ^ obj.Group.GetHashCode();
        } 
    }
}