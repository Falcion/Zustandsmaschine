using Zustand.Data.Types;
using Zustand.Data.Types.Interfaces;

namespace Zustand.Subflow
{
    /// <summary>
    /// A class which represents the transdefinitions between instances of the <see cref="Flow.Stateflow"/>
    /// </summary>
    public class Transdefs
    {
        /// <summary>
        /// An array of signed 32-bit integer values which represents the matrix of transdefinition
        /// </summary>
        private int[,] MATRIX_COEF = new int[5, 5]
        {
            /* 
             * Matrix logic-map for parameters (in HASH values):
             * [1,1] -> [2,3]: defining block for state value
             * [5,5] -> [3,4]: defining block for shift value
             * Unar-diagonal for matrix is defining the absolutist chaos of transdefinitions
             * [1,4] -> [2,5]: defining block for self-existence
             * Remaining blocks of "Г" forms are external blocks
             */
            
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        };

        /// <summary>
        /// An instance <see cref="Tuple{T1, T2}"/> which represents the pair of definitions
        /// </summary>
        private Pair<string> _transdef = new Pair<string>(string.Empty, 
                                                          string.Empty);
        /// <summary>
        /// An instance <see cref="Tuple{T1, T2}"/> which represents the pair of coordinates
        /// </summary>
        private Pair<UInt32> _coords = new Pair<UInt32>(default(uint),
                                                        default(uint));

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        public Transdefs() { }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="matrix">
        /// An array of signed 32-bit integer values which represents the matrix of transdefinition
        /// </param>
        public Transdefs(int[,] matrix)
        { 
            MATRIX_COEF = matrix;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="transdefinitions">
        /// An instance <see cref="Pair{T}"/> which represents the pair of definitions
        /// </param>
        public Transdefs(Pair<string> transdefinitions)
        {
            _transdef.Param1 = transdefinitions.Param1;
            _transdef.Param2 = transdefinitions.Param2;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="transdefinitions">
        /// An instance <see cref="Tuple{T1, T2}"/> which represents the pair of definitions
        /// </param>
        public Transdefs((string, 
                          string) transdefinitions)
        {
            _transdef.Param1 = transdefinitions.Item1;
            _transdef.Param2 = transdefinitions.Item2;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="coords">
        /// An instance <see cref="Tuple{T1, T2}"/> which represents the pair of coordinates
        /// </param>
        public Transdefs((uint,
                          uint) coords)
        {
            _coords.Param1 = coords.Item1;
            _coords.Param2 = coords.Item2;
        }

        /// <summary>
        /// Instance constructor for the class
        /// </summary>
        /// <param name="matrix">
        /// An array of signed 32-bit integer values which represents the matrix of transdefinition
        /// </param>
        /// <param name="coords">
        /// An instance <see cref="Tuple{T1, T2}"/> which represents the pair of coordinates
        /// </param>
        /// <param name="transdefinitions">
        /// An instance <see cref="Tuple{T1, T2}"/> which represents the pair of definitions
        /// </param>
        public Transdefs(int[,] matrix,
                         (uint,
                          uint) coords,
                         (string,
                          string) transdefinitions) : this(matrix)
        {
            _transdef.Item1 = transdefinitions.Item1;
            _transdef.Item2 = transdefinitions.Item2;
            _coords.Item1 = coords.Item1;
            _coords.Item2 = coords.Item2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix">
        /// An array of signed 32-bit integer values which represents the matrix of transdefinition
        /// </param>
        internal void Redefine(int[,] matrix)
                     => MATRIX_COEF = matrix;

        /// <summary>
        /// An array of signed 32-bit integer values which represents the matrix of transdefinition
        /// </summary>
        public int[,] Matrix => MATRIX_COEF;

        /// <summary>
        /// Method which add specified indices in a row
        /// </summary>
        /// <param name="row">
        /// A signed 32-bit integer value which represents the number of row in which number would be set
        /// </param>
        /// <param name="indices">
        /// An array of signed 32-bit integer values which must be added in the indices of given row of matrix 
        /// </param>
        public void Redefine(int[] row, int[] indices)
                 => MATRIX_COEF.SetValue(row, indices);

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
                           => MATRIX_COEF.SetValue(value, rpos, tpos);

        /// <summary>
        /// An instance <see cref="Tuple{T1, T2}"/> which represents the pair of coordinates
        /// </summary>
        public (uint,
                uint) Coords => _coords;

        /// <summary>
        /// Method which injects the coordinates value of indirect format
        /// </summary>
        /// <param name="coords">
        /// An instance <see cref="Tuple{T1, T2}"/> which represents the pair of coordinates
        /// </param>
        public void InjectCoords((uint, uint) coords)
                                  { _coords = coords; }

        /// <summary>
        /// Method which injects the coordinates value of specified format and position
        /// </summary>
        /// <param name="item_coord">
        /// An unsigned 32-bit integer value which represents an item which must be inserted in current instance's tuple
        /// </param>
        /// <param name="s">
        /// A char value which represents item between two in which value must be inserted
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when the specified mode char cast is not in range of coordinates tuple
        /// </exception>
        public void InjectCoords(uint item_coord, char s)
        {
            switch(s)
            {
                case '1':
                    _coords.Item1 = item_coord;
                    break;
                case '2':
                    _coords.Item2 = item_coord;
                    break;
                default:
                    throw new ArgumentException("Unknown operand time for procedure of injecting coords.");

            }
        }

        /// <summary>
        /// An instance <see cref="Tuple{T1, T2}"/> which represents the pair of definitions
        /// </summary>
        public (string,
                string) Transdefinitions => _transdef;

        /// <summary>
        /// Method which injects the transdefinitions value of indirect format
        /// </summary>
        /// <param name="transdef">
        /// An instance <see cref="Tuple{T1, T2}"/> which represents the pair of definitions
        /// </param>
        public void InjectTransdef((string, string) transdef)
                                      { _transdef = transdef; }

        /// <summary>
        /// Method which injects the transdefinitions value of specified format and position
        /// </summary>
        /// <param name="item_transdef">
        /// A string value which represents an item which must be inserted in current instance's tuple
        /// </param>
        /// <param name="s">
        /// A char value which represents item between two in which value must be inserted
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when the specified mode char cast is not in range of coordinates tuple
        /// </exception>
        public void InjectTransdef(string item_transdef, char s)
        {
            switch(s)
            {
                case '1':
                    _transdef.Item1 = item_transdef;
                    break;
                case '2':
                    _transdef.Item2 = item_transdef;
                    break;
                default:
                    throw new ArgumentException("Unknown operand time for procedure of injecting transdefinitions.");
            }    
        }

        /// <summary>
        /// Method which swaps the values both of definitions and coordinates between in the current instance
        /// </summary>
        public void Enswap()
        {
            (_coords.Item1, _coords.Item2) = (_coords.Item2, _coords.Item1);

            (_transdef.Item1, _transdef.Item2) = (_transdef.Item2, _transdef.Item1);
        }

        /// <summary>
        /// A static instance of the <see cref="Transdefs"/> which represents correspondive default combination
        /// </summary>
        public static Transdefs NOTHINGNESS { get; } = new(new int[,]
                    {
                        { 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0 }
                    },
                    (0, 0),
                    (string.Empty,
                     string.Empty));

        /// <summary>
        /// A static instance of the <see cref="Transdefs"/> which represents correspondive default combination
        /// </summary>
        public static Transdefs SINGULARITY { get; } = new(new int[,]
                    {
                        { 1, 1, 1, 1, 1 },
                        { 1, 1, 1, 1, 1 },
                        { 1, 1, 1, 1, 1 },
                        { 1, 1, 1, 1, 1 },
                        { 1, 1, 1, 1, 1 }
                    },
                    (1, 1),
                    (string.Empty,
                     string.Empty));

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

            int nrows = MATRIX_COEF.GetLength(0);
            int ncols = MATRIX_COEF.GetLength(1);

            if (row < 0 || row + bsize > nrows || col < 0 || col + bsize > ncols)
                throw new ArgumentException("Invalid block coordinates");

            for (int i = 0; i < bsize; i++)
                for (int j = 0; j < bsize; j++)
                    MATRIX_COEF[row + i, col + j] = matrix_rect[i, j];
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
            for(int i = 0; i < 5; i++)
                for(int j = 0; j < 5; j++) 
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
        /// 
        /// </summary>
        public void Transponate()
        {
            int[,] matrix = new int[5, 5];

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    matrix[j, i] = MATRIX_COEF[i, j];

            Redefine(matrix);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int this[int i, 
                        int j]
        {
            get { return MATRIX_COEF[i, j]; }
        }
    }
}
