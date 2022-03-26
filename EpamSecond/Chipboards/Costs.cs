namespace EpamTaskTwo.Chipboards
{
    /// <summary>
    /// Class contains cost of 1mm cubical of chipboard
    /// </summary>
    public static class ChipboardCost
    {
        public static double CostOfMMCub { get; private set; } = 0;
        public static void SetCost(double cost)
        {
            CostOfMMCub = cost;
        }
    }
}
