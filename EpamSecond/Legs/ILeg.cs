using EpamTaskTwo.Measure;
using EpamTaskTwo.Matherials;

namespace EpamTaskTwo.Legs
{
    /// <summary>
    /// Interface describing table's legs
    /// </summary>
    public interface ILeg : IComponent
    {
        public IMatherial Matherial { get; }
        public Type Form { get; }
    }
}
