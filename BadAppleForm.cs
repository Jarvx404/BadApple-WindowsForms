using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadApple
{
    public partial class BadAppleForm : Form
    {
        //Pretty bad code ngl

        List<Bitmap> videoFrame = new List<Bitmap>();
        Button[,] pixels;

        public void loadFrames()
        {
            //load the frames from the frames folder (it's already splitted)
            //TODO: maybe make a splitter into frames

            string frameLocation = "./res/ezgif-frame-";
            string frameIndex = "";

            for(int i=1; i <= 200; i += 1)
            {
                if (i < 10)
                    frameIndex = frameLocation + "00";
                else if (i >= 10 && i < 100)
                    frameIndex = frameLocation + "0";
                else
                    frameIndex = frameLocation;

                frameIndex= frameIndex + i.ToString() + ".jpg";
                videoFrame.Add(new Bitmap(Image.FromFile(frameIndex)));
            }
        }

        public void getButtonsReady()
        {
            //Generates the button matrix 

            for(int i=0; i < 18; i+=1)
                for(int j=0; j < 13; j+=1)
                {
                    pixels[i, j] = new Button();
                    pixels[i, j].Width = pixels[i, j].Height = 24;
                    pixels[i,j].Location = new Point(i*24,j*24);

                    //Adds button to form controls
                    this.Controls.Add(pixels[i,j]);
                }
        }

        
        public bool bestColor(Bitmap bmp, int x, int y)
        {
            //Creates 100 pixel groups and takes the color that it encounter the most
            int totalSize = 100;
            int cBlack = 0;


            for (int i = x; i < x + 10; i += 1)
                for (int j = y; j < y + 10; j += 1)
                    if (bmp.GetPixel(j, i).GetBrightness() < 0.8)
                        cBlack += 1; //Adds black pixel if the brightness coresponds
                

            if (totalSize - cBlack > (totalSize / 2))
                return true; //W
            return false; //B     
        }
        public Bitmap frameKiller(Bitmap bmp)
        {
            //Creates the smaller map
            Bitmap smallerFrame = new Bitmap(20, 15); // /10 map

            int smi = 0, smj = 0;

            

            for (int i = 1; i < bmp.Height-10; i += 10)
            {
                smj = 0;
                for (int j = 1; j < bmp.Width-10; j += 10)
                {

                    Color clr = bestColor(bmp, i, j) ? Color.White : Color.Black;
                    smallerFrame.SetPixel(smj, smi, clr);
                    smj += 1;
                }
                smi += 1;
            }

            return smallerFrame;
        }
        
        public void updateButtons(Bitmap bmp)
        {
            for(int i = 0; i < 18; i += 1)
                for(int j=0; j < 13; j += 1)
                    pixels[i,j].BackColor = bmp.GetPixel(i, j);
        }

        
        PictureBox pb;
        int frm = 0;
        private void aniTick(object sender, EventArgs e)
        {
            //goes trough each frame and updates buttons
            if (frm < videoFrame.ToArray().Length-1)
            { frm += 1; updateButtons(frameKiller(videoFrame[frm])); }
            else
            { aniTimer.Stop(); return; }
            
        }

        public BadAppleForm()
        {
            pixels = new Button[19, 14];
            InitializeComponent();
            enBox.Hide();
            loadFrames();
            getButtonsReady();
            aniTimer.Start();
        }

      

    }
}
