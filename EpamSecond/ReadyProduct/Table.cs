using EpamTaskTwo.Chipboards;
using EpamTaskTwo.Legs;
using EpamTaskTwo.Operations;
using EpamTaskTwo.Storage;
using EpamTaskTwo.MachineWork;
using EpamTaskTwo.Matherials;

namespace EpamTaskTwo.ReadyProduct
{
    public class Table : ITable
    {
        public string Name { get; }
        public IFullChipboard Countertop { get; }
        public List<ILeg> Legs { get; }
        public List<IOperation> Operations { get; }
        public List<IFurniture> Furnitures { get; }
        public Table(IFullChipboard countertop, List<ILeg> legs, List<IFurniture> furnitures,string name)
        {
            Countertop = countertop;
            Legs = legs;
            Operations = new List<IOperation>();
            Furnitures = furnitures;
            ObjectStorage.RemoveComponent(countertop);
            foreach(ILeg leg in legs) ObjectStorage.RemoveComponent(leg);
            Name = name;
        }
        public Table(IFullChipboard countertop, List<ILeg> legs, List<IFurniture> furnitures,ICut cut,string name)
        {
            Countertop = countertop;
            Legs = legs;
            Operations = new List<IOperation>();
            Furnitures = furnitures;
            Operations.Add(cut);
            Name = name;
            ObjectStorage.RemoveComponent(countertop);
            foreach (ILeg leg in legs) ObjectStorage.RemoveComponent(leg);
        }
        public Table(IFullChipboard countertop, List<ILeg> legs, List<IFurniture> furnitures, ICut cut,
            Paper edge,string name)
        {
            Countertop = countertop;
            Legs = legs;
            Operations = new List<IOperation>();
            Operations.Add(cut);
            Name = name;
            Furnitures = furnitures;
            ObjectStorage.RemoveComponent(countertop);
            foreach (ILeg leg in legs) ObjectStorage.RemoveComponent(leg);
            foreach (IFurniture furniture in furnitures) ObjectStorage.RemoveComponent(furniture);
            Operations.Add(new PaperPasting(edge, countertop, edge.CostOfMM));
            foreach (ILeg leg in legs) ObjectStorage.RemoveComponent(leg);
        }
        public Table(IFullChipboard countertop, List<ILeg> legs, List<IFurniture> furnitures, ICut cut,
            Plastic edge,string name)
        {
            Countertop = countertop;
            Legs = legs;
            Operations = new List<IOperation>();
            if (cut != null) Operations.Add(cut);
            Furnitures = furnitures;
            Name = name;
            ObjectStorage.RemoveComponent(countertop);
            foreach(ILeg leg in legs) ObjectStorage.RemoveComponent(leg);
            foreach (IFurniture furniture in furnitures) ObjectStorage.RemoveComponent(furniture);
            if (edge != null) Operations.Add(new PlasticInsert(edge, countertop, edge.CostOfMM));
        }
        public Table(IFullChipboard countertop, List<ILeg> legs, List<IFurniture> furnitures,Paper edge,string name) {
            Countertop = countertop;
            Legs = legs;
            Operations = new List<IOperation>();
            Furnitures = furnitures;
            Name = name;
            ObjectStorage.RemoveComponent(countertop);
            foreach (ILeg leg in legs) ObjectStorage.RemoveComponent(leg);
            foreach (IFurniture furniture in furnitures) ObjectStorage.RemoveComponent(furniture);
            Operations.Add(new PaperPasting(edge, countertop, edge.CostOfMM));
            foreach (ILeg leg in legs) ObjectStorage.RemoveComponent(leg);
        }
        public Table(IFullChipboard countertop, List<ILeg> legs, List<IFurniture> furnitures, Plastic edge,string name)
        {
            Countertop = countertop;
            Legs = legs;
            Operations = new List<IOperation>();
            Furnitures = furnitures;
            Name = name;
            ObjectStorage.RemoveComponent(countertop);
            foreach (ILeg leg in legs) ObjectStorage.RemoveComponent(leg);
            foreach (IFurniture furniture in furnitures) ObjectStorage.RemoveComponent(furniture);
            Operations.Add(new PlasticInsert(edge, countertop,edge.CostOfMM));
            foreach (ILeg leg in legs) ObjectStorage.RemoveComponent(leg);
        }
        public Table(IFullChipboard countertop,List<ILeg> legs, List<IOperation> operations, List<IFurniture> furnitures,string name)
        {
            Countertop = countertop;
            Legs = legs;
            Operations = operations;
            Furnitures = furnitures;
            Name = name;
        }
        public double TotalCost { get {
                return Countertop.TotalCost + Legs.Sum(s => s.TotalCost) + Operations.Sum(op => op.Cost) + Furnitures.Sum(f => f.TotalCost);
            } }
        public override string ToString()
        {
            string operationsInfo = "";
            foreach (IOperation op in Operations)
            {
                operationsInfo += op.ToString();
            }
            return $"Table. Countertop info: {Countertop.ToString}, Legs info: Number {Legs.Count}" +
                $" {Legs[0].ToString}, Operations: { operationsInfo}. Total cost: {TotalCost}";
        }
    }
}
