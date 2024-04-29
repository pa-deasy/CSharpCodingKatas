namespace RotateMatrix90InPlace
{
    public static class MatrixOperations
    {
        public static Matrix Rotate90AntiClock(this Matrix matrix)
            => new Matrix(
                Rotate90AntiClock(RotateState.New(matrix))
                .CurrentCells);

        public static Matrix Rotate90Clock(this Matrix matrix)
            => new Matrix(
                Rotate90Clock(RotateState.New(matrix))
                .CurrentCells);

        private static RotateState Rotate90AntiClock(RotateState state)
        {
            if (state.CycleCount >= state.MaxCycles)
                return state;

            if (state.CycleFullyRotated)
                return Rotate90AntiClock(new RotateState(state.CurrentCells, state.CycleCount + 1, 0));

            var cells = state.CurrentCells;
            var tempPosition = cells[state.CycleCount, state.CycleCount + state.RotationCount];

            cells[state.CycleCount, state.CycleCount + state.RotationCount] = cells[state.CycleCount + state.RotationCount, state.MaxCellPos - state.CycleCount];

            cells[state.CycleCount + state.RotationCount, state.MaxCellPos - state.CycleCount] = cells[state.MaxCellPos - state.CycleCount, state.MaxCellPos - state.RotationCount - state.CycleCount];

            cells[state.MaxCellPos - state.CycleCount, state.MaxCellPos - state.RotationCount - state.CycleCount] = cells[state.MaxCellPos - state.RotationCount - state.CycleCount, state.CycleCount];

            cells[state.MaxCellPos - state.RotationCount - state.CycleCount, state.CycleCount] = tempPosition;

            return Rotate90AntiClock(new RotateState(cells, state.CycleCount, state.RotationCount + 1));
        }

        private static RotateState Rotate90Clock(RotateState state)
        {
            if (state.CycleCount > state.MaxCycles)
                return state;

            if (state.CycleFullyRotated)
                return Rotate90Clock(new RotateState(state.CurrentCells, state.CycleCount + 1, 0));

            var cells = state.CurrentCells;
            var tempPosition = cells[state.CycleCount, state.CycleCount + state.RotationCount];

            cells[state.CycleCount, state.CycleCount + state.RotationCount] = cells[state.MaxCellPos - state.RotationCount - state.CycleCount, state.CycleCount];

            cells[state.MaxCellPos - state.RotationCount - state.CycleCount, state.CycleCount] = cells[state.MaxCellPos - state.CycleCount, state.MaxCellPos - state.CycleCount - state.RotationCount];

            cells[state.MaxCellPos - state.CycleCount, state.MaxCellPos - state.CycleCount - state.RotationCount] = cells[state.CycleCount + state.RotationCount, state.MaxCellPos - state.CycleCount];

            cells[state.CycleCount + state.RotationCount, state.MaxCellPos - state.CycleCount] = tempPosition;

            return Rotate90Clock(new RotateState(cells, state.CycleCount, state.RotationCount + 1));
        }
    }

    public class RotateState
    {
        public int[,] CurrentCells { get; private set; }
        public int CycleCount { get; private set; }
        public int RotationCount { get; private set; }

        public int MatrixLength => CurrentCells.GetLength(0);
        public int MaxCellPos => MatrixLength - 1;
        public int MaxCycles => MatrixLength / 2;
        public bool CycleFullyRotated => RotationCount >= MaxCellPos - (CycleCount * 2);

        public RotateState(int[,] currentCells, int cycleCount, int rotationCount)
        {
            CurrentCells = currentCells;
            CycleCount = cycleCount;
            RotationCount = rotationCount;
        }

        public static RotateState New(Matrix matrix) => new RotateState(matrix.Cells, 0, 0);
    }
}
