#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MonogameShooter.GameEngine;
#endregion

namespace MonogameShooter
{
    /// <summary>
    /// Показывает основную статистику игроков и меню боевых действий.
    /// </summary>
    class HudScreen
    {
        private ScreenManager screenManager;

        public const int HudHeight = 183;


        #region Графическая состовляющая

        private Texture2D backgroundHudTexture;
        private Texture2D topHudTexture;
        private Texture2D combatPopupTexture;
        private Texture2D activeCharInfoTexture;
        private Texture2D inActiveCharInfoTexture;
        private Texture2D cantUseCharInfoTexture;
        private Texture2D selectionBracketTexture;
        private Texture2D menuTexture;
        private Texture2D statsTexture;
        private Texture2D deadPortraitTexture;
        private Texture2D charSelFadeLeftTexture;
        private Texture2D charSelFadeRightTexture;
        private Texture2D charSelArrowLeftTexture;
        private Texture2D charSelArrowRightTexture;
        private Texture2D actionTexture;
        private Texture2D yButtonTexture;
        private Texture2D startButtonTexture;

        private Vector2 topHudPosition = new Vector2(353f, 30f);
        private Vector2 charSelLeftPosition = new Vector2(70f, 600f);
        private Vector2 charSelRightPosition = new Vector2(1170f, 600f);
        private Vector2 yButtonPosition = new Vector2(0f, 560f + 20f);
        private Vector2 startButtonPosition = new Vector2(0f, 560f + 35f);
        private Vector2 yTextPosition = new Vector2(0f, 560f + 70f);
        private Vector2 startTextPosition = new Vector2(0f, 560f + 70f);
        private Vector2 actionTextPosition = new Vector2(640f, 55f);
        private Vector2 backgroundHudPosition = new Vector2(0f, 525f);
        private Vector2 portraitPosition = new Vector2(640f, 55f);
        private Vector2 startingInfoPosition = new Vector2(0f, 550f);
        private Vector2 namePosition;
        private Vector2 levelPosition;
        private Vector2 detailPosition;

        private readonly Color activeNameColor = new Color(200, 200, 200);
        private readonly Color inActiveNameColor = new Color(100, 100, 100);
        private readonly Color nonSelColor = new Color(86, 26, 5);
        private readonly Color selColor = new Color(229, 206, 144);

        private SpriteFont HudFont;


        #endregion

        #region Текст действия


        /// <summary>
        /// Текст, показываемый в шкале действия вверху боевого экрана.
        /// </summary>
        private string actionText = String.Empty;

        public string ActionText
        {
            get { return actionText; }
            set { actionText = value; }
        }

        #endregion

        #region Запуск


        /// <summary>
        /// СОздаем новый ХУД объект используя ScreenManager
        /// </summary>
        public HudScreen(ScreenManager screenManager, Player player)
        {
            // проверяем параметр
            if (screenManager == null)
            {
                throw new ArgumentNullException("screenManager");
            }
            this.screenManager = screenManager;
        }



        /// <summary>
        /// Загружаем грфический контент из менеджера контента.
        /// </summary>
        public void LoadContent()
        {
            ContentManager content = screenManager.Game.Content;

            backgroundHudTexture =
                content.Load<Texture2D>(@"Textures\HUD\HudBkgd");
            topHudTexture =
                content.Load<Texture2D>(@"Textures\HUD\CombatStateInfoStrip");
            activeCharInfoTexture =
                content.Load<Texture2D>(@"Textures\HUD\PlankActive");
            inActiveCharInfoTexture =
                content.Load<Texture2D>(@"Textures\HUD\PlankInActive");
            cantUseCharInfoTexture =
                content.Load<Texture2D>(@"Textures\HUD\PlankCantUse");
            selectionBracketTexture =
                content.Load<Texture2D>(@"Textures\HUD\SelectionBrackets");
            deadPortraitTexture =
                content.Load<Texture2D>(@"Textures\Characters\Portraits\Tombstone");
            combatPopupTexture =
                content.Load<Texture2D>(@"Textures\HUD\CombatPopup");
            charSelFadeLeftTexture =
                content.Load<Texture2D>(@"Textures\Buttons\CharSelectFadeLeft");
            charSelFadeRightTexture =
                content.Load<Texture2D>(@"Textures\Buttons\CharSelectFadeRight");
            charSelArrowLeftTexture =
                content.Load<Texture2D>(@"Textures\Buttons\CharSelectHlLeft");
            charSelArrowRightTexture =
                content.Load<Texture2D>(@"Textures\Buttons\CharSelectHlRight");
            actionTexture =
                content.Load<Texture2D>(@"Textures\HUD\HudSelectButton");
            yButtonTexture =
                content.Load<Texture2D>(@"Textures\Buttons\YButton");
            startButtonTexture =
                content.Load<Texture2D>(@"Textures\Buttons\StartButton");
            menuTexture =
                content.Load<Texture2D>(@"Textures\HUD\Menu");
            statsTexture =
                content.Load<Texture2D>(@"Textures\HUD\Stats");

            HudFont = content.Load<SpriteFont>(@"Fonts\gamefont");
        }


