﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Luciol.Plugin.Context
{
    /// <summary>
    /// Triangle that display interaction between the SNP
    /// </summary>
    /// <typeparam name="TIn">Data taken in input</typeparam>
    public interface IMainTriangle<TIn>
    {
        public void LoadData(string infoPath, string layersPath,
            IReadOnlyCollection<SNPData<TIn>> diagonal,
            Func<string, TIn[]> loader);

        /// <summary>
        /// Get data about a snip
        /// For a point in the diagonal, a SNP is the vertical line followed by the horizontal line
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="layer"></param>
        /// <exception cref="ArgumentOutOfRangeException">Layer must be between 0 (inclusive) and max layer (exclusive)</exception>
        public Task<SNPData<TIn>[]> GetSNPDataAsync(int pos, int layer);

        public Task<TIn> GetValueAsync(int layer, int x, int y);
        public Task<TIn> GetValueAsync(Annotation a);

        /// <summary>
        /// Get all values on the diagonal
        /// </summary>
        public IReadOnlyCollection<SNPData<TIn>> GetDiagonal();
        /// <summary>
        /// Check if the given position is in the triangle
        /// </summary>
        /// <param name="posX">X position to check</param>
        /// <param name="posY">Y position to check</param>
        /// <param name="layer">Layer to check</param>
        /// <returns>true if in the triangle, false otherwise</returns>
        public bool IsPositionValid(int posX, int posY, int layer);

        /// <summary>
        /// Called before data are load
        /// This happens when the user move the triangle view
        /// </summary>
        public event EventHandler<EventArgs> OnDataLoading;
        /// <summary>
        /// Called after data are loaded
        /// </summary>
        public event EventHandler<EventArgs> OnDataLoaded;
        /// <summary>
        /// Called right after the resource manager clean removed old data
        /// </summary>
        /// <remarks>This is not called from the main thread</remarks>
        public event EventHandler<EventArgs> OnDataCleaned;
    }
}
