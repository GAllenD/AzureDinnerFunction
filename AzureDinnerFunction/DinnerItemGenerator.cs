using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDinnerFunction
{
    public class DinnerItemGenerator
    {
        private List<DinnerItem> AllItems = new List<DinnerItem>()
        {
            new DinnerItem("Cream chicken over Biscuits", DinnerItemType.Chicken, DinnerItemRanking.Medium),
            new DinnerItem("Tomato Soup and Grilled Cheese", DinnerItemType.Sandwich, DinnerItemRanking.Medium),
            new DinnerItem("Mini meatloafs", DinnerItemType.RedMeat, DinnerItemRanking.High),
            new DinnerItem("Syd Meatload", DinnerItemType.RedMeat, DinnerItemRanking.High),
            new DinnerItem("Spighetti and garlic bread", DinnerItemType.Pasta, DinnerItemRanking.Medium),
            new DinnerItem("Sub sandwiches", DinnerItemType.Sandwich, DinnerItemRanking.Medium),
            new DinnerItem("Pork Chops and Beans", DinnerItemType.Pork, DinnerItemRanking.Medium),
            new DinnerItem("Chicken Salad", DinnerItemType.Chicken, DinnerItemRanking.Low),
            new DinnerItem("Sausage Pasta", DinnerItemType.Pasta, DinnerItemRanking.High),
            new DinnerItem("Chicken pot pie", DinnerItemType.Chicken, DinnerItemRanking.Medium),
            new DinnerItem("Stir fry over rice", DinnerItemType.Chicken, DinnerItemRanking.Medium),
            new DinnerItem("Cheese ravioli", DinnerItemType.Pasta, DinnerItemRanking.Medium),
            new DinnerItem("Busy day pork chops", DinnerItemType.Pork, DinnerItemRanking.Medium),
            new DinnerItem("Steak tips on grill or broiler", DinnerItemType.RedMeat, DinnerItemRanking.Medium),
            new DinnerItem("BBQ chicken", DinnerItemType.Chicken, DinnerItemRanking.Low),
            new DinnerItem("Wedding soup", DinnerItemType.Soup, DinnerItemRanking.Medium),
            new DinnerItem("Sweet and sour chicken", DinnerItemType.Chicken, DinnerItemRanking.High),
            new DinnerItem("Hot dogs and kraut", DinnerItemType.Other, DinnerItemRanking.Medium),
            new DinnerItem("Tomato Pasta", DinnerItemType.Pasta, DinnerItemRanking.Medium),
            new DinnerItem("Tacos!", DinnerItemType.Other, DinnerItemRanking.Medium),
            new DinnerItem("Chicken and cheese quesadilla", DinnerItemType.Other, DinnerItemRanking.Medium),
            new DinnerItem("Meatball subs", DinnerItemType.Sandwich, DinnerItemRanking.Medium),
            new DinnerItem("Cold cut and avacodo sandwiches", DinnerItemType.Sandwich, DinnerItemRanking.Medium),
            new DinnerItem("Make-your-own meal day. Likely cereal and/or whatever we have", DinnerItemType.Other, DinnerItemRanking.Medium),
            new DinnerItem("Homemade pizza", DinnerItemType.Pizza, DinnerItemRanking.Medium)
        };


        public List<DinnerItem> GetDinnerOptions(int numOfItems)
        {
            var items = new List<DinnerItem>();
            var random = new Random();


            for (var i = 1; i < numOfItems + 1; i++)
            {
                var index = random.Next(AllItems.Count);

                if (MaxNumberOfTypeReached(items, AllItems[index].Type))
                {
                    AllItems.RemoveAll(r => r.Type == AllItems[index].Type);
                    index = random.Next(AllItems.Count);
                }

                items.Add(AllItems[index]);

                AllItems.Remove(AllItems[index]);
            }

            return items;
        }

        public bool MaxNumberOfTypeReached(List<DinnerItem> items, DinnerItemType type)
        {
            if (items.Count(i => i.Type == type) > 2)
            {
                return true;
            }
            return false;
        }
    }

}
