using Leopotam.Ecs;

namespace Game
{
    internal class HandSpeedBackSystem : IEcsRunSystem
    {
        private GameState _gameState;
        private EcsFilter<HandSpeedBackEvent> _eventFilter;
        private EcsFilter<ClockComponent> _clock;
        
        public void Run()
        {
            if (_gameState.Score < 100 || _eventFilter.IsEmpty()) return;
            _gameState.Score -= 100;
            foreach (var index in _eventFilter)
            {
                ref ClockComponent clock = ref _clock.Get1(index);
                clock.SpeedHandBack += _gameState.handSpeedBackLvl * 2f;
                _gameState.handSpeedBackLvl += 1;
            }
        }
    }
}