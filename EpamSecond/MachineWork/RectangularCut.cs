using EpamTaskTwo.Forms;
using EpamTaskTwo.Matherials;
using EpamTaskTwo.Chipboards;
using EpamTaskTwo.Storage;
using EpamTaskTwo.Measure;
using EpamTaskTwo.Creators;

namespace EpamTaskTwo.MachineWork
{
    public class RectangularCut : Rectangular, ICut
    {
        public IMachine MachineInformation { get; private set; }
        public double Cost { get { return MachineInformation.CostOfMM * (2*Width + 2*Length); } }
        public IMatherial NecessaryMatherial { get; set; }
        public FormTypes Form { get; }
        public double TotalCost { get { return 2 * MachineInformation.CostOfMM * (Width + Length); } }
        public RectangularCut(double width, double length, double height, FormTypes form,IMachine machine) : base(width, length, height) {
            Form = form;
            MachineInformation = machine;
        }
        public RectangularCut(double width,double length,double height,FormTypes form):base(width,length,height)
        {
            Form = form;
            FindBestMachine();
        }
        public IMachine FindBestMachine()
        {
            List<IMachine> machines = new List<IMachine>();
            foreach (IComponent comp in ObjectStorage.Components) {
                if(comp is IMachine mach && mach.MaxPossibleWidth >= Width 
                    && mach.MaxPossibleLength >= Length 
                    && mach.MaxPossibleHeight >= Height) {
                    machines.Add(mach); 
                }
            }
            if (Form==FormTypes.NonRectangular) machines.RemoveAll(mach => !mach.AllowNonRectangular);
            if (machines.Count == 0) throw new NotImplementedException("There aren't a machine for given cut");
            machines.Sort();
            MachineInformation = machines[0];
            return machines[0];
        }
        public IFullChipboard MakeCut()
        {
            if (NecessaryMatherial is IFullChipboard fullCb) return MakeCut(fullCb);
            else if (NecessaryMatherial is IDeformedChipboard defCb) return MakeCut(defCb);
            else throw new ArgumentException("Unknown type");
        }

        public IFullChipboard MakeCut(IFullChipboard fullCB)
        {
            if (NecessaryMatherial == null || MachineInformation == null) throw new ArgumentNullException("Some necessary params are " +
    "not filled");
            if (Width == fullCB.Width && Length == fullCB.Length || Width == fullCB.Width && Height == fullCB.Height
                || Length == fullCB.Length && Height == fullCB.Height)
            {
                try
                {
                    ResultOfCut res = new ResultOfCut();
                    res = fullCB.ChangeMeasures(this);
                    if (res == ResultOfCut.Destroyed) ObjectStorage.RemoveComponent(fullCB);
                }
                catch { }
            }
            else
            {
                if (MainPoints == null) throw new ArgumentNullException("Impossible to make a cut without points");
                try
                {
                    ResultOfCut res = fullCB.ChangeMeasures(this);
                    if (res == ResultOfCut.Impossible)
                    {
                        MainPoints = new List<Point>();
                        MainPoints.AddRange(new Point[]
                        { new Point(NecessaryMatherial.Length,NecessaryMatherial.Width,NecessaryMatherial.Height),
                        new Point(NecessaryMatherial.Length-Length,NecessaryMatherial.Width,NecessaryMatherial.Height),
                        new Point(NecessaryMatherial.Length-Length,NecessaryMatherial.Width-Width,Height),
                        new Point(NecessaryMatherial.Length,NecessaryMatherial.Width-Width,NecessaryMatherial.Height),
                        new Point(NecessaryMatherial.Length,NecessaryMatherial.Width,NecessaryMatherial.Height-Height),
                        new Point(NecessaryMatherial.Length-Length,NecessaryMatherial.Width,NecessaryMatherial.Height-Height),
                        new Point(NecessaryMatherial.Length-Length,NecessaryMatherial.Width-Width,Height-Height),
                        new Point(NecessaryMatherial.Length,NecessaryMatherial.Width-Width,NecessaryMatherial.Height-Height)});
                        IChipboard deformedResult = new DeformedChipboard(fullCB, this);
                        ObjectStorage.ReplaceChipboard(deformedResult, fullCB);
                    }
                }
                catch { }
            }
            IChipboard fullResult = new FullChipboard(Length, Width, Height);
            ObjectStorage.AddComponent(fullResult);
            return fullResult as IFullChipboard;
        }

        public IFullChipboard MakeCut(IDeformedChipboard defCb) {
            NecessaryMatherial = null;
            defCb.ChangeMeasures(this);
            IChipboard fullResult = new FullChipboard(Length,Width,Height);
            ObjectStorage.AddComponent(fullResult);
            return fullResult as IFullChipboard;
        }

        public override string ToString()
        {
            return $"Cut of { NecessaryMatherial.ToString }. { MachineInformation.ToString } is using." +
                $"Width {Width}, Length {Length}, Height {Height}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is ICut cut) return cut.Width == Width && cut.Height == Height && cut.Length == Length &&
                    NecessaryMatherial.Equals(cut.NecessaryMatherial) &&
                    MachineInformation.Equals(cut.MachineInformation);
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
