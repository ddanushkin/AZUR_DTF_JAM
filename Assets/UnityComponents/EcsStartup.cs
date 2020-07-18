using System;
using Leopotam.Ecs;
using UnityEngine;

namespace Game {
    sealed class EcsStartup : MonoBehaviour
    {
        EcsWorld _world;
        EcsSystems _systems;
        private GameState _gameState;
        public Configuration Configuration;
        public SceneData SceneData;

        void Start () {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _gameState = new GameState();
            
            _systems
                // register your systems here, for example:
                .Add(new InitSystem())
                .Add(new ClockSystem())
                .Add(new UpdateTimerSystem())
                .Add(new UpdateScoreSystem())
                .Add(new UiUpgradeSystem())
                .Add(new HandSpeedUpgradeSystem())
                .Add(new ScoreUpgradeSystem())
                .Add(new HandSpeedBackSystem())
                
                // register one-frame components (order is important), for example:
                .OneFrame<UpdateScoreEvent> ()
                .OneFrame<HandSpeedUpgradeEvent>()
                .OneFrame<ScoreUpgradeEvent>()
                .OneFrame<HandSpeedBackEvent>()
                // inject service instances here (order doesn't important), for example:
                .Inject(Configuration)
                .Inject(SceneData)
                .Inject(_gameState)

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
}