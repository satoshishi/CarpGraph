using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Graph.MasterData;
using DG.Tweening;

namespace Graph.View
{
    public class TypeAGraphProvider<T> : IGraphProvider<T>
    {
        private Transform dot;
        private Transform line;

        private List<Transform> dots;

        public TypeAGraphProvider(Transform d, Transform l)
        {
            dot = d;
            line = l;
            dots = new List<Transform>();
        }

        public void DrawDots(List<IGraphEntity<T>> entities)
        {
            RemoveDots();

            foreach (IGraphEntity<T> entity in entities)
                SpawnDot(entity);
        }

        private void SpawnDot(IGraphEntity<T> entity)
        {
            Transform _line = UnityEngine.GameObject.Instantiate(line, Vector3.zero, Quaternion.identity);
            var lineRender = _line.GetComponent<LineRenderer>();
            lineRender.SetColors(entity.Color, entity.Color);
            dots.Add(_line);

            for (int i = 0; i < entity.Position.Count; i++)
            {
                Vector3 pos = (Vector3)(object)entity.Position[i];

                var _dot = UnityEngine.GameObject.Instantiate(dot, pos, Quaternion.identity);
                _dot.GetComponent<Renderer>().material.SetColor("_Color", entity.Color);
                lineRender.SetPosition(i, pos);
                _dot.DOScale(5f, 0.2f).SetEase(Ease.InSine).SetDelay(i * 0.1f);
                dots.Add(_dot);
            }
            lineRender.positionCount = entity.Position.Count;
        }

        private void RemoveDots()
        {
            foreach (Transform d in dots)
                UnityEngine.GameObject.Destroy(d.gameObject);
            dots = new List<Transform>();
        }
    }
}
