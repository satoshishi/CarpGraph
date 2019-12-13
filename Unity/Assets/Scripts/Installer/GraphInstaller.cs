using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Graph.MasterData;
using Graph.Model;
using Graph.View;
using Graph.Presenter;

public class GraphInstaller : MonoInstaller<VariableInstaller>
{
    [SerializeField]
    private Transform dot;
    [SerializeField]
    private Transform line;

    public override void InstallBindings()
    {
        Container.Bind<IGraphModel<Vector3>>().To<TypeAGraphModel<Vector3>>().AsCached();
        Container.Bind<IGraphEntity<Vector3>>().To<TypeAGraphEntity<Vector3>>().AsTransient();
        Container.Bind<float>().WithId("AxisMaxSize").FromInstance(160f).AsCached();

        Container.Bind<IGraphProvider<Vector3>>().To<TypeAGraphProvider<Vector3>>().AsCached()
            .WithArguments(dot,line);

        Container
       .Bind(typeof(GraphPresenter<Vector3>), typeof(IInitializable))
       .To<GraphPresenter<Vector3>>()
       .AsTransient();

        Container.BindFactoryCustomInterface<List<Vector3>, Color, TypeAGraphEntity<Vector3>,
            TypeAGraphEntity<Vector3>.GraphVector3Factory,
            TypeAVector3GraphEntityFactory>();
    }
}