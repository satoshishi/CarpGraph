using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Table.MasterData
{

    public interface ITableValueEntity<T>
    {
        T xValue { get; }
        T yValue { get; }
        T zValue { get; }
    }
    public interface TypeAFloatTableEntityFactory
        : IFactory<
            float, float, float,
            TypeATableEntity<float>>
    {
    }

    public interface ITableSizeEntity<T>
    {
        T xAxisMax { get; }
        T xAxisMin { get; }
        //
        T yAxisMax { get; }
        T yAxisMin { get; }
        //
        T zAxisMax { get; }
        T zAxisMin { get; }
    }
    public interface TypeAFloatTableSizeEntityFactory
    : IFactory<
        float, float, float, float, float, float,
        TypeATableSizeEntity<float>>
    {
    }
}
