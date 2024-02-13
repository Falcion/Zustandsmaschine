namespace Zustand.Subflow
{
    using Zustand.Data.Types;
    using Zustand.Data.Types.Interfaces;

    public class Transdefs
    {
        private int[,] _matrix = new int[5, 5];

        private Pair<int> _corners = new Pair<int>(default(int),
                                                   default(int));

        private Pair<int> _centers = new Pair<int>(default(int),
                                                   default(int));

        public Transdefs() { }

        public Transdefs(int[,] matrix)
        {
            _matrix = matrix;
        }

        public Transdefs(Pair<int> corners,
                         Pair<int> centers, int[,] matrix) : this(matrix)
        {
            _corners = corners;
            _centers = centers;
        }

        public Transdefs(Pair<int> corners,
                         Pair<int> centers)
        {
            _corners = corners;
            _centers = centers;
        }

        public void Nullify()
        {
            _matrix = new int[5, 5];

            _corners = new();
            _centers = new();
        }

        public int[,] Matrix
        {
            get => _matrix;
            set => _matrix = value;
        }

        public Pair<int> Corners => _corners;

        public Pair<int> Centers => _centers;

        public void InjectCorners(Pair<int> corners) => _corners = corners;

        public void InjectCorners(int corner, char pos_item)
        {
            switch (pos_item)
            {
                case '1':
                    _corners = new Pair<int>(corner, _corners.Param2);
                    break;
                case '2':
                    _corners = new Pair<int>(_corners.Param1, corner);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pos_item), "Can't change item in pair within out of its bounds.");
            }
        }

        public void InjectCenters(Pair<int> centers) => _centers = centers;

        public void InjectCenters(int center, char pos_item)
        {
            switch (pos_item)
            {
                case '1':
                    _centers = new Pair<int>(center, _centers.Param2);
                    break;
                case '2':
                    _centers = new Pair<int>(_centers.Param1, center);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pos_item), "Can't change item in pair within out of its bounds.");
            }
        }

        /// <summary>
        /// Method which inserts the value in specified position of matrix
        /// </summary>
        /// <param name="rpos">
        /// A signed 32-bit integer value which represents the number of row in which number would be set
        /// </param>
        /// <param name="tpos">
        /// A signed 32-bit integer value which represents the number of column in which number would be set
        /// </param>
        /// <param name="value">
        /// A signed 32-bit integer value which represents the value which must be inserted in the matrix
        /// </param>
        public void Inject(int rpos, int tpos, int value)
                               => _matrix.SetValue(value, rpos, tpos);


        public void Redefine(int[,] matrix)
                       => _matrix = matrix;

        public void Redefine(int[] row, int[] indices)
                     => _matrix.SetValue(row, indices);

        public void Enswap()
        {
            _corners.Swap();
            _centers.Swap();
        }

        public static Transdefs NOTHINGNESS { get; } = new Transdefs(new Pair<int>(0, 0),
                                                                     new Pair<int>(0, 0),
                                                                     new int[,]
                                            {
                                                { 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 0, 0 }
                                            });

        public static Transdefs SINGULARITY { get; } = new Transdefs(new Pair<int>(1, 1),
                                                                     new Pair<int>(1, 1),
                                                                     new int[,]
                                            {
                                                { 1, 1, 1, 1, 1 },
                                                { 1, 1, 1, 1, 1 },
                                                { 1, 1, 1, 1, 1 },
                                                { 1, 1, 1, 1, 1 },
                                                { 1, 1, 1, 1, 1 }
                                            });

        /// <summary>
        /// Method which inserts block inside the matrix of the current instance by specified positions
        /// </summary>
        /// <param name="row">
        /// A signed 32-bit integer value which represents the starting row inside the matrix of instance
        /// </param>
        /// <param name="col">
        /// A signed 32-bit integer value which represents the starting column inside the matrix of instance
        /// </param>
        /// <param name="matrix_rect">
        /// An array of signed 32-bit integer values which represents inserting block
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when given matrix block is in incorrect form of origin matrix of the current instance
        /// </exception>
#pragma warning disable S2368
        public void Renowate(int row, int col, int[,] matrix_rect)
#pragma warning restore S2368
        {
            int bsize = matrix_rect.GetLength(0);

            int nrows = _matrix.GetLength(0);
            int ncols = _matrix.GetLength(1);

            if (row < 0 || row + bsize > nrows || col < 0 || col + bsize > ncols)
                throw new ArgumentException("Invalid block coordinates");

            for (int i = 0; i < bsize; i++)
                for (int j = 0; j < bsize; j++)
                    _matrix[row + i, col + j] = matrix_rect[i, j];
        }

        /// <summary>
        /// An operator cast for logical operation of XOR
        /// </summary>
        /// <param name="origin">
        /// An instance of <see cref="Transdefs"/> to which operation would be applied
        /// </param>
        /// <param name="another">
        /// An instance of <see cref="Transdefs"/> which would be applied in current operation cast
        /// </param>
        /// <returns>
        /// An instance of new <see cref="Transdefs"/> which represents transdef after operator cast operation
        /// </returns>
        public static Transdefs operator ^(Transdefs origin, Transdefs another)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    origin.Inject(i, j, origin[i, j] ^ another[i, j]);

            return origin;
        }

        /// <summary>
        /// An operator cast for logical operation of AND
        /// </summary>
        /// <param name="origin">
        /// An instance of <see cref="Transdefs"/> to which operation would be applied
        /// </param>
        /// <param name="another">
        /// An instance of <see cref="Transdefs"/> which would be applied in current operation cast
        /// </param>
        /// <returns>
        /// An instance of new <see cref="Transdefs"/> which represents transdef after operator cast operation
        /// </returns>
        public static Transdefs operator &(Transdefs origin, Transdefs another)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    origin.Inject(i, j, origin[i, j] & another[i, j]);

            return origin;
        }

        /// <summary>
        /// An operator cast for logical operation of OR
        /// </summary>
        /// <param name="origin">
        /// An instance of <see cref="Transdefs"/> to which operation would be applied
        /// </param>
        /// <param name="another">
        /// An instance of <see cref="Transdefs"/> which would be applied in current operation cast
        /// </param>
        /// <returns>
        /// An instance of new <see cref="Transdefs"/> which represents transdef after operator cast operation
        /// </returns>
        public static Transdefs operator |(Transdefs origin, Transdefs another)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    origin.Inject(i, j, origin[i, j] | another[i, j]);

            return origin;
        }

        /// <summary>
        /// Method which transponates origin of transdefinied matrix represented by an <see cref="Array"/> of signed 32-bit integer values
        /// </summary>
        public void Transponate()
        {
            int[,] matrix = new int[5, 5];

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    matrix[j, i] = _matrix[i, j];

            Redefine(matrix);
        }

        /// <summary>
        /// Index accessor for get-set pair of functions for this instance        
        /// </summary>
        /// <param name="i">
        /// A signed 32-bit integer value which represents number of matrixes row
        /// </param>
        /// <param name="j">
        /// A signed 32-bit integer value which represents number of matrixes column
        /// </param>
        /// <returns>
        /// A signed 32-bit integer value which represents an element in specified coords of matrix
        /// </returns>
        public int this[int i,
                        int j]
        {
            get => _matrix[i, j];
            set => _matrix[i, j]= value;
        }
    }
}
