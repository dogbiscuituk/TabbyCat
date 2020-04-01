namespace TabbyCat.Common.Types
{
    using OpenTK;

    public static class Entity
    {
        #region Public Methods

        /// <summary>
        /// Get the coordinates of all points in a regular 3D xyz lattice, where -1 <= x,y,z <= +1.
        /// Points are returned ordered by x value, then by y value, and finally by z value.
        /// In other words, x varies most slowly, and z most quickly.
        /// To get the points on a regular 2D grid, set the missing axis strip count to 0.
        /// To get the points along a single axis, set both missing axes' strip counts to 0.
        /// </summary>
        /// <param name="stripCount">The number of steps along each axis.</param>
        /// <returns>
        /// 3(cx+1)(cy+1)(cz+1) floats, being the xyz coordinates of the points in the lattice.
        /// </returns>
        public static float[] GetCoordinates(Vector3 stripCount) =>
            GetCoordinates((int)stripCount.X, (int)stripCount.Y, (int)stripCount.Z);

        /// <summary>
        /// Get the coordinates of all points in a regular 3D xyz lattice, where -1 <= x,y,z <= +1.
        /// Points are returned ordered by x value, then by y value, and finally by z value.
        /// In other words, x varies most slowly, and z most quickly.
        /// To get the points on a regular 2D grid, set the missing axis strip count to 0.
        /// For example, GetVertexCoords(8, 8, 0) returns the 81 vertices of an 8x8, xy chessboard.
        /// To get the points along a single axis, set both missing axes' strip counts to 0.
        /// For example, GetVertexCoords(8, 0, 0) returns 9 points evenly spaced along the x axis.
        /// </summary>
        /// <param name="cx">The number of steps along the x axis.</param>
        /// <param name="cy">The number of steps along the y axis.</param>
        /// <param name="cz">The number of steps along the z axis.</param>
        /// <returns>
        /// 3(cx+1)(cy+1)(cz+1) floats, being the xyz coordinates of the points in the lattice.
        /// </returns>
        public static float[] GetCoordinates(int cx = 0, int cy = 0, int cz = 0)
        {
            var result = new float[3 * (cx + 1) * (cy + 1) * (cz + 1)];
            var p = 0;
            for (var i = 0; i <= cx; i++)
            {
                var x = cx == 0 ? 0 : 2f * i / cx - 1;
                for (int j = 0; j <= cy; j++)
                {
                    var y = cy == 0 ? 0 : 2f * j / cy - 1;
                    for (int k = 0; k <= cz; k++)
                    {
                        var z = cz == 0 ? 0 : 2f * k / cz - 1;
                        result[p++] = x;
                        result[p++] = y;
                        result[p++] = z;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Get the order of vertices required to draw a single continuous triangle strip covering
        /// the grid. This method uses the vertex return order implemented by GetVertexCoords, and
        /// the output is a sequence of alternately ascending and descending strips. For the 6x3
        /// example below (cx=5, cy=2), the 26-element returned sequence is:
        /// 
        ///     00 - 03-01-04-02-05 - 08-04-07-03-06
        ///        - 09-07-10-08-11 - 14-10-03-09-12
        ///        - 15-13-16-14-17
        ///        
        /// To see this, play Snakes & Ladders. Start in the bottom left corner 00, and climb first
        /// up the ladder 03-01-04-02-05, then down the snake 08-04-07-03-06. Now climb back up the
        /// ladder 09-07-10-08-11, and down 14-10-13-09-12. Lastly climb 15-13-16-14-17 and declare
        /// victory. The result describes a single triangle strip, covering the entire grid, though
        /// with degenerate or "null" triangles at 02-05-08, 03-06-09, 08-11-14, and 09-12-15. This
        /// pattern has cx-2 such triangles, so a 1001x1001 grid (cx=cy=1000) will have more than 2
        /// million triangles, less than a thousand of which are degenerate. Hence, any performance
        /// improvement from further grid optimization will be limited to less than 0.05%.
        /// 
        ///    y
        ///     |
        ///    2|   02--05--08--11--14--17
        ///     |     \    /  \    /  \
        ///     |      \  /    \  /    \
        ///    1|   01--04--07--10--13--16
        ///     |     \    /  \    /  \
        ///     |      \  /    \  /    \
        ///    0|   00--03--06--09--12--15
        ///    
        ///         0---1---2---3---4---5--- x
        /// 
        /// </summary>
        /// <param name="cx">The number of steps along the first axis.</param>
        /// <param name="cy">The number of steps along the second axis.</param>
        /// <returns>
        /// A total of 1+cx*(1+cy*2) ints ranging from 0 to 3(cx+1)(cy+1)-1 inclusive, which are the
        /// required vertex indices.
        /// </returns>
        public static int[] GetFill(int cx = 0, int cy = 0)
        {
            var result = new int[cx * (2 * cy + 1) + 1];
            int p = 0, q = 0;
            var even = true;
            result[p++] = 0;
            for (var i = 0; i < cx; i++)
            {
                for (var j = 0; j < cy; j++)
                {
                    result[p++] = q + cy + 1;
                    result[p++] = even ? ++q : --q;
                }
                result[p++] = q += cy + 1;
                even = !even;
            }
            return result;
        }

        public static int[] GetIndices(Pattern pattern, Vector3 stripCount) =>
            GetIndices(pattern, (int)stripCount.X, (int)stripCount.Y, (int)stripCount.Z);

        public static int[] GetIndices(Pattern pattern, int cx = 0, int cy = 0, int cz = 0)
        {
            switch (pattern)
            {
                case Pattern.Fill:
                    return GetFill(cx, cy);
                case Pattern.Points:
                    return GetPoints(cx, cy, cz);
                case Pattern.Rectangles:
                    return GetRectangles(cx, cy, cz);
                case Pattern.Saltires:
                    return GetSaltires(cx, cy);
                case Pattern.Triangles:
                    return GetTriangles(cx, cy);
            }
            return new int[1] { 0 };
        }

        public static int[] GetPoints(int cx = 0, int cy = 0, int cz = 0)
        {
            var n = (cx + 1) * (cy + 1) * (cz + 1);
            var result = new int[n];
            for (var p = 0; p < n; p++)
                result[p] = p;
            return result;
        }

        public static int[] GetRectangles(int cx = 0, int cy = 0, int cz = 0)
        {
            var result = new int[2 * (3 * cx * cy * cz + 2 * (cx * cy + cx * cz + cy * cz) + cx + cy + cz)];
            int p = 0, q = 0;
            for (var x = 0; x <= cx; x++)
                for (var y = 0; y <= cy; y++)
                    for (var z = 0; z <= cz; z++)
                    {
                        if (x < cx)
                        {
                            result[p++] = q;
                            result[p++] = q + (cy + 1) * (cz + 1);
                        }
                        if (y < cy)
                        {
                            result[p++] = q;
                            result[p++] = q + cz + 1;
                        }
                        if (z < cz)
                        {
                            result[p++] = q;
                            result[p++] = q + 1;
                        }
                        q++;
                    }
            return result;
        }

        public static int[] GetSaltires(int cx = 0, int cy = 0)
        {
            var result = new int[8 * cx * cy + 2 * (cx + cy)];
            for (int i = 0, p = 0, q = 0; i <= cx; i++)
                for (var j = 0; j <= cy; j++)
                {
                    if (j < cy)
                    {
                        result[p++] = q;
                        result[p++] = q + 1;
                    }
                    if (i < cx)
                    {
                        result[p++] = q;
                        result[p++] = q + cy + 1;
                        if (j < cy)
                        {
                            result[p++] = q;
                            result[p++] = q + cy + 2;
                            result[p++] = q + 1;
                            result[p++] = q + cy + 1;
                        }
                    }
                    q++;
                }
            return result;
        }

        public static int[] GetTriangles(int cx = 0, int cy = 0)
        {
            var result = new int[6 * cx * cy + 2 * (cx + cy)];
            for (int i = 0, p = 0, q = 0; i <= cx; i++)
                for (var j = 0; j <= cy; j++)
                {
                    if (j < cy)
                    {
                        result[p++] = q;
                        result[p++] = q + 1;
                    }
                    if (i < cx)
                    {
                        result[p++] = q;
                        result[p++] = q + cy + 1;
                        if (j < cy)
                        {
                            result[p++] = q + 1;
                            result[p++] = q + cy + 1;
                        }
                    }
                    q++;
                }
            return result;
        }

        #endregion

        #region

        private static void Sort(ref int x1, ref int x2)
        {
            if (x1 > x2)
            {
                var x = x1;
                x1 = x2;
                x2 = x;
            }
        }

        #endregion
    }
}
