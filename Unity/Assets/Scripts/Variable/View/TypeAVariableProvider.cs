using UnityEngine;
using UniRx;
using System;
using UnityEngine.UI;
using Zenject;

namespace Variable.View
{
    public class TypeAVariableProvider : IVariableProvider
    {
        private Dropdown xAxis;
        private Dropdown yAxis;
        private Dropdown zAxis;
        private InputField feature;

        public IObservable<string> OnChangeValue { get { return onChangeValue; } }
        private Subject<string> onChangeValue;

        public TypeAVariableProvider(Dropdown x,Dropdown y,Dropdown z,InputField f)
        {
            xAxis = x;
            yAxis = y;
            zAxis = z;
            feature = f;
            onChangeValue = new Subject<string>();

            xAxis.OnValueChangedAsObservable()
                .Subscribe(_value => onChangeValue.OnNext(GetVariableStr()));

            yAxis.OnValueChangedAsObservable()
                .Subscribe(_value => onChangeValue.OnNext(GetVariableStr()));

            zAxis.OnValueChangedAsObservable()
                .Subscribe(_value => onChangeValue.OnNext(GetVariableStr()));

            feature.OnEndEditAsObservable()
                .Subscribe(_value =>
                    onChangeValue.OnNext(GetVariableStr()));
        }

        private string GetVariableStr()
        {
            return xAxis.options[xAxis.value].text + "_" +
                        yAxis.options[yAxis.value].text + "_" +
                        zAxis.options[zAxis.value].text + "_" +
                        (feature.text.Equals("") ? "ALL" : feature.text);
        }
    }
}
