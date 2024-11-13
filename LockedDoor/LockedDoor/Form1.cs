using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
using System.Windows.Forms;

namespace LockedDoor
{
    public partial class Level2 : Form
    {
        private  PictureBox player2;
        ProgressBar playerhealth;
        bool flag=false;
        string verticalenemeydirection = "Up";
        private List<PictureBox> pfires = new List<PictureBox>();
        private List<PictureBox> coins = new List<PictureBox>();
        private List<PictureBox> enemyfires = new List<PictureBox>();
        private List<PictureBox> walls = new List<PictureBox>();
        private List<PictureBox> enemies = new List<PictureBox>();
        private List<string> enemiesDirection = new List<string>();
        int enemyFireGenerationTime ;
        int enemyFirecurrentTime;
        int playerFireGenerationTime;
        int playerFirecurrentTime;
        ProgressBar enemyhealth;
        private int score=0;
        private int keystatus=0;
        private int lives = 10;
        public Level2()
        {
            InitializeComponent();
            walls.Add(wall3);
            walls.Add(wall2);
            walls.Add(wall);
            addcoins();
        }

        private void playerpb_Click(object sender, EventArgs e)
        {

        }
       
       
        private void Form1_Load(object sender, EventArgs e)
        {

            start();
        }
        private void start()
        {
           
            timer.Enabled = true;
            player2 = createPlayer();
            this.Controls.Add(player2);
            createenemy1();
            createenemy2();
            createenemy3vertical();
            enemyFireGenerationTime = 10;
            enemyFirecurrentTime = 0;
            playerFireGenerationTime=30;
            playerFirecurrentTime=0;

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
            player2.Top = this.Height-(img.Height+40);
            player2.SizeMode = PictureBoxSizeMode.StretchImage;
            playerhealth = new ProgressBar();
            playerhealth.Value = 100;
            playerhealth.Left = player2.Left;
            playerhealth.Top = player2.Top + player2.Height + 10;
            this.Controls.Add(playerhealth);
            return player2;

        }
        private void createenemy1()
        {
            PictureBox enemy = new PictureBox();
            Image img = LockedDoor.Properties.Resources.snake;
            enemy.Image = img;
            enemy.Width = 50;
            enemy.Height = 50;
            enemy.BackColor = Color.Transparent;
            enemy.Left = 8;
            enemy.Top = this.Height - (img.Height + 167);
            enemy.SizeMode = PictureBoxSizeMode.StretchImage;
            enemiesDirection.Add("Right");
            enemies.Add(enemy);
            this.Controls.Add(enemy);

        }
        private void addcoins()
        {

            coins.Add(coin0);
            coins.Add(coin1);
            coins.Add(coin2);
            coins.Add(coin6);
            coins.Add(coin4);
            coins.Add(coin5);
            coins.Add(coin7);
            coins.Add(coin8);
            coins.Add(coin9);
            coins.Add(coin10);
            coins.Add(coin11);
            coins.Add(coin12);
           
            
        }
        private void createenemy2()
        {
            PictureBox enemy2 = new PictureBox();
            Image img = LockedDoor.Properties.Resources.snake2;
            enemy2.Image = img;
            enemy2.Width = 50;
            enemy2.Height =50;
            enemy2.BackColor = Color.Transparent;
            enemy2.Left = this.Width-30;
            enemy2.Top = this.Height - (img.Height + 210);
            enemy2.SizeMode = PictureBoxSizeMode.StretchImage;
            enemiesDirection.Add("Left");
            enemies.Add(enemy2);
            this.Controls.Add(enemy2);


        }
        private void createenemy3vertical()
        {
            PictureBox enemy3 = new PictureBox();
            enemy3.Name = "shooter";
            Image img = LockedDoor.Properties.Resources.shooterenemey;
            enemy3.Image = img;
            enemy3.Width = 70;
            enemy3.Height = 70;
            enemy3.BackColor = Color.Transparent;
            enemy3.Left = this.Width /2 ;
            enemy3.Top = (this.Height-img.Height)+21;
            enemy3.SizeMode = PictureBoxSizeMode.StretchImage;
            enemiesDirection.Add("Up");
            enemies.Add(enemy3);
            this.Controls.Add(enemy3);
            enemyhealth = new ProgressBar();
            enemyhealth.Value = 100;
            enemyhealth.Left = enemy3.Left-10;
            enemyhealth.Top = enemies[2].Top - enemyhealth.Height - 10;
            this.Controls.Add(enemyhealth);


        }
        private PictureBox createFire()
        {
            PictureBox pfire = new PictureBox();
            Image img = LockedDoor.Properties.Resources.newbullet;
            pfire.Image = img;
            pfire.Width = img.Width;
            pfire.Height = img.Height;
            pfire.BackColor = Color.Transparent;
            pfire.Left = player2.Left + 50;
            pfire.Top = player2.Top;
            pfire.SizeMode = PictureBoxSizeMode.StretchImage;
            return pfire;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if(Keyboard.IsKeyPressed(Key.RightArrow))
            {
                if (player2.Left + player2.Width <= this.Width)
                {
                    player2.Left = player2.Left + 20;
                    calculatescore();
                    collectkey();
                    collectlife();
                    collectenergizer();
                }
               

            }
            else if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                if (player2.Left > 0)
                {
                    player2.Left = player2.Left - 20;
                    calculatescore();
                    collectkey();
                    collectlife();
                    collectenergizer();
                }
               

            }
            else if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                if (walls.Count != 0)
                {
                    if (!(player2.Bounds.IntersectsWith(walls[0].Bounds)))
                    {
                        if (player2.Top + player2.Height > 0)
                        {
                            player2.Top = player2.Top - 20;
                        }
                    }
                }
                else
                {
                    if (player2.Top + player2.Height > 0)
                    {
                        player2.Top = player2.Top - 20;
                    }
                    calculatescore();
                    collectkey();
                    collectlife();
                    collectenergizer();
                }
                
                

            }
            else if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                if (player2.Top + player2.Height <= 600)
                {
                    player2.Top = player2.Top + 20;
                    calculatescore();
                    collectkey();
                    collectlife();
                    collectenergizer();
                }
                
            }

            playerFirecurrentTime++;
            if (playerFirecurrentTime >= 110)
            {
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    if (keystatus == 1)
                    {
                        PictureBox pfire = createFire();
                        pfires.Add(pfire);
                        this.Controls.Add(pfire);
                    }
                }
            }
            movebullet();
            removewalls();
            removebullet();
            moveenemy1();
            moveenemy2();
            moveverticalenemy();
            detectplayerCollision();
            detectCollision();
            enemyFirecurrentTime++;
            if(enemyFirecurrentTime==enemyFireGenerationTime)
            {
                PictureBox enemeyfire=createEnemyBullet();
                enemyfires.Add(enemeyfire);
                this.Controls.Add(enemeyfire);
                enemyFirecurrentTime = 0;
            }
            moveenemybullet();
            livedecrease();
            collectlife(); 
            playerhealth.Left = player2.Left;
            playerhealth.Top = player2.Top +player2.Height;
            enemyhealth.Top=enemies[2].Top-enemyhealth.Height-10;
            displaylifeandscore();
            if(lives==0)
            {
                timer.Enabled = false;
                Image img = Properties.Resources.gameover;
                End newform = new End(img);
                DialogResult result = newform.ShowDialog();
                if(result== DialogResult.Yes)
                {
                    Level2 level2 = new Level2();
                    level2.Show();
                    this.Hide();
                }
               else if (result == DialogResult.No)
                {
                    this.Close();
                }
            }
            if(player2.Bounds.IntersectsWith(door.Bounds)&&score>=8)
            {

                timer.Enabled = false;
                Image img = Properties.Resources.win;
                End newform = new End(img);
                DialogResult result = newform.ShowDialog();
               
                if (result == DialogResult.Yes)
                {
                    Level2 level2 = new Level2();
                    level2.Show();
                    this.Hide();
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
        private void detectCollision()
        {
            foreach(PictureBox bullet in pfires)
            {
                foreach(PictureBox enemy in enemies)
                {
                    if(enemy.Name == "shooter")
                    {
                        if(bullet.Bounds.IntersectsWith(enemy.Bounds))
                        {
                            if (enemyhealth.Value < 0)
                            {
                                enemyhealth.Value = enemyhealth.Value - 25;
                            }
                            
                            score += 10;
                            }
                    }
                   else if(bullet.Bounds.IntersectsWith(enemy.Bounds))
                    {
                        enemy.Hide();
                        bullet.Hide();
                    }
                }

            }
        }
        private void collectenergizer()
        {
            if(player2.Bounds.IntersectsWith(energizer1.Bounds))
            {
                if (playerhealth.Value < 100)
                {
                    playerhealth.Value += 20;
                   
                }
                energizer1.Hide();


            }
           if(player2.Bounds.IntersectsWith(energizer2.Bounds))
            {
                if (playerhealth.Value < 100)
                {
                    playerhealth.Value += 20;
                   
                }
                energizer2.Hide();
            }
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
            foreach(PictureBox enemy in enemies)
            {
                if (enemy.Bounds.IntersectsWith(player2.Bounds))
                {
                    if (playerhealth.Value > 0)
                    {
                        playerhealth.Value = playerhealth.Value - 20;
                        break;
                    }
                 
                }

            }
        }

        private void livedecrease()
        {
            if(playerhealth.Value==0)
            {
                lives--;
                playerhealth.Value = 100;
            }
        }
        private void collectlife()
        {
            if(player2.Bounds.IntersectsWith(life.Bounds))
            {
                lives += 5;
                life.Hide();
                this.Controls.Remove(life);
            }
        }
        private void collectkey()
        {
            if (player2.Bounds.IntersectsWith(key.Bounds))
            {
                keystatus=1;
                key.Hide();
                Controls.Remove(key);
            }
        }
        private void moveenemybullet()
        {
            foreach(PictureBox fire in enemyfires)
            {
                fire.Top = fire.Top + 15;
            }
        }
        private PictureBox createEnemyBullet()
        {
            PictureBox pfire = new PictureBox();
            Image img = LockedDoor.Properties.Resources.enemybullet;
            pfire.Image = img;
            pfire.Width = img.Width;
            pfire.Height = img.Height;
            pfire.BackColor = Color.Transparent;
            pfire.Left = enemies[2].Left + 36;
            pfire.Top = enemies[2].Top+60;
            pfire.SizeMode = PictureBoxSizeMode.StretchImage;
            return pfire;
        }
        private void removewalls()
        {
        foreach (PictureBox fire in pfires)
            {
            foreach (PictureBox wall in walls)
            {
                if (wall.Bounds.IntersectsWith(fire.Bounds))
                {
                    wall.Hide();
                    pfires.Remove(fire);
                    fire.Hide();
                    fire.Visible = false;
                    walls.Remove(wall);
                    this.Controls.Remove(wall);
                    this.Controls.Remove(fire);
                    flag = true;
                    break;
                }

            }
            if (flag == true)
            {
                break;
            }
        }
        }
        private void moveenemy1()
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
        private void moveenemy2()
        {
            if (enemiesDirection[1] == "Left")
            {
                enemies[1].Left = enemies[1].Left - 15;

            }
            else if (enemiesDirection[1] == "Right")
            {
                enemies[1].Left = enemies[1].Left + 15;

            }
            if (enemies[1].Left <= 0)
            {
                enemiesDirection.Insert(1, "Right");
            }
            if (enemies[1].Left + enemies[1].Width >= this.Width)
            {
                enemiesDirection.Insert(1, "Left");
            }
        }
        private void moveverticalenemy()
        {
            if (verticalenemeydirection == "Up")
            {
                enemies[2].Top = enemies[2].Top - 15;

            }
            else if (verticalenemeydirection == "Down")
            {
                enemies[2].Top = enemies[2].Top + 15;

            }
            if (walls.Count==0)
            {
                if (enemies[2].Top <=0)
                {
                    verticalenemeydirection = "Down";
                }
            }
            else if (walls[0].Bounds.IntersectsWith(enemies[2].Bounds))
            {
                verticalenemeydirection = "Down";
            }
            if (enemies[2].Top + enemies[2].Height >= this.Height)
            {
                verticalenemeydirection = "Up";
            }
        }
        private void player_Click(object sender, EventArgs e)
        {

        }
        private void movebullet()
        {
            foreach (PictureBox bullet in pfires)
            {
                bullet.Top = bullet.Top - 20;
            }
        }
        private void removebullet()
        {
            for (int i = 0; i < pfires.Count; i++)
            {
                if (pfires[i].Bottom < 0)
                {
                    pfires.Remove(pfires[i]);
                }
            }
            for (int i = 0; i < enemyfires.Count; i++)
            {
                if (enemyfires[i].Top >=this.Height || enemyfires[i].Visible==false)
                {
                    enemyfires.Remove(enemyfires[i]);
                }
            }

        }

        private void key_Click(object sender, EventArgs e)
        {

        }
    }
}
