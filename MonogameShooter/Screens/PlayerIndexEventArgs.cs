#region File Description
//-----------------------------------------------------------------------------
// PlayerIndexEventArgs.cs
//
// XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using Microsoft.Xna.Framework;
#endregion

namespace MonogameShooter
{
    /// <summary>
    /// ѕользовательский аргумент событи€, которое включает в себ€ индекс игрока, инициировавшего событие. 
    /// Ёто используетс€ в случае MenuEntry.Selected
    /// </summary>
    class PlayerIndexEventArgs : EventArgs
    {
        /// <summary>
        ///  онструктор
        /// </summary>
        public PlayerIndexEventArgs(PlayerIndex playerIndex)
        {
            this.playerIndex = playerIndex;
        }


        /// <summary>
        /// ѕолучаем индекс игрока, инициировавшего событие.
        /// </summary>
        public PlayerIndex PlayerIndex
        {
            get { return playerIndex; }
        }

        PlayerIndex playerIndex;
    }
}
