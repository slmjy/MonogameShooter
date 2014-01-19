using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace MonogameShooter.GameEngine
{


    class Player : GameScreen
    {

        public int HP = 100, HPLeft, SP = 100, Level = 1;
        public string Name;
        public Texture2D Portrait;
        ContentManager content;
        public PlayerIndex ? playerIndex;  
         

        public Player(Texture2D Portrait, ContentManager cm)
        {
           if(content == null)
            content = new ContentManager(ScreenManager.Game.Services, "Content");
            Portrait = content.Load<Texture2D>("portrait.jpg");
            
        }
    }
}
