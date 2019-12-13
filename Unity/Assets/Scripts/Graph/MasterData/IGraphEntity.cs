using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Graph.MasterData
{
    public interface IGraphEntity<T>
    {
        List<T> Position { get; }
        Color Color { get; }
    }

    public interface TypeAVector3GraphEntityFactory
        : IFactory<
            List<Vector3>, Color,
            TypeAGraphEntity<Vector3>>
    {
    }
}

