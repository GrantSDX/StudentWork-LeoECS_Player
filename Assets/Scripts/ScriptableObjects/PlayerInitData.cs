using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerInitData", menuName = "ScriptableObject/PlayerInitData", order = 0)]
    public class PlayerInitData : ScriptableObject
    {

        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private float speedPlayer;

        public GameObject PlayerPrefab => playerPrefab;
        public float SpeedPlayer => speedPlayer;
    }
}