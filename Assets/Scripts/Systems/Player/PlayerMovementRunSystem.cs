
using UnityEngine;
using Leopotam.Ecs;
using Components.Player;
using Components.UI.Joystick;

namespace Systems.Player
{
    public class PlayerMovementRunSystem : IEcsRunSystem
    {
        
        private EcsFilter<PlayerMovementComponent> _filter1 = null;
        private EcsFilter<JoystickUIComponent> _filter2 = null;

        public void Run()
        {
            foreach (var j in _filter2)
            {
                ref var joystickUIComponent = ref _filter2.Get1(j);

                var horizontal = joystickUIComponent.TouchDirection.x;
                var vertical = joystickUIComponent.TouchDirection.y;

                foreach (var i in _filter1)
                {
                    ref var playerMovementComponent = ref _filter1.Get1(i);

                    playerMovementComponent.Transform.position +=
                        (new Vector3(horizontal, vertical, 0f).normalized * playerMovementComponent.Speed) * Time.deltaTime;

                }
            }
        }
    }
}