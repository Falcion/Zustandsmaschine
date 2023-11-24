using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Zustand.Subflow
{
    public class Transdefs
    {
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

        private (string, string) _transdef = (string.Empty,
                                              string.Empty);
        private (uint, uint) _coords = (default,
                                        default);

        public Transdefs() { }

        public Transdefs(int[,] matrix)
                { MATRIX_COEF = matrix; }

        public Transdefs((string,
                          string) transdefinitions)
        {
            _transdef.Item1 = transdefinitions.Item1;
            _transdef.Item2 = transdefinitions.Item2;
        }

        public Transdefs((uint,
                          uint) coords)
        {
            _coords.Item1 = coords.Item1;
            _coords.Item2 = coords.Item2;
        }

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

        internal void Redefine(int[,] matrix)
                     => MATRIX_COEF = matrix;

        public int[,] Matrix => MATRIX_COEF;

        public void Redefine(int[] row, int[] indices)
                 => MATRIX_COEF.SetValue(row, indices);

        public void Inject(int rpos, int tpos, int value)
                           => MATRIX_COEF.SetValue(value, rpos, tpos);

        public (uint,
                uint) Coords => _coords;

        public void InjectCoords((uint, uint) coords)
                                  { _coords = coords; }

        public void InjectCoords(uint item_coord, char s)
        {
            if (s == '1')
                _coords.Item1 = item_coord;
            if (s == '2')
                _coords.Item2 = item_coord;

            throw new ArgumentException("Unknown operand time for procedure of injecting coords.");
        }

        public (string,
                string) Transdefinitions => _transdef;

        public void InjectTransdef((string, string) transdef)
                                      { _transdef = transdef; }

        public void InjectTransdef(string item_transdef, char s)
        {
            if (s == '1')
                _transdef.Item1 = item_transdef;
            if (s == '2')
                _transdef.Item2 = item_transdef;

            throw new ArgumentException("Unknown operand time for procedure of injecting transdefinitions.");
        }

        public void Enswap()
        {
            var coordsItem1 = _coords.Item1;
            _coords.Item1 = _coords.Item2;
            _coords.Item2 = coordsItem1;

            var transdefItem1 = _transdef.Item1;
            _transdef.Item1 = _transdef.Item2;
            _transdef.Item2 = transdefItem1;
        }

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

        public static Transdefs operator ^(Transdefs origin, Transdefs another)
        {
            for(int i = 0; i < 5; i++)
                for(int j = 0; j < 5; j++) 
                    origin.Inject(i, j, origin[i, j] ^ another[i, j]);

            return origin;
        }

        public static Transdefs operator &(Transdefs origin, Transdefs another)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    origin.Inject(i, j, origin[i, j] & another[i, j]);

            return origin;
        }

        public static Transdefs operator |(Transdefs origin, Transdefs another)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    origin.Inject(i, j, origin[i, j] | another[i, j]);

            return origin;
        }

        public void Transponate()
        {
            int[,] matrix = new int[5, 5];

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    matrix[j, i] = MATRIX_COEF[i, j];

            Redefine(matrix);
        }

        public int this[int i, 
                        int j]
        {
            get { return MATRIX_COEF[i, j]; }
        }
    }
}
