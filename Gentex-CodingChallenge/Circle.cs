using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gentex_CodingChallenge
{
    /// <summary>
    /// Basic class implementing the geometric circle object. Returns 2-dimensional area, perimeter, and centroid coordinates.
    /// Args: string[] line used to extract:
    /// center:list[] -> [x coordinate, y coordinate], radius -> non-zero value for the radius of the circle
    /// </summary>
    public class Circle
    {
        // private variables
        private int _id;
        private float _x;
        private float _y;
        private float _radius;

        // private calculated fields
        private float _centroidX;
        private float _centroidY;
        private float _area;
        private float _circumference;

        // public properties
        public int Id { get { return _id; } }
        public float X { get { return _x; } }
        public float Y { get { return _y; } }
        public float Radius { get { return _radius; } }

        // public calculated properties
        public float CentroidX { get { return _centroidX; } }
        public float CentroidY { get { return _centroidY; } }
        public float Area { get { return _area; } } 
        public float Circumference { get { return _circumference; } }


        // Constructor
        public Circle(string[] line)
        {
            _id = Convert.ToInt32(line[0]);


            int IdxX = Array.IndexOf(line, "CenterX"); // locate index of CenterX
            int IdxY = Array.IndexOf(line, "CenterY"); // locate index of CenterY
            int IdxR = Array.IndexOf(line, "Radius"); // locate index of Radius

            _x = Convert.ToSingle(line[IdxX + 1]); // offset by 1
            _y = Convert.ToSingle(line[IdxY + 1]);
            _radius = Convert.ToSingle(line[IdxR + 1]);

            CalculateProperties(_id, _x, _y, _radius);

        }

        public void CalculateProperties(int id, float x, float y, float radius)
        {
            // Calculations
            _id = id;
            _centroidX = x;
            _centroidY = y;
            _area = (float)(3.14 * radius * radius); // Area = pi*r^2
            _circumference = (float)(2 * 3.14 * radius); // C = 2*pi*r
        }

        

    }
}
