using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Data;
using System.Media;

namespace MSF
{
	public partial class f_Level1 : System.Windows.Forms.Form
	{
		//Declaring the variables
		private SoundPlayer soundPlayer;
		private System.Windows.Forms.Timer timer1;

		protected int kNumberOfRows = 4;
		protected const int kNumberOfShields = 3;
		protected long TimerCounter = 0;
		protected int TheSpeed = 4;
		protected int TheLevel = 0;
		protected bool ActiveBullet = false;


		protected int NumberOfMen;
		protected CMario TheMan = null;
		protected bool GameGoing = true;
		protected CBullet TheBullet = new CBullet(20, 30);
		protected CScore TheScore = null;
		protected CAmmunitionScore AmmoScore = null;
		protected CAlienRows[] AlienRows = new CAlienRows[6];
		protected CShields[] TheShields = new CShields[3];
		protected CAlienRows TheAlien = null;
		protected CLifeIndicator LifeIndicator;

		private int kSaucerInterval = 400;

		private string CurrentKeyDown = "";
		private string LastKeyDown = "";
		

		[DllImport("winmm.dll")]
		public static extern long PlaySound(String lpszName, long hModule, long dwFlags);
		//End of variable decleration

		//Constructor
		public f_Level1()
		{
			//Initialize form components
			InitializeComponents();
			
			//Assign the music to the sound player
			soundPlayer = new SoundPlayer("mario music.wav");

			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			
			//Set background image
			this.BackgroundImage = Properties.Resources.Stars;

			//Remove form border
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

			//Set the size of the form
			this.ClientSize = new System.Drawing.Size(850, 720);

			//Set the position of the form
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

			//Retrieve all objects
			InitializeAllGameObjects(true);

			//Start the timer
			timer1.Start();
		}

		//Retrieve and initialize all objects
		private void InitializeAllGameObjects(bool bScore)
		{
			//Call all the methods for initialization
			InitializeShields();
			InitializeMan();
			InitializeLivesIndicator();

			if (bScore)
			{
				InitializeScore();
				InitializeAmmoScore();
			}

			InitializeInvaderRows(TheLevel);
			TheScore.IsGameOver = false;
			AmmoScore.IsGameOver = false;
			GameGoing = true;
			TheSpeed = 6;
		}

		//Initialize Mario
		protected virtual void InitializeMan()
		{
			TheMan = new CMario();
			TheMan.gameObject_Position.Y = ClientRectangle.Bottom - 50;
			NumberOfMen = 4;
		}

		//Initialize the lives on screen
        private void InitializeLivesIndicator()
        {
			LifeIndicator = new CLifeIndicator(ClientRectangle.Right - 250, 25);
        }

		//Initialize the score on screen
        protected virtual void InitializeScore()
        {
            TheScore = new CScore(ClientRectangle.Right - 850, 25);
        }

		//Initialize the ammo score on screen
		protected virtual void InitializeAmmoScore()
		{
			AmmoScore = new CAmmunitionScore(ClientRectangle.Right - 850, 45);
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
                TheShields[i].gameObject_Position.X = (TheShields[i].GetImageBounds().Width + 130) * i + 150;
                TheShields[i].gameObject_Position.Y = ClientRectangle.Bottom -
                              (TheShields[i].GetImageBounds().Height + 130);
            }
        }

		//Initialize alien rows
        protected virtual void InitializeInvaderRows(int level)
		{
			//Arrays to hold the aliens
			AlienRows[0] = new CAlienRows("invader3.gif", "invader3c.gif", 2 + level, 10);
			AlienRows[1] = new CAlienRows("invader2.gif", "invader2c.gif", 3 + level, 10);
			AlienRows[2] = new CAlienRows("invader1.gif", "invader1c.gif", 4 + level, 10);
			AlienRows[3] = new CAlienRows("invader1.gif", "invader1c.gif", 5 + level, 10);
			
		}


