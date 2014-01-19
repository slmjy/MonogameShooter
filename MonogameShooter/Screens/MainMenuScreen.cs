#region File Description
//-----------------------------------------------------------------------------
// MainMenuScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using Microsoft.Xna.Framework;
using MonogameShooter.GameEngine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
#endregion

namespace MonogameShooter
{
    /// <summary>
    /// Экран главного меню - первая вещь отображаемая, когда игра запускается.
    /// </summary>
    class MainMenuScreen : MenuScreen
    {
        #region Initialization


        /// <summary> 
        ///  Конструктор заполняет контент меню.
        /// </summary>
        public MainMenuScreen()
            : base("Main Menu")
        {
            // Создает компоненты нашего меню.
            MenuEntry playGameMenuEntry = new MenuEntry("Play Game");
            MenuEntry testMenuEntry = new MenuEntry("3D Test");
            MenuEntry optionsMenuEntry = new MenuEntry("Options");
            MenuEntry exitMenuEntry = new MenuEntry("Exit");

            // Подключаем обработчики событий меню.
            playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
            testMenuEntry.Selected += testMenuEntrySelected;
            optionsMenuEntry.Selected += OptionsMenuEntrySelected;
            exitMenuEntry.Selected += OnCancel;

            // Добавляет компоненты в меню.
            MenuEntries.Add(playGameMenuEntry);
            MenuEntries.Add(testMenuEntry);
            MenuEntries.Add(optionsMenuEntry);
            MenuEntries.Add(exitMenuEntry);
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Событие обработчика, если выбран компонент меню Играть.
        /// </summary>
        void PlayGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex,
                               new GameplayScreen());
        }

        /// <summary>
        /// Событие обработчика, если выбран компонент меню 3D тест.
        /// <summary>
        void testMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            var player = new Player(null, new ContentManager(ScreenManager.Game.Services, "Content"),100,100,10,10,1,"TestPlayer");
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex, new HudScreen(ScreenManager,player));
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex, new Test3DScreen());
        }
        /// <summary>
        /// Событие обработчика, если выбран компонент меню Опции.
        /// </summary>
        void OptionsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new OptionsMenuScreen(), e.PlayerIndex);
        }


        /// <summary>
        /// Когда пользователь закрывает главное меню, спрашивает, хочет ли он выйти из приложения.
        /// </summary>
        protected override void OnCancel(PlayerIndex playerIndex)
        {
            const string message = "Вы точно хотите выйти из приложения?";

            MessageBoxScreen confirmExitMessageBox = new MessageBoxScreen(message);

            confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;

            ScreenManager.AddScreen(confirmExitMessageBox, playerIndex);
        }


        /// <summary>
        /// Событие обработчика, когда пользователь выбирает ОК в сообщении"Вы точно 
        /// хотите выйти из приложение?".
        /// </summary>
        void ConfirmExitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.Game.Exit();
        }


        #endregion

    }
}
