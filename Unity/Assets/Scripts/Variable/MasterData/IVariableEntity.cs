using Zenject;

namespace Variable.MasterData
{
    public interface IVariableEntity<T>
    {
        T xAxis { get; }
        T yAxis { get; }
        T zAxis { get; }
        T feature { get; }
    }

    public interface TypeAStringVariableEntityFactory
        : IFactory<
            string, string, string, string,
            TypeAVariableEntity<string>>
    {
    }
}