        #endregion


        #region Прорисовка


        /// <summary>
        /// Вырисовываем экран
        /// </summary>
        public void Draw()
        {
            SpriteBatch spriteBatch = screenManager.SpriteBatch;

            spriteBatch.Begin();

            startingInfoPosition.X = 640f;

            spriteBatch.Draw(backgroundHudTexture, backgroundHudPosition, Color.White);
            //нужен боевой движок
            //if (CombatEngine.IsActive)
            //{
            //    DrawForCombat();
            //}
            //else
            //{
            //    DrawForNonCombat();
            //}

            spriteBatch.End();
        }


        /// <summary>
        /// Прорисовка ХУДа для боевого режима
        /// </summary>
        private void DrawForCombat()
        {
            SpriteBatch spriteBatch = screenManager.SpriteBatch;
            Vector2 position = startingInfoPosition;
// и тут
            //foreach (CombatantPlayer combatantPlayer in CombatEngine.Players)
            //{
            //    DrawCombatPlayerDetails(combatantPlayer, position);
            //    position.X += activeCharInfoTexture.Width - 6f;
            //}

            charSelLeftPosition.X = startingInfoPosition.X - 5f -
                charSelArrowLeftTexture.Width;
            charSelRightPosition.X = position.X + 5f;
            // Рисует стрелки выбора персонажа
            // и тут движок
            //if (CombatEngine.IsPlayersTurn)
            //{
            //    spriteBatch.Draw(charSelArrowLeftTexture, charSelLeftPosition,
            //        Color.White);
            //    spriteBatch.Draw(charSelArrowRightTexture, charSelRightPosition,
            //        Color.White);
            //}
            //else
            //{
            //    spriteBatch.Draw(charSelFadeLeftTexture, charSelLeftPosition,
            //        Color.White);
            //    spriteBatch.Draw(charSelFadeRightTexture, charSelRightPosition,
            //        Color.White);
            //}

            if (actionText.Length > 0)
            {
                spriteBatch.Draw(topHudTexture, topHudPosition, Color.White);
                // Русует текст действия
                //Fonts.DrawCenteredText(spriteBatch, Fonts.PlayerStatisticsFont,
                //    actionText, actionTextPosition, Color.Black);
                spriteBatch.DrawString(HudFont, actionText, actionTextPosition, Color.Black);
                //непонял откуда ошибка
            }
        }


        /// <summary>
        /// Рисуем ХУд для небоевого режима
        /// </summary>
        private void DrawForNonCombat()
        {
            SpriteBatch spriteBatch = screenManager.SpriteBatch;

            Vector2 position = startingInfoPosition;

            yTextPosition.X = position.X + 5f;
            yButtonPosition.X = position.X + 9f;

            // Ривуем кнопку ВЫбор
            spriteBatch.Draw(statsTexture, yTextPosition, Color.White);
            spriteBatch.Draw(yButtonTexture, yButtonPosition, Color.White);

            startTextPosition.X = startingInfoPosition.X -
                startButtonTexture.Width - 25f;
            startButtonPosition.X = startingInfoPosition.X -
                startButtonTexture.Width - 10f;

            // Рисуем кнопку Назад
            spriteBatch.Draw(menuTexture, startTextPosition, Color.White);
            spriteBatch.Draw(startButtonTexture, startButtonPosition, Color.White);
        }


        enum PlankState
        {
            Active,
            InActive,
            CantUse,
        }


