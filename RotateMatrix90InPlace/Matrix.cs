namespace RotateMatrix90InPlace
{
    public class Matrix
    {
        public int[,] Cells { get; private set; }

        public Matrix(int[,] cells)
        {
            Cells = cells;
        }
    }
}
