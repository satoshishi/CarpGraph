using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Table.MasterData
{
    [CreateAssetMenu(menuName = "MasterData/CreatePlayerRepository", fileName = "PlayerRepository")]
    public class PlayerRepository : ScriptableObject
    {
        public List<PlayerEntity> DataStore;
    }

    [System.Serializable]
    public class PlayerEntity
    {
        public string Name;
        public string BloodType;
        public string Origin;
        public string FullData;
        public float Height;
        public float Weight;
        public int Age;
        public int AnnualSalary;
        public int DataYear;
    }
}
