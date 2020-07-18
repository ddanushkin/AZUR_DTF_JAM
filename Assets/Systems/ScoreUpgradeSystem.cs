using Leopotam.Ecs;

namespace Game
{
    internal class ScoreUpgradeSystem : IEcsRunSystem
    {
        private GameState _gameState;
        private EcsFilter<ScoreUpgradeEvent> _eventFilter;
        private EcsFilter<ClockComponent> _filter;

        public void Run()
        {
            if (_eventFilter.IsEmpty() || _gameState.Score < 100) return;
            _gameState.Score -= 100;
            foreach (var index in _filter)
            {
                ref ClockComponent clock = ref _filter.Get1(index);
                clock.ScorePerSecond += _gameState.scoreUpgradeLvl * 2f;
                _gameState.scoreUpgradeLvl += 1;
            }
        }
    }
}