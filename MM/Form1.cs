using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MM
{
    public partial class Form1 : Form
    {
        public int ronde = 1;
        public int error = 0;

        public List<string> code = new List<string>();
        public List<string> solution = new List<string>();
        public List<string> guess = new List<string>() { "Blanco", "Blanco", "Blanco", "Blanco" };
        


        public Form1()
        {
            InitializeComponent();
        }



        private void validate_Click(object sender, EventArgs e)
        {
            FillGuess();

            ValidateGuess();
            if(error==0)
            {
                DrawValidation();
                ronde++;
                lbloutput.Visible = false;
            }
            else
            {
                if(error==1)
                {
                    lbloutput.Text = "Do not leave any pin empty.";
                    lbloutput.Visible = true;
                }

                if(error==2)
                {
                    lbloutput.Text = "Choose a different color for each pin";
                    lbloutput.Visible = true;
                }
            }
            


        }

        private void startgame_Click(object sender, EventArgs e)
        {
            //IN GEVAL VAN RESTART, ALLES CLEAREN
            RestartGame();


            //eerste rij zichtbaar
            label1.Visible = true;
            R1K1.Visible = true;
            R1K2.Visible = true;
            R1K3.Visible = true;
            R1K4.Visible = true;

            //Start knop weg & andere knoppen zichtbaar
            startgame.Visible = false;
            validate.Visible = true;
            end.Visible = true;

            //Genereer een code
            GenerateCode();
        }

        private void RestartGame()
        {
            ronde = 1;
            label1.Visible = false;
            R1K1.Visible = false;
            R1K2.Visible = false;
            R1K3.Visible = false;
            R1K4.Visible = false;
            label2.Visible = false;
            R2K1.Visible = false;
            R2K2.Visible = false;
            R2K3.Visible = false;
            R2K4.Visible = false;
            label3.Visible = false;
            R3K1.Visible = false;
            R3K2.Visible = false;
            R3K3.Visible = false;
            R3K4.Visible = false;
            label4.Visible = false;
            R4K1.Visible = false;
            R4K2.Visible = false;
            R4K3.Visible = false;
            R4K4.Visible = false;
            label5.Visible = false;
            R5K1.Visible = false;
            R5K2.Visible = false;
            R5K3.Visible = false;
            R5K4.Visible = false;
            label6.Visible = false;
            R6K1.Visible = false;
            R6K2.Visible = false;
            R6K3.Visible = false;
            R6K4.Visible = false;
            label7.Visible = false;
            R7K1.Visible = false;
            R7K2.Visible = false;
            R7K3.Visible = false;
            R7K4.Visible = false;
            label8.Visible = false;
            R8K1.Visible = false;
            R8K2.Visible = false;
            R8K3.Visible = false;
            R8K4.Visible = false;
            label9.Visible = false;
            R9K1.Visible = false;
            R9K2.Visible = false;
            R9K3.Visible = false;
            R9K4.Visible = false;
            label10.Visible = false;
            R10K1.Visible = false;
            R10K2.Visible = false;
            R10K3.Visible = false;
            R10K4.Visible = false;
            label11.Visible = false;
            R11K1.Visible = false;
            R11K2.Visible = false;
            R11K3.Visible = false;
            R11K4.Visible = false;
            label12.Visible = false;
            R12K1.Visible = false;
            R12K2.Visible = false;
            R12K3.Visible = false;
            R12K4.Visible = false;


            R1K1.BackColor = Color.Empty;
            R1K2.BackColor = Color.Empty;
            R1K3.BackColor = Color.Empty;
            R1K4.BackColor = Color.Empty;

            R2K1.BackColor = Color.Empty;
            R2K2.BackColor = Color.Empty;
            R2K3.BackColor = Color.Empty;
            R2K4.BackColor = Color.Empty;

            R3K1.BackColor = Color.Empty;
            R3K2.BackColor = Color.Empty;
            R3K3.BackColor = Color.Empty;
            R3K4.BackColor = Color.Empty;

            R4K1.BackColor = Color.Empty;
            R4K2.BackColor = Color.Empty;
            R4K3.BackColor = Color.Empty;
            R4K4.BackColor = Color.Empty;

            R5K1.BackColor = Color.Empty;
            R5K2.BackColor = Color.Empty;
            R5K3.BackColor = Color.Empty;
            R5K4.BackColor = Color.Empty;

            R6K1.BackColor = Color.Empty;
            R6K2.BackColor = Color.Empty;
            R6K3.BackColor = Color.Empty;
            R6K4.BackColor = Color.Empty;

            R7K1.BackColor = Color.Empty;
            R7K2.BackColor = Color.Empty;
            R7K3.BackColor = Color.Empty;
            R7K4.BackColor = Color.Empty;

            R8K1.BackColor = Color.Empty;
            R8K2.BackColor = Color.Empty;
            R8K3.BackColor = Color.Empty;
            R8K4.BackColor = Color.Empty;

            R9K1.BackColor = Color.Empty;
            R9K2.BackColor = Color.Empty;
            R9K3.BackColor = Color.Empty;
            R9K4.BackColor = Color.Empty;

            R10K1.BackColor = Color.Empty;
            R10K2.BackColor = Color.Empty;
            R10K3.BackColor = Color.Empty;
            R10K4.BackColor = Color.Empty;

            R11K1.BackColor = Color.Empty;
            R11K2.BackColor = Color.Empty;
            R11K3.BackColor = Color.Empty;
            R11K4.BackColor = Color.Empty;

            R12K1.BackColor = Color.Empty;
            R12K2.BackColor = Color.Empty;
            R12K3.BackColor = Color.Empty;
            R12K4.BackColor = Color.Empty;

            R1S1.BackColor= Color.Empty;
            R1S1.Visible = false;
            R1S2.BackColor = Color.Empty;
            R1S2.Visible = false;
            R1S3.BackColor = Color.Empty;
            R1S3.Visible = false;
            R1S4.BackColor = Color.Empty;
            R1S4.Visible = false;

            R2S1.BackColor = Color.Empty;
            R2S1.Visible = false;
            R2S2.BackColor = Color.Empty;
            R2S2.Visible = false;
            R2S3.BackColor = Color.Empty;
            R2S3.Visible = false;
            R2S4.BackColor = Color.Empty;
            R2S4.Visible = false;

            R3S1.BackColor = Color.Empty;
            R3S1.Visible = false;
            R3S2.BackColor = Color.Empty;
            R3S2.Visible = false;
            R3S3.BackColor = Color.Empty;
            R3S3.Visible = false;
            R3S4.BackColor = Color.Empty;
            R3S4.Visible = false;

            R4S1.BackColor = Color.Empty;
            R4S1.Visible = false;
            R4S2.BackColor = Color.Empty;
            R4S2.Visible = false;
            R4S3.BackColor = Color.Empty;
            R4S3.Visible = false;
            R4S4.BackColor = Color.Empty;
            R4S4.Visible = false;

            R5S1.BackColor = Color.Empty;
            R5S1.Visible = false;
            R5S2.BackColor = Color.Empty;
            R5S2.Visible = false;
            R5S3.BackColor = Color.Empty;
            R5S3.Visible = false;
            R5S4.BackColor = Color.Empty;
            R5S4.Visible = false;

            R6S1.BackColor = Color.Empty;
            R6S1.Visible = false;
            R6S2.BackColor = Color.Empty;
            R6S2.Visible = false;
            R6S3.BackColor = Color.Empty;
            R6S3.Visible = false;
            R6S4.BackColor = Color.Empty;
            R6S4.Visible = false;

            R7S1.BackColor = Color.Empty;
            R7S1.Visible = false;
            R7S2.BackColor = Color.Empty;
            R7S2.Visible = false;
            R7S3.BackColor = Color.Empty;
            R7S3.Visible = false;
            R7S4.BackColor = Color.Empty;
            R7S4.Visible = false;

            R8S1.BackColor = Color.Empty;
            R8S1.Visible = false;
            R8S2.BackColor = Color.Empty;
            R8S2.Visible = false;
            R8S3.BackColor = Color.Empty;
            R8S3.Visible = false;
            R8S4.BackColor = Color.Empty;
            R8S4.Visible = false;

            R9S1.BackColor = Color.Empty;
            R9S1.Visible = false;
            R9S2.BackColor = Color.Empty;
            R9S2.Visible = false;
            R9S3.BackColor = Color.Empty;
            R9S3.Visible = false;
            R9S4.BackColor = Color.Empty;
            R9S4.Visible = false;

            R10S1.BackColor = Color.Empty;
            R10S1.Visible = false;
            R10S2.BackColor = Color.Empty;
            R10S2.Visible = false;
            R10S3.BackColor = Color.Empty;
            R10S3.Visible = false;
            R10S4.BackColor = Color.Empty;
            R10S4.Visible = false;

            R11S1.BackColor = Color.Empty;
            R11S1.Visible = false;
            R11S2.BackColor = Color.Empty;
            R11S2.Visible = false;
            R11S3.BackColor = Color.Empty;
            R11S3.Visible = false;
            R11S4.BackColor = Color.Empty;
            R11S4.Visible = false;

            R12S1.BackColor = Color.Empty;
            R12S1.Visible = false;
            R12S2.BackColor = Color.Empty;
            R12S2.Visible = false;
            R12S3.BackColor = Color.Empty;
            R12S3.Visible = false;
            R12S4.BackColor = Color.Empty;
            R12S4.Visible = false;
        }

        private void GenerateCode()
        {
            
            List<string> kleuren = new List<string> { "Red", "Blue", "Green", "Yellow", "White", "Black" };
            int n = kleuren.Count;
            Random rnd = new Random();

            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                string value = kleuren[k];
                kleuren[k] = kleuren[n];
                kleuren[n] = value;
            }


            //Debug kleuren

            code.Add(kleuren[0]);
            code.Add(kleuren[1]);
            code.Add(kleuren[2]);
            code.Add(kleuren[3]);

            //show colors for debugging purps

            Color csol1 = Color.FromName(kleuren[0]);
            Color csol2 = Color.FromName(kleuren[1]);
            Color csol3 = Color.FromName(kleuren[2]);
            Color csol4 = Color.FromName(kleuren[3]);

            sol1.BackColor = csol1;
            sol2.BackColor = csol2;
            sol3.BackColor = csol3;
            sol4.BackColor = csol4;

            sol1.Visible = false;
            sol2.Visible = false;
            sol3.Visible = false;
            sol4.Visible = false;

            /*  
              sol1.Visible = true;
              sol2.Visible = true;
              sol3.Visible = true;
              sol4.Visible = true;*/


        }

        private void ToggleColor(object sender)
        {
            Button kleurknop = (Button)sender;
            kleurknop.FlatStyle = FlatStyle.Flat;
            switch(kleurknop.BackColor.Name)
            {
                case ("Control"):
                    kleurknop.BackColor = Color.Red;
                    break;
                case ("Black"):
                    kleurknop.BackColor = Color.Red;
                    break;
                case ("Red"):
                    kleurknop.BackColor = Color.Blue;
                    break;
                case ("Blue"):
                    kleurknop.BackColor = Color.Green;
                    break;
                case ("Green"):
                     kleurknop.BackColor = Color.Yellow;
                     break;
                case ("Yellow"):
                    kleurknop.BackColor = Color.White;
                    break;
                case ("White"):
                    kleurknop.BackColor = Color.Black;
                    break;
                default:
                    break;
            }




        }

        private void FillGuess()
        {
            string K1="";
            string K2="";
            string K3="";
            string K4="";


            switch(ronde)
                {
                case 1:
                    K1 = R1K1.BackColor.Name;
                    K2 = R1K2.BackColor.Name;
                    K3 = R1K3.BackColor.Name;
                    K4 = R1K4.BackColor.Name;
                    break;
                case 2:
                    K1 = R2K1.BackColor.Name;
                    K2 = R2K2.BackColor.Name;
                    K3 = R2K3.BackColor.Name;
                    K4 = R2K4.BackColor.Name;
                    break;
                case 3:
                    K1 = R3K1.BackColor.Name;
                    K2 = R3K2.BackColor.Name;
                    K3 = R3K3.BackColor.Name;
                    K4 = R3K4.BackColor.Name;
                    break;
                case 4:
                    K1 = R4K1.BackColor.Name;
                    K2 = R4K2.BackColor.Name;
                    K3 = R4K3.BackColor.Name;
                    K4 = R4K4.BackColor.Name;
                    break;
                case 5:
                    K1 = R5K1.BackColor.Name;
                    K2 = R5K2.BackColor.Name;
                    K3 = R5K3.BackColor.Name;
                    K4 = R5K4.BackColor.Name;
                    break;
                case 6:
                    K1 = R6K1.BackColor.Name;
                    K2 = R6K2.BackColor.Name;
                    K3 = R6K3.BackColor.Name;
                    K4 = R6K4.BackColor.Name;
                    break;
                case 7:
                    K1 = R7K1.BackColor.Name;
                    K2 = R7K2.BackColor.Name;
                    K3 = R7K3.BackColor.Name;
                    K4 = R7K4.BackColor.Name;
                    break;
                case 8:
                    K1 = R8K1.BackColor.Name;
                    K2 = R8K2.BackColor.Name;
                    K3 = R8K3.BackColor.Name;
                    K4 = R8K4.BackColor.Name;
                    break;
                case 9:
                    K1 = R9K1.BackColor.Name;
                    K2 = R9K2.BackColor.Name;
                    K3 = R9K3.BackColor.Name;
                    K4 = R9K4.BackColor.Name;
                    break;
                case 10:
                    K1 = R10K1.BackColor.Name;
                    K2 = R10K2.BackColor.Name;
                    K3 = R10K3.BackColor.Name;
                    K4 = R10K4.BackColor.Name;
                    break;
                case 11:
                    K1 = R11K1.BackColor.Name;
                    K2 = R11K2.BackColor.Name;
                    K3 = R11K3.BackColor.Name;
                    K4 = R11K4.BackColor.Name;
                    break;
                case 12:
                    K1 = R12K1.BackColor.Name;
                    K2 = R12K2.BackColor.Name;
                    K3 = R12K3.BackColor.Name;
                    K4 = R12K4.BackColor.Name;
                    break;
            }

            guess[0] = K1;
            guess[1] = K2;
            guess[2] = K3;
            guess[3] = K4;


        }

        private void ValidateGuess()
        {
           // if(ronde>1)
           if(solution.Count > 0)
            {
                solution.RemoveAt(3);
                solution.RemoveAt(2);
                solution.RemoveAt(1);
                solution.RemoveAt(0);
            }

            error = 0;
            if (guess.Contains("Control"))
            {

                error = 1;
            }
            else
            {
                List<string> tmpsol = new List<string>();

                for (int i = 0; i < 4; i++)
                {
                    if (guess.Contains(code[i]))
                    {
                        if (guess.IndexOf(code[i]) == i)
                        {
                            tmpsol.Add("Black");
                        }
                        else
                        {
                            tmpsol.Add("White");
                        }
                    }
                    else
                    {
                        tmpsol.Add("Blanco");
                    }
                }



                for (int i = 0; i < 4; i++)
                {
                    if (tmpsol[i] == "Black")
                    {
                        solution.Add("Black");
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    if (tmpsol[i] == "White")
                    {
                        solution.Add("White");
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    if (tmpsol[i] == "Blanco")
                    {
                        solution.Add("Blanco");
                    }
                }

                //check for doubles
               for(int i=0;i<4;i++)
                {
                    for(int y=0;y<4;y++)
                    {
                        if(i!=y)
                        {
                            if (guess[i]== guess[y])
                            {
                                error = 2;
                            }
                        }
                        
                    }
                }
                
            }




            

        }

        private void DrawValidation()
        {


            switch (ronde)
            {
                case 1:
                    if (solution[0] == "Black") 
                        R1S1.BackColor = Color.Black;
                    if (solution[0] == "White") 
                        R1S1.BackColor = Color.White;
                    if(solution[0]!="Blanco")
                        R1S1.Visible = true;

                    if (solution[1] == "Black")
                        R1S2.BackColor = Color.Black;
                    if (solution[1] == "White")
                        R1S2.BackColor = Color.White;
                    if (solution[1] != "Blanco")
                        R1S2.Visible = true;

                    if (solution[2] == "Black")
                        R1S3.BackColor = Color.Black;
                    if (solution[2] == "White")
                        R1S3.BackColor = Color.White;
                    if (solution[2] != "Blanco")
                        R1S3.Visible = true;

                    if (solution[3] == "Black")
                        R1S4.BackColor = Color.Black;
                    if (solution[3] == "White")
                        R1S4.BackColor = Color.White;
                    if (solution[3] != "Blanco")
                        R1S4.Visible = true;

                    if (solution[0]=="Black"&& solution[1] == "Black" &&solution[2] == "Black" && solution[3] == "Black")
                    {
                        lbloutput.Text = "You found the code in on the first try!";
                        lbloutput.Visible = true;
                        validate.Visible = false;
                        end.Visible = false;
                        startgame.Text = "RESTART GAME?";
                        startgame.Visible = true;
                    }
                    else
                    {
                        R1K1.Click -= R1K1_Click;
                        R1K2.Click -= R1K2_Click;
                        R1K3.Click -= R1K3_Click;
                        R1K4.Click -= R1K4_Click;

                        R2K1.Visible = true;
                        R2K2.Visible = true;
                        R2K3.Visible = true;
                        R2K4.Visible = true;
                        label2.Visible = true;

                    }

                    break;
                case 2:

                    if (solution[0] == "Black")
                        R2S1.BackColor = Color.Black;
                    if (solution[0] == "White")
                        R2S1.BackColor = Color.White;
                    if (solution[0] != "Blanco")
                        R2S1.Visible = true;

                    if (solution[1] == "Black")
                        R2S2.BackColor = Color.Black;
                    if (solution[1] == "White")
                        R2S2.BackColor = Color.White;
                    if (solution[1] != "Blanco")
                        R2S2.Visible = true;

                    if (solution[2] == "Black")
                        R2S3.BackColor = Color.Black;
                    if (solution[2] == "White")
                        R2S3.BackColor = Color.White;
                    if (solution[2] != "Blanco")
                        R2S3.Visible = true;

                    if (solution[3] == "Black")
                        R2S4.BackColor = Color.Black;
                    if (solution[3] == "White")
                        R2S4.BackColor = Color.White;
                    if (solution[3] != "Blanco")
                        R2S4.Visible = true;

                    if (solution[0] == "Black" && solution[1] == "Black" && solution[2] == "Black" && solution[3] == "Black")
                    {
                        lbloutput.Text = "You found the code in " + ronde + " tries!";
                        lbloutput.Visible = true;
                        validate.Visible = false;
                        end.Visible = false;
                        startgame.Text = "RESTART GAME?";
                        startgame.Visible = true;
                        sol1.Visible = true;
                        sol2.Visible = true;
                        sol3.Visible = true;
                        sol4.Visible = true;
                    }
                    else
                    {
                        R2K1.Click -= R2K1_Click;
                        R2K2.Click -= R2K2_Click;
                        R2K3.Click -= R2K3_Click;
                        R2K4.Click -= R2K4_Click;

                        R3K1.Visible = true;
                        R3K2.Visible = true;
                        R3K3.Visible = true;
                        R3K4.Visible = true;
                        label3.Visible = true;

                    }

                    break;
                case 3:

                    if (solution[0] == "Black")
                        R3S1.BackColor = Color.Black;
                    if (solution[0] == "White")
                        R3S1.BackColor = Color.White;
                    if (solution[0] != "Blanco")
                        R3S1.Visible = true;

                    if (solution[1] == "Black")
                        R3S2.BackColor = Color.Black;
                    if (solution[1] == "White")
                        R3S2.BackColor = Color.White;
                    if (solution[1] != "Blanco")
                        R3S2.Visible = true;

                    if (solution[2] == "Black")
                        R3S3.BackColor = Color.Black;
                    if (solution[2] == "White")
                        R3S3.BackColor = Color.White;
                    if (solution[2] != "Blanco")
                        R3S3.Visible = true;

                    if (solution[3] == "Black")
                        R3S4.BackColor = Color.Black;
                    if (solution[3] == "White")
                        R3S4.BackColor = Color.White;
                    if (solution[3] != "Blanco")
                        R3S4.Visible = true;

                    if (solution[0] == "Black" && solution[1] == "Black" && solution[2] == "Black" && solution[3] == "Black")
                    {
                                                lbloutput.Text = "You found the code in " + ronde + " tries!";
                        lbloutput.Visible = true;
                        validate.Visible = false;
                        end.Visible = false;
                        startgame.Text = "RESTART GAME?";
                        startgame.Visible = true;
                        sol1.Visible = true;
                        sol2.Visible = true;
                        sol3.Visible = true;
                        sol4.Visible = true;
                    }
                    else
                    {
                        R3K1.Click -= R3K1_Click;
                        R3K2.Click -= R3K2_Click;
                        R3K3.Click -= R3K3_Click;
                        R3K4.Click -= R3K4_Click;

                        R4K1.Visible = true;
                        R4K2.Visible = true;
                        R4K3.Visible = true;
                        R4K4.Visible = true;
                        label4.Visible = true;

                    }

                    break;
                case 4:

                    if (solution[0] == "Black")
                        R4S1.BackColor = Color.Black;
                    if (solution[0] == "White")
                        R4S1.BackColor = Color.White;
                    if (solution[0] != "Blanco")
                        R4S1.Visible = true;

                    if (solution[1] == "Black")
                        R4S2.BackColor = Color.Black;
                    if (solution[1] == "White")
                        R4S2.BackColor = Color.White;
                    if (solution[1] != "Blanco")
                        R4S2.Visible = true;

                    if (solution[2] == "Black")
                        R4S3.BackColor = Color.Black;
                    if (solution[2] == "White")
                        R4S3.BackColor = Color.White;
                    if (solution[2] != "Blanco")
                        R4S3.Visible = true;

                    if (solution[3] == "Black")
                        R4S4.BackColor = Color.Black;
                    if (solution[3] == "White")
                        R4S4.BackColor = Color.White;
                    if (solution[3] != "Blanco")
                        R4S4.Visible = true;

                    if (solution[0] == "Black" && solution[1] == "Black" && solution[2] == "Black" && solution[3] == "Black")
                    {
                                                lbloutput.Text = "You found the code in " + ronde + " tries!";
                        lbloutput.Visible = true;
                        validate.Visible = false;
                        end.Visible = false;
                        startgame.Text = "RESTART GAME?";
                        startgame.Visible = true;
                        sol1.Visible = true;
                        sol2.Visible = true;
                        sol3.Visible = true;
                        sol4.Visible = true;
                    }
                    else
                    {
                        R4K1.Click -= R4K1_Click;
                        R4K2.Click -= R4K2_Click;
                        R4K3.Click -= R4K3_Click;
                        R4K4.Click -= R4K4_Click;

                        R5K1.Visible = true;
                        R5K2.Visible = true;
                        R5K3.Visible = true;
                        R5K4.Visible = true;
                        label5.Visible = true;

                    }

                    break;
                case 5:

                    if (solution[0] == "Black")
                        R5S1.BackColor = Color.Black;
                    if (solution[0] == "White")
                        R5S1.BackColor = Color.White;
                    if (solution[0] != "Blanco")
                        R5S1.Visible = true;

                    if (solution[1] == "Black")
                        R5S2.BackColor = Color.Black;
                    if (solution[1] == "White")
                        R5S2.BackColor = Color.White;
                    if (solution[1] != "Blanco")
                        R5S2.Visible = true;

                    if (solution[2] == "Black")
                        R5S3.BackColor = Color.Black;
                    if (solution[2] == "White")
                        R5S3.BackColor = Color.White;
                    if (solution[2] != "Blanco")
                        R5S3.Visible = true;

                    if (solution[3] == "Black")
                        R5S4.BackColor = Color.Black;
                    if (solution[3] == "White")
                        R5S4.BackColor = Color.White;
                    if (solution[3] != "Blanco")
                        R5S4.Visible = true;

                    if (solution[0] == "Black" && solution[1] == "Black" && solution[2] == "Black" && solution[3] == "Black")
                    {
                                                lbloutput.Text = "You found the code in " + ronde + " tries!";
                        lbloutput.Visible = true;
                        validate.Visible = false;
                        end.Visible = false;
                        startgame.Text = "RESTART GAME?";
                        startgame.Visible = true;
                        sol1.Visible = true;
                        sol2.Visible = true;
                        sol3.Visible = true;
                        sol4.Visible = true;
                    }
                    else
                    {
                        R5K1.Click -= R5K1_Click;
                        R5K2.Click -= R5K2_Click;
                        R5K3.Click -= R5K3_Click;
                        R5K4.Click -= R5K4_Click;

                        R6K1.Visible = true;
                        R6K2.Visible = true;
                        R6K3.Visible = true;
                        R6K4.Visible = true;
                        label6.Visible = true;

                    }

                    break;
                case 6:

                    if (solution[0] == "Black")
                        R6S1.BackColor = Color.Black;
                    if (solution[0] == "White")
                        R6S1.BackColor = Color.White;
                    if (solution[0] != "Blanco")
                        R6S1.Visible = true;

                    if (solution[1] == "Black")
                        R6S2.BackColor = Color.Black;
                    if (solution[1] == "White")
                        R6S2.BackColor = Color.White;
                    if (solution[1] != "Blanco")
                        R6S2.Visible = true;

                    if (solution[2] == "Black")
                        R6S3.BackColor = Color.Black;
                    if (solution[2] == "White")
                        R6S3.BackColor = Color.White;
                    if (solution[2] != "Blanco")
                        R6S3.Visible = true;

                    if (solution[3] == "Black")
                        R6S4.BackColor = Color.Black;
                    if (solution[3] == "White")
                        R6S4.BackColor = Color.White;
                    if (solution[3] != "Blanco")
                        R6S4.Visible = true;

                    if (solution[0] == "Black" && solution[1] == "Black" && solution[2] == "Black" && solution[3] == "Black")
                    {
                                                lbloutput.Text = "You found the code in " + ronde + " tries!";
                        lbloutput.Visible = true;
                        validate.Visible = false;
                        end.Visible = false;
                        startgame.Text = "RESTART GAME?";
                        startgame.Visible = true;
                        sol1.Visible = true;
                        sol2.Visible = true;
                        sol3.Visible = true;
                        sol4.Visible = true;
                    }
                    else
                    {
                        R6K1.Click -= R6K1_Click;
                        R6K2.Click -= R6K2_Click;
                        R6K3.Click -= R6K3_Click;
                        R6K4.Click -= R6K4_Click;

                        R7K1.Visible = true;
                        R7K2.Visible = true;
                        R7K3.Visible = true;
                        R7K4.Visible = true;
                        label7.Visible = true;

                    }

                    break;
                case 7:

                    if (solution[0] == "Black")
                        R7S1.BackColor = Color.Black;
                    if (solution[0] == "White")
                        R7S1.BackColor = Color.White;
                    if (solution[0] != "Blanco")
                        R7S1.Visible = true;

                    if (solution[1] == "Black")
                        R7S2.BackColor = Color.Black;
                    if (solution[1] == "White")
                        R7S2.BackColor = Color.White;
                    if (solution[1] != "Blanco")
                        R7S2.Visible = true;

                    if (solution[2] == "Black")
                        R7S3.BackColor = Color.Black;
                    if (solution[2] == "White")
                        R7S3.BackColor = Color.White;
                    if (solution[2] != "Blanco")
                        R7S3.Visible = true;

                    if (solution[3] == "Black")
                        R7S4.BackColor = Color.Black;
                    if (solution[3] == "White")
                        R7S4.BackColor = Color.White;
                    if (solution[3] != "Blanco")
                        R7S4.Visible = true;

                    if (solution[0] == "Black" && solution[1] == "Black" && solution[2] == "Black" && solution[3] == "Black")
                    {
                                                lbloutput.Text = "You found the code in " + ronde + " tries!";
                        lbloutput.Visible = true;
                        validate.Visible = false;
                        end.Visible = false;
                        startgame.Text = "RESTART GAME?";
                        startgame.Visible = true;
                        sol1.Visible = true;
                        sol2.Visible = true;
                        sol3.Visible = true;
                        sol4.Visible = true;
                    }
                    else
                    {
                        R7K1.Click -= R7K1_Click;
                        R7K2.Click -= R7K2_Click;
                        R7K3.Click -= R7K3_Click;
                        R7K4.Click -= R7K4_Click;

                        R8K1.Visible = true;
                        R8K2.Visible = true;
                        R8K3.Visible = true;
                        R8K4.Visible = true;
                        label8.Visible = true;

                    }

                    break;
                case 8:

                    if (solution[0] == "Black")
                        R8S1.BackColor = Color.Black;
                    if (solution[0] == "White")
                        R8S1.BackColor = Color.White;
                    if (solution[0] != "Blanco")
                        R8S1.Visible = true;

                    if (solution[1] == "Black")
                        R8S2.BackColor = Color.Black;
                    if (solution[1] == "White")
                        R8S2.BackColor = Color.White;
                    if (solution[1] != "Blanco")
                        R8S2.Visible = true;

                    if (solution[2] == "Black")
                        R8S3.BackColor = Color.Black;
                    if (solution[2] == "White")
                        R8S3.BackColor = Color.White;
                    if (solution[2] != "Blanco")
                        R8S3.Visible = true;

                    if (solution[3] == "Black")
                        R8S4.BackColor = Color.Black;
                    if (solution[3] == "White")
                        R8S4.BackColor = Color.White;
                    if (solution[3] != "Blanco")
                        R8S4.Visible = true;

                    if (solution[0] == "Black" && solution[1] == "Black" && solution[2] == "Black" && solution[3] == "Black")
                    {
                                                lbloutput.Text = "You found the code in " + ronde + " tries!";
                        lbloutput.Visible = true;
                        validate.Visible = false;
                        end.Visible = false;
                        startgame.Text = "RESTART GAME?";
                        startgame.Visible = true;
                        sol1.Visible = true;
                        sol2.Visible = true;
                        sol3.Visible = true;
                        sol4.Visible = true;
                    }
                    else
                    {
                        R8K1.Click -= R8K1_Click;
                        R8K2.Click -= R8K2_Click;
                        R8K3.Click -= R8K3_Click;
                        R8K4.Click -= R8K4_Click;

                        R9K1.Visible = true;
                        R9K2.Visible = true;
                        R9K3.Visible = true;
                        R9K4.Visible = true;
                        label9.Visible = true;

                    }

                    break;
                case 9:

                    if (solution[0] == "Black")
                        R9S1.BackColor = Color.Black;
                    if (solution[0] == "White")
                        R9S1.BackColor = Color.White;
                    if (solution[0] != "Blanco")
                        R9S1.Visible = true;

                    if (solution[1] == "Black")
                        R9S2.BackColor = Color.Black;
                    if (solution[1] == "White")
                        R9S2.BackColor = Color.White;
                    if (solution[1] != "Blanco")
                        R9S2.Visible = true;

                    if (solution[2] == "Black")
                        R9S3.BackColor = Color.Black;
                    if (solution[2] == "White")
                        R9S3.BackColor = Color.White;
                    if (solution[2] != "Blanco")
                        R9S3.Visible = true;

                    if (solution[3] == "Black")
                        R9S4.BackColor = Color.Black;
                    if (solution[3] == "White")
                        R9S4.BackColor = Color.White;
                    if (solution[3] != "Blanco")
                        R9S4.Visible = true;

                    if (solution[0] == "Black" && solution[1] == "Black" && solution[2] == "Black" && solution[3] == "Black")
                    {
                                                lbloutput.Text = "You found the code in " + ronde + " tries!";
                        lbloutput.Visible = true;
                        validate.Visible = false;
                        end.Visible = false;
                        startgame.Text = "RESTART GAME?";
                        startgame.Visible = true;
                        sol1.Visible = true;
                        sol2.Visible = true;
                        sol3.Visible = true;
                        sol4.Visible = true;
                    }
                    else
                    {
                        R9K1.Click -= R9K1_Click;
                        R9K2.Click -= R9K2_Click;
                        R9K3.Click -= R9K3_Click;
                        R9K4.Click -= R9K4_Click;

                        R10K1.Visible = true;
                        R10K2.Visible = true;
                        R10K3.Visible = true;
                        R10K4.Visible = true;
                        label10.Visible = true;

                    }

                    break;
                case 10:

                    if (solution[0] == "Black")
                        R10S1.BackColor = Color.Black;
                    if (solution[0] == "White")
                        R10S1.BackColor = Color.White;
                    if (solution[0] != "Blanco")
                        R10S1.Visible = true;

                    if (solution[1] == "Black")
                        R10S2.BackColor = Color.Black;
                    if (solution[1] == "White")
                        R10S2.BackColor = Color.White;
                    if (solution[1] != "Blanco")
                        R10S2.Visible = true;

                    if (solution[2] == "Black")
                        R10S3.BackColor = Color.Black;
                    if (solution[2] == "White")
                        R10S3.BackColor = Color.White;
                    if (solution[2] != "Blanco")
                        R10S3.Visible = true;

                    if (solution[3] == "Black")
                        R10S4.BackColor = Color.Black;
                    if (solution[3] == "White")
                        R10S4.BackColor = Color.White;
                    if (solution[3] != "Blanco")
                        R10S4.Visible = true;

                    if (solution[0] == "Black" && solution[1] == "Black" && solution[2] == "Black" && solution[3] == "Black")
                    {
                                                lbloutput.Text = "You found the code in " + ronde + " tries!";
                        lbloutput.Visible = true;
                        validate.Visible = false;
                        end.Visible = false;
                        startgame.Text = "RESTART GAME?";
                        startgame.Visible = true;
                        sol1.Visible = true;
                        sol2.Visible = true;
                        sol3.Visible = true;
                        sol4.Visible = true;
                    }
                    else
                    {
                        R10K1.Click -= R10K1_Click;
                        R10K2.Click -= R10K2_Click;
                        R10K3.Click -= R10K3_Click;
                        R10K4.Click -= R10K4_Click;

                        R11K1.Visible = true;
                        R11K2.Visible = true;
                        R11K3.Visible = true;
                        R11K4.Visible = true;
                        label11.Visible = true;

                    }

                    break;
                case 11:

                    if (solution[0] == "Black")
                        R11S1.BackColor = Color.Black;
                    if (solution[0] == "White")
                        R11S1.BackColor = Color.White;
                    if (solution[0] != "Blanco")
                        R11S1.Visible = true;

                    if (solution[1] == "Black")
                        R11S2.BackColor = Color.Black;
                    if (solution[1] == "White")
                        R11S2.BackColor = Color.White;
                    if (solution[1] != "Blanco")
                        R11S2.Visible = true;

                    if (solution[2] == "Black")
                        R11S3.BackColor = Color.Black;
                    if (solution[2] == "White")
                        R11S3.BackColor = Color.White;
                    if (solution[2] != "Blanco")
                        R11S3.Visible = true;

                    if (solution[3] == "Black")
                        R11S4.BackColor = Color.Black;
                    if (solution[3] == "White")
                        R11S4.BackColor = Color.White;
                    if (solution[3] != "Blanco")
                        R11S4.Visible = true;

                    if (solution[0] == "Black" && solution[1] == "Black" && solution[2] == "Black" && solution[3] == "Black")
                    {
                                                lbloutput.Text = "You found the code in " + ronde + " tries!";
                        lbloutput.Visible = true;
                        validate.Visible = false;
                        end.Visible = false;
                        startgame.Text = "RESTART GAME?";
                        startgame.Visible = true;
                        sol1.Visible = true;
                        sol2.Visible = true;
                        sol3.Visible = true;
                        sol4.Visible = true;
                    }
                    else
                    {
                        R11K1.Click -= R11K1_Click;
                        R11K2.Click -= R11K2_Click;
                        R11K3.Click -= R11K3_Click;
                        R11K4.Click -= R11K4_Click;

                        R12K1.Visible = true;
                        R12K2.Visible = true;
                        R12K3.Visible = true;
                        R12K4.Visible = true;
                        label12.Visible = true;

                    }

                    break;
                case 12:

                    if (solution[0] == "Black")
                        R12S1.BackColor = Color.Black;
                    if (solution[0] == "White")
                        R12S1.BackColor = Color.White;
                    if (solution[0] != "Blanco")
                        R12S1.Visible = true;

                    if (solution[1] == "Black")
                        R12S2.BackColor = Color.Black;
                    if (solution[1] == "White")
                        R12S2.BackColor = Color.White;
                    if (solution[1] != "Blanco")
                        R12S2.Visible = true;

                    if (solution[2] == "Black")
                        R12S3.BackColor = Color.Black;
                    if (solution[2] == "White")
                        R12S3.BackColor = Color.White;
                    if (solution[2] != "Blanco")
                        R12S3.Visible = true;

                    if (solution[3] == "Black")
                        R12S4.BackColor = Color.Black;
                    if (solution[3] == "White")
                        R12S4.BackColor = Color.White;
                    if (solution[3] != "Blanco")
                        R12S4.Visible = true;

                    if (solution[0] == "Black" && solution[1] == "Black" && solution[2] == "Black" && solution[3] == "Black")
                    {
                        lbloutput.Text = "You found the code in " + ronde + " tries!";
                        lbloutput.Visible = true;
                        validate.Visible = false;
                        end.Visible = false;
                        startgame.Text = "RESTART GAME?";
                        startgame.Visible = true;
                        sol1.Visible = true;
                        sol2.Visible = true;
                        sol3.Visible = true;
                        sol4.Visible = true;
                    }
                    else
                    {
                        R12K1.Click -= R12K1_Click;
                        R12K2.Click -= R12K2_Click;
                        R12K3.Click -= R12K3_Click;
                        R12K4.Click -= R12K4_Click;


                        lbloutput.Text = "You did not find the secret code,\n this is the solution:";
                        lbloutput.Visible = true;

                    }

                    break;
            }



        }

        //RIJ1
        private void R1K1_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R1K2_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R1K3_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R1K4_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }

        //RIJ2
        private void R2K1_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R2K2_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R2K3_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R2K4_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }

        //RIJ3
        private void R3K1_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R3K2_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R3K3_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R3K4_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }

        //RIJ4
        private void R4K1_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R4K2_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R4K3_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R4K4_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }

        //RIJ5
        private void R5K1_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R5K2_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R5K3_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R5K4_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }

        //RIJ6
        private void R6K1_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R6K2_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R6K3_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R6K4_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }

        //RIJ7
        private void R7K1_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R7K2_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R7K3_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R7K4_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }

        //RIJ8
        private void R8K1_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R8K2_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R8K3_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R8K4_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }

        //RIJ9
        private void R9K1_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R9K2_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R9K3_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R9K4_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }

        //RIJ10
        private void R10K1_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R10K2_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R10K3_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R10K4_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }

        //RIJ11
        private void R11K1_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R11K2_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R11K3_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R11K4_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }

        //RIJ12
        private void R12K1_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R12K2_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R12K3_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }
        private void R12K4_Click(object sender, EventArgs e)
        {
            ToggleColor(sender);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void end_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
