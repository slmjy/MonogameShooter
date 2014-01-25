#region File Description
//-----------------------------------------------------------------------------
// Test3D.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonogameShooter.Engine;
#endregion

namespace MonogameShooter
{
    /// <summary>
    /// Этот экран осуществляет реальную логику игры.
    /// Это лишь только заполнитель, чтобы достичь основной идеи.
    /// Вы наверняка захотите добавить интересных фич сюда. 
    /// </summary>
    class Test3DScreen : GameScreen
    {
        #region Fields

        MyEngine engine;

        ContentManager content;
        SpriteFont gameFont;
        
        Vector3 position = new Vector3(0, 0.01f, 0);
        Vector3 playerPosition = new Vector3(100, 100 ,100);
        Vector3 enemyPosition = new Vector3(100, 100, 100);

        //EffectParameter EFP; // = new EffectParameter();
       //DirectionalLight LIGHT = new DirectionalLight();


        private Matrix world =  Matrix.CreateTranslation(new Vector3(0, 0, 0));
        Vector3 cameraPosition= new Vector3(0, 0, 10);
        Vector3 cameraTarget= new Vector3(0, 0, 0);
        private Matrix view = Matrix.CreateLookAt(new Vector3(0, 10, 100), new Vector3(0, 10, 0), Vector3.UnitY);
        private Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 100f);

        Model model;

        Random random = new Random();

        float pauseAlpha;

        #endregion

        #region Initialization


