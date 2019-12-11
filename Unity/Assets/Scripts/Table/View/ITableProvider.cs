using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Table.MasterData;

namespace Table.View
{

    public interface ITableProvider
    {
        IObservable<int> OnUpdateTableSize { get; }
        void UpdateTable(List<PlayerEntity> target);
    }
}
