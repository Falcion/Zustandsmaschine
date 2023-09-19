using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zustand.Attributes.Flow;
using Zustand.Exceptions.Flow;
using Zustand.Flow.Subjects;

namespace Zustand.Flow
{
    /// <summary>
    /// 
    /// </summary>
    public class Stateflow
    {
        /// <summary>
        /// 
        /// </summary>
        private States? _state;
        /// <summary>
        /// 
        /// </summary>
        private Shifts? _shift;

        /// <summary>
        /// 
        /// </summary>
        private Stateflow? _inner = null;

        /// <summary>
        /// 
        /// </summary>
        private int _entropy = 1;

        /// <summary>
        /// 
        /// </summary>
        private int? _id = 0;

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public Stateflow() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public Stateflow(States state)
        {
            _state = state;

            CalculateId();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shift"></param>
        public Stateflow(Shifts shift)
        {
            _shift = shift;

            CalculateId();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="inner"></param>
        public Stateflow(States state, Stateflow inner)
        {
            _state = state;
            _inner = inner;

            CalculateId();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shift"></param>
        /// <param name="inner"></param>
        public Stateflow(Shifts shift, Stateflow inner)
        {
            _shift = shift;
            _inner = inner;

            CalculateId();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inner"></param>
        public Stateflow(Stateflow inner)
        {
            _inner = inner;

            _state = inner.State;
            _shift = inner.Shift;

            CalculateId();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inner"></param>
        /// <param name="state"></param>
        /// <param name="shift"></param>
        public Stateflow(Stateflow? inner, States? state, Shifts? shift)
        {
            if (state == null)
            {
                if (shift == null)
                {
                    _inner = inner;

                    if (_inner == null)
                        throw new StateflowNullException(this, "Can't call constructor with custom parameters and use all of them as nullable.");
                    else
                    {
                        _state = _inner.State;
                        _shift = _inner.Shift;

                        _entropy = _inner.Entropy;
                    }
                }
                else
                {
                    _shift = shift;
                    _inner = inner;
                }
            }
            else
            {
                _state = state;
                _shift = shift;
                _inner = inner;
            }

            CalculateId();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="shift"></param>
        public Stateflow(States state, Shifts shift)
        {
            _state = state;
            _shift = shift;

            CalculateId();
        }
        #endregion
        #region Constructors (with entropy)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="entropy"></param>
        public Stateflow(States state, int entropy) : this(state)
        { _entropy = entropy; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shift"></param>
        /// <param name="entropy"></param>
        public Stateflow(Shifts shift, int entropy) : this(shift)
        { _entropy = entropy; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="inner"></param>
        /// <param name="entropy"></param>
        public Stateflow(States state, Stateflow inner, int entropy) : this(state, inner)
        { _entropy = entropy; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shift"></param>
        /// <param name="inner"></param>
        /// <param name="entropy"></param>
        public Stateflow(Shifts shift, Stateflow inner, int entropy) : this(shift, inner)
        { _entropy = entropy; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inner"></param>
        /// <param name="entropy"></param>
        public Stateflow(Stateflow inner, int entropy) : this(inner)
        { _entropy = entropy; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inner"></param>
        /// <param name="state"></param>
        /// <param name="shift"></param>
        /// <param name="entropy"></param>
        public Stateflow(Stateflow? inner, States? state, Shifts? shift, int entropy) : this(inner, state, shift)
        { _entropy = entropy; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="shift"></param>
        /// <param name="entropy"></param>
        public Stateflow(States state, Shifts shift, int entropy) : this(state, shift)
        { _entropy = entropy; }
        #endregion

        #region Update methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public void Redirect(States state)
        {
            _state = state;

            CalculateEntropy();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shift"></param>
        public void Redirect(Shifts shift)
        {
            _shift = shift;

            CalculateEntropy();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inner"></param>
        public void Redirect(Stateflow inner)
        {
            _inner = inner;

            CalculateEntropy();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inner"></param>
        /// <param name="state"></param>
        /// <param name="shift"></param>
        public void Redirect(Stateflow? inner, States? state, Shifts? shift)
        {
            if (inner == null && state == null && shift == null)
                throw new StateflowNullException(this, "Can't redirect stateflow with null parameters, use nullify method for this.");

            _state = state;
            _shift = shift;
            _inner = inner;

            CalculateEntropy();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="shift"></param>
        public void Redirect(States state, Shifts shift)
        {
            _state = state;
            _shift = shift;

            CalculateEntropy();
        }
        #endregion

        #region Calculate methods
        /// <summary>
        /// 
        /// </summary>
        public void CalculateId()
        {
            int state_weights = _state?.Weight ?? 0,
                shift_weights = _shift?.Weight ?? 0,
                inner_entropy = _inner?.Entropy ?? 1;

            int weight_degree = new Random().Next(int.MinValue, int.MaxValue);

            double res_entropy = (state_weights + shift_weights) * inner_entropy * weight_degree;

            if (res_entropy > int.MaxValue)
                _id = (int)(res_entropy - int.MaxValue);
            else if (res_entropy < int.MinValue)
                _id = (int)(res_entropy + int.MaxValue);
            else
            {
                _id = (int)(res_entropy);

                _entropy = Convert.ToInt32(Math.Ceiling(res_entropy / 1E3));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void CalculateEntropy()
        {
            int state_weights = _state?.Weight ?? 0,
                shift_weights = _shift?.Weight ?? 0,
                inner_entropy = _inner?.Entropy ?? 1;

            int weight_degree = new Random().Next(int.MinValue, int.MaxValue);

            double res_entropy = (state_weights + shift_weights) * inner_entropy * weight_degree;

            _entropy = Convert.ToInt32(Math.Ceiling(res_entropy / 1E3));
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void Nullify()
        {
            _state = null;
            _shift = null;
            _inner = null;

            _entropy = 1;

            _id = null;
        }

        /// <summary>
        /// 
        /// </summary>
        public States? State => _state;
        /// <summary>
        /// 
        /// </summary>
        public Shifts? Shift => _shift;
        /// <summary>
        /// 
        /// </summary>
        public Stateflow? Inner => _inner;

        /// <summary>
        /// 
        /// </summary>
        public int Entropy => _entropy;

        /// <summary>
        /// 
        /// </summary>
        public int? Id => _id;
    }
}
