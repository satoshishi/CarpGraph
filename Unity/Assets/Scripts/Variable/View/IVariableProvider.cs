using System;

namespace Variable.View
{
    public interface IVariableProvider
    {
        IObservable<string> OnChangeValue { get; }
    }
}
