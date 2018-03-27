using System;

namespace equality_examples
{
    class Program
    {
        static void Main(string[] args)
        {
            CalorieCount cal300 = new CalorieCount(300);
            CalorieCount cal400 = new CalorieCount(400);

            DisplayOrder(cal300, cal400);
            DisplayOrder(cal400, cal300);
            DisplayOrder(cal300, cal300);



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

        static void DisplayWhetherEqual(Food food1, Food food2)
        {
            if(food1 == food2)
                Console.WriteLine($"{food1,12} == {food2}");
            else
                Console.WriteLine($"{food1,12} != {food2}");
        }
    }
}
