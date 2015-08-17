using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frontier_Based_Exploration
{
    class group
    {
        Cartesian[] points;
        int r=0;
        int numberOfPoints = 0;
        int defaultNumberOfPoints = 1000;
        Cartesian edge1, edge2;
        int n=0;
        
        #region Constuctor
        public group()
        {
            points = new Cartesian[defaultNumberOfPoints];
            for (int i = 0; i < defaultNumberOfPoints; i++)
            {
                points[i] = new Cartesian(-1,-1);
            }
            edge1 = new Cartesian(-1, -1);
            edge2 = new Cartesian(-1, -1);
        }

        public group(int input_r)
        {
            points = new Cartesian[defaultNumberOfPoints];
            for (int i = 0; i < defaultNumberOfPoints; i++)
            {
                points[i] = new Cartesian(-1, -1);
            }
            edge1 = new Cartesian(-1, -1);
            edge2 = new Cartesian(-1, -1);
            r = input_r;
        }
        #endregion

        #region setPoint
        public void setPoint(int i, int j)
        {
            points[numberOfPoints++].set(i, j);
        }

        public void setPoint(Cartesian input)
        {
            points[numberOfPoints].set(input);
            numberOfPoints++;
        }
        #endregion

        public Cartesian returnRandomPoint()
        {
            Random rnd = new Random();
            int n = rnd.Next(numberOfPoints);
            return points[n];
        }

        public void setEdges(Cartesian point)
        {
            if (n == 0)
            {
                edge1.set(point);
                n++;
            }
            else if (n == 1)
            {
                edge2.set(point);
            }
        }
        
    }
}
