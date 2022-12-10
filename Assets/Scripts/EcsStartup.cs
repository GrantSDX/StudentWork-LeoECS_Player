using Leopotam.Ecs;
using UnityEngine;
using ScriptableObjects;
using Systems.Player;
using Systems.UI.Joystick;

sealed class EcsStartup : MonoBehaviour 
    {
        [SerializeField] private PlayerInitData playerInitData;
        [SerializeField] private JoystickUIInitData joystickUIInitData;
        [SerializeField] private CanvasUIInitData canvasUIInitData;
        [SerializeField] private TextMessageInitData textMessageInitData;

        EcsWorld _world;
        EcsSystems _systems;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                // register your systems here, for example:
                // .Add (new TestSystem1 ())
                //.Add (new WelcomeInitSystem())
                //.Add (new PlayerTimeGameRunSystem())
                .Add (new PlayerInitSystem())
                .Add (new PlayerMovementRunSystem())
                .Add (new PlayerAnimationRunSystem())
                .Add (new CanvasUIInitSystem())
                .Add (new JoystickUIInitSystem())
                .Add (new WelcomeInitSystem())
                .Add (new PlayerTimeGameRunSystem())                   
                .Add (new JoystickUIRunSystem())
                
                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()
                
                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Inject(playerInitData)
                .Inject(joystickUIInitData)
                .Inject(canvasUIInitData)
                .Inject(textMessageInitData)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
