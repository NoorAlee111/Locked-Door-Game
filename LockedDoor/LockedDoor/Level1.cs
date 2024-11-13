using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;

namespace LockedDoor
{
    public partial class Level1 : Form
    {
        int enemyFireGenerationTime;
        int enemyFirecurrentTime;
        private List<PictureBox> enemyfires = new List<PictureBox>();
        private PictureBox player2;
        ProgressBar playerhealth;
        private int score;
        private int lives;
        ProgressBar enemyhealth;
        private List<PictureBox> walls = new List<PictureBox>();
        private List<PictureBox> coins = new List<PictureBox>();
        private List<PictureBox> enemies = new List<PictureBox>();
        private List<string> enemiesDirection = new List<string>();
        Random random;
        bool flag,flag1,flag2,flag3,flag4;
        public Level1()
        {
            InitializeComponent();
            addwalls();
            addcoins();
            
        }
        private void addwalls()
        {
            walls.Add(wall1);
            walls.Add(wall2);
            walls.Add(wall3);
            walls.Add(wall4);
            walls.Add(wall5);
            walls.Add(wall6);

        }
        private void start()
        {
            
        }
        private void addcoins()
        {
            coins.Add(coin1);
            coins.Add(coin2);
            coins.Add(coin3);
            coins.Add(coin4);
            coins.Add(coin5);
            coins.Add(coin6);
            coins.Add(coin7);
            coins.Add(coin8);
            coins.Add(coin9);
            coins.Add(coin10);
            coins.Add(coin11);
            coins.Add(coin12);
            coins.Add(coin13);
            coins.Add(coin14);
            coins.Add(coin15);
            coins.Add(coin16);
            coins.Add(coin17);
            coins.Add(coin18);
            coins.Add(coin19);
            coins.Add(coin20);
            coins.Add(coin21);
            coins.Add(coin22);
            coins.Add(coin23);
            coins.Add(coin24);
        }
       private int ghostDirection()
        {
            Random r = new Random();
            int value = r.Next(4);
            return value;
        }
        private void randomghostmovement()
        {
            int value = ghostDirection();
            if(value==0)
            {
                if (enemies[1].Left + enemies[1].Width <= this.Width)
                {
                    enemies[1].Left = enemies[1].Left + 15;
                }
            }
            else if(value == 1)
            {
                if (enemies[1].Top + enemies[1].Height > 0)
                {
                    enemies[1].Left = enemies[1].Left - 15;
                }
            }
            else if(value==2)
            {
                if (enemies[1].Top + enemies[1].Height > 0)
                {
                    enemies[1].Top = enemies[1].Top - 15;
                }
            }
            else if(value==3)
            {
                if (enemies[1].Top + enemies[1].Height <= 489)
                {
                    enemies[1].Top = enemies[1].Top + 15;
                }
            }
        }
        private void Level1_Load(object sender, EventArgs e)
        {
          
            score = 0;
            lives = 5;
            addwalls();
            addcoins();
            gameloop.Enabled = true;
            player2 = createPlayer();
            this.Controls.Add(player2);
            createenemyhorizontal();
            enemyFireGenerationTime = 20;
            enemyFirecurrentTime = 0;
            random = new Random();
            createenemyrandom1();
       
        }
        private void detectplayerCollision()
        {
            foreach (PictureBox bullet in enemyfires)
            {
                if (bullet.Bounds.IntersectsWith(player2.Bounds))
                {
                    if (playerhealth.Value > 0)
                    {
                        playerhealth.Value = playerhealth.Value - 20;
                    }
                }
            }
            foreach (PictureBox enemy in enemies)
            {
                if (enemy.Bounds.IntersectsWith(player2.Bounds))
                {
                    if (playerhealth.Value > 0)
                    {
                        playerhealth.Value = playerhealth.Value - 20;
                       
                    }

                }

            }
        }
        private void moveenemyhorizontal()
        {
            if (enemiesDirection[0] == "Left")
            {
                enemies[0].Left = enemies[0].Left - 15;

            }
            else if (enemiesDirection[0] == "Right")
            {
                enemies[0].Left = enemies[0].Left + 15;

            }
            if (enemies[0].Left <= 0)
            {
                enemiesDirection.Insert(0, "Right");
            }
            if (enemies[0].Left + enemies[0].Width >= this.Width)
            {

                enemiesDirection.Insert(0, "Left");
            }
        }
        private void createenemyhorizontal()
        {
            PictureBox enemy = new PictureBox();
            Image img = LockedDoor.Properties.Resources._21;
            enemy.Image = img;
            enemy.Width = 80;
            enemy.Height = 80;
            enemy.BackColor = Color.Transparent;
            enemy.Left = 8;
            enemy.Top = this.Height - (img.Height + 170);
            enemy.SizeMode = PictureBoxSizeMode.StretchImage;
            enemiesDirection.Add("Right");
            enemies.Add(enemy);
            this.Controls.Add(enemy);
            enemyhealth = new ProgressBar();
            enemyhealth.Value = 100;
            enemyhealth.Left = enemy.Left - 10;
            enemyhealth.Top = enemies[0].Top + enemies[0].Height + 10;
            this.Controls.Add(enemyhealth);

        }
        private void createenemyrandom1()
        {
            PictureBox enemy = new PictureBox();
            Image img = LockedDoor.Properties.Resources.chaser;
            enemy.Image = img;
            enemy.Width = 70;
            enemy.Height = 70;
            enemy.BackColor = Color.Transparent;
            enemy.Left = random.Next(0,this.Width-img.Width);
            enemy.Top = random.Next(0,this.Height-img.Height+20);
            enemy.SizeMode = PictureBoxSizeMode.StretchImage;
            enemies.Add(enemy);
            this.Controls.Add(enemy);

        }
        private PictureBox createPlayer()
        {
            PictureBox player2 = new PictureBox();
            Image img = LockedDoor.Properties.Resources.player1;
            player2.Image = img;
            player2.Width = 100;
            player2.Height = 100;
            player2.BackColor = Color.Transparent;
            player2.Left = 8;
            player2.Top = this.Height - (img.Height + 40);
            player2.SizeMode = PictureBoxSizeMode.StretchImage;
            playerhealth = new ProgressBar();
            playerhealth.Value = 100;
            playerhealth.Left = player2.Left;
            playerhealth.Top = player2.Top + player2.Height + 10;
            this.Controls.Add(playerhealth);
            return player2;

        }
        private void removebullet()
        {
            
            for (int i = 0; i < enemyfires.Count; i++)
            {
                if (enemyfires[i].Top >= this.Height || enemyfires[i].Visible == false)
                {
                    enemyfires.Remove(enemyfires[i]);
                }
            }

        }
        private void calculatescore()
        {
            foreach (PictureBox coin in coins)
            {
                if (player2.Bounds.IntersectsWith(coin.Bounds))
                {
                    score++;
                    coin.Hide();
                    coins.Remove(coin);
                    this.Controls.Remove(coin);
                    break;
                }
            }
        }
        private void gameloop_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                if (player2.Left + player2.Width <= this.Width)
                {
                    flag = detectCollisionwithwalls1();
                    flag2 = detectCollisionwithwalls3();
                    flag3 = detectCollisionwithwalls4();
                    flag4 = detectCollisionwithwalls5();
                    if (flag == true)
                    {
                        player2.Left = player2.Left - 5;
                        player2.Top = player2.Top - 5;
                    }
                     else if(flag2==true)
                    {
                        player2.Left = player2.Left + 10;
                        player2.Top = player2.Top - 10;
                    }
                    else if(flag3==true)
                    {
                        player2.Left = player2.Left - 20;
                        player2.Top = player2.Top - 10;
                    }
                    else if (flag4 == true)
                    {
                        player2.Left = player2.Left + 10;
                        player2.Top = player2.Top + 10;
                    }
                    else
                    {
                        player2.Left = player2.Left + 20;
                    }
                    calculatescore();
                    collectlife();
                    collectenergizer();

                }
                

            }
            else if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                if (player2.Left > 0)
                {
                    flag1 = detectCollisionwithwalls2();
                    if(flag1==true)
                    {
                        player2.Left = player2.Left + 10;
                        player2.Top = player2.Top + 20;
                    }
                    else
                    {
                        player2.Left = player2.Left - 20;
                        calculatescore();
                        collectlife();
                        collectenergizer();

                    }

                   

                }
               

            }
            else if (Keyboard.IsKeyPressed(Key.UpArrow))
            {

                if (player2.Top + player2.Height > 0 )
                {
                    flag4= detectCollisionwithwalls5();

                    flag1 = detectCollisionwithwalls2();
                    if (flag1 == true)
                    {
                        player2.Left = player2.Left + 10;
                        player2.Top = player2.Top + 20;
                    }
                   else if (flag4 == true)
                    {
                        player2.Left = player2.Left + 10;
                        player2.Top = player2.Top + 10;
                    }
                    else
                    {
                        player2.Top = player2.Top - 20;
                        
                    }
                    calculatescore();
                    collectlife();
                    collectenergizer();


                }
                
               
               

            }
            else if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                if (player2.Top+player2.Height <= 489)
                {
                    flag3 = detectCollisionwithwalls4();
                    
                    flag = detectCollisionwithwalls1();
                    flag2 = detectCollisionwithwalls3();
                    if (flag == true)
                    {
                        player2.Left = player2.Left - 5;
                        player2.Top = player2.Top - 20;
                    }
                   else if (flag3 == true)
                    {
                        player2.Left = player2.Left - 10;
                        player2.Top = player2.Top - 10;

                    }
                    else if (flag2 == true)
                    {
                        player2.Left = player2.Left + 10;
                        player2.Top = player2.Top - 10;
                    }
                    else
                    {
                        player2.Top = player2.Top + 20;
                        calculatescore();
                        collectlife();
                        collectenergizer();
                    }
                      
                }
                
            }
            flag = detectCollisionwithwalls1();
            if (flag == true)
            {
                player2.Left = player2.Left - 5;
                player2.Top = player2.Top - 20;
            }
            flag1 = detectCollisionwithwalls2();
            if (flag1 == true)
            {
                player2.Left = player2.Left + 10;
                player2.Top = player2.Top + 20;
            }
             flag2 = detectCollisionwithwalls3();
            if (flag2 == true)
            { 
                player2.Left = player2.Left + 10;
                player2.Top = player2.Top - 10;
            }
            flag3 = detectCollisionwithwalls4();
            if (flag3 == true)
            {
                player2.Left = player2.Left - 10;
                player2.Top = player2.Top - 10;

            }
            flag4 = detectCollisionwithwalls5();
            if (flag4 == true)
            {
                player2.Left = player2.Left + 10;
                player2.Top = player2.Top + 10;
            }
            playerhealth.Left = player2.Left;
            playerhealth.Top = player2.Top + player2.Height;
            enemyhealth.Left = enemies[0].Left-3;
            enemyhealth.Top = enemies[0].Top + enemies[0].Height;

            moveenemyhorizontal();
            enemyFirecurrentTime++;
            if (enemyFirecurrentTime == enemyFireGenerationTime)
            {
                PictureBox enemeyfire = createEnemyBullet();
                enemyfires.Add(enemeyfire);
                this.Controls.Add(enemeyfire);
                enemyFirecurrentTime = 0;
            }
            moveenemybullet();
            randomghostmovement();
            detectplayerCollision();
            decreaseenemyhealth();
            livedecrease();
            displaylifeandscore();
            removebullet();
            if (enemyhealth.Value==0)
            {
                enemies[2].Hide();
                enemies.Remove(enemies[2]);
            }
            if(lives==0)
            {
                gameloop.Enabled = false;
                Image img = Properties.Resources.gameover;
                LevelChange newform = new LevelChange(img,"Restart");
                DialogResult result = newform.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    Level1 restart = new Level1();
                    restart.Show();
                    this.Hide();
                }
                else if (result == DialogResult.No)
                {
                    this.Close();
                }
            }
             if(score>=18)
            {
                
                Image img = Properties.Resources.win;
                LevelChange newform = new LevelChange(img, "Level2");
                gameloop.Enabled = false;
                DialogResult result = newform.ShowDialog();
                if (result == DialogResult.Yes)
                {
                    Level2 level2form = new Level2();
                    level2form.Show();
                    this.Close();
                }
                else if (result == DialogResult.No)
                {
                    this.Close();
                }
            }
            
        }
        private void displaylifeandscore()
        {
            label2.Text = "Lives:" + lives;
            label1.Text = "Score:" + score;
        }
        private void livedecrease()
        {
            if (playerhealth.Value == 0)
            {
                lives--;
                playerhealth.Value = 100;
            }
        }
        private void decreaseenemyhealth()
        {
            if(score==10)
            {
                if (enemyhealth.Value > 0)
                {
                    enemyhealth.Value = 50;
                }
              
            }
        }
        private void collectenergizer()
        {
            if (player2.Bounds.IntersectsWith(energizer1.Bounds))
            {
                if (playerhealth.Value < 100)
                {
                    playerhealth.Value += 20;
                   
                }
                energizer1.Hide();
                this.Controls.Remove(energizer1);


            }
            else if (player2.Bounds.IntersectsWith(energizer2.Bounds))
            {
                if (playerhealth.Value < 100)
                {
                    playerhealth.Value += 20;
                   
                }
                energizer2.Hide();
                this.Controls.Remove(energizer2);
            }
        }
        private void collectlife()
        {
            if (player2.Bounds.IntersectsWith(life.Bounds))
            {
                lives += 2;
                life.Hide();
                this.Controls.Remove(life);
            }
        }
        private void moveenemybullet()
        {
            foreach (PictureBox fire in enemyfires)
            {
                fire.Top = fire.Top + 10;
            }
        }
        private PictureBox createEnemyBullet()
        {
            PictureBox pfire = new PictureBox();
            Image img = LockedDoor.Properties.Resources.Fire5;
            pfire.Image = img;
            pfire.Width = img.Width;
            pfire.Height = img.Height;
            pfire.BackColor = Color.Transparent;
            pfire.Left = enemies[0].Left + 36;
            pfire.Top = enemies[0].Top + 60;
            pfire.SizeMode = PictureBoxSizeMode.StretchImage;
            return pfire;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private bool detectCollisionwithwalls1()
        {
                if (player2.Bounds.IntersectsWith(walls[5].Bounds))
                {
                    return true;
                }
            
            return false;
        }
        private bool detectCollisionwithwalls2()
        {
            if (player2.Bounds.IntersectsWith(walls[4].Bounds))
            {
                return true;
            }

            return false;
        }
        private bool detectCollisionwithwalls3()
        {
            if (player2.Bounds.IntersectsWith(walls[2].Bounds))
            {
                return true;
            }

            return false;
        }
        private bool detectCollisionwithwalls4()
        {
            if (player2.Bounds.IntersectsWith(walls[1].Bounds))
            {
                return true;
            }

            return false;
        }
        private bool detectCollisionwithwalls5()
        {
            if (player2.Bounds.IntersectsWith(walls[0].Bounds))
            {
                return true;
            }

            return false;
        }
        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }
    }
}
