using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using ScriptableObjects;
using Components.Player;

namespace Systems.Player
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        readonly EcsWorld _world = null;
        private PlayerInitData _playerInitData;

        public void Init()
        {
            var player = _world.NewEntity();
            var spawnPlayer = GameObject.Instantiate(_playerInitData.PlayerPrefab);

            ref var playerMovementComponent = ref player.Get<PlayerMovementComponent>();
            playerMovementComponent.Transform = spawnPlayer.transform;
            playerMovementComponent.Speed = _playerInitData.SpeedPlayer;

            ref var playerAnimationComponent = ref player.Get<PlayerAnimationComponent>();
            playerAnimationComponent.Animator = spawnPlayer.GetComponent<Animator>();


        }
    }
}