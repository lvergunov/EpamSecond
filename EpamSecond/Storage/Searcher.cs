using EpamTaskTwo.Chipboards;
using EpamTaskTwo.Measure;
using EpamTaskTwo.MachineWork;

namespace EpamTaskTwo.Storage
{
    public class SearcherByMeasures : IMainMeasures
    {
        public double Width { get; }
        public double Height { get; }
        public double Length { get; }
        public SearcherByMeasures(double wd,double hg,double ln)
        {
            Width = wd; Height = hg; Length = ln; 
        }
    }
}
