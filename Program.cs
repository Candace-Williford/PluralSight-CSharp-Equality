using System;
using System.Globalization;
using System.Threading;

namespace equality_examples
{
    class Program
    {
        // static void Main(string[] args)
        // {
        //     CalorieCount cal300 = new CalorieCount(300);
        //     CalorieCount cal400 = new CalorieCount(400);

        //     DisplayOrder(cal300, cal400);
        //     DisplayOrder(cal400, cal300);
        //     DisplayOrder(cal300, cal300);
        // }

        // static void Main(string[] args)
        // {
            // Food apple = new Food("apple", FoodGroup.Fruit);
            // CookedFood stewedApple = new CookedFood("stewed", "apple", FoodGroup.Fruit);
            // CookedFood bakedApple = new CookedFood("baked", "apple", FoodGroup.Fruit);
            // CookedFood stewedApple2 = new CookedFood("stewed", "apple", FoodGroup.Fruit);
            // Food apple2 = new Food("apple", FoodGroup.Fruit);

            // DisplayWhetherEqual(apple, stewedApple);
            // DisplayWhetherEqual(stewedApple, bakedApple);
            // DisplayWhetherEqual(stewedApple, stewedApple2);
            // DisplayWhetherEqual(apple, apple2);
            // DisplayWhetherEqual(apple, apple);
        //}

        // static void Main(string[] args)
        // {
            // FoodItem banana = new FoodItem("banana", FoodGroup.Fruit);
            // FoodItem banana2 = new FoodItem("banana", FoodGroup.Fruit);
            // FoodItem chocolate = new FoodItem("chocolate", FoodGroup.Sweets);

            // Console.WriteLine(
            //     "banana     == banana2:     " + (banana == banana2)
            // );
            // Console.WriteLine(
            //     "banana2    == chocolate:   " + (banana2 == chocolate)
            // );
            // Console.WriteLine(
            //     "chocolate  == banana:      " + (banana == chocolate)
            // );
        // }

        // static void Main(string[] args)
        // {
        //     Console.WriteLine($"Current culture is {Thread.CurrentThread.CurrentCulture}");

        //     // string str1 = "apple";
        //     // string str2 = "PINEAPPLE";
        //     // string str1 = "Stra\u00dfe";
        //     // string str2 = "Strasse";
        //     string str1 = "erkl\u00e4ren";
        //     string str2 = "erkla\u0308ren";
        //     DisplayAllComparisons(str1, str2);

        //     //ordinal has better performance and is culture independent
        //     //but you usually want to use current culture for anything that has to do with end user data

        //     string apple = "Apple";
        //     string apple2 = "Ap" + "ple";
        //     string pineapple = "Pineapple";

        //     Console.WriteLine($"strings are {apple} and {apple2}");

        //     //concatenation is done at run time instead of compile time.
        //     //hardcoded strings might compile to a single instance
        //     //saves memory and can make comparisons faster
        //     //this optimization is known as string pooling
        //     //you can use string.Inter() to force this optimization. not typically used
        //     Console.WriteLine(apple == apple2); //true
        //     Console.WriteLine(ReferenceEquals(apple, apple2)); //true

        //     bool areEqual = string.Equals(
        //         apple, pineapple, StringComparison.CurrentCultureIgnoreCase);
            
        //     //there is a static comparison override that allows you to specify the culture
        //     int cmpResult = string.Compare(
        //         apple, pineapple, CultureInfo.GetCultureInfo("fr-FR"),
        //         CompareOptions.IgnoreSymbols);
        //     areEqual = (cmpResult == 0);

        //     // case-sensitive ordinal comparison
        //     areEqual = (apple == pineapple);
        //     areEqual = apple.Equals(pineapple);
        // }

        static void Main(string[] args)
        {
            //string knows to sort alphabetically because it implements IComparable<string>

            Food[] list = {
                new Food("apple", FoodGroup.Fruit),
                new Food("pear", FoodGroup.Fruit),
                new CookedFood("baked", "apple", FoodGroup.Fruit)
            };
            SortAndShowList(list);

            Console.WriteLine();

            Food[] list2 = {
                new CookedFood("baked", "apple", FoodGroup.Fruit),
                new Food("pear", FoodGroup.Fruit),
                new Food("apple", FoodGroup.Fruit)
            };
            SortAndShowList(list);
        }

        static void SortAndShowList(Food[] list)
        {
            Array.Sort(list, FoodNameComparer.Instance);

            foreach (var item in list)
                Console.WriteLine(item);
        }

        static void DisplayWhetherEqual(Food food1, Food food2)
        {
            if(food1 == food2)
                Console.WriteLine($"{food1,12} == {food2}");
            else
                Console.WriteLine($"{food1,12} != {food2}");
        }

        static void DisplayAllComparisons(string str1, string str2)
        {
            DisplayComparison(str1, str2, StringComparison.Ordinal);
            DisplayComparison(str1, str2, StringComparison.OrdinalIgnoreCase);
            Console.WriteLine();

            DisplayComparison(str1, str2, StringComparison.InvariantCulture);
            DisplayComparison(str1, str2, StringComparison.InvariantCultureIgnoreCase);
            Console.WriteLine();

            DisplayComparison(str1, str2, StringComparison.CurrentCulture);
            DisplayComparison(str1, str2, StringComparison.CurrentCultureIgnoreCase);
            Console.WriteLine();
        }

        static void DisplayComparison(string str1, string str2, StringComparison comparison)
        {
            int result = string.Compare(str1, str2, comparison);
            Console.WriteLine($"{str1} {GetCompareSymbol(result)} {str2}    ({result} {comparison})");
        }

        static string GetCompareSymbol(int compareResult)
        {
            if(compareResult == 0)
                return "==";
            else if(compareResult < 0)
                return "<";
            else
                return ">";
        }

        static void DisplayOrder<T>(T x, T y) where T : IComparable<T>
        {
            //remember that you can't use operators on generics which is 
            //why there is the restriction that the types being passed MUST 
            //implement IComparable<T>
            int result = x.CompareTo(y);

            if(result == 0)
                Console.WriteLine($"{x, 12} = {y}");
            else if(result > 0)
                Console.WriteLine($"{x, 12} > {y}");
            else
                Console.WriteLine($"{x, 12} < {y}");
        }
    }
}
