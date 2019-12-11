using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Zenject;
using Table.Model;
using Table.View;
using Table.MasterData;

namespace Table.Presenter
{

    public class TablePresenter<T> : IInitializable
    {
        [Inject]
        private ITableModel<T> model;
        [Inject]
        private ITableProvider view;

        public void Initialize()
        {
            view.OnUpdateTableSize
                .Subscribe(_variable =>
                {
                //                model.CreateTable();
            });

            model.Created.Subscribe(_value => view.UpdateTable(_value));
        }
    }
}
