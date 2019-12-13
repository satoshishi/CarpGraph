using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Table.MasterData;
using Table.Model;
using Table.Presenter;
using Table.View;
using UnityEngine.UI;

public class TableInstaller : MonoInstaller<TableInstaller>
{
    [SerializeField]
    private InputField table;
    [SerializeField]
    private InputField tableSize;
    public override void InstallBindings()
    {
        Container.Bind<ITableProvider>().To<TypeATableProvider>().AsCached()
            .WithArguments(table,tableSize);

        Container.Bind<ITableModel<string>>().To<TypeATableModel<string>>().AsCached();

        Container
            .Bind(typeof(TablePresenter<string>), typeof(IInitializable))
            .To< TablePresenter<string>> ()
            .AsTransient();

        Container.Bind<ITableSizeEntity<float>>().To<TypeATableSizeEntity<float>>().AsTransient();
        Container.Bind<ITableValueEntity<float>>().To<TypeATableEntity<float>>().AsTransient();

        Container.BindFactoryCustomInterface<float, float, float, TypeATableEntity<float>,
            TypeATableEntity<float>.TableFloatFactory,
            TypeAFloatTableEntityFactory>();

        Container.BindFactoryCustomInterface<float, float, float, float, float, float, TypeATableSizeEntity<float>,
            TypeATableSizeEntity<float>.TableFloatFactory,
            TypeAFloatTableSizeEntityFactory>();
    }
}
