using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;
using UniRx;
using Variable.MasterData;
using Table.MasterData;
using System.Linq;

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

            created.OnNext(playerEntities);

            List<ITableValueEntity<float>> tableValueEntities = new List<ITableValueEntity<float>>();
            foreach(PlayerEntity pe in playerEntities)
            {
                tableValueEntities.Add(tableFactory.Create(
                        GetVariableFloatValue(entity.xAxis, pe),
                        GetVariableFloatValue(entity.xAxis, pe),
                        GetVariableFloatValue(entity.xAxis, pe)));
            }
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
