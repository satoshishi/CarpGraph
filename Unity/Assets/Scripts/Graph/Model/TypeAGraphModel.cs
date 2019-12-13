using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Graph.MasterData;
using System;
using Table.MasterData;
using Zenject;
using UniRx;

namespace Graph.Model
{
    public class TypeAGraphModel<T> : IGraphModel<T>
    {
        [Inject]
        private TypeAVector3GraphEntityFactory factory;
        [Inject(Id = "AxisMaxSize")]
        private float AxisMaxSize;

        public IObservable<List<IGraphEntity<T>>> OnUpdate => onUpdate;
        private Subject<List<IGraphEntity<T>>> onUpdate;

        [Inject]
        public void Initialize()
        {
            onUpdate = new Subject<List<IGraphEntity<T>>>();
        }

        public void UpdateGraph(
            Dictionary<string, List<ITableValueEntity<float>>> valueEntities,
            ITableSizeEntity<float> sizeEntity)
        {
            List<IGraphEntity<T>> graphEntities = new List<IGraphEntity<T>>();

            foreach (KeyValuePair<string, List<ITableValueEntity<float>>> valueEntity in valueEntities)
            {
                List<Vector3> coordinates = new List<Vector3>();

                for (int i = 0; i < valueEntity.Value.Count; i++)
                {
                    coordinates.Add(GetGraphCoordinate(valueEntity.Value[i], sizeEntity));
                }

                IGraphEntity<T> graphEntity = (IGraphEntity<T>)(object)(factory.Create(coordinates,
                    new Color(
                    UnityEngine.Random.Range(0f, 1f),
                    UnityEngine.Random.Range(0f, 1f),
                    UnityEngine.Random.Range(0f, 1f))));

                graphEntities.Add(graphEntity);
            }
            onUpdate.OnNext(graphEntities);
        }

        private Vector3 GetGraphCoordinate(ITableValueEntity<float> valueEntity, ITableSizeEntity<float> sizeEntity)
        {
            return new Vector3(
                        (Mathf.Max(valueEntity.zValue - sizeEntity.zAxisMin, 0.01f) / Mathf.Max(sizeEntity.zAxisMax - sizeEntity.zAxisMin, 0.01f)) * AxisMaxSize,
                        (Mathf.Max(valueEntity.yValue - sizeEntity.yAxisMin, 0.01f) / Mathf.Max(sizeEntity.yAxisMax - sizeEntity.yAxisMin, 0.01f)) * AxisMaxSize,
                        (Mathf.Max(valueEntity.xValue - sizeEntity.xAxisMin, 0.01f) / Mathf.Max(sizeEntity.xAxisMax - sizeEntity.xAxisMin, 0.01f)) * AxisMaxSize);
        }
    }
}
