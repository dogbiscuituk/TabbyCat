namespace TabbyCat.Common.Types
{
    using OpenTK;
    using System.Collections.Generic;

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
        public static IEnumerable<float> GetCoordinates(Vector3 stripCount) =>
            GetCoordinates((int)stripCount.X, (int)stripCount.Y, (int)stripCount.Z);

        /// <summary>
        /// Calculate the number of floats which will be returned by a subsequent call to
        /// GetCoordinates, using a given number of steps along each axis (cx, cy, cz).
        /// </summary>
        /// <param name="stripCount">The number of steps along each axis.</param>
        /// <returns>3(cx+1)(cy+1)(cz+1)</returns>
        public static int GetCoordinatesCount(Vector3 stripCount) =>
            GetCoordinatesCount((int)stripCount.X, (int)stripCount.Y, (int)stripCount.Z);

        /// <summary>
        /// Get the order of vertices required to draw a given pattern covering the grid.
        /// This method uses the vertex return order implemented by GetVertexCoords.
        /// </summary>
        /// <param name="pattern">The type of pattern used to cover the grid.</param>
        /// <param name="stripCount">The number of steps along each axis.</param>
        /// <returns>A sequence of integers, being the index of each vertex in the
        /// visitation.</returns>
        public static IEnumerable<int> GetIndices(Pattern pattern, Vector3 stripCount) =>
            GetIndices(pattern, (int)stripCount.X, (int)stripCount.Y, (int)stripCount.Z);

        /// <summary>
        /// Calculate the number of indices which will be returned by a subsequent call to
        /// GetIndices, using a given number of steps along each axis (cx, cy, cz).
        /// </summary>
        /// <param name="pattern">The type of pattern used to cover the grid.</param>
        /// <param name="stripCount">The number of steps along each axis.</param>
        /// <returns>The total number of vertices in the visitation, including duplicates.</returns>
        public static int GetIndicesCount(Pattern pattern, Vector3 stripCount) =>
            GetIndicesCount(pattern, (int)stripCount.X, (int)stripCount.Y, (int)stripCount.Z);

        #endregion

        #region Private Methods

        private static IEnumerable<float> GetCoordinates(int cx, int cy, int cz)
        {
            for (var i = 0; i <= cx; i++)
            {
                var x = cx == 0 ? 0 : 2f * i / cx - 1;
                for (int j = 0; j <= cy; j++)
                {
                    var y = cy == 0 ? 0 : 2f * j / cy - 1;
                    for (int k = 0; k <= cz; k++)
                    {
                        var z = cz == 0 ? 0 : 2f * k / cz - 1;
                        yield return x;
                        yield return y;
                        yield return z;
                    }
                }
            }
            yield break;
        }

        private static int GetCoordinatesCount(int cx, int cy, int cz) =>
            3 * (cx + 1) * (cy + 1) * (cz + 1);

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
        ///         0---1---2---3---4---5-- x
        /// 
        /// </summary>
        /// <param name="cx">The number of steps along the first axis.</param>
        /// <param name="cy">The number of steps along the second axis.</param>
        /// <returns>
        /// A total of 1+cx*(1+cy*2) ints ranging from 0 to 3(cx+1)(cy+1)-1 inclusive, which are the
        /// required vertex indices.
        /// </returns>
        private static IEnumerable<int> GetFill(int cx, int cy)
        {
            yield return 0;
            int p = 0;
            var even = true;
            for (var i = 0; i < cx; i++)
            {
                for (var j = 0; j < cy; j++)
                {
                    yield return p + cy + 1;
                    yield return even ? ++p : --p;
                }
                yield return p += cy + 1;
                even = !even;
            }
            yield break;
        }

        private static int GetFillCount(int cx, int cy) =>
            (2 * cy + 1) * cx + 1;

        private static IEnumerable<int> GetIndices(Pattern pattern, int cx, int cy, int cz)
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
            return new int[1] { 0 }; // NB: This method is not an iterator.
        }

        private static int GetIndicesCount(Pattern pattern, int cx, int cy, int cz)
        {
            switch (pattern)
            {
                case Pattern.Fill:
                    return GetFillCount(cx, cy);
                case Pattern.Points:
                    return GetPointsCount(cx, cy, cz);
                case Pattern.Rectangles:
                    return GetRectanglesCount(cx, cy, cz);
                case Pattern.Saltires:
                    return GetSaltiresCount(cx, cy);
                case Pattern.Triangles:
                    return GetTrianglesCount(cx, cy);
            }
            return 1; // NB: This method is not an iterator.
        }

        private static IEnumerable<int> GetPoints(int cx, int cy, int cz)
        {
            var n = GetPointsCount(cx, cy, cz);
            for (var p = 0; p < n; p++)
                yield return p;
            yield break;
        }

        private static int GetPointsCount(int cx, int cy, int cz) =>
            (cx + 1) * (cy + 1) * (cz + 1);

        private static IEnumerable<int> GetRectangles(int cx, int cy, int cz)
        {
            int p = 0;
            for (var x = 0; x <= cx; x++)
                for (var y = 0; y <= cy; y++)
                    for (var z = 0; z <= cz; z++)
                    {
                        if (x < cx)
                        {
                            yield return p;
                            yield return p + (cy + 1) * (cz + 1);
                        }
                        if (y < cy)
                        {
                            yield return p;
                            yield return p + cz + 1;
                        }
                        if (z < cz)
                        {
                            yield return p;
                            yield return p + 1;
                        }
                        p++;
                    }
            yield break;
        }

        private static int GetRectanglesCount(int cx, int cy, int cz) =>
            2 * (3 * cx * cy * cz + 2 * (cx * cy + cx * cz + cy * cz) + cx + cy + cz);

        private static IEnumerable<int> GetSaltires(int cx, int cy)
        {
            for (int i = 0, p = 0; i <= cx; i++)
                for (var j = 0; j <= cy; j++)
                {
                    if (j < cy)
                    {
                        yield return p;
                        yield return p + 1;
                    }
                    if (i < cx)
                    {
                        yield return p;
                        yield return p + cy + 1;
                        if (j < cy)
                        {
                            yield return p;
                            yield return p + cy + 2;
                            yield return p + 1;
                            yield return p + cy + 1;
                        }
                    }
                    p++;
                }
            yield break;
        }

        private static int GetSaltiresCount(int cx, int cy) =>
            8 * cx * cy + 2 * (cx + cy);

        private static IEnumerable<int> GetTriangles(int cx, int cy)
        {
            for (int i = 0, p = 0; i <= cx; i++)
                for (var j = 0; j <= cy; j++)
                {
                    if (j < cy)
                    {
                        yield return p;
                        yield return p + 1;
                    }
                    if (i < cx)
                    {
                        yield return p;
                        yield return p + cy + 1;
                        if (j < cy)
                        {
                            yield return p + 1;
                            yield return p + cy + 1;
                        }
                    }
                    p++;
                }
            yield break;
        }

        private static int GetTrianglesCount(int cx, int cy) =>
            6 * cx * cy + 2 * (cx + cy);

        #endregion
    }
}
