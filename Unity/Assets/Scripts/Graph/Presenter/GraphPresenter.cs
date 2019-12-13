using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;
using UniRx;
using Graph.MasterData;
using Graph.Model;
using Graph.View;

namespace Graph.Presenter
{
    public class GraphPresenter<T> : IInitializable
    {
        [Inject]
        private IGraphModel<T> model;
        [Inject]
        private IGraphProvider<T> view;

        public void Initialize()
        {
            model.OnUpdate.
                Subscribe(_value => view.DrawDots(_value));
        }
    }
}
