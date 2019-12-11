using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UniRx;
using Table.MasterData;

namespace Table.View
{

    public class TypeATableProvider : ITableProvider
    {
        private InputField table;
        private InputField tableSize;

        public IObservable<int> OnUpdateTableSize => onUpdateTableSize;
        private Subject<int> onUpdateTableSize;

        public TypeATableProvider(InputField t, InputField ts)
        {
            table = t;
            tableSize = ts;

            onUpdateTableSize = new Subject<int>();


            int parsed = 0;
            tableSize.OnEndEditAsObservable()
                .Where(_value => int.TryParse(_value, out parsed))
                .Subscribe(_value => onUpdateTableSize.OnNext(parsed));
        }

        public void UpdateTable(List<PlayerEntity> target)
        {
            string res = "";

            foreach (PlayerEntity t in target)
                res += t.FullData + "\n";

            table.text = res;
        }
    }
}
