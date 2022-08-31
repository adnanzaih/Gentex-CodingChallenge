using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gentex_CodingChallenge
{
    /// <summary>
    /// Basic class implementing the geometric equilateral triangle object. 
    /// Returns 2-dimensional area, perimeter, and centroid coordinates.
    /// Note: All sides are equivalent and the geometric center is equivalent to the centroid location.
    /// /// Args: string[] used to extract:
    /// center:list[] -> [x coordinate, y coordinate], sidelength -> non-zero value for one of the sides of the triangle
    /// </summary>
    public class EquilateralTri
    {
        // private variables
        private int _id;
        private float _x;
        private float _y;
        private float _sidelength;

        // private calculated fields
        private float _centroidX;
        private float _centroidY;
        private float _area;
        private float _perimeter;

        // public properties
        public int Id { get { return _id; } }
        public float X { get { return _x; } }
        public float Y { get { return _y; } }
        public float SideLength { get { return _sidelength; } }

        // public calculated properties
        public float CentroidX { get { return _centroidX; } }
        public float CentroidY { get { return _centroidY; } }
        public float Area { get { return _area; } }
        public float Perimeter { get { return _perimeter; } }

        // Constructor

        public EquilateralTri(string[] line)
        {
            _id = Convert.ToInt32(line[0]);

            int IdxX = Array.IndexOf(line, "CenterX"); // locate index of CenterX
            int IdxY = Array.IndexOf(line, "CenterY"); // locate index of CenterY
            int IdxS = Array.IndexOf(line, "SideLength"); // locate index of side length

            _x = Convert.ToSingle(line[IdxX + 1]); // offset by 1
            _y = Convert.ToSingle(line[IdxY + 1]);
            _sidelength = Convert.ToSingle(line[IdxS + 1]);

            CalculateProperties(_id, _x, _y, _sidelength);
            
        }
        public void CalculateProperties(int id, float x, float y, float sidelength)
        {
            // Calculations
            _id = id;
            _centroidX = x;
            _centroidY = y;
            _area = (float)Math.Sqrt(3) / 4 * _sidelength * _sidelength;
            _perimeter = (float)3 * _sidelength;
        }
    }
}
