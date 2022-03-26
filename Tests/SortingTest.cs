using NUnit.Framework;
using EpamTaskTwo.Matherials;
using EpamTaskTwo.MachineWork;
using EpamTaskTwo.Chipboards;
using EpamTaskTwo.Storage;
using EpamTaskTwo.Measure;
using EpamTaskTwo.ReadyProduct;
using EpamTaskTwo.Legs;
using EpamTaskTwo.Operations;
using System.Linq;
using System.Collections.Generic;

namespace Test.SortingTest
{
    [TestFixture]
    public class Sorting_Test
    {
        [OneTimeSetUp]
        public void Setup()
        {
            IChipboard[] chipboards = new IChipboard[] {new FullChipboard(5,8,2), new FullChipboard(3,3,3),
            new FullChipboard(4,5,2),new FullChipboard(5,10,3),new FullChipboard(5,2,2)};
            foreach (IChipboard cb in chipboards)
            {
                ObjectStorage.AddComponent(cb);
            }
            IMachine[] machines = new IMachine[] { new Machine(4, 4, 4, true, 10), new Machine(10,2,4,false,5),
            new Machine(10,10,10,false,20),new Machine(10,10,10,true,25)};
            foreach (IMachine mach in machines)
                ObjectStorage.AddComponent(mach);
        }
        [Test]
        public void Test_Sorter_1()
        {
            ICut cut = new RectangularCut(5, 3, 2, FormTypes.Rectangular);
            cut.FindBetweenFull();
            cut.FindBestMachine();
            Assert.AreEqual(cut.MachineInformation, new Machine(10, 10, 10, false, 20));
            Assert.AreEqual(cut.NecessaryMatherial, new FullChipboard(5, 8, 2));
        }
        [Test]
        public void Test_Sorter_2()
        {
            ICut[] cuts = { new RectangularCut(5, 3, 2, FormTypes.Rectangular), 
                new RectangularCut(3, 3, 3, FormTypes.NonRectangular),
                new RectangularCut(3,4,1,FormTypes.Rectangular)};
            IFullChipboard[] countertops = new IFullChipboard[3];
            List<ILeg>[] legs = new List<ILeg>[3];
            double[] costs = new double[] { 12.3, 18.2, 8.72 };
            Steel[] steelOrders = new Steel[] { new Steel(1.4, 1.4, 3), new Steel(1.3, 1.3, 3), new Steel(0.5, 0.5, 2) };
            IFurniture[] furniture = new Furniture[] { new Furniture(2.1),new Furniture(1.5),new Furniture(1.2) };
            ITable[] tables = new ITable[3];
            for (int i=0;i<3;i++)
            {
                cuts[i].FindBetweenFull();
                cuts[i].FindBestMachine();
                countertops[i] = cuts[i].MakeCut();
                legs[i] = new List<ILeg>();
                legs[i].AddRange(new ILeg[] { new CircleLeg(steelOrders[i],costs[i]),
                    new CircleLeg(steelOrders[i], costs[i]),
                    new CircleLeg(steelOrders[i], costs[i]),
                new CircleLeg(steelOrders[i],costs[i])});
            }
            List<IOperation> operations = new List<IOperation>();
            Paper paper = new Paper(100,100,0.01,0.01);
            Plastic plastic = new Plastic(100,100,0.01,0.10);
            List<IFurniture> furnituresOne = new List<IFurniture>();
            furnituresOne.Add(furniture[0]);
                tables[0] = new Table(countertops[0],legs[0],furnituresOne,cuts[0],paper,"Model1");
            List<IFurniture> furnituresTwo = new List<IFurniture>();
            furnituresOne.Add(furniture[1]);
            tables[1] = new Table(countertops[1], legs[1], furnituresTwo, cuts[1],"Model2");
            List<IFurniture> furnituresThree = new List<IFurniture>();
            furnituresOne.Add(furniture[2]);
            tables[2] = new Table(countertops[2], legs[2], furnituresThree, cuts[2],plastic,"Model2");
            foreach (ITable table in tables) ReadyStorage.Add(table);
            List<ITable> testTables = ReadyStorage.GetByOperationsNumber(1);
            Assert.AreEqual(testTables[0],tables[1]);
            testTables = ReadyStorage.GetByOperationsNumber(2);
            Assert.AreEqual(testTables.Count, 2);
        }
        [OneTimeTearDown]
        public void Clearing()
        {
            foreach (IComponent comp in ObjectStorage.Components.ToList()) ObjectStorage.RemoveComponent(comp);
            ObjectStorage.RemoveJsons();
        }
    }
}
