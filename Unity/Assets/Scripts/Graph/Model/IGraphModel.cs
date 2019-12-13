using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Graph.MasterData;
using Table.MasterData;

namespace Graph.Model
{
    public interface IGraphModel<T>
    {
        IObservable<List<IGraphEntity<T>>> OnUpdate { get; }
        void UpdateGraph(Dictionary<string, List<ITableValueEntity<float>>> valueEntities, ITableSizeEntity<float> sizeEntity);
    }
}
