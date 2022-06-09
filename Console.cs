using System.Collections.Immutable;

public static class Console
{
    private class SimulatedGameInputQueue
    {
        private readonly ImmutableQueue<int> _inputQueue;

        private SimulatedGameInputQueue(ImmutableQueue<int> inputQueue) => _inputQueue = inputQueue;

        public static SimulatedGameInputQueue Empty => new(ImmutableQueue<int>.Empty);

        public SimulatedGameInputQueue Play(int row, int col) => new(_inputQueue.Enqueue(row).Enqueue(col));

        public SimulatedGameInputQueue GetNextInput(out int input) => new(_inputQueue.Dequeue(out input));
    }

    private static SimulatedGameInputQueue xWinningGame = 
        SimulatedGameInputQueue.Empty
            .Play(1, 1)
            .Play(0, 0)
            .Play(0, 1)
            .Play(1, 0)
            .Play(2, 1);

    private static SimulatedGameInputQueue currentGameInputQueue = xWinningGame;

    public static string? ReadLine()
    {
        currentGameInputQueue = currentGameInputQueue.GetNextInput(out int input);
        return input.ToString();
    }

    public static void WriteLine(object value) => System.Console.WriteLine(value);
}