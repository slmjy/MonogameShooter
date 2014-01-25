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

        public List<Weapon> weapons = new List<Weapon>();
        public Weapon currentWeapon;

        public Player(Weapon weapon, Texture2D Portrait, ContentManager cm, int HP = 100, int HPLeft = 100, int SP = 10, int SPLeft = 10, int Level = 1, string Name = "Player")
        {
            if (Portrait == null)
                Portrait = cm.Load<Texture2D>("portrait.jpg");

            if(weapons == null)
                    currentWeapon = new Weapon(cm.Load<Texture2D>("default_gun.jpg"), cm, 100, 20, "Gun");


            weapons.Add(currentWeapon);
            
            
           this.Portrait = Portrait;
           this.content = cm;
           this.HP = HP;
           this.HPLeft = HPLeft;
           this.SP = SP;
           this.SPLeft = SPLeft;
           this.Level = Level;
           this.Name = Name;

          

        }

      

    }
}