        /// <summary>
        /// Рисуем детали о игроке
        /// </summary>
        /// <param name="playerIndex">Показатель детлей о игроке, которые нужно отрисовать</param>
        /// <param name="position">Место где прорисовать</param>
        private void DrawCombatPlayerDetails(Player player, Vector2 position)
        {
            SpriteBatch spriteBatch = screenManager.SpriteBatch;

            PlankState plankState = new PlankState();
            bool isPortraitActive = false;
            bool isCharDead = false;
            Color color;

            portraitPosition.X = position.X + 7f;
            portraitPosition.Y = position.Y + 7f;

            namePosition.X = position.X + 84f;
            namePosition.Y = position.Y + 12f;

            levelPosition.X = position.X + 84f;
            levelPosition.Y = position.Y + 39f;

            detailPosition.X = position.X + 25f;
            detailPosition.Y = position.Y + 66f;

            position.X -= 2;
            position.Y -= 4;

            //if (player.IsTurnTaken)
            //{
            //    plankState = PlankState.CantUse;

            //    isPortraitActive = false;
            //}
            //else
            //{
            //    plankState = PlankState.InActive;

            //    isPortraitActive = true;
            //}
            //движоок
            //if (((CombatEngine.HighlightedCombatant == player) && !player.IsTurnTaken) ||
            //   (CombatEngine.PrimaryTargetedCombatant == player) ||
            //  (CombatEngine.SecondaryTargetedCombatants.Contains(player)))
            // {
            // plankState = PlankState.Active;
            //}

            //if (player.IsDeadOrDying)
            //{
            //    isCharDead = true;
            //    isPortraitActive = false;
            //    plankState = PlankState.CantUse;
            //}

            // Рисует информационную плитку
            if (plankState == PlankState.Active)
            {
                color = activeNameColor;

                spriteBatch.Draw(activeCharInfoTexture, position, Color.White);

                // Рисует скобки
                // if ((CombatEngine.HighlightedCombatant == player) && !player.IsTurnTaken)
                // {
                //      spriteBatch.Draw(selectionBracketTexture, position, Color.White);
                //  }

                //if (isPortraitActive &&
                //    (CombatEngine.HighlightedCombatant == player) &&
                //    (CombatEngine.HighlightedCombatant.CombatAction == null) &&
                //    !CombatEngine.IsDelaying)
                //{
                //        position.X += activeCharInfoTexture.Width / 2;
                //        position.X -= combatPopupTexture.Width / 2;
                //        position.Y -= combatPopupTexture.Height;
                //        // Рисует действие
                //        DrawActionsMenu(position);
                //    }
                //}
                //else if (plankState == PlankState.InActive)
                //{
                //    color = inActiveNameColor;
                //    spriteBatch.Draw(inActiveCharInfoTexture, position, Color.White);
                //}
                //else
                //{
                //    color = Color.Black;
                //    spriteBatch.Draw(cantUseCharInfoTexture, position, Color.White);
                //}

                if (isCharDead)
                {
                    spriteBatch.Draw(deadPortraitTexture, portraitPosition, Color.White);
                }
                else
                {
                    // Рисует портрет игрока
                    DrawPortrait(player, portraitPosition, plankState);
                }

                // Рисует имя игрока
                spriteBatch.DrawString(HudFont,
                    player.Name,
                    namePosition, color);

                color = Color.Black;
                // РИсует детали о игроке
                spriteBatch.DrawString(HudFont,
                    "Lvl: " + player.Level,
                    levelPosition, color);

                spriteBatch.DrawString(HudFont,
                    "HP: " + player.HP +
                    "/" + player.HPLeft,
                    detailPosition, color);

                detailPosition.Y += 30f;
                spriteBatch.DrawString(HudFont,
                    "SP: " + player.SP +
                    "/" + player.SPLeft,
                    detailPosition, color);
            }
        }
        

        /// <summary>
        /// Рисует детали о ироке
        /// </summary>
        /// <param name="playerIndex">Показатель детлей о игроке, которые нужно отрисовать</param>
        /// <param name="position">Место где прорисовать</param>
        private void DrawNonCombatPlayerDetails(Player player, Vector2 position)
        {
            SpriteBatch spriteBatch = screenManager.SpriteBatch;

            PlankState plankState;
            bool isCharDead = false;
            Color color;

            portraitPosition.X = position.X + 7f;
            portraitPosition.Y = position.Y + 7f;

            namePosition.X = position.X + 84f;
            namePosition.Y = position.Y + 12f;

            levelPosition.X = position.X + 84f;
            levelPosition.Y = position.Y + 39f;

            detailPosition.X = position.X + 25f;
            detailPosition.Y = position.Y + 66f;

            position.X -= 2;
            position.Y -= 4;

            plankState = PlankState.Active;

            // Рисуем инф. плитку
            if (plankState == PlankState.Active)
            {
                color = activeNameColor;

                spriteBatch.Draw(activeCharInfoTexture, position, Color.White);
            }
            else if (plankState == PlankState.InActive)
            {
                color = inActiveNameColor;
                spriteBatch.Draw(inActiveCharInfoTexture, position, Color.White);
            }
            else
            {
                color = Color.Black;
                spriteBatch.Draw(cantUseCharInfoTexture, position, Color.White);
            }

            if (isCharDead)
            {
                spriteBatch.Draw(deadPortraitTexture, portraitPosition, Color.White);
            }
            else
            {
                // Рисуем портрет,
                DrawPortrait(player, portraitPosition, plankState);
            }

            // имя,
            spriteBatch.DrawString(HudFont,
                player.Name,
                namePosition, color);

            color = Color.Black;
            // и детали.
            spriteBatch.DrawString(HudFont,
                "Lvl: " + player.Level,
                levelPosition, color);

            spriteBatch.DrawString(HudFont,
                "HP: " + player.HP +
                "/" + player.HP,
                detailPosition, color);

            detailPosition.Y += 30f;
            spriteBatch.DrawString(HudFont,
                "MP: " + player.SP +
                "/" + player.SPLeft,
                detailPosition, color);
        }


