using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure.Events
{
    public delegate void VEventHandler<TEventArgs>(TEventArgs e);
    public class CEventArgs<T1> : EventArgs
    {
        public T1 Para1 { get; set; }
        public CEventArgs(T1 para1)
        {
            this.Para1 = para1;
        }
    }
    public class CEventArgs<T1, T2> : EventArgs
    {
        public T1 Para1 { get; set; }
        public T2 Para2 { get; set; }
        public CEventArgs(T1 para1, T2 para2)
        {
            this.Para1 = para1;
            this.Para2 = para2;
        }
    }
    public class CEventArgs<T1, T2, T3> : EventArgs
    {
        public T1 Para1 { get; set; }
        public T2 Para2 { get; set; }
        public T3 Para3 { get; set; }
        public CEventArgs(T1 para1, T2 para2, T3 para3)
        {
            this.Para1 = para1;
            this.Para2 = para2;
            this.Para3 = para3;
        }
    }
    public class CEventArgs<T1, T2, T3, T4> : EventArgs
    {
        public T1 Para1 { get; set; }
        public T2 Para2 { get; set; }
        public T3 Para3 { get; set; }
        public T4 Para4 { get; set; }
        public CEventArgs(T1 para1, T2 para2, T3 para3, T4 para4)
        {
            this.Para1 = para1;
            this.Para2 = para2;
            this.Para3 = para3;
            this.Para4 = para4;
        }
    }
}
