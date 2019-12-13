using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;
using UniRx;
using Variable.MasterData;
using Table.MasterData;
using System.Linq;
using Graph.Model;

namespace Table.Model
{
    public class TypeATableModel<T> : ITableModel<T>
    {
        [Inject]
        private PlayerRepository playerRepository;
        [Inject]
        private TypeAFloatTableEntityFactory tableFactory;
        [Inject]
        private TypeAFloatTableSizeEntityFactory tableSize;
        [Inject]
        private IGraphModel <Vector3> graphModel;

        public IObservable<List<PlayerEntity>> Created { get { return created; } }
        private Subject<List<PlayerEntity>> created;

        [Inject]
        void Initialize()
        {
            created = new Subject<List<PlayerEntity>>();
        }

        public void CreateTable(IVariableEntity<T> entity)
        {
            List<PlayerEntity> playerEntities =
                entity.feature.ToString().Equals("ALL") ?
                playerRepository.DataStore :
                playerRepository.DataStore.FindAll(player =>
                    player.FullData.Contains(entity.feature.ToString()));

            if (playerEntities.Count <= 0)
                return;

            created.OnNext(playerEntities);

            List<ITableValueEntity<float>> tableValueEntities = new List<ITableValueEntity<float>>();
            Dictionary<string, List<ITableValueEntity<float>>> PlayerValueDict = new Dictionary<string, List<ITableValueEntity<float>>>();

            foreach (PlayerEntity pe in playerEntities)
            {
                ITableValueEntity<float> tableValue = tableFactory.Create(
                        GetVariableFloatValue(entity.xAxis, pe),
                        GetVariableFloatValue(entity.yAxis, pe),
                        GetVariableFloatValue(entity.zAxis, pe));

                if (!PlayerValueDict.ContainsKey(pe.Name))
                    PlayerValueDict.Add(pe.Name, new List<ITableValueEntity<float>>());
                PlayerValueDict[pe.Name].Add(tableValue);

                tableValueEntities.Add(tableValue);
            }

            ITableSizeEntity<float> tableSizeEntity = tableSize.Create(
                (float)((object)tableValueEntities.OrderByDescending(_value => _value.xValue).FirstOrDefault().xValue),
                (float)((object)tableValueEntities.OrderByDescending(_value => _value.xValue).LastOrDefault().xValue),

                (float)((object)tableValueEntities.OrderByDescending(_value => _value.yValue).FirstOrDefault().yValue),
                (float)((object)tableValueEntities.OrderByDescending(_value => _value.yValue).LastOrDefault().yValue),

                (float)((object)tableValueEntities.OrderByDescending(_value => _value.zValue).FirstOrDefault().zValue),
                (float)((object)tableValueEntities.OrderByDescending(_value => _value.zValue).LastOrDefault().zValue)
                );
            graphModel.UpdateGraph(PlayerValueDict, tableSizeEntity);
        }

        public float GetVariableFloatValue(T variableKey, PlayerEntity playerEntity)
        {
            float _value = 0f;
            switch (variableKey.ToString())
            {
                case "Height":
                    _value = playerEntity.Height;
                    break;
                case "Weight":
                    _value = playerEntity.Weight;
                    break;
                case "Age":
                    _value = playerEntity.Age;
                    break;
                case "Annual Salary":
                    _value = playerEntity.AnnualSalary;
                    break;
                case "Data Year":
                    _value = playerEntity.DataYear;
                    break;
            }
            return _value;
        }
    }
}
