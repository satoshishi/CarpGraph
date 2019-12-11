using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Table.MasterData
{
    public class TypeATableEntity<T> : ITableValueEntity<T>
    {
        public T xValue => x;
        private T x;

        public T yValue => y;
        private T y;

        public T zValue => z;
        private T z;

        public TypeATableEntity(T _x, T _y, T _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public class TableFloatFactory : PlaceholderFactory<
            float, float, float,
            TypeATableEntity<float>>,
            TypeAFloatTableEntityFactory
        {
        }
    }

    public class TypeATableSizeEntity<T> : ITableSizeEntity<T>
    {
        public T xAxisMax => xMax;
        private T xMax;
        public T xAxisMin => xMin;
        private T xMin;

        public T yAxisMax => yMax;
        private T yMax;
        public T yAxisMin => yMin;
        private T yMin;

        public T zAxisMax => zMax;
        private T zMax;
        public T zAxisMin => zMin;
        private T zMin;

        public TypeATableSizeEntity(
            T xmax, T xmin,
            T ymax, T ymin,
            T zmax, T zmin)
        {
            xMax = xmax;
            xMin = xmin;
            yMax = ymax;
            yMin = ymin;
            zMax = zmax;
            zMin = zmin;
        }

        public class TableFloatFactory : PlaceholderFactory<
            float, float, float, float, float, float,
            TypeATableSizeEntity<float>>,
            TypeAFloatTableSizeEntityFactory
        {
        }
    }
}
