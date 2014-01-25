using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace MonogameShooter.GameEngine
{
    public class Weapon
    {
        public int damage { get; set; }
        public int bullets { get; set; }
        public string WeaponName { get; set; }
        ContentManager content { get; set; }
        public Texture2D WeaponTexture { get; set; }

        public Weapon(Texture2D WeaponTexture, ContentManager cm, int damage = 100, int bullets = 20, string WeaponName = "Gun")
        {
            if (WeaponTexture == null)
                WeaponTexture = cm.Load<Texture2D>("default_gun.jpg");

            this.WeaponTexture = WeaponTexture;
            this.content = cm;
            this.damage = damage;
            this.bullets = bullets;
            this.WeaponName = WeaponName;
            

        }

    }
}
