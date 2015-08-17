using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Frontier_Based_Exploration
{
    public partial class Form1 : Form
    {
        #region variables
        
        Bitmap input_pic = null;
        Bitmap frontier_pic = null;
        Bitmap edge_pic = null;
        double[,] cells=new double[400,400];//store the occupancy probability
        double[,] copy = new double[400, 400];//a copy of occupancy probability
        int[,] d = new int[400, 400];
        int x_pix = 400;//number of pixels in X
        int y_pix = 400;//number of pixels in y
        double prior = 0.5;//prior probability
        int defaultNumberOfFrontiers = 100; 
        int numberOfFrontiers = 0;
        int numberOfGroups = 0;
        Graphics graphic;//for Drawing
        int pos_X = -1;
        int pos_Y = -1;
        Queue<int> x_queue = new Queue<int>(1000);
        Queue<int> y_queue = new Queue<int>(1000);

        #endregion

        #region Costructor

        public Form1()
        {
            InitializeComponent();
            
            for (int i = 0; i < x_pix; i++)
            {
                for (int j = 0; j < y_pix; j++)
                {
                    cells[i, j] = 0.5;
                }
            }
            
            graphic = this.CreateGraphics();

            for (int i = 0; i < 400; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    d[i, j] = 0;
                }
            }
         }

        #endregion

        #region Drawing
        //Draw Robot Position
        private void drawRobotPosition(Bitmap pic,int x, int y, Color color)
        {
            for (int i = -5; i < 5; i++)
            {
                pic.SetPixel(x, y + i, color);
            }
            for (int i = 0; i < 5; i++)
            {
                pic.SetPixel(x+i, y + 5, color);
            }
        }

        #region drawRoad
        //Draw road between two points
        private void drawRoad(int x1, int y1, int x2, int y2)
        {
            double m = (y2 - y1) / (x2 - x1);
            double j;
            for (int i = x1; i < x2; i++)
            {
                j = m * i + y1;
                frontier_pic.SetPixel(i, (int)j, Color.Red);
            }
        }

        private void drawRoad(Cartesian pos1, Cartesian pos2)
        {
            double m = (pos2.y - pos2.y) / (pos2.x - pos1.x);
            double j;
            for (int i = pos1.x; i < pos2.x; i++)
            {
                j = m * i + pos1.y;
                frontier_pic.SetPixel(i, (int)j, Color.Red);
            }
        }
        #endregion

        //draw a sign for frontier
        private void drawFrontiers(Bitmap pic,int x,int y,Color color)
        {
            for (int i = -5; i < 5; i++)
            {
                pic.SetPixel(x + i, y, color);
            }
            for (int i = -5; i < 5; i++)
            {
                pic.SetPixel(x, y + i, color);
            }
        }

        #endregion

        #region Image Processing

        //Apply Prewitt Filter for Edge Detection
        private Bitmap applyFilter(Bitmap  pic)
        {
            Bitmap temp = new Bitmap(pic);
            Bitmap result = null;
            
            int num=0;
            int num2 = 0;
            
            #region 2*2 for , replace the black to white
            for (int i = 0; i < x_pix; i++)
            {
                for (int j = 0; j < y_pix; j++)
                {
                    if (colorDetecting(temp,i,j) == 0)
                    {
                        temp.SetPixel(i, j, Color.White);
                    }
                }
            }
            #endregion

            result = temp.PrewittFilter(false);

            Bitmap result2 = new Bitmap(400, 400);

            #region Set gray color for all of the result2's pixels
            for (int i = 0; i < x_pix; i++)
            {
                for (int j = 0; j < y_pix; j++)
                {
                    result2.SetPixel(i, j, Color.Gray);
                }
            }
            #endregion

            #region Check the edges & find frontiers
            for (int i = 0; i < x_pix; i++)
            {
                for (int j = 0; j < y_pix; j++)
                {
                    if (!(colorDetecting(result,i,j) == 0))
                    {
                        num2++;
                        if (cells[i, j] < 0.5)
                        {
                            result2.SetPixel(i, j, Color.White);
                            num++;
                        }
                    }
                }
            }
            #endregion
            
            edge_pic = result;
            edgeDetection_pictureBox.Image = result;
            return result2;
        }
        
        private Cartesian detectFirstWhitePoint(Bitmap pic)
        {
            Cartesian output = new Cartesian(-1, -1);
            bool check = false;
            for (int i = 0; i < pic.Width; i++)
            {
                for (int j = 0; j < pic.Height; j++)
                {
                    if (d[i,j] == 1)             /*if (colorDetecting(pic, i, j) == 1)*/
                    {
                        output.x = i;
                        output.y = j;
                        check = true;
                        break;
                    }
                }
                if (check)
                    break;
            }
            return output;
        }

        private bool detectGroups(Bitmap pic)
        {
            Cartesian resource = new Cartesian();
            Cartesian temp = new Cartesian();
            resource = detectFirstWhitePoint(pic);
            if ((resource.x < 0) || (resource.y < 0))
            {
                return false;
            }
            x_queue.Enqueue(resource.x);
            y_queue.Enqueue(resource.y);
            while (x_queue.Count > 0 && y_queue.Count > 0)
            {
                temp.x = x_queue.Dequeue();
                temp.y = y_queue.Dequeue();
                d[temp.x, temp.y] = numberOfGroups;
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (d[temp.x + i, temp.y + j] == 1)
                        {
                            x_queue.Enqueue(temp.x + i);
                            y_queue.Enqueue(temp.y + j);
                        }
                    }
                }
            }
            numberOfGroups++;
            return true;
        }
        
        private int colorDetecting(Bitmap pic, int x, int y)
        {
            double sum = (pic.GetPixel(x, y).R + pic.GetPixel(x, y).G + pic.GetPixel(x, y).B) / 3;
            int temp = -1;
            if (sum < 2)
                temp = 0;
            else if (sum > 252)
                temp = 1;
            return temp;
        }

        //Read all of pixels from a picture & set the probability of cells
        private void getAllPixels(Bitmap pic)
        {
            double check = 0;
            for (int i = 0; i < x_pix; i++)
            {
                for (int j = 0; j < y_pix; j++)
                {
                    check = colorDetecting(pic, i, j);
                    if (check == 0)
                    {
                        cells[i, j] = 0.9;
                    }
                    else if (check == 1)
                    {
                        cells[i, j] = 0.1;
                    }
                }
            }
        }

        #endregion

        #region Button Functions

        private void set_button_Click(object sender, EventArgs e)
        {
            pos_X = Convert.ToInt16(x_textBox.Text);
            pos_Y = Convert.ToInt16(y_textBox.Text);
            x_textBox.Visible = false;
            y_textBox.Visible = false;
            set_button.Visible = false;
            x_label.Visible = false;
            y_label.Visible = false;
            nextImage_button.Enabled = true;
        }

        private void nextImage_button_Click(object sender, EventArgs e)
        {
            Cartesian[] frontier;
            group[] frontierGroups;
            numberOfFrontiers = 0;
            numberOfGroups = 0;
            #region Open A Picture
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select next image file.";
            ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(ofd.FileName);
                input_pic = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                streamReader.Close();
            }
            #endregion
            numberOfFrontiers = 0;
            numberOfGroups = 0;
            frontier = new Cartesian[defaultNumberOfFrontiers];
            for (int i = 0; i < defaultNumberOfFrontiers; i++)
            {
                frontier[i] = new Cartesian(0, 0);
            }

            frontierGroups = new group[defaultNumberOfFrontiers];
            for (int i = 0; i < defaultNumberOfFrontiers; i++)
            {
                frontierGroups[i] = new group(20);
            } 
            Bitmap temp_input = new Bitmap(input_pic);
            drawRobotPosition(temp_input, pos_X, pos_Y, Color.Purple);
            input_pictureBox.Image = temp_input;
            getAllPixels(input_pic);
            frontier_pic = applyFilter(input_pic);
            frontier_pictureBox.Image = frontier_pic;
            bool truth = true;
            for (int i = 0; i < frontier_pic.Width; i++)
            {
                for (int j = 0; j < frontier_pic.Height; j++)
                {
                    d[i, j] = 0;
                }
            } 
            for (int i = 0; i < frontier_pic.Width; i++)
            {
                for (int j = 0; j < frontier_pic.Height; j++)
                {
                    if (colorDetecting(frontier_pic, i, j) == 1)
                    {
                        d[i, j] = 1;
                    }
                }
            }
            numberOfGroups = 2;
            do
            {
                truth = detectGroups(frontier_pic);
                x_queue.Clear();
                y_queue.Clear();
             }
            while (truth);
            #region  reGroup(frontier_pic);
            for (int k = 2; k < numberOfGroups; k++)
            {
                for (int i = 0; i < frontier_pic.Width; i++)
                {
                    for (int j = 0; j < frontier_pic.Height; j++)
                    {
                        if (d[i, j] == k)
                        {
                            frontierGroups[k - 2].setPoint(i, j);
                        }
                    }
                }

            }
            #endregion
            numberOfGroups = numberOfGroups - 2;
            #region detectFrontier(frontier_pic);
            for (int i = 0; i < numberOfGroups; i++)
            {
                frontier[numberOfFrontiers] = frontierGroups[i].returnRandomPoint();
                drawFrontiers(frontier_pic, frontier[numberOfFrontiers].x, frontier[numberOfFrontiers].y, Color.Red);
                numberOfFrontiers++;
            }
            #endregion
            #region selectFrontier(frontier_pic);
            Cartesian pos = new Cartesian(pos_X, pos_Y);
            double distance = 5000;
            Cartesian temp = new Cartesian(-1, -1);
            int index = -1;
            for (int i = 0; i < numberOfFrontiers; i++)
            {
                if (!frontier[i].check_parameter)
                {
                    if (distance > pos.distanceCalculator(frontier[i]))
                    {
                        distance = pos.distanceCalculator(frontier[i]);
                        temp.x = frontier[i].x;
                        temp.y = frontier[i].y;
                        index = i;
                    }
                }
            }
            if (temp.x == -1 || temp.y == -1)
                MessageBox.Show("Finish");
            else
            {
                pos_X = temp.x; pos_Y = temp.y;
                frontier[index].check();
                drawFrontiers(frontier_pic, pos_X, pos_Y, Color.Blue);
            }
            #endregion
        }
            
        #endregion
    }
}