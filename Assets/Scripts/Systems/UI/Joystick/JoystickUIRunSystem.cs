using System.Collections;
using UnityEngine;
using Leopotam.Ecs;
using Components.UI.Joystick;

namespace Systems.UI.Joystick
{
    public class JoystickUIRunSystem : IEcsRunSystem
    {

        
        private EcsFilter<JoystickUIComponent> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var joysticUIComponent = ref _filter.Get1(i);

                if(Input.touchCount >0)
                {
                    if(Vector2.Distance(Input.GetTouch(0).position, joysticUIComponent.OriginHeaderPosition) < 800f)
                    {
                        if(Input.GetTouch(0).phase == TouchPhase.Began)
                        {
                            joysticUIComponent.TouchStart = true;
                            joysticUIComponent.FirstTouchPosition = Input.GetTouch(0).position;
                            joysticUIComponent.SecondTouchPosition = Input.GetTouch(0).position;

                            joysticUIComponent.Header.position = joysticUIComponent.FirstTouchPosition;
                            joysticUIComponent.Body.position = joysticUIComponent.FirstTouchPosition;
                        }
                    }

                    if ((Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary) && joysticUIComponent.TouchStart == true)
                    {
                        joysticUIComponent.SecondTouchPosition = Input.GetTouch(0).position;
                       
                        joysticUIComponent.Body.position = new Vector3(joysticUIComponent.FirstTouchPosition.x + joysticUIComponent.TouchDirection.x, 
                            joysticUIComponent.FirstTouchPosition.y + joysticUIComponent.TouchDirection.y);
                        
                    }

                    if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
                    {
                        joysticUIComponent.TouchStart = false;
                        joysticUIComponent.FirstTouchPosition = Vector2.zero;
                        joysticUIComponent.SecondTouchPosition = Vector2.zero;
                        joysticUIComponent.TouchDirection = Vector2.zero;
                        joysticUIComponent.Header.position = joysticUIComponent.OriginHeaderPosition;
                        joysticUIComponent.Body.position = joysticUIComponent.OriginBodyPosition;
                    }

                    if (joysticUIComponent.TouchStart)
                    {
                        joysticUIComponent.TouchOffset = joysticUIComponent.SecondTouchPosition - joysticUIComponent.FirstTouchPosition;
                        joysticUIComponent.TouchDirection = Vector2.ClampMagnitude(joysticUIComponent.TouchOffset, 100f);
                        
                    }
                }


            }
        }
    }
}