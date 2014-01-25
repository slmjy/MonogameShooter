using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonogameShooter.Engine
{
    public class MyEngine
    {
        List<Player> _player;
        public Player _currentPlayer;

        public MyEngine(Player Player)
        {
            _player = new List<Player>();
            _player.Add(Player);
            _currentPlayer = Player;
        }

        public bool AddPlayer(Player Player)
        {
            try
            {
                this._player.Add(Player);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Args Update()
        {


            return new Args();
        }

    }
}
