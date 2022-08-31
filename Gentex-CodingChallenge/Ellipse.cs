using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gentex_CodingChallenge
{
    /// <summary>
    /// Basic class implementing the geometric ellipse object. Returns 2-dimensional area, perimeter, and centroid coordinates. 
    ///    Note: The two axis provided R1,R2 are assumed to be semi-major 
    ///    axes' lengths and not diameters from vertex to vertex. Therefore the area 
    ///    of the ellipse is given by A = pi* R1* R2.
    ///    Similar to circles, if the center of the ellipse is provided, then the geometric center of a 2D ellipse is equivalent to its centroid coordinates.
    /// Utilize Ramanujan’s approximation to calculate the circumference of an ellipse using its semi major and minor 
    ///    axes. Reference: https://arxiv.org/pdf/math/0506384.pdf (equation: 1.2)
    
    /// /// Args: string[] used to extract:
    /// center:list[] -> [x coordinate, y coordinate]
    /// R1, R2 float values representing the axes of the ellipse
    /// </summary>
    public class Ellipse
    {
        // private variables
        private int _id;
        private float _x;
        private float _y;
        private float _r1;
        private float _r2;

        // private calculated fields
        private float _centroidX;
        private float _centroidY;
        private float _area;
        private float _circumference;

        // public properties
        public int Id { get { return _id; } }
        public float X { get { return _x; } }
        public float Y { get { return _y; } }
        public float R1 { get { return _r1; } }
        public float R2 { get { return _r2; } }
        
        // public calculated properties
        public float CentroidX { get { return _centroidX; } }
        public float CentroidY { get { return _centroidY; } }
        public float Area { get { return _area; } }
        public float Circumference { get { return _circumference; } }

        // Constructor
        public Ellipse(string[] line)
        {
            _id = Convert.ToInt32(line[0]);

            int IdxX = Array.IndexOf(line, "CenterX"); // locate index of CenterX
            int IdxY = Array.IndexOf(line, "CenterY"); // locate index of CenterY
            int IdxR1 = Array.IndexOf(line, "R1"); // locate index of axes 1 
            int IdxR2 = Array.IndexOf(line, "R2"); // locate index of axes 2 

            _x = Convert.ToSingle(line[IdxX + 1]); // offset by 1
            _y = Convert.ToSingle(line[IdxY + 1]);
            _r1 = Convert.ToSingle(line[IdxR1 + 1]);
            _r2 = Convert.ToSingle(line[IdxR2 + 1]);

            CalculateProperties(_id, _x, _y, _r1, _r2);

        }

        private void CalculateProperties(int id, float x, float y, float r1, float r2)
        {
            float a = 0;
            float b = 0;

            // This is required for the circumference formula.
            if (r1 > r2)
            {
                 a = r1; // semi major
                 b = r2; // semi minor
            }
            else if (r1 < r2)
            {
                 a = r2; // semi major
                 b = r1; // semi minor
            }
            else
            {
                 a = r1;
                 b = r2;
            }
            _area = (float) 3.14 * r2 * r1;
            _circumference = (float)((float) 3.14 * ((a + b) + ((3 * (a - b)*(a-b)) / (10 * (a + b) + Math.Sqrt(a*a + 14 * a * b + b*b))))); // Ramanujan's Approximation.
            _centroidX = x;
            _centroidY = y;

        }
    }
}
