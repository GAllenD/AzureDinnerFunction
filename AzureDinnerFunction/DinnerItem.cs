namespace AzureDinnerFunction
{
    public class DinnerItem
    {
        public DinnerItem(string title, DinnerItemType type, DinnerItemRanking rank)
        {
            Title = title;
            Type = type;
            Rank = rank;
        }

        public string Title { get; internal set; }

        public DinnerItemType Type { get; internal set; }

        public DinnerItemRanking Rank { get; internal set; }

    }

    public enum DinnerItemRanking
    {
        High = 3,
        Medium = 2,
        Low = 1
    }

    public enum DinnerItemType
    {
        Chicken,
        Pork,
        RedMeat,
        Pasta,
        Sandwich,
        Soup,
        Breakfast,
        Other,
        Pizza
    }
}
