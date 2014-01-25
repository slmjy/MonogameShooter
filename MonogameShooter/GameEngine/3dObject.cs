using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameShooter.Engine
{
    abstract public class _3dObject
    {
        #region Arguments
        public int X;
        public int Y;
        public int Z;
        Model Model;
        #endregion

        public _3dObject(int X, int Y, int Z, Model Model)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            this.Model = Model;
        }
    }
}