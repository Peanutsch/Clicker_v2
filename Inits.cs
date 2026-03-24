using System;
using System.Windows.Forms;

namespace Clicker_v2
{
    /// <summary>
    /// Legacy compatibility class for the Clicker game initialization.
    /// This class maintains backward compatibility with existing code while delegating to new services.
    /// 
    /// DEPRECATED: New code should use the individual services directly:
    /// - RandomizerService for randomization
    /// - TimerService for timer management
    /// - GameConfiguration for configuration constants
    /// </summary>
    [Obsolete("Use RandomizerService, TimerService, and GameConfiguration directly instead.", false)]
    public class Inits
    {
        private static TimerService? _timerService;

        /// <summary>
        /// Gets or creates the singleton TimerService instance.
        /// </summary>
        private static TimerService TimerServiceInstance
        {
            get
            {
                _timerService ??= new TimerService();
                return _timerService;
            }
        }

        #region CONFIGURATION CONSTANTS (DEPRECATED)
        /// <summary>DEPRECATED: Use GameConfiguration.TotalSeconds instead.</summary>
        internal const int totalSeconds = GameConfiguration.TotalSeconds;

        /// <summary>DEPRECATED: Use GameConfiguration.ColorChangeInterval instead.</summary>
        internal const int colorChangeInterval = GameConfiguration.ColorChangeInterval;

        /// <summary>DEPRECATED: Use GameConfiguration.TimerInterval instead.</summary>
        internal const int timerInterval = GameConfiguration.TimerInterval;

        /// <summary>DEPRECATED: Use GameConfiguration.AdditionalTimeIndicator instead.</summary>
        internal const int additionalTimeIndicator = GameConfiguration.AdditionalTimeIndicator;

        /// <summary>DEPRECATED: Use GameConfiguration.AdditionalTimeCountdown instead.</summary>
        internal const int additionalTimeCountdown = GameConfiguration.AdditionalTimeCountdown;

        /// <summary>DEPRECATED: Use GameConfiguration.BonusTimeLimit instead.</summary>
        internal const int bonusTimeLimit = GameConfiguration.BonusTimeLimit;

        /// <summary>DEPRECATED: Use GameConfiguration.ElapsedSeconds instead.</summary>
        internal const int elapsedSeconds = GameConfiguration.ElapsedSeconds;

        /// <summary>DEPRECATED: Use GameConfiguration.BonusTimeRemaining instead.</summary>
        internal const int bonusTimeRemaining = GameConfiguration.BonusTimeRemaining;

        /// <summary>DEPRECATED: Use GameConfiguration.StartQuota instead.</summary>
        internal const int startQuota = GameConfiguration.StartQuota;
        #endregion

        #region RANDOMIZERS (DEPRECATED)
        /// <summary>
        /// DEPRECATED: Use RandomizerService.GetRandomPosition instead.
        /// Returns randomized coordinates (x, y) for a circle within the specified maximum width and height.
        /// </summary>
        [Obsolete("Use RandomizerService.GetRandomPosition instead.", false)]
        public static (int, int) RandomizerPositions(int maxWidth, int maxHeight)
        {
            return RandomizerService.GetRandomPosition(maxWidth, maxHeight);
        }

        /// <summary>
        /// DEPRECATED: Use RandomizerService.GetRandomCircleSize instead.
        /// Returns a randomized size for a circle within a specified range.
        /// </summary>
        [Obsolete("Use RandomizerService.GetRandomCircleSize instead.", false)]
        public static int RandomizerCircleSize()
        {
            return RandomizerService.GetRandomCircleSize();
        }

        /// <summary>
        /// DEPRECATED: Use RandomizerService.GetRandomColor instead.
        /// Returns a random color from a predefined list of colors.
        /// </summary>
        [Obsolete("Use RandomizerService.GetRandomColor instead.", false)]
        public static Color RandomizerColor()
        {
            return RandomizerService.GetRandomColor();
        }
        #endregion

        #region TIMER MANAGEMENT (DEPRECATED)
        /// <summary>
        /// DEPRECATED: Use TimerService directly instead.
        /// An event that is triggered on each tick of the board timer.
        /// </summary>
        [Obsolete("Use TimerService.TimerTickBoard event instead.", false)]
        public static event EventHandler? TimerTickBoard
        {
            add => TimerServiceInstance.TimerTickBoard += value;
            remove => TimerServiceInstance.TimerTickBoard -= value;
        }

        /// <summary>
        /// DEPRECATED: Use TimerService directly instead.
        /// An event that is triggered on each tick of the indicator timer.
        /// </summary>
        [Obsolete("Use TimerService.TimerTickIndicator event instead.", false)]
        public static event EventHandler? TimerTickIndicator
        {
            add => TimerServiceInstance.TimerTickIndicator += value;
            remove => TimerServiceInstance.TimerTickIndicator -= value;
        }

        /// <summary>
        /// DEPRECATED: Use TimerService.InitializeBoardTimer instead.
        /// Initializes the board timer and stopwatch, and starts the timers with the specified interval.
        /// </summary>
        [Obsolete("Use TimerService.InitializeBoardTimer instead.", false)]
        public static void InitializeBoardTimer(int interval)
        {
            TimerServiceInstance.InitializeBoardTimer(interval);
        }

        /// <summary>
        /// DEPRECATED: Use TimerService.InitializeIndicatorTimer instead.
        /// Initializes the indicator timer and starts it.
        /// </summary>
        [Obsolete("Use TimerService.InitializeIndicatorTimer instead.", false)]
        public static void InitializeIndicatorTimer()
        {
            TimerServiceInstance.InitializeIndicatorTimer();
        }

        /// <summary>
        /// DEPRECATED: Use TimerService.StopAllTimers instead.
        /// Stops both the board timer and the indicator timer, and the stopwatch.
        /// </summary>
        [Obsolete("Use TimerService.StopAllTimers instead.", false)]
        public static TimeSpan StopTimer(PanelBoardCircles drawPanelBoard)
        {
            drawPanelBoard.Visible = false;
            return TimerServiceInstance.StopAllTimers();
        }
        #endregion

        #region INITIALIZATION
        /// <summary>
        /// DEPRECATED: This method is not implemented.
        /// Initializes game levels and quotas.
        /// </summary>
        [Obsolete("This method is no longer supported.", false)]
        public void InitLevels()
        {
            // Not implemented
        }
        #endregion

        /// <summary>
        /// Cleans up the timer service resources.
        /// Should be called when the application is shutting down.
        /// </summary>
        public static void Cleanup()
        {
            _timerService?.Dispose();
            _timerService = null;
        }
    }
}
