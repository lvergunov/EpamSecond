using NUnit.Framework;
using EpamTaskTwo.Matherials;
using EpamTaskTwo.MachineWork;
using EpamTaskTwo.Chipboards;
using EpamTaskTwo.Storage;
using EpamTaskTwo.Measure;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Test
{
    public class Chipboard_Cutting_Test
    {
        private IChipboard _chipboardOne;
        private IMachine _machineOne;
        private IMachine _machineTwo;
        private IMachine _machineThree;
        private IMachine _machineFour;
        private ICut _cut;
        private IDeformedChipboard _testDeformed;
        List<Point> points = new List<Point>();

        [OneTimeSetUp]
        public void Setup()
        {
            ChipboardCost.SetCost(3);
            _chipboardOne = new FullChipboard(18, 10, 4);
            _machineOne = new Machine(4,11,3,true,10);
            _machineTwo = new Machine(10,10,6,false,12);
            _machineThree = new Machine(9,5,4,true,20);
            _machineFour = new Machine(7,7,7,true,15);
            IComponent[] components = { _chipboardOne, _machineOne, _machineTwo, _machineThree, _machineFour };
            foreach(IComponent comp in components)
                ObjectStorage.AddComponent(comp);
            _cut = new RectangularCut(5,4,4,FormTypes.NonRectangular);
            _cut.FindBetweenFull();

            _cut.MakeCut();
            var defCb = from def in ObjectStorage.Components
                        where def is IDeformedChipboard
                        select def;
            var defCbs = defCb.ToList();
            _testDeformed = defCbs[0] as IDeformedChipboard;
            points.AddRange(new Point[] {new Point(0,0,0), new Point(2,0,0),new Point(2,2,0),new Point(0,2,0),
            new Point(0,0,2),new Point(2,0,2),new Point(2,2,2),new Point(0,2,2)});
        }
        [Test]
        public void Test_Of_Cut_2()
        {
            Assert.IsTrue(_testDeformed.ArePointsInside(points));
        }
        [Test]
        public void Test_Of_Cut_3()
        {
            ICut cut = new RectangularCut(2,2,2,FormTypes.Rectangular);
            cut.FindBetweenDeformed(points);
            cut.FindBestMachine();
            cut.MakeCut();
            Assert.AreEqual(ObjectStorage.Components[ObjectStorage.Components.Count-1],new FullChipboard(2,2,2));
        }
        [Test]
        public void Test_Of_Cut_4()
        {
            ICut cut = new RectangularCut(2, 2, 2, FormTypes.Rectangular);
            cut.FindBetweenDeformed(points);
            cut.FindBestMachine();
            Assert.Throws<ArgumentException>(
                delegate { cut.MakeCut(); }
                );
        }
        [OneTimeTearDown]
        public void Clearing() {
            foreach (IComponent comp in ObjectStorage.Components.ToList()) ObjectStorage.RemoveComponent(comp);
            ObjectStorage.RemoveJsons();
        }
    }
}