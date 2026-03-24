namespace Clicker_v2
{
    /// <summary>
    /// Contains all game configuration constants.
    /// Centralizes configuration values to improve maintainability and separation of concerns.
    /// </summary>
    public static class GameConfiguration
    {
        /// <summary>Total duration of the timer in seconds</summary>
        public const int TotalSeconds = 1000;

        /// <summary>The interval for color change in seconds</summary>
        public const int ColorChangeInterval = 1;

        /// <summary>Set interval tick in milliseconds for the indicator timer</summary>
        public const int TimerInterval = 1500;

        /// <summary>Additional time in seconds for TimerIndicator</summary>
        public const int AdditionalTimeIndicator = 5;

        /// <summary>Additional time in seconds for TimerCountdown</summary>
        public const int AdditionalTimeCountdown = 5;

        /// <summary>Bonus time limit threshold</summary>
        public const int BonusTimeLimit = 10;

        /// <summary>Initial elapsed time in seconds</summary>
        public const int ElapsedSeconds = 0;

        /// <summary>Initial bonus time in seconds</summary>
        public const int BonusTimeRemaining = 0;

        /// <summary>Starting quota for the game</summary>
        public const int StartQuota = 100;

        /// <summary>Minimum circle size in pixels</summary>
        public const int CircleSizeMin = 10;

        /// <summary>Maximum circle size in pixels</summary>
        public const int CircleSizeMax = 100;
    }
}
