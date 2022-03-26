using EpamTaskTwo.Measure;
using EpamTaskTwo.Matherials;
using EpamTaskTwo.Operations;
using EpamTaskTwo.Chipboards;
using EpamTaskTwo.Storage;

namespace EpamTaskTwo.MachineWork
{
    public interface ICut : IOperation,IMainMeasures,IExtendedMeasures
    {
        public IMatherial NecessaryMatherial { get; protected set; }
        public List<Point> MainPoints { get; protected set; }
        public double TotalCost { get; }
        public FormTypes Form { get; }
        public IMachine MachineInformation { get; }
        public IFullChipboard FindBetweenFull()
        {
            var fullCBSLinq = from comp in ObjectStorage.Components
                              where comp is IFullChipboard fullCB
                              && fullCB.Width >= Width && fullCB.Height >= Height && fullCB.Length >= Length
                              select comp;
            List<IComponent> fullCBs = fullCBSLinq.ToList();
            List<IFullChipboard> Chipboards = new List<IFullChipboard>();
            foreach (IComponent comp in fullCBs)
            {
                if (comp is IFullChipboard fullCB) Chipboards.Add(fullCB);
            }
            if (Chipboards.Count != 0)
            {
                Chipboards.Sort();
                NecessaryMatherial = Chipboards[0];
                return Chipboards[0];
            }
            throw new ArgumentNullException("Fitable chipboard was not found");
        }
        public IDeformedChipboard FindBetweenDeformed(List<Point> points)
        {
            var defCBSLinq = from comp in ObjectStorage.Components
                             where comp is IDeformedChipboard defCB
                             && defCB.ArePointsInside(points) && points.Intersect(defCB.ControlPoints) != null
                             select comp;
            var Chipboards = defCBSLinq.ToList();
            if (Chipboards.Count != 0)
            {
                MainPoints = points;
                List<IComponent> defCbs = new List<IComponent>();
                foreach (IComponent comp in defCbs)
                {
                    if (comp is IDeformedChipboard defCB) Chipboards.Add(defCB);
                }
                if (Chipboards.Count != 0)
                {
                    Chipboards.Sort();
                    return Chipboards[0] as IDeformedChipboard;
                }
            }
            return null;
        }
        public IMachine FindBestMachine();
        public IFullChipboard MakeCut();
        protected IFullChipboard MakeCut(IFullChipboard fullCB);
        protected IFullChipboard MakeCut(IDeformedChipboard defCB);
        public bool IsPointInside(Point point);
        public bool ArePointsInside(List<Point> point);
    }
}
    