		#region Windows Form Designer generated code
		private void InitializeComponents()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_Level1));
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			this.timer1.Interval = 50;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(672, 622);
			this.KeyPreview = true;
			this.Name = "Form1";
			this.Text = "Space Invaders Game";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			this.MaximizeBox = false;
			this.ResumeLayout(false);

		}
        private void Form1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
        }
        #endregion

		//The main entry point for the application.

		//Key handler
        private void HandleKeys()
		{
			//Switch to see which key is the one selected
			switch (CurrentKeyDown)
			{
				case "Space":
					if (ActiveBullet == false)
					{
						TheBullet.gameObject_Position = TheMan.BulletStartPosition();
						ActiveBullet = true;
					}
					CurrentKeyDown = LastKeyDown;
					break;
				case "Left":
					TheMan.MoveLeft();
					Invalidate(TheMan.GetImageBounds());
					if (timer1.Enabled == false)
						timer1.Start();
					break;
				case "A":
					TheMan.MoveLeft();
					Invalidate(TheMan.GetImageBounds());
					if (timer1.Enabled == false)
						timer1.Start();
					break;
				case "Right":
					TheMan.MoveRight(ClientRectangle.Right);
					Invalidate(TheMan.GetImageBounds());
					if (timer1.Enabled == false)
						timer1.Start();
					break;
				case "D":
					TheMan.MoveRight(ClientRectangle.Right);
					Invalidate(TheMan.GetImageBounds());
					if (timer1.Enabled == false)
						timer1.Start();
					break;
				case "Escape":
					Application.Exit();
					break;
				default:
					break;
			}


		}

		//Key down movement of Mario
		private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			string result = e.KeyData.ToString();
			CurrentKeyDown = result;
			if (result == "Left" || result == "Right")
			{
				LastKeyDown = result;
			}
			Invalidate(TheMan.GetImageBounds());
		}

		//Paint all the game objects to the form
		protected virtual void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			//Draw the shields
			for (int i = 0; i < kNumberOfShields; i++)
			{
				TheShields[i].DrawElement(g); 
			}

			g.FillRectangle(Brushes.Transparent, 0, 0, ClientRectangle.Width, ClientRectangle.Height);
			//Draw Mario
			TheMan.DrawElement(g);
			//Draw Score
			TheScore.Draw(g);
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

			if ((CalculateLargestLastPosition()) > ClientRectangle.Width - AlienRows[3][0].GetImageWidth())
			{
				TheAlien.DirectionRight = false;
				SetAllDirections(false);
			}

			if ((CalculateSmallestFirstPosition()) < AlienRows[3][0].ImageWidth / 3)
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
				//Move the aliens down
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
			//Score
			int nScore = 0;
			switch (num)
			{
				case 0:
					//Fourth line gives 0 in thie switch because those points are stored in a different file 
					//and are calculated below
					nScore = 0;
					break;
				case 1:
					//Third line gives 25 points each alien
					nScore = 25;
					break;
				case 2:
					//Second line gives 20 points each alien
					nScore = 20;
					break;
				case 3:
					//First line gives 20 points each alien
					nScore = 20;
					break;
			}

			return nScore;
		}

		//Calculate ammo score
		public int CalcAmmoScoreFromRow(int num)
		{
			//Ammo score
			int aScore = 0;
			switch (num)
			{
				case 0:
					//Fourth line gives 30 points which is added to the ammo score
					aScore = 30;
					break;
			}

			return aScore;
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
					//Add the corresponding ammo points to the ammo score
					AmmoScore.AddPlayerScore(CalcAmmoScoreFromRow(rowNum));

					//Reset the bullet
                    ActiveBullet = false;
                    TheBullet.ResetBulletPosition();
                }
            }
        }

		//Reset the bombs
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
					//The game is over
					TheScore.IsGameOver = true;
					//Stop the game
					GameGoing = false;
					//Show message box to user
					if (MessageBox.Show("Do you want to restart the level?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						//If yes, restart the game
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
					}
					//If the bomb hit mario
					if (TheAlien.Aliens[j].IsBombColliding(TheMan.GetImageBounds()))
					{
						//Hit mario
						TheMan.IsHit = true;
					}
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

				//If the aliens are all dead
                if (nTotalInvaders == 0)
                {
					//Dont initialize the game objects
                    InitializeAllGameObjects(false);					
                    TheLevel++;
					//Write the score to an external file
					TheScore.WriteFile(TheScore.CountScore);
					//Write the ammo to an external file
					AmmoScore.WriteFile(TheScore.CountScore);
					//Close the form for level 1 and open the form for level 2
					Form form = new frmLevel2();
					this.Hide();
					form.Show();
				}


            }
            TestBulletCollision();
            TestBombCollision();
            Invalidate();
        }

		//Release the last selection when a key is no longer pressed
		private void Form1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			string result = e.KeyData.ToString();
			if (result == "Left" || result == "Right")
			{
				LastKeyDown = "";
			}

		}

			private void Menu_Exit(object sender, System.EventArgs e)
			{
				Application.Exit();
			}
			
			//On the form load
			private void Form1_Load(object sender, EventArgs e)
			{
			//Play the music
			soundPlayer.PlayLooping();
			}
	}
}
