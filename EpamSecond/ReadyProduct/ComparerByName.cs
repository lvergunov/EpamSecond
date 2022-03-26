﻿namespace EpamTaskTwo.ReadyProduct
{
    public class ComparerByName : IComparer<ITable>
    {
        public int Compare(ITable? table1, ITable? table2) {
            if (table1 == null || table2 == null)
                throw new ArgumentNullException("Incorrect params");
            else return table1.Name.CompareTo(table2.Name);
        }
    }
}
