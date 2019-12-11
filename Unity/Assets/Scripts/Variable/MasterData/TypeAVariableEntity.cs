using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Variable.MasterData
{

    public class TypeAVariableEntity<T> : IVariableEntity<T>
    {
        public T xAxis { get; }
        public T yAxis { get; }
        public T zAxis { get; }
        public T feature { get; }

        public TypeAVariableEntity(T x,T y,T z,T f)
        {
            xAxis = x;
            yAxis = y;
            zAxis = z;
            feature = f;
        }


        public class VariableStrFactory : PlaceholderFactory<
            string, string, string, string,
            TypeAVariableEntity<string>>,
            TypeAStringVariableEntityFactory
        {

        }
    }
}
