using System;
using Game.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Game {
    sealed class EcsStartup : MonoBehaviour
    {
        EcsWorld _world;
        EcsSystems _systems;
        public GameState GameState;
        public Configuration Configuration;
        public SceneData SceneData;

        void Start () {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            GameState = new GameState();
            
            _systems
                // register your systems here, for example:
                .Add(new InitSystem())
                .Add(new InitUpgradeSystem())
                .Add(new MouseInputSystem())
                .Add(new ClockSystem())
                .Add(new ClockReloadSystem())
                .Add(new UpdateScoreSystem())
                .Add(new UpdateScoreUISystem())
                .Add(new UpgradeEventSystem())
                .Add(new ClockSpawnSystem())
                .Add(new HelperSpawnSystem())
                .Add(new HelperMotionSystem())
                .Add(new TimerSystem())
                .Add(new HelperProcSystem())
                .Add(new UpdateTimerUISystem())
                
                // register one-frame components (order is important), for example:
                .OneFrame<UpdateScoreEvent>()
                .OneFrame<ClockSpawnEvent>()
                .OneFrame<UpdateScoreUIEvent>()
                .OneFrame<HelperSpawnEvent>()
                .OneFrame<UpgradeEvent>()

                // inject service instances here (order doesn't important), for example:
                .Inject(Configuration)
                .Inject(SceneData)
                .Inject(GameState)

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

    public struct TimerComponent
    {
        public float TotalSeconds;
        public float ElapsedSeconds;
        public bool Finished;
    }
}