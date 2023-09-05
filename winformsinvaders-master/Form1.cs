using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    
    public partial class frmInvaders : Form
    {
        public static int numinvaders = 18;
        public bool gamestart = false;
        public bool collision = true;
        public bool enemyfire = true;
        public int movement = 5;
        public int movement2 = 40;
        public int cycle = 0;
        public int down = 0;
        public int score = 0;

        public PictureBox[] invader = new PictureBox[numinvaders + 1];

        public frmInvaders()
        {
            InitializeComponent();
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            if (gamestart)
            {
                //Move Invaders Left or Right
                for (int i = 1; i <= numinvaders; i++)
                {
                    PictureBox img = invader[i];
                    img.Left += movement;
                }

                cycle++;
                if (cycle == 62)
                {
                    movement *= -1;
                    cycle = 0;

                    // Move invaders a little down
                    for (int i = 1; i <= numinvaders; i++)
                    {
                        PictureBox img = invader[i];
                        img.Top += movement2;
                    }
                    down++;

                    if (down == 8)
                    {
                        // GameOver by Invasion
                        btnnewgame.Enabled = true;
                        gamestart = false;
                        MessageBox.Show("Game Over!\nYou Lose");
                        Shot1.Visible = false;
                        enemyshot.Visible = false;
                        timer1.Enabled = false;
                        Application.DoEvents();
                    }
                }
            }
        }

        // Reset Routine
        public void btnNovoJogo_Click(object sender, EventArgs e)
        {
            if (gamestart == false)
            {
                inv1.Visible = true;
                inv2.Visible = true;
                inv3.Visible = true;
                inv4.Visible = true;
                inv5.Visible = true;
                inv6.Visible = true;
                inv7.Visible = true;
                inv8.Visible = true;
                inv9.Visible = true;
                inv10.Visible = true;
                inv11.Visible = true;
                inv12.Visible = true;
                inv13.Visible = true;
                inv14.Visible = true;
                inv15.Visible = true;
                inv16.Visible = true;
                inv17.Visible = true;
                inv18.Visible = true;

                inv1.Top = 16;
                inv2.Top = 16;
                inv3.Top = 16;
                inv4.Top = 16;
                inv5.Top = 16;
                inv6.Top = 16;
                inv7.Top = 73;
                inv8.Top = 73;
                inv9.Top = 73;
                inv10.Top = 73;
                inv11.Top = 73;
                inv12.Top = 73;
                inv13.Top = 130;
                inv14.Top = 130;
                inv15.Top = 130;
                inv16.Top = 130;
                inv17.Top = 130;
                inv18.Top = 130;

                inv1.Left = 12;
                inv2.Left = 93;
                inv3.Left = 171;
                inv4.Left = 247;
                inv5.Left = 325;
                inv6.Left = 404;
                inv7.Left = 28;
                inv8.Left = 109;
                inv9.Left = 187;
                inv10.Left = 263;
                inv11.Left = 341;
                inv12.Left = 420;
                inv13.Left = 12;
                inv14.Left = 93;
                inv15.Left = 171;
                inv16.Left = 247;
                inv17.Left = 325;
                inv18.Left = 404;
                movement = 5;
                movement2 = 40;
                cycle = 0;
                down = 0;
                score = 0;
                enemyshot.Visible = false;
                Shot1.Visible = false;
                collision = true;
                enemyfire = true;
                Defender.Left = 345;
                gamestart = true;
                timer1.Enabled = true;
                btnnewgame.Enabled = false;
                panel1.Focus();
                lblScore.Text = "Score: 0";
            }
        }

        // Player Input Routine
        public void frmInvaders_KeyPress(object sender, KeyPressEventArgs e)
        {
            int n = e.KeyChar;

            // Left
            if (gamestart && (n == 52 || n == 97) && Defender.Left > 25)
            {
                Defender.Left -= 15;
            }

            // Right
            if (gamestart && (n == 54 || n == 100) && Defender.Left < 720)
            {
                Defender.Left += 15;
            }

            // Shoot
            if (gamestart && collision && n == 32 && ((Defender.Left < 80) || ((Defender.Left > 230) && (Defender.Left < 490)) || (Defender.Left > 630)))
            {
                enemyshot.Left = Defender.Left + 18;
                enemyshot.Top = Defender.Top - 25;
                enemyshot.Visible = true;
                collision = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (gamestart)
            {
                // If the player has shooted
                if (enemyshot.Visible == true)
                {
                    // Move the player shoot
                    enemyshot.Top -= 10;

                    // Check if player shot collides with any alive Invader
                    for (int j = 1; j <= numinvaders; j++)
                    {
                        PictureBox img = invader[j];
                        if (img.Visible == true)
                        {
                            if (Math.Abs(img.Left - enemyshot.Left) < 30 && Math.Abs(img.Top - enemyshot.Top) < 10)
                            {
                                img.Visible = false;
                                enemyshot.Visible = false;
                                score += 100;
                                lblScore.Text = "Score: " + score;
                                collision = true;
                                break;
                            }
                        }
                    }

                    // Destroy Shoot by reaching limit
                    if (enemyshot.Top < 25)
                    {
                        enemyshot.Visible = false;
                        collision = true;
                    }

                    // The player wins the game by killing all invaders)
                    if (score == 900)
                    {
                        MessageBox.Show("You Win!");
                        btnnewgame.Enabled = true;
                        gamestart = false;
                    }
                }

                // Invaders shoots randomly
                Random rand = new Random();
                int a = rand.Next(0, 25);

                if (enemyfire == true && a == 5)
                {
                   
                    int q = rand.Next(1, 19);
                    PictureBox img = invader[q];

                    // The shooter must be alive
                    if (img.Visible == true)
                    {
                        Shot1.Visible = true;
                        Shot1.Left = img.Left;
                        Shot1.Top = img.Top + 40;
                        enemyfire = false;
                    }
                }

                
                if (Shot1.Visible == true)
                {
                    
                    Shot1.Top += 10;

                    // Check invader shoot collision with player
                    PictureBox img = Shot1;

                   

                    // Destroys the shoot if it reaches the lower limit
                    if (Shot1.Top > 500 || ((Shot1.Top > 430) && ((Shot1.Left > 100) && (Shot1.Left < 240))) || ((Shot1.Top > 430) && ((Shot1.Left > 500) && (Shot1.Left < 630))))
                    {
                        Shot1.Visible = false;
                        enemyfire = true;
                    }

                }
            }
        }

        private void frmInvaders_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Winforms Space Invaders\nA - Left)\nD - Right)\nSpace - Shoot");

            // Invaders
            invader[1] = inv1;
            invader[2] = inv2;
            invader[3] = inv3;
            invader[4] = inv4;
            invader[5] = inv5;
            invader[6] = inv6;
            invader[7] = inv7;
            invader[8] = inv8;
            invader[9] = inv9;
            invader[10] = inv10;
            invader[11] = inv11;
            invader[12] = inv12;
            invader[13] = inv13;
            invader[14] = inv14;
            invader[15] = inv15;
            invader[16] = inv16;
            invader[17] = inv17;
            invader[18] = inv18;
        }

        private void inv16_Click(object sender, EventArgs e)
        {

        }

        private void inv2_Click(object sender, EventArgs e)
        {

        }

        private void inv6_Click(object sender, EventArgs e)
        {

        }

        private void Barrier2_Click(object sender, EventArgs e)
        {

        }
    }
}
