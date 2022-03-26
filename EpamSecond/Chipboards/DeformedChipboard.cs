using EpamTaskTwo.MachineWork;
using EpamTaskTwo.Measure;
using EpamTaskTwo.Matherials;
using EpamTaskTwo.Storage;

namespace EpamTaskTwo.Chipboards
{
    public class DeformedChipboard : IDeformedChipboard, IMainMeasures, IExtendedMeasures
    {
        public double CostOfMMCub { get; }
        public double TotalCost { get { return Volume * ChipboardCost.CostOfMMCub; } }
        public List<ICut> Cuts { get; private set; }
        public List<Point> ControlPoints { get; private set; }
        public double Width { get; }
        public double Length { get; }
        public double Height { get; }  
        public DeformedChipboard(IMatherial chipboard,ICut cutParams) {
            if (chipboard is not IFullChipboard fullCb) throw new ArgumentException("Can be created only from full chipboard.");
            Length = chipboard.Length;
            Width = chipboard.Width;
            Height = chipboard.Height;
            ControlPoints = new List<Point>();
            ControlPoints.AddRange(fullCb.MainPoints);
            Cuts = new List<ICut>();
            ChangeMeasures(cutParams);
        }
        /// <summary>
        /// sawing method
        /// </summary>
        /// <param name="cut">Cut parameters</param>
        /// <returns>Enum that shows was sawing successfully or not</returns>
        public ResultOfCut ChangeMeasures(ICut cut) {
            if (TryResize(cut)||Cuts.Count==0)
            {
                Cuts.Add(cut);
                List<Point> searchedPoint = new List<Point>();
                var commonLinq = ControlPoints.Intersect(cut.MainPoints);
                var unicalInCb = ControlPoints.Except(commonLinq);
                var unicalInCut = cut.MainPoints.Except(commonLinq);
                var total = unicalInCb.Union(unicalInCut);
                ControlPoints = total.ToList();
                return ResultOfCut.CutAsDeformed;
            }
            return ResultOfCut.Impossible;
        }
        /// <summary>
        /// Method that shows is possibly to make a cut
        /// </summary>
        /// <param name="cut">Cut parametrs</param>
        /// <returns></returns>
        public bool TryResize(ICut cut) {
            var searchedCut = from c in Cuts where c.ArePointsInside(cut.MainPoints) select c;
            if (searchedCut.Any()) return true;
            else return false;
        }
        public double SizeOfTop
        {
            get
            { return Length * Width - Cuts.Sum(c => c.SizeOfTop); }
        }
        public double SizeOfSide
        {
            get { return Width * Height - Cuts.Sum(c => c.SizeOfSide); }
        }
        public double SizeOfFront
        {
            get { return Length * Height - Cuts.Sum(c => c.SizeOfFront); }
        }
        public double Volume
        {
            get { return Width * Height * Length - Cuts.Sum(c => c.Volume); }
        }
        public bool IsPointInside(Point point) {
            if (point.X<=Length && point.Y<=Width && point.Z<=Height)
            {
                var selectedCut = from innerCut in this.Cuts where innerCut.IsPointInside(point) select innerCut;
                var selectedCuts = selectedCut.ToList();
                if (selectedCuts.Count==0) return true;
            }
            return false;
        }
        public bool ArePointsInside(List<Point> points)
        {
            var selectedPointsLinq = from point in points where !IsPointInside(point) select point;
            var selectedPoints = selectedPointsLinq.ToList();
            if (selectedPoints.Count != 0) return false;
            else return true;
        }
        public int CompareTo(object? obj)
        {
            if (obj is not IChipboard cb) throw new ArgumentException();
            else return Volume.CompareTo(cb.Volume);
        }
        public override string ToString()
        {
            return $"Deformed chipboard. Size Of Top: {SizeOfTop}, SizeOfFront: {SizeOfFront}, Volume: {Volume}." +
                $"Height: {Height}. Total Cost is {TotalCost}.";
        }
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
