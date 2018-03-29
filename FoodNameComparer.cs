using System;
using System.Collections.Generic;

namespace equality_examples
{
    //can cause problems with inheritance. might be best to only implement on a sealed type
    class FoodNameComparer : Comparer<Food>
    {
        private static FoodNameComparer _instance = new FoodNameComparer();

        public static FoodNameComparer Instance { get { return _instance; } } //makes this comparer a singleton which is useful and provides better performance if you need it in more than one place

        private FoodNameComparer() { }

        public override int Compare(Food x, Food y)
        {
            if(x == null && y == null)
                return 0;
            if(x == null)
                return -1;
            if(y == null)
                return 1;

            int nameOrder = string.Compare(x.Name, y.Name, StringComparison.CurrentCulture); //string.Compare automatically deals with Name being null

            if(nameOrder != 0)
                return nameOrder;

            return string.Compare(x.Group.ToString(), y.Group.ToString(), StringComparison.CurrentCulture);
        }
    }
}