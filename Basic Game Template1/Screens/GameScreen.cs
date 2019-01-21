using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameSystemServices;

namespace Basic_Game_Template1
{
    public partial class GameScreen : UserControl
    {
        //player1 button control keys - DO NOT CHANGE
        Boolean downArrowDown, upArrowDown, bDown, nDown, mDown, spaceDown;

        //player2 button control keys - DO NOT CHANGE
        Boolean sDown, wDown, cDown, vDown, xDown, zDown;

        //TODO create your global game variables here
        int heroX, heroY, heroSize, heroSpeed;
        SolidBrush heroBrush = new SolidBrush(Color.Black);
        int wallX = 500;
        int tWallY = 00;
        int bWallY = 1;
        int wallWidth = 50;
        int wallHeight = 200;
        int wallSpeed = 1;
        Pen drawPen = new Pen(Color.Red);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        SolidBrush wallBrush = new SolidBrush(Color.Black);

        int startTimer = 0;
        List<Rectangle> wallRecList = new List<Rectangle>();


        public GameScreen()
        {
            InitializeComponent();
            InitializeGameValues();
        }

        public void InitializeGameValues()
        {
            //TODO - setup all your initial game values here. Use this method
            // each time you restart your game to reset all values.
            heroX = 50;
            heroY = 100;
            heroSize = 20;
            heroSpeed = 5;

            Rectangle R = new Rectangle(wallX, tWallY, wallWidth, wallHeight);
            wallRecList.Add(R);

            Rectangle R1 = new Rectangle(wallX, bWallY, wallWidth, wallHeight);
            wallRecList.Add(R1);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // opens a pause screen is escape is pressed. Depending on what is pressed
            // on pause screen the program will either continue or exit to main menu
            if (e.KeyCode == Keys.Escape && gameTimer.Enabled)
            {
                gameTimer.Enabled = false;
                upArrowDown = downArrowDown = false;

                DialogResult result = PauseForm.Show();

                if (result == DialogResult.Cancel)
                {
                    gameTimer.Enabled = true;
                }
                else if (result == DialogResult.Abort)
                {
                    MainForm.ChangeScreen(this, "MenuScreen");
                }
            }

            //TODO - basic player 1 key down bools set below. Add remainging key down
            // required for player 1 or player 2 here.

            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
                case Keys.M:
                    mDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //TODO - basic player 1 key up bools set below. Add remainging key up
            // required for player 1 or player 2 here.

            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
            }
        }

        /// <summary>
        /// This is the Game Engine and repeats on each interval of the timer. For example
        /// if the interval is set to 16 then it will run each 16ms or approx. 50 times
        /// per second
        /// </summary>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (downArrowDown == true)
            {
                heroY = heroY + heroSpeed;
            }
            if (upArrowDown == true)
            {
                heroY = heroY - heroSpeed;
            }
            startTimer++;

            for (int i = 0; i < wallRecList.Count; i++)
            {
                if (wallRecList[i].X > 0)
                {
                    Rectangle r = new Rectangle(wallRecList[i].X - wallSpeed, wallRecList[i].Y, wallRecList[i].Width, wallRecList[i].Height);
                    wallRecList[i] = r;
                }
            }
           

            //TODO collisions checks 

            //calls the GameScreen_Paint method to draw the screen.
            Refresh();
        }


        //Everything that is to be drawn on the screen should be done here
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            if (startTimer > 50)
            {
                e.Graphics.FillRectangle(heroBrush, heroX, heroY, heroSize, heroSize);

                for (int i = 0; i < wallRecList.Count; i++)
                {
                    e.Graphics.FillRectangle(wallBrush, wallRecList[i].X, wallRecList[i].Y, wallRecList[i].Width, wallRecList[i].Height);
                }

            }

            //draw rectangle to screen
            
            
        }
    }

}
