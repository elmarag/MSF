using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSF
{
    public partial class frmLevel2 : Form
    {
        //Declaring variables
        private SoundPlayer soundPlayer;
        private System.Windows.Forms.Timer timer2;
        protected int kNumberOfRows = 5;
        protected const int kNumberOfShields = 2;
        protected const int mNumberOfWalls = 2;
        protected long TimerCounter = 0;
        protected int TheSpeed = 4;
        protected int TheLevel = 0;
        protected bool ActiveBullet = false;

        protected int NumberOfMen;
        protected CMario TheMan = null;
        protected CMothership Mothership = null;
        protected bool GameGoing = true;
        protected CBullet TheBullet = new CBullet(20, 30);
        protected CScore TheScore = null;
        protected CHighScore TheHighScore = null;
        protected CAmmunitionScore AmmoScore = null;
        protected CAlienRows[] AlienRows = new CAlienRows[5];
        protected CShields[] TheShields = new CShields[2];
        protected CShields[] Walls = new CShields[2];
        protected CAlienRows TheAlien = null;
        protected CLifeIndicator LifeIndicator;


        private string CurrentKeyDown = "";
        private string LastKeyDown = "";

        //End of decleration

        //Constructor
        public frmLevel2()
        {
            //Initialize form components
            InitializeComponent();
            InitializeComponents();

            //Assign the music to the sound player
            soundPlayer = new SoundPlayer("mario music.wav");

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //Set background image
            this.BackgroundImage = Properties.Resources.Stars;

            //Set the position of the form
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            //Set the size of the form
            this.ClientSize = new System.Drawing.Size(850, 720);

            //Retrieve all objects
            InitializeAllGameObjects(true);

            //Start the timer
            timer2.Start();

        }

        //Retrieve and initialize all objects
        private void InitializeAllGameObjects(bool bScore)
        {
            //Call all the methods for initialization
            InitializeShields();
            InitializeMan();
            InitializeLivesIndicator();
            InitializeMothership();

            if (bScore)
            {
                InitializeScore();
                InitializeAmmoScore();
            }
                
            InitializeInvaderRows(TheLevel);
            TheScore.IsGameOver = false;
            GameGoing = true;
            TheSpeed = 6;
        }

        //Initialize Mario
        protected virtual void InitializeMan()
        {
            TheMan = new CMario();
            TheMan.gameObject_Position.Y = ClientRectangle.Bottom - 50;
            NumberOfMen = 3;
        }

        //Initialize the lives on screen
        protected virtual void InitializeMothership()
        {
            Mothership = new CMothership("TopShip.gif");
        }

        //Initialize the score on screen
        private void InitializeScore()
        {
            TheScore = new CScore(ClientRectangle.Right - 850, 25);
            TheHighScore = new CHighScore(ClientRectangle.Left + 0, 50);
            TheHighScore.ReadFile();
            TheScore.ReadFile();
        }

        //Initialize the ammo score on screen
        protected virtual void InitializeAmmoScore()
        {
            AmmoScore = new CAmmunitionScore(ClientRectangle.Right - 850, 75);
            AmmoScore.ReadFile();
        }

        //Initialize the shields
        private void InitializeShields()
        {
            for (int i = 0; i < kNumberOfShields; i++)
            {
                //Array to hold the number of shields
                TheShields[i] = new CShields();
                TheShields[i].UpdateGameBounds();
                //Set position of the shields
                TheShields[i].gameObject_Position.X = (TheShields[i].GetImageBounds().Width + 250) * i + 200;
                TheShields[i].gameObject_Position.Y = ClientRectangle.Bottom -
                              (TheShields[i].GetImageBounds().Height + 75);
            }
            
            //Shields around the mothership
            for (int i = 0; i < mNumberOfWalls; i++)
            {
                //Array to hold the number of shields
                Walls[i] = new CShields();
                Walls[i].UpdateGameBounds();
                //Set position of the shields
                Walls[i].gameObject_Position.X = (TheShields[i].GetImageBounds().Width + 0) * i + 325;
                Walls[i].gameObject_Position.Y = ClientRectangle.Bottom -
                              (TheShields[i].GetImageBounds().Height + 580);
            }
        }

        //Initialize the lives indicator
        private void InitializeLivesIndicator()
        {
            LifeIndicator = new CLifeIndicator(ClientRectangle.Right - 250, 25);
            LifeIndicator.NoOfLives = 3;
        }

        //Initialize alien rows
        protected virtual void InitializeInvaderRows(int level)
        {
            //Arrays to hold the aliens
            AlienRows[0] = new CAlienRows("invader4.gif", "invader4c.gif", 2 + level, 150);
            AlienRows[1] = new CAlienRows("invader2.gif", "invader2c.gif", 3 + level, 150);
            AlienRows[2] = new CAlienRows("invader3.gif", "invader3c.gif", 4 + level, 150);
            AlienRows[3] = new CAlienRows("invader3.gif", "invader3c.gif", 5 + level, 150);
            AlienRows[4] = new CAlienRows("invader1.gif", "invader1c.gif", 6 + level, 150);
        }

        //Key handler
        private void HandleKeys()
        {
            //Switch to see which key is the one selected
            switch (CurrentKeyDown)
            {
                //In this case, we are using the ammo points we gathered that are reduced with each shot.
                case "Space":
                    if (ActiveBullet == false)
                    {
                        TheBullet.gameObject_Position = TheMan.BulletStartPosition();
                        ActiveBullet = true;

                       int score = AmmoScore.DecrementPlayerScore();
                        //If the ammo points are 0 then the game is over
                        if(score == 0)
                        {
                            TheScore.IsGameOver = true;
                            GameGoing = false;
                            //Message box asking the user to restart or exit
                            if (MessageBox.Show("Game Over. Restart the game?", "Game Over.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //If yes, then game restarts on level 1
                                Form frm = new f_Level1();
                                this.Hide();
                                frm.Show();
                            }
                            else
                            {
                                //Else the game exits to the main window
                                Form frm = new frmEntrance();
                                this.Hide();
                                frm.Show();
                            }
                        }
                    }
                    CurrentKeyDown = LastKeyDown;
                    break;
                case "Left":
                    TheMan.MoveLeft();
                    Invalidate(TheMan.GetImageBounds());
                    if (timer2.Enabled == false)
                        timer2.Start();
                    break;
                case "A":
                    TheMan.MoveLeft();
                    Invalidate(TheMan.GetImageBounds());
                    if (timer2.Enabled == false)
                        timer2.Start();
                    break;
                case "Right":
                    TheMan.MoveRight(ClientRectangle.Right);
                    Invalidate(TheMan.GetImageBounds());
                    if (timer2.Enabled == false)
                        timer2.Start();
                    break;
                case "D":
                    TheMan.MoveRight(ClientRectangle.Right);
                    Invalidate(TheMan.GetImageBounds());
                    if (timer2.Enabled == false)
                        timer2.Start();
                    break;
                case "Escape":
                    Application.Exit();
                    break;
                default:
                    break;
            }
        }

        //Paint all the game objects to the form
        protected virtual void Form2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Draw the shields
            for (int i = 0; i < kNumberOfShields; i++)
            {
                TheShields[i].DrawElement(g);    
            }
            //Draw the shields around the mothership
            for (int i = 0; i < mNumberOfWalls; i++)
            {
                Walls[i].DrawElement(g);
            }

            g.FillRectangle(Brushes.Transparent, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
            //Draw Mario
            TheMan.DrawElement(g);
            //Draw Mothership
            Mothership.DrawElement(g);
            //Draw Score
            TheScore.Draw(g);
            //Draw High Score
            TheHighScore.Draw(g);
            //Draw Ammo Score
            AmmoScore.Draw(g);
            //Draw Life Indicator
            LifeIndicator.DrawElement(g);

            //Draw bullet
            if (ActiveBullet)
            {
                TheBullet.DrawElement(g);
            }

            //Draw the aliens
            for (int i = 0; i < kNumberOfRows; i++)
            {
                TheAlien = AlienRows[i];
                TheAlien.Draw(g);
            }

        }

        //Get the largest last position of the aliens (needed for their movement)
        private int CalculateLargestLastPosition()
        {
            int max = 0;
            for (int i = 0; i < kNumberOfRows; i++)
            {
                TheAlien = AlienRows[i];
                int nLastPos = TheAlien.GetLastInvader().gameObject_Position.X;
                if (nLastPos > max)
                    max = nLastPos;
            }

            return max;
        }

        //Get the smallest first position of the aliens (needed for their movement)
        private int CalculateSmallestFirstPosition()
        {
            int min = 50000;

            try
            {
                for (int i = 0; i < kNumberOfRows; i++)
                {
                    TheAlien = AlienRows[i];
                    int nFirstPos = TheAlien.FirstAlien().gameObject_Position.X;
                    if (nFirstPos < min)
                        min = nFirstPos;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return min;

        }

        //Move the aliens
        private void MoveAliens()
        {
            bool bMoveDown = false;

            //Count the number of rows and moce the aliens
            for (int i = 0; i < kNumberOfRows; i++)
            {

                TheAlien = AlienRows[i];
                TheAlien.Move();

            }

            if ((CalculateLargestLastPosition()) > ClientRectangle.Width - AlienRows[4][0].GetImageWidth())
            {
                TheAlien.DirectionRight = false;
                SetAllDirections(false);
            }

            if ((CalculateSmallestFirstPosition()) < AlienRows[4][0].ImageWidth / 3)
            {
                TheAlien.DirectionRight = true;
                SetAllDirections(true);
                for (int i = 0; i < kNumberOfRows; i++)
                {
                    bMoveDown = true;
                }
            }

            if (bMoveDown)
            {
                for (int i = 0; i < kNumberOfRows; i++)
                {

                    TheAlien = AlienRows[i];
                    TheAlien.MoveDown();

                }
            }
        }

        //Calculate the number of aliens left
        private int TotalNumberOfInvaders()
        {
            int sum = 0;
            for (int i = 0; i < kNumberOfRows; i++)
            {
                //Asign the new number of aliens after counting if any has died
                TheAlien = AlienRows[i];
                sum += TheAlien.NumberOfLiveInvaders();
            }

            return sum;
        }

        private void MoveOnSpot()
        {
            for (int i = 0; i < kNumberOfRows; i++)
            {
                TheAlien = AlienRows[i];
                TheAlien.MoveOnSpot();
            }

        }

        private void SetAllDirections(bool bDirection)
        {
            for (int i = 0; i < kNumberOfRows; i++)
            {
                TheAlien = AlienRows[i];
                TheAlien.DirectionRight = bDirection;
            }

        }

        //Calculate the score that each alien gives
        public int CalcScoreFromRow(int num)
        {
            int nScore = 0;
            switch (num)
            {
                case 0:
                    //Fifth line gives 40 points
                    nScore = 40;
                    break;
                case 1:
                    //Fourth line gives 30 points
                    nScore = 30;
                    break;
                case 2:
                    //Third line gives 25 points
                    nScore = 25;
                    break;
                case 3:
                    //Second line gives 25 points
                    nScore = 25;
                    break;
                case 4:
                    //First line gives 20 points
                    nScore = 20;
                    break;
            }

            return nScore;
        }

        //Create the bullet hitting aliens and shields
        void TestBulletCollision()
        {
           
            int rowNum = 0;
            for (int i = 0; i < kNumberOfRows; i++)
            {
                TheAlien = AlienRows[i];
                rowNum = i;
                //Store collision event
                int collisionIndex = TheAlien.CollisionTest(TheBullet.GetImageBounds());

                //If there was a collision while a bullet was shot
                if ((collisionIndex >= 0) && ActiveBullet)
                {
                    //Set the attribute of aliens to being hit
                    TheAlien.Aliens[collisionIndex].isHit = true;
                    //Add the corresponding poins to the total score
                    TheScore.AddPlayerScore(CalcScoreFromRow(rowNum));

                    //Reset the bullet
                    ActiveBullet = false;
                    TheBullet.ResetBulletPosition();
                }

                //If mothershiop is hit from bullet
                if (Mothership.GetImageBounds().IntersectsWith(TheBullet.GetImageBounds()))
                {
                    //Mothership is hit
                    Mothership.isHit = true;
                    //Write the highscore to a file
                    TheHighScore.WriteFile(TheScore.CountScore);
                    //Game is over
                    TheScore.IsGameOver = true;
                    //Game stops 
                    GameGoing = false;
                    //Messagebox to the user to restart or quit
                    if (MessageBox.Show("Do you want to restart the game?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //If yes, restart level 1
                        Form frm = new f_Level1();
                        this.Hide();
                        frm.Show();
                    }
                    else
                    {
                        //If no, quit to main window
                        Form frm = new frmEntrance();
                        this.Hide();
                        frm.Show();
                    }
                }
                else
                {
                    //Mothership is not hit
                    Mothership.isHit = false;
                }
            }
        }


        void ResetAllBombCounters()
        {
            for (int i = 0; i < kNumberOfRows; i++)
            {
                TheAlien = AlienRows[i];
                TheAlien.ResetBombCounters();
            }
        }

        //Create the alien bomb hitting mario
        void TestBombCollision()
        {
            //If Mario died
            if (TheMan.IsDead)
            {
                //Reduce a life
                NumberOfMen--;
                //Remove a life from the top right indicator
                LifeIndicator.DecrementLives();
                Invalidate();
                //If there are no more lives
                if (NumberOfMen == 0)
                {
                    //Write the score to a highscore file
                    TheHighScore.WriteFile(TheScore.CountScore);
                    //The game is over
                    TheScore.IsGameOver = true;
                    //Stop the game
                    GameGoing = false;
                    //Show message box to user
                    if (MessageBox.Show("Do you want to restart the level?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //If yes, restart the game
                        Form frm = new frmLevel2();
                        this.Hide();
                        frm.Show();
                    }
                    else
                    {
                        //If no, quit to main window
                        Form frm = new frmEntrance();
                        this.Hide();
                        frm.Show();
                    }
                }
                else
                {
                    //Reset the man for another round
                    TheMan.Reset();
                    //Reset the bomb counters
                    ResetAllBombCounters();
                }
            }

            if (TheMan.IsHit == true)
                return;


            for (int i = 0; i < kNumberOfRows; i++)
            {
                TheAlien = AlienRows[i];
                for (int j = 0; j < TheAlien.Aliens.Length; j++)
                {
                    //For each shield found in the array
                    for (int k = 0; k < kNumberOfShields; k++)
                    {
                        bool bulletHole = false;
                        //Check to see if the bombs shot from the aliens went through the bullet hole of the shield
                        if (TheShields[k].TestCollision(TheAlien.Aliens[j].GetBombBounds(), true, out bulletHole))
                        {
                            //Reset the bomb position
                            TheAlien.Aliens[j].ResetBombPosition();
                            //Create the bullet hole
                            Invalidate(TheShields[k].GetImageBounds());
                        }

                        //Check to see if the bullet shot from Mario went through the bullet hole of the shield
                        if (TheShields[k].TestCollision(TheBullet.GetImageBounds(), false, out bulletHole))
                        {
                            ActiveBullet = false;
                            //Reset the bomb position
                            Invalidate(TheShields[k].GetImageBounds());
                            //Create the bullet hole
                            TheBullet.ResetBulletPosition();
                        }
                        //Check to see if the bullet shot from Mario went through the bullet hole of the shield of mothership
                        if (Walls[k].TestCollision(TheBullet.GetImageBounds(), false, out bulletHole))
                        {
                            ActiveBullet = false;
                            //Reset the bomb position
                            Invalidate(Walls[k].GetImageBounds());
                            //Create the bullet hole
                            TheBullet.ResetBulletPosition();
                        }
                    }
                    //If the bomb hit mario
                    if (TheAlien.Aliens[j].IsBombColliding(TheMan.GetImageBounds()))
                    {
                        //Hit mario
                        TheMan.IsHit = true;
                    }
                }
                //If the bomb of mothership hit mario
                if (Mothership.IsBombColliding(TheMan.GetImageBounds()))
                {
                    //Hit mario
                    TheMan.IsHit = true;
                }
            }
        }

        private int nTotalInvaders = 0;

        //Timer handler
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            HandleKeys();

            TimerCounter++;

            //If the game stopped
            if (GameGoing == false)
            {
                if (TimerCounter % 6 == 0)
                    MoveOnSpot();
                Invalidate();
                return;
            }

            //If the bullet is outside of the bounds of the form
            if (TheBullet.gameObject_Position.Y < 0)
            {
                //Reset the bullet
                ActiveBullet = false;
            }

            if (TimerCounter % TheSpeed == 0)
            {
                MoveAliens();

                nTotalInvaders = TotalNumberOfInvaders();
                //Calculate how many aliens are left and make their speed faster
                //According to the number of aliens
                if (nTotalInvaders <= 20)
                {
                    TheSpeed = 5;
                }

                if (nTotalInvaders <= 10)
                {
                    TheSpeed = 4;
                }


                if (nTotalInvaders <= 5)
                {
                    TheSpeed = 3;
                }

                if (nTotalInvaders <= 3)
                {
                    TheSpeed = 2;
                }

                if (nTotalInvaders <= 1)
                {
                    TheSpeed = 1;
                }
            }

            TestBulletCollision();
            TestBombCollision();


            Invalidate();
        }


        private void InitializeComponents()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLevel2));
            this.timer2 = new System.Windows.Forms.Timer(this.components);

            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer2.Interval = 50;
            this.timer2.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(672, 622);
            this.KeyPreview = true;
            this.Name = "Form2";
            this.Text = "Space Invaders Game";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyUp);
            this.MaximizeBox = false;
            this.ResumeLayout(false);

        }

        //Release the last selection when a key is no longer pressed
        private void Form2_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            string result = e.KeyData.ToString();
            if (result == "Left" || result == "Right")
            {
                LastKeyDown = "";
            }
        }


        private void Form2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            string result = e.KeyData.ToString();
            CurrentKeyDown = result;
            if (result == "Left" || result == "Right")
            {
                LastKeyDown = result;
            }

            Invalidate(TheMan.GetImageBounds());

        }

        //On the form load
        private void Form2_Load(object sender, EventArgs e)
        {
            //Play the music
            soundPlayer.PlayLooping();
        }

        private void frmLevel2_Load(object sender, EventArgs e)
        {

        }
    }
}
