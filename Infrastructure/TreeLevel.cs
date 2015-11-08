using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FengSharp.OneCardAccess.Infrastructure
{
    public class TreeLevel
    {
        public int PId { get; set; }
        private int level_deep;
        /// <summary>
        /// 树的深度
        /// </summary>
        public int Level_Deep
        {
            get { return level_deep; }
            set
            {

                if (level_deep != value)
                {
                    level_deep = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Level_Deep"));
                    }
                    if (level_deep < 0)
                        level_deep = 0;
                }
            }
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
