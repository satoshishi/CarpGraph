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
        private IVariableModel model;
        
        private IVariableProvider view;
        // Start is called before the first frame update

        public VariablePresenter(IVariableModel m,IVariableProvider p)
        {
            model = m;
            view = p;
            view.OnChangeValue
                .Subscribe(_variable =>
                {
                    model.UpdateVariable(_variable);
                });
        }

        void IInitializable.Initialize()
        {

        }
    }
}