using System;
using System.Text.Json;

namespace ClkTeknoloji.CustomerDashboard
{
    public class CounterState
    {
        public int CurrentCount { get; private set; }

        public void IncrementCount()
        {
            CurrentCount++;
            StateChanged?.Invoke();
            Console.WriteLine(JsonSerializer.Serialize(""));

        }

        public event Action StateChanged;
    }
}
