using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Components.Player;
using Components.UI.Joystick;

namespace Systems.Player
{
    public class PlayerAnimationRunSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerAnimationComponent> _filter1;
        private EcsFilter<JoystickUIComponent> _filter2 = null;
        public void Run()
        {
            foreach (var j in _filter2)
            {
                ref var joystickUIComponent = ref _filter2.Get1(j);

                foreach (var i in _filter1)
                {
                    var playerAnimationComponent = _filter1.Get1(i);

                    var horizontal = joystickUIComponent.TouchDirection.x;
                    var vertical = joystickUIComponent.TouchDirection.y;

                    if (horizontal != 0f || vertical != 0f)
                        playerAnimationComponent.Animator.Play("Movement");

                    if (horizontal == 0f && vertical == 0f)
                        playerAnimationComponent.Animator.Play("Idle");

                    if (horizontal != 0f || vertical != 0f)
                    {
                        playerAnimationComponent.Animator.SetFloat("Horizontal", horizontal);
                        playerAnimationComponent.Animator.SetFloat("Vertical", vertical);
                    }
                }
            }
        }
    }
}