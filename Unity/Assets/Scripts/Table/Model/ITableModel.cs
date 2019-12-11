using Variable.MasterData;
using System;
using System.Collections.Generic;
using Table.MasterData;

namespace Table.Model
{
    public interface ITableModel<T>
    {
        IObservable<List<PlayerEntity>> Created { get; }
        void CreateTable(IVariableEntity<T> entity);
    }
}