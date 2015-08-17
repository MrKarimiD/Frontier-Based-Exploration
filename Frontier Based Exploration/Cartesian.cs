using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frontier_Based_Exploration
{
    class Cartesian
    {
        public int x; 
        public int y; 
        public bool check_parameter=false;

        #region Constructor
        
        public Cartesian(int in_x, int in_y)
        {
            x = in_x; y = in_y;
        }

        public Cartesian()
        {
            x = -100; y = -100;
        }

        #endregion

        #region Set
        public void set(int in_x, int in_y)
        {
            x = in_x; y = in_y;
        }

        public void set(Cartesian input)
        {
            x = input.x;
            y = input.y;
        }
        #endregion

        public void check()
        {
            this.check_parameter = true;
        }

        public double distanceCalculator(Cartesian input)
        {
            double sum = Math.Pow((this.x - input.x), 2) + Math.Pow((this.y - input.y), 2);
            return Math.Sqrt(sum);
        }
    
    }
}
