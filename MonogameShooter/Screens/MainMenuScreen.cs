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
    /// ����� �������� ���� - ������ ���� ������������, ����� ���� �����������.
    /// </summary>
    class MainMenuScreen : MenuScreen
    {
        #region Initialization


        /// <summary> 
        ///  ����������� ��������� ������� ����.
        /// </summary>
        public MainMenuScreen()
            : base("Main Menu")
        {
            // ������� ���������� ������ ����.
            MenuEntry playGameMenuEntry = new MenuEntry("Play Game");
            MenuEntry testMenuEntry = new MenuEntry("3D Test");
            MenuEntry optionsMenuEntry = new MenuEntry("Options");
            MenuEntry exitMenuEntry = new MenuEntry("Exit");

            // ���������� ����������� ������� ����.
            playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
            testMenuEntry.Selected += testMenuEntrySelected;
            optionsMenuEntry.Selected += OptionsMenuEntrySelected;
            exitMenuEntry.Selected += OnCancel;

            // ��������� ���������� � ����.
            MenuEntries.Add(playGameMenuEntry);
            MenuEntries.Add(testMenuEntry);
            MenuEntries.Add(optionsMenuEntry);
            MenuEntries.Add(exitMenuEntry);
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// ������� �����������, ���� ������ ��������� ���� ������.
        /// </summary>
        void PlayGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex,
                               new GameplayScreen());
        }

        /// <summary>
        /// ������� �����������, ���� ������ ��������� ���� 3D ����.
        /// <summary>
        void testMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            var player = new Player(null, new ContentManager(ScreenManager.Game.Services, "Content"),100,100,10,10,1,"TestPlayer");
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex, new HudScreen(ScreenManager,player));
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex, new Test3DScreen());
        }
        /// <summary>
        /// ������� �����������, ���� ������ ��������� ���� �����.
        /// </summary>
        void OptionsMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new OptionsMenuScreen(), e.PlayerIndex);
        }


        /// <summary>
        /// ����� ������������ ��������� ������� ����, ����������, ����� �� �� ����� �� ����������.
        /// </summary>
        protected override void OnCancel(PlayerIndex playerIndex)
        {
            const string message = "�� ����� ������ ����� �� ����������?";

            MessageBoxScreen confirmExitMessageBox = new MessageBoxScreen(message);

            confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;

            ScreenManager.AddScreen(confirmExitMessageBox, playerIndex);
        }


        /// <summary>
        /// ������� �����������, ����� ������������ �������� �� � ���������"�� ����� 
        /// ������ ����� �� ����������?".
        /// </summary>
        void ConfirmExitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.Game.Exit();
        }


        #endregion

    }
}
