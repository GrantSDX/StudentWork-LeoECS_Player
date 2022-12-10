using System.Collections;
using UnityEngine;
using Leopotam.Ecs;
using ScriptableObjects;
using Components.UI.Canvas;

namespace Systems.UI.Joystick
{
    public class CanvasUIInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;

        private CanvasUIInitData _canvasUIinitData;

        public void Init()
        {
            var canvas = _world.NewEntity();
            var spawnedCanwas = GameObject.Instantiate(_canvasUIinitData.CanvasPrefab);

            ref var canvasUIComponent = ref canvas.Get<CanvasUIComponent>();
            canvasUIComponent.Canvas = spawnedCanwas.GetComponent<Canvas>();
            canvasUIComponent.Root = spawnedCanwas.transform;
        }
    }
}