## Quick Reference: New Services

### 🎲 RandomizerService
```csharp
// Get random position for circles
var (x, y) = RandomizerService.GetRandomPosition(panelWidth, panelHeight);

// Get random circle size (10-100 pixels)
int size = RandomizerService.GetRandomCircleSize();

// Get random color from predefined list
Color color = RandomizerService.GetRandomColor();
```

### ⏱️ TimerService
```csharp
// Create instance
var timerService = new TimerService();

// Initialize timers
timerService.InitializeBoardTimer(interval: 500);
timerService.InitializeIndicatorTimer();

// Subscribe to tick events
timerService.TimerTickBoard += (s, e) => { /* handle board tick */ };
timerService.TimerTickIndicator += (s, e) => { /* handle indicator tick */ };

// Get elapsed time
TimeSpan elapsed = timerService.ElapsedTime;

// Stop timers and get final elapsed time
TimeSpan totalElapsed = timerService.StopAllTimers();

// Resume paused timers
timerService.ResumeBoardTimer();

// Clean up resources (IMPORTANT!)
timerService.Dispose();
```

### ⚙️ GameConfiguration
```csharp
// Access any constant
int totalSeconds = GameConfiguration.TotalSeconds;
int timerInterval = GameConfiguration.TimerInterval;
int bonusTimeLimit = GameConfiguration.BonusTimeLimit;
// ... etc
```

### 🔄 Backward Compatibility (via Inits - DEPRECATED)
```csharp
// Old code still works (but shows obsolete warnings)
var (x, y) = Inits.RandomizerPositions(400, 300);
Inits.InitializeBoardTimer(500);
Inits.TimerTickBoard += OnTick;
```

---

## 🚀 Recommended Usage Patterns

### Pattern 1: Inject TimerService (Best Practice)
```csharp
public class GameWindow : Form
{
    private TimerService _timerService;

    public GameWindow()
    {
        _timerService = new TimerService();
        _timerService.InitializeBoardTimer(GameWindow.SelectedInterval);
        _timerService.TimerTickBoard += OnBoardTimerTick;
    }

    private void OnBoardTimerTick(object sender, EventArgs e) { }
}
```

### Pattern 2: Static Access (Current - for Constants)
```csharp
// Use GameConfiguration for constants
var bonusLimit = GameConfiguration.BonusTimeLimit;
```

### Pattern 3: Singleton Pattern (if needed)
```csharp
public class TimerManager
{
    private static TimerService? _instance;
    
    public static TimerService Instance
    {
        get
        {
            _instance ??= new TimerService();
            return _instance;
        }
    }
}
```
