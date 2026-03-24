using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Clicker_v2
{
    /// <summary>
    /// Service for managing game timers and their lifecycle.
    /// Handles initialization, starting, stopping, and disposal of timers and stopwatches.
    /// Implements IDisposable to ensure proper resource cleanup.
    /// </summary>
    public class TimerService : IDisposable
    {
        private System.Windows.Forms.Timer? _boardTimer;
        private System.Windows.Forms.Timer? _indicatorTimer;
        private Stopwatch? _stopwatch;
        private bool _disposed = false;

        /// <summary>
        /// Event triggered on each tick of the board timer.
        /// </summary>
        public event EventHandler? TimerTickBoard;

        /// <summary>
        /// Event triggered on each tick of the indicator timer.
        /// </summary>
        public event EventHandler? TimerTickIndicator;

        /// <summary>
        /// Initializes the board timer with the specified interval and starts it.
        /// Also initializes and starts a stopwatch to track elapsed time.
        /// </summary>
        /// <param name="interval">The interval in milliseconds for the board timer.</param>
        /// <exception cref="ObjectDisposedException">Thrown if the service has been disposed.</exception>
        public void InitializeBoardTimer(int interval)
        {
            ThrowIfDisposed();

            _boardTimer?.Stop();
            _boardTimer?.Dispose();

            _boardTimer = new System.Windows.Forms.Timer();
            _boardTimer.Interval = interval;
            _boardTimer.Tick += OnBoardTimerTick;
            
            _stopwatch = new Stopwatch();
            
            _boardTimer.Start();
            _stopwatch.Start();
        }

        /// <summary>
        /// Initializes the indicator timer and starts it.
        /// Sets the interval from GameConfiguration.
        /// </summary>
        /// <exception cref="ObjectDisposedException">Thrown if the service has been disposed.</exception>
        public void InitializeIndicatorTimer()
        {
            ThrowIfDisposed();

            // Stop and dispose existing timer if present
            _indicatorTimer?.Stop();
            _indicatorTimer?.Dispose();

            _indicatorTimer = new System.Windows.Forms.Timer();
            _indicatorTimer.Interval = GameConfiguration.TimerInterval;
            _indicatorTimer.Tick += OnIndicatorTimerTick;
            _indicatorTimer.Start();
        }

        /// <summary>
        /// Stops all timers and the stopwatch.
        /// </summary>
        /// <returns>The elapsed time from the stopwatch when stopped.</returns>
        /// <exception cref="ObjectDisposedException">Thrown if the service has been disposed.</exception>
        public TimeSpan StopAllTimers()
        {
            ThrowIfDisposed();

            _boardTimer?.Stop();
            _indicatorTimer?.Stop();
            _stopwatch?.Stop();

            return _stopwatch?.Elapsed ?? TimeSpan.Zero;
        }

        /// <summary>
        /// Resumes the board timer if it was stopped.
        /// </summary>
        /// <exception cref="ObjectDisposedException">Thrown if the service has been disposed.</exception>
        public void ResumeBoardTimer()
        {
            ThrowIfDisposed();

            if (_boardTimer != null && !_boardTimer.Enabled)
            {
                _boardTimer.Start();
            }

            if (_stopwatch != null && !_stopwatch.IsRunning)
            {
                _stopwatch.Start();
            }
        }

        /// <summary>
        /// Gets the current elapsed time from the stopwatch.
        /// </summary>
        public TimeSpan ElapsedTime
        {
            get => _stopwatch?.Elapsed ?? TimeSpan.Zero;
        }

        /// <summary>
        /// Handles the board timer tick event and raises the TimerTickBoard event.
        /// </summary>
        public void OnBoardTimerTick(object? sender, EventArgs e)
        {
            TimerTickBoard?.Invoke(sender, e);
        }

        /// <summary>
        /// Handles the indicator timer tick event and raises the TimerTickIndicator event.
        /// </summary>
        public void OnIndicatorTimerTick(object? sender, EventArgs e)
        {
            TimerTickIndicator?.Invoke(sender, e);
        }

        /// <summary>
        /// Throws an ObjectDisposedException if the service has been disposed.
        /// </summary>
        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name, "Cannot access a disposed TimerService.");
            }
        }

        /// <summary>
        /// Disposes of the timer resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Protected dispose method to ensure proper cleanup.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _boardTimer?.Stop();
                    _boardTimer?.Dispose();
                    _indicatorTimer?.Stop();
                    _indicatorTimer?.Dispose();
                    _stopwatch?.Stop();
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Finalizer to ensure timers are disposed even if Dispose is not called explicitly.
        /// </summary>
        ~TimerService()
        {
            Dispose(false);
        }
    }
}