        /// <summary>
        /// Конструктор.
        /// </summary>
        public Test3DScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
            engine = new MyEngine(new Player(0,0,0,new OpenTK.Vector3(10,10,10)));

        }


        /// <summary>
        /// Загружает графический контент игры
        /// </summary>
        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            gameFont = content.Load<SpriteFont>("Fonts/gamefont");

            model = content.Load<Model>("Models/Guns/GUN");

            // A real game would probably have more content than this sample, so
            // it would take longer to load. We simulate that by delaying for a
            // while, giving you a chance to admire the beautiful loading screen.
            Thread.Sleep(1000);

            // once the load has finished, we use ResetElapsedTime to tell the game's
            // timing mechanism that we have just finished a very long frame, and that
            // it should not try to catch up.
            ScreenManager.Game.ResetElapsedTime();
        }


        /// <summary>
        /// Перезагружает контент игры
        /// </summary>
        public override void UnloadContent()
        {
            content.Unload();
        }


        #endregion

        #region Update and Draw


        /// <summary>
        /// Обновляет состояние игры. Этот метод проверяет свойства GameScreen.IsActive
        /// поэтому игра остановит обновление, когда пауза в меню будет активна
        /// или когда вы не фокусируетесь на окне игры, а например свернули окно.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);
            view = Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.UnitY);
            /// Постепенное появление зависит от того, на что мы навели на экране Паузы
            //if (coveredByOtherScreen)
            //    pauseAlpha = Math.Min(pauseAlpha + 1f / 32, 1);
            //else
            //    pauseAlpha = Math.Max(pauseAlpha - 1f / 32, 0);

            //if (IsActive)
            //{
            //    ///Добавляет !!!рандомного!!! :) дрожания, чтобы противник двигался
            //    const float randomization = 10;

            //    enemyPosition.X += (float)(random.NextDouble() - 0.5) * randomization;
            //    enemyPosition.Y += (float)(random.NextDouble() - 0.5) * randomization


            //}


        }


        /// <summary>
        /// Добавим реакцию игры на действия пользователя. В отличии от метода Апдейт,
        /// этот метод будет вызван, когда экран Геймплей будет активным.
        /// </summary>
        public override void HandleInput(InputState input)
        {
            if (input == null)
                throw new ArgumentNullException("input");


            ///Проверка действий для действий пользователя
            int playerIndex = (int)ControllingPlayer.Value;

            KeyboardState keyboardState = input.CurrentKeyboardStates[playerIndex];
            GamePadState gamePadState = input.CurrentGamePadStates[playerIndex];

            //Игра будет в режиме паузы, если пользователь нажал на паузу, или если
            /// он отключил активный геймпад. Это требуется для того, чтобы мы следили
            /// когда геймпад включен, потому что мы не хотим ставить на паузу игру
            /// на ПК, если они играют на клаве и у них нету геймпада!!!!!!!!!!

            bool gamePadDisconnected = !gamePadState.IsConnected &&
                                       input.GamePadWasConnected[playerIndex];

            if (input.IsPauseGame(ControllingPlayer) || gamePadDisconnected)
            {
                ScreenManager.AddScreen(new PauseMenuScreen(), ControllingPlayer);
            }
            else if (keyboardState.IsKeyDown(Keys.Space))
            {
                 cameraPosition = new Vector3(0, 0, 10);
                 cameraTarget = new Vector3(0, 0, 0);
            }
            else
            {
                // Иначе передвигаем позицию игрока
                Vector2 movement = Vector2.Zero;

                if (keyboardState.IsKeyDown(Keys.Q))
                    engine._currentPlayer.ViewPoint.X++;

                if (keyboardState.IsKeyDown(Keys.A))
                    engine._currentPlayer.ViewPoint.X--;

                if (keyboardState.IsKeyDown(Keys.W))
                    engine._currentPlayer.ViewPoint.Y++;

                if (keyboardState.IsKeyDown(Keys.S))
                    engine._currentPlayer.ViewPoint.Y--;

                if (keyboardState.IsKeyDown(Keys.E))
                    engine._currentPlayer.ViewPoint.Z++;

                if (keyboardState.IsKeyDown(Keys.D))
                    engine._currentPlayer.ViewPoint.Z--;






                if (keyboardState.IsKeyDown(Keys.R))
                    engine._currentPlayer.ViewTarget.X++;


                if (keyboardState.IsKeyDown(Keys.F))
                    engine._currentPlayer.ViewTarget.X--;

                if (keyboardState.IsKeyDown(Keys.T))
                    engine._currentPlayer.ViewTarget.Y++;

                if (keyboardState.IsKeyDown(Keys.G))
                    engine._currentPlayer.ViewTarget.Y--;

                if (keyboardState.IsKeyDown(Keys.Y))
                    engine._currentPlayer.ViewTarget.Z++;

                if (keyboardState.IsKeyDown(Keys.H))
                    engine._currentPlayer.ViewTarget.Z--;

                Vector2 thumbstick = gamePadState.ThumbSticks.Left;

                movement.X += thumbstick.X;
                movement.Y -= thumbstick.Y;

                if (movement.Length() > 1)
                    movement.Normalize();

                //playerPosition += movement * 2;
            }
        }


        /// <summary>
        /// Отрисовка экрана
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            // Эта игра имеет синий фон. Почему? Потому что! (Примечание редакции)
            ScreenManager.GraphicsDevice.Clear(ClearOptions.Target,
                                               Color.Black, 0, 0);

            // Наш игрок и враг вместе всего лишь текстовые переменные
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();


            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;
                    effect.LightingEnabled = true; // turn on the lighting subsystem.
                    effect.DirectionalLight0.DiffuseColor = new Vector3(100, 100, 100); // a red light
                    effect.DirectionalLight0.Direction = new Vector3(0, 10, 100); // coming along the x-axis
                    effect.DirectionalLight0.SpecularColor = new Vector3(100, 100, 100); // with green highlights
                    effect.AmbientLightColor = new Vector3(0.2f, 0.2f, 0.2f);
                    effect.EmissiveColor = new Vector3(1, 1, 1);
                }

                mesh.Draw();
            }
            
          //  model.Draw(world, view, projection);



            spriteBatch.DrawString(gameFont, "X: " + cameraPosition.X.ToString() + " Y: " + cameraPosition.Y.ToString() + " Z: " + cameraPosition.Z.ToString(), new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(gameFont, "X: " + cameraTarget.X.ToString() + " Y: " + cameraTarget.Y.ToString() + " Z: " + cameraTarget.Z.ToString(), new Vector2(0, 30), Color.White);
            

            spriteBatch.End();


            /// Если игра включается или выключается, проявим ее из черного
            if (TransitionPosition > 0 || pauseAlpha > 0)
            {
                float alpha = MathHelper.Lerp(1f - TransitionAlpha, 1f, pauseAlpha / 2);

                ScreenManager.FadeBackBufferToBlack(alpha);
            }
        }


        #endregion
    }
}
