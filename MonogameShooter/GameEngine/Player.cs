using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace MonogameShooter.GameEngine
{


    public class Player
    {

        public int HP { get; set; }
        public int HPLeft { get; set; }
        public int SP { get; set; }
        public int SPLeft { get; set; }
        public int Level { get; set; }
        public string Name  { get; set; }
        public Texture2D Portrait { get; set; }
        ContentManager content { get; set; }
        public PlayerIndex? playerIndex { get; set; }

         
      

        public Player(Texture2D Portrait, ContentManager cm, int HP = 100, int HPLeft = 100, int SP = 10, int SPLeft = 10, int Level = 1, string Name = "Player")
        {
            if (Portrait == null)
                Portrait = cm.Load<Texture2D>("portrait.jpg");

           this.Portrait = Portrait;
           this.content = cm;
           this.HP = HP;
           this.HPLeft = HPLeft;
           this.SP = SP;
           this.SPLeft = SPLeft;
           this.Level = Level;
           this.Name = Name;
            
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
