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
using System.Threading;

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
        int bWallY = 200;
        int wallWidth = 50;
        int wallHeight = 200;
        int wallSpeed = 4;
        int score = 0;
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

            Rectangle R1 = new Rectangle(700, bWallY, wallWidth, wallHeight);
            wallRecList.Add(R1);

            Rectangle R2 = new Rectangle(850, tWallY, wallWidth, wallHeight);
            wallRecList.Add(R2);

            Rectangle R3 = new Rectangle(1000, bWallY, wallWidth, wallHeight);
            wallRecList.Add(R3);
             
            Rectangle R4 = new Rectangle(1100, bWallY, wallWidth, wallHeight);
            wallRecList.Add(R4);

            Rectangle R5 = new Rectangle(1200, tWallY, wallWidth, wallHeight);
            wallRecList.Add(R5);

            Rectangle R6 = new Rectangle(1300, bWallY, wallWidth, wallHeight);
            wallRecList.Add(R6);

            Rectangle R7 = new Rectangle(1350, bWallY, wallWidth, wallHeight);
            wallRecList.Add(R7);

            Rectangle R8 = new Rectangle(1450, tWallY, wallWidth, wallHeight);
            wallRecList.Add(R8);

            Rectangle R9 = new Rectangle(1450, tWallY, wallWidth, wallHeight);
            wallRecList.Add(R9);

            Rectangle R10 = new Rectangle(1575, bWallY, wallWidth, wallHeight);
            wallRecList.Add(R10);

            Rectangle R11 = new Rectangle(1675, tWallY, wallWidth, wallHeight);
            wallRecList.Add(R11);

            Rectangle R12 = new Rectangle(1800, bWallY, wallWidth, wallHeight);
            wallRecList.Add(R12);

            Rectangle R13 = new Rectangle(1890, tWallY, wallWidth, wallHeight);
            wallRecList.Add(R13);

            Rectangle R14 = new Rectangle(2000, bWallY, wallWidth, wallHeight);
            wallRecList.Add(R14);

            Rectangle R15 = new Rectangle(2100, tWallY, wallWidth, wallHeight);
            wallRecList.Add(R15);

            Rectangle R16 = new Rectangle(2130, tWallY, wallWidth, wallHeight);
            wallRecList.Add(R16);

            Rectangle R17 = new Rectangle(2230, bWallY, wallWidth, wallHeight);
            wallRecList.Add(R17);

            Rectangle R18 = new Rectangle(2360, tWallY, wallWidth, wallHeight);
            wallRecList.Add(R18);

            Rectangle R19 = new Rectangle(2450, bWallY, wallWidth, wallHeight);
            wallRecList.Add(R19);
            
            Rectangle R20 = new Rectangle(2550, tWallY, wallWidth, wallHeight);
            wallRecList.Add(R20);



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

                    if(wallRecList[i].X <= 0)
                    {
                        wallRecList.RemoveAt(i);
                        score++;
                        scoreText.Text = "Score:" + score;
                        if (score == 21)
                        {
                            Thread.Sleep(1500);
                            MainForm.ChangeScreen(this, "ScoreScreen");
                        }
                    }

                }
            }

            Rectangle heroRec = new Rectangle(heroX, heroY, heroSize, heroSize);
            //TODO collisions checks 
            if (wallRecList.Count > 0)
            {
                for (int i = 0; i < wallRecList.Count; i++)
                {
                    if (wallRecList[i].IntersectsWith(heroRec))
                    {
                        gameTimer.Enabled = false;
                        upArrowDown = downArrowDown = false;
                        Thread.Sleep(3000);
                        MainForm.ChangeScreen(this, "MenuScreen");
                    }
                }
            }
            if (heroY == 325)
            {
                MainForm.ChangeScreen(this, "MenuScreen");
            }
            if (heroY == 0)
            {
                MainForm.ChangeScreen(this, "MenuScreen");
            }
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
