using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Graph.MasterData
{
    public class TypeAGraphEntity<T> : IGraphEntity<T>
    {
        public List<T> Position => position;
        private List<T> position;

        public Color Color => color;
        private Color color;

        public TypeAGraphEntity(List<T> p, Color c)
        {
            position = p;
            color = c;
        }

        public class GraphVector3Factory : PlaceholderFactory<
            List<Vector3>,Color,
            TypeAGraphEntity<Vector3>>,
            TypeAVector3GraphEntityFactory
        {

        }
    }
}
