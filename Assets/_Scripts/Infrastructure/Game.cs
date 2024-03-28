using TopDownShooter.Service.Input;

namespace TopDownShooter.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;

        public Game()
        {
            InputService = new InputService();
        }
    }

}

