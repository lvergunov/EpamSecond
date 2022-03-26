using EpamTaskTwo.Chipboards;
using EpamTaskTwo.Factory;
using EpamTaskTwo.MachineWork;
using EpamTaskTwo.Matherials;
using EpamTaskTwo.Measure;
using EpamTaskTwo.Storage;
using EpamTaskTwo.XMLWork;
using NUnit.Framework;
using System.Linq;

namespace Test.ParserTest
{
    [TestFixture]
    public class Parser_Test
    {
        private FullChipboard _testFullCb;
        private IMachineCreator _machineCreator;
        private IMachine _machine;
        private IMachine _testMachine;
        private IChipboard _testCb;

        [OneTimeSetUp]
        public void Setup()
        {
            _machine = new Machine(10, 10, 10, true, 0.4);
            ObjectStorage.AddComponent(_machine);
            _machineCreator = new MachineReader("Machine0");
            _testMachine = _machineCreator.GetMachine();
        }

        [Test]
        public void Reader_Test_1()
        {
            Assert.AreEqual(_machine, _testMachine);
        }
        [Test]
        public void Reader_Test_2()
        {
            _testCb = new FullChipboard(10, 2, 1);
            ObjectStorage.AddComponent(_testCb);
            IAbstractChipboardReader reader = new FullChipboardReader("FullChipboard1");
            IChipboard getChipboard = reader.GetChipboard();
            Assert.AreEqual(getChipboard, _testCb);
        }
        [Test]
        public void Reader_Test_3()
        {
            _machine = new Machine(10, 10, 10, true, 0.5);
            WriterByStream writerByStream = new WriterByStream(_machine, 10);
            _machineCreator = new MachineReader("Machine10", System.Text.Encoding.UTF8);
            _testMachine = _machineCreator.GetMachine();
            Assert.AreEqual(_machine, _testMachine);
        }
        [OneTimeTearDown]
        public void Clearing()
        {
            foreach (IComponent comp in ObjectStorage.Components.ToList()) ObjectStorage.RemoveComponent(comp);
            ObjectStorage.RemoveJsons();
        }
    }
}