using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Graph.MasterData;

namespace Graph.View
{
    public interface IGraphProvider<T>
    {
        void DrawDots(List<IGraphEntity<T>> entity);
    }
}
