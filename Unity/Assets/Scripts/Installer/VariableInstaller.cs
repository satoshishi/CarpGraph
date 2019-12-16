using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;
using Variable.View;
using Variable.Model;
using Variable.MasterData;
using Variable.Presenter;

public class VariableInstaller : MonoInstaller<VariableInstaller>
{
    [SerializeField]
    private Dropdown xAxis;
    [SerializeField]
    private Dropdown yAxis;
    [SerializeField]
    private Dropdown zAxis;
    [SerializeField]
    private InputField feature;

    public override void InstallBindings()
    {
        Container.Bind<IVariableModel>().To<TypeAVariableModel>().AsCached();

        Container.Bind<IVariableProvider>().To<TypeAVariableProvider>().AsCached()
            .WithArguments(xAxis, yAxis, zAxis, feature);

        Container.Bind<IVariableEntity<string>>().To<TypeAVariableEntity<string>>().AsCached();

        Container.BindFactoryCustomInterface<string, string, string, string, TypeAVariableEntity<string>,
             TypeAVariableEntity<string>.VariableStrFactory,
             TypeAStringVariableEntityFactory>();

        Container
            .BindInterfacesTo<VariablePresenter>()
            .AsTransient();
    }
}
