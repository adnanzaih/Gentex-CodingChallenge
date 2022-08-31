using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gentex_CodingChallenge
{
    /// <summary>
    /// Basic polygon class. Assumes number of x and y coordinates are equal. Can be used to calculate the area 
    /// and perimeter of a basic polygon.
    /// Assumption: Estimating the area of a polygon using the shoelace formula. All coordinates are wellbehaved and given in clockwise order. There are not inner loops or voids in the polygon.
    /// Args: string[] line used to extract:
    /// center:list[] -> [x coordinate, y coordinate], verticies of the polygon.
    /// </summary>
    public class Polygon
    {
        // private variables
        private int _id;
        private float[] _x;
        private float[] _y;
        private List<Point> _xy;

        // private calculated fields
        private float _area;
        private float _perimeter;

        // public properties
        public int Id { get { return _id; } }
        public List<Point> XY { get { return _xy; } }
        
        // public calculated properties
        public float Area { get { return _area; } }
        public float Perimeter { get { return _perimeter; } }

        public Polygon(string[] line)
        {
            _id = Convert.ToInt32(line[0]);
            List<Point> XY = new List<Point>(); // instantiate

            int start = 2; // loop through data points and pair (X,Y) together
            for (int i = 3; i < line.Length-start; i+=4)
            {
                XY.Add(new Point
                {
                    X = Convert.ToSingle(line[i]),
                    Y = Convert.ToSingle(line[i+2])
                });
            }

            CalculateProperties(XY);

        }

        private void CalculateProperties(List<Point> xy)
        {
            /// Area Calculation
            _area = 0;
            int n = xy.Count;
            int k = n - 1;

            for (int i = 0; i < n; i++)
            {
                _area += (xy[k].X + xy[i].X)*(xy[k].Y - xy[i].Y);
                k = i;
            }
            _area /= 2;

            /// Perimeter Calculation
            _perimeter = 0;
            for (int i = 0; i < n - 1; i++)
            {
                _perimeter += (float)Math.Sqrt(Math.Pow((xy[i].X - xy[i + 1].X), 2) + Math.Pow((xy[i].Y - xy[i + 1].Y), 2));
            }
        }
    }
    public struct Point
    {
        public float X;
        public float Y;
    }
}
