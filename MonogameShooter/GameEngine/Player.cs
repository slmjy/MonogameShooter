using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace MonogameShooter.GameEngine
{


    class Player
    {

        public int HP = 100, HPLeft, SP = 100, SPLeft, Level = 1;
        public string Name;
        public Texture2D Portrait;
        ContentManager content;
        public PlayerIndex ? playerIndex;

         
      

        public Player(Texture2D Portrait, ContentManager cm, int HP, int HPLeft, int SP, int SPLeft, int Level, string Name)
        {
            if (Portrait == null)
                Portrait = cm.Load<Texture2D>("portrait.jpg");
            
        }

      

        //public Player(Texture2D HP_2, ContentManager SP_2, object HPLeft_2, object Lifes)
        //{
        //    // TODO: Complete member initialization
        //    this.HP_2 = HP_2;
        //    this.SP_2 = SP_2;
        //    this.HPLeft_2 = HPLeft_2;
        //    this.Lifes = Lifes;
        //}
    }
}
