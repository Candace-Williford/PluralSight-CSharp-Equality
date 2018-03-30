using System;
using System.Collections.Generic;

namespace equality_examples
{
    //can cause problems with inheritance. might be best to only implement on a sealed type
    class FoodNameEqualityComparer : EqualityComparer<FoodItem> //implementing the abstract class EqualityComparer<FoodItem> makes it where you only have one implementation that includes the generic AND non-generic interfaces IEqualityComparer
    {
        private static FoodNameEqualityComparer _instance = new FoodNameEqualityComparer();

        public static FoodNameEqualityComparer Instance { get { return _instance; } } //makes this comparer a singleton which is useful and provides better performance if you need it in more than one place

        private FoodNameEqualityComparer() { }

        public override bool Equals(FoodItem x, FoodItem y) => x.Name.ToUpperInvariant() == y.Name.ToUpperInvariant(); //good example of why you're Equals and GetHashCode override MUST match. If you aren't evaluating equality for a field, then it should NOT be included when getting the hash code

        public override int GetHashCode(FoodItem obj) => obj.Name.ToUpperInvariant().GetHashCode() ^ obj.Group.GetHashCode();
    }
}