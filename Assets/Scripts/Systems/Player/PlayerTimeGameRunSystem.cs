using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using System;
using Components.UI.TextBord;

namespace Systems.Player
{
    public class PlayerTimeGameRunSystem : IEcsRunSystem
    {
        private EcsFilter<TextMessageComponent> _filter;
        TimeSpan timespan;
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var timeGame = ref _filter.Get1(i);

                timespan = TimeSpan.FromSeconds(Time.realtimeSinceStartup);

                timeGame.TimeGame.text = $"Время в игре: Ч: {timespan.Hours} М: {timespan.Minutes} С: {timespan.Seconds}";
                


            }
        }
    }
}