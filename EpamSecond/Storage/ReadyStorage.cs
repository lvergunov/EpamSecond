using EpamTaskTwo.ReadyProduct;

namespace EpamTaskTwo.Storage
{
    public static class ReadyStorage
    {
        public static List<ITable> Tables { get; private set; }
        static ReadyStorage()
        {
            Tables = new List<ITable>();
        }
        public static void Add(ITable table) { 
            Tables.Add(table);
            ObjectStorage.RenewXLMS();
        }
        public static void Delete(ITable table) { 
            Tables.Remove(table);
            ObjectStorage.RenewXLMS();
        }
        public static List<ITable> GetByChipboardVolume(double volume) { 
            var tables = from table in Tables where table.Countertop.Volume == volume select table;
            return tables.ToList();
        }
        public static List<ITable> GetByOperationsNumber(int number)
        {
            var tables = from table in Tables where table.Operations.Count == number select table;
            return tables.ToList();
        }
        public static List<string> GetCosts()
        {
            List<string> costs = new List<string>();
            foreach (ITable table in Tables) {
                costs.Add($"Expences for chipboard {table.TotalCost}, expences for Legs {table.Legs.Sum(l => l.TotalCost)}," +
                    $" expences for operations {table.Operations.Sum(op => op.Cost)}, expences for furniture " +
                    $"{table.Furnitures.Sum(fur => fur.TotalCost)}");
            }
            return costs;
        }
    }
}
