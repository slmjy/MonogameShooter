using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonogameShooter.Engine;
using Microsoft.Xna.Framework.Graphics;
using OpenTK;

namespace MonogameShooter.Engine
{
    public class Player:_3dObject
    {
        public Vector3 ViewPoint;
        public Vector3 ViewTarget;

        public Player(int X, int Y, int Z, Vector3 ViewTarget)
            :base(X,Y,Z,null)
        {
            ViewPoint = new Vector3();
            ViewPoint.X = X;
            ViewPoint.Y = Y;
            ViewPoint.Z = Z + 10;
            this.ViewTarget = ViewTarget;
        } 
    }
}
