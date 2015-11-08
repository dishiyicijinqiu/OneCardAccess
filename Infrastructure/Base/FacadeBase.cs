using System;

namespace FengSharp.OneCardAccess.Infrastructure.Base
{
    public abstract class ActualBase<TActual>
    {
        public TActual Actual { get; set; }
        public ActualBase(TActual actual)
        {
            if (actual == null)
            {
                throw new ArgumentNullException("actual");
            }
            this.Actual = actual;
        }
    }
}