        /// <summary>
        /// Рисем портрет данного игрока на данной позиции.
        /// </summary>
        private void DrawPortrait(Player player, Vector2 position,
            PlankState plankState)
        {
            switch (plankState)
            {
                case PlankState.Active:
                    screenManager.SpriteBatch.Draw(player.Portrait,
                        position, Color.White);
                    break;
                //case PlankState.InActive:
                //    screenManager.SpriteBatch.Draw(player.InactivePortraitTexture,
                //        position, Color.White);
                   // break;
                //case PlankState.CantUse:
                //    screenManager.SpriteBatch.Draw(player.UnselectablePortraitTexture,
                //        position, Color.White);
                //    break;
            }
        }


        #endregion


     #region Меню Боевых Действий (МБД)


        ///// <summary>
        ///// Список элементов в мбд
        ///// </summary>
        //private string[] actionList = new string[5]
        //    {
        //        "Стрелять",
        //        "Перезарядка",
        //        "Сменить оружие",
        //        "Параметр1",
        //        "Параметр2",
        //    };


        ///// <summary>
        ///// Выделенный сейчас предмет.
        ///// </summary>
        //private int highlightedAction = 0;


        /// <summary>
        /// Делаем выбор пользователя в меню действий
        /// </summary>
        //public void UpdateActionsMenu()
        //{
        //    // курсор вверх
        //    if (InputManager.IsActionTriggered(InputManager.Action.CursorUp))
        //    {
        //        if (highlightedAction > 0)
        //        {
        //            highlightedAction--;
        //        }
        //        return;
        //    }
        //    // курсор вниз
        //    if (InputManager.IsActionTriggered(InputManager.Action.CursorDown))
        //    {
        //        if (highlightedAction < actionList.Length - 1)
        //        {
        //            highlightedAction++;
        //        }
        //        return;
        //    }
        //    // выбор действияя
        //    if (InputManager.IsActionTriggered(InputManager.Action.Ok))
        //    {
        //        switch (actionList[highlightedAction])
        //        {
        //            case "Стрелять":
        //                {
        //                    ActionText = "Начинаем стрелять";
        //                    CombatEngine.HighlightedCombatant.CombatAction =
        //                        new RangedCombatAction(CombatEngine.HighlightedCombatant);
        //                    CombatEngine.HighlightedCombatant.CombatAction.Target =
        //                        CombatEngine.FirstEnemyTarget;
        //                }
        //                break;

                    //case "Перезарядка":
                    //    {
                           
                    //    }
                    //    break;

                    //case "Сменить оружие":
                    //    {
                           
                    //    }
                    //    break;

                    //case "Параметр1":
                    //    {
                           
                    //    }
                    //    break;

                    //case "Параметр2":
                    //    {

                    //    }
                    //    break;

        //        }
        //        return;
        //    }
        //}


        /// <summary>
        /// Рисуем меню боевых действий
        /// </summary>
        /// <param name="position">The position of the menu.</param>
        //private void DrawActionsMenu(Vector2 position)
        //{
        //    ActionText = "Выберите действие";

        //    SpriteBatch spriteBatch = screenManager.SpriteBatch;

        //    Vector2 arrowPosition;
        //    float height = 25f;

        //    spriteBatch.Draw(combatPopupTexture, position, Color.White);

        //    position.Y += 21f;
        //    arrowPosition = position;

        //    arrowPosition.X += 10f;
        //    arrowPosition.Y += 2f;
        //    arrowPosition.Y += height * (int)highlightedAction;
        //    spriteBatch.Draw(actionTexture, arrowPosition, Color.White);

        //    position.Y += 4f;
        //    position.X += 50f;

        //    // Рисуем текст действия
        //    for (int i = 0; i < actionList.Length; i++)
        //    {
        //        spriteBatch.DrawString(Fonts.GearInfoFont, actionList[i], position,
        //            i == highlightedAction ? selColor : nonSelColor);
        //        position.Y += height;
        //    }
        //}


        #endregion
    }
}