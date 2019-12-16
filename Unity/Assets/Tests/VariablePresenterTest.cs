using UnityEngine.TestTools;
using UnityEngine;
using Moq;
using Zenject;
using NUnit.Framework;
using UniRx;
using Variable.View;
using Variable.Model;
using Variable.Presenter;
using Table.MasterData;

namespace Tests
{
    [TestFixture]
    public class VariablePresenterTest : ZenjectUnitTestFixture
    {
        Mock<IVariableProvider> _mockView;
        Mock<IVariableModel> _mockModel;

        VariablePresenter _presenter;
        Subject<string> _onChangeValue;

        [SetUp]
        public void SetUp()
        {
            Container
            .BindInterfacesAndSelfTo<VariablePresenter>()
            .AsTransient();

            _mockView = new Mock<IVariableProvider>();    
            _mockModel = new Mock<IVariableModel>();
            _onChangeValue = new Subject<string>();
            _mockView.Setup(x => x.OnChangeValue).Returns(_onChangeValue);

            Container.BindInstance<IVariableModel>(_mockModel.Object);
            Container.BindInstance<IVariableProvider>(_mockView.Object);
            Container.Inject(this);
        }

        [Test]
        public void Viewの入力値がModelに正常に送られているか()
        {
            var Presenter = Container.Resolve<VariablePresenter>();
            _onChangeValue.OnNext("test_test_test");
            _mockModel.Verify(x=>x.UpdateVariable("test_test_test"),Times.Once);
        }
    }

}

