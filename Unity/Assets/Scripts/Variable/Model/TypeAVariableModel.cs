using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variable.MasterData;
using Zenject;
using System;
using Table.Model;

namespace Variable.Model
{

    public class TypeAVariableModel : IVariableModel
    {
        [Inject]
        private TypeAStringVariableEntityFactory factory;
        [Inject]
        private ITableModel<string> tableModel;

        public void UpdateVariable(string axises)
        {
            string[] variables = axises.Split('_');

            var variableEntity = factory.Create(
                 variables[0],
                 variables[1],
                 variables[2],
                 variables[3]);

            tableModel.CreateTable(variableEntity);
        }
    }
}
