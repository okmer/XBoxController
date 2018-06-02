using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Okmer.GameController.Helpers;

namespace SteintjeControllerFun.Models
{
    public abstract class MoveModel : NotifyPropertyChanged
    {
        private double value = 0.0f;
        public virtual double Value
        {
            get => value;
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    OnPropertyChanged();
                }
            }
        }

        private double offsetX = 0.0f;
        public double OffsetX
        {
            get => offsetX;
            protected set
            {
                if (offsetX != value)
                {
                    offsetX = value;
                    OnPropertyChanged();
                }
            }
        }

        private double offsetY = 0.0f;
        public double OffsetY
        {
            get => offsetY;
            protected set
            {
                if (offsetY != value)
                {
                    offsetY = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
