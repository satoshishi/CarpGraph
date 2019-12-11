using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Variable.Model;
using Variable.View;
using UniRx;

namespace Variable.Presenter
{
    public class VariablePresenter : IInitializable
    {
        [Inject]
        private IVariableModel model;
        [Inject]
        private IVariableProvider view;
        // Start is called before the first frame update

        public void Initialize()
        {
            view.OnChangeValue
                .Subscribe(_variable =>
                {
                    model.UpdateVariable(_variable);
                });
        }
    }
}