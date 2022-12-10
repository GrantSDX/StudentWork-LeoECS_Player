using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using ScriptableObjects;
using Components.UI.Canvas;
using Components.UI.TextBord;
using TMPro;


namespace Systems.Player
{
    public class WelcomeInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;
        private EcsFilter<CanvasUIComponent> _filter;
        private TextMessageInitData _textMessageInitData;
        public void Init()
        {
            foreach (var i in _filter)
            {
                var canvasUIComponent = _filter.Get1(i);

                var welcomeToTimeGame = _world.NewEntity();
                var spawnedWelcome = GameObject.Instantiate(_textMessageInitData.Welcome, canvasUIComponent.Root);             
                var spawnedTimeGame = GameObject.Instantiate(_textMessageInitData.TimeGame, canvasUIComponent.Root);

                ref var textMessageComponent = ref welcomeToTimeGame.Get<TextMessageComponent>();
                textMessageComponent.Welcome = spawnedWelcome.GetComponent<TextMeshProUGUI>();
                textMessageComponent.Welcome.text = "Welcome to Game!!!";

                textMessageComponent.TimeGame = spawnedTimeGame.GetComponent<TextMeshProUGUI>();
                textMessageComponent.TimeGame.text = "";



            }
        }
    }
}