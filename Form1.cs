using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDraft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IntitalizeRace();
            this.KeyPreview = false;
            //this.Focus = true;
        }

        double ratioCar1X = 0, ratioCar2X = 0, ratioCar1Y = 0, ratioCar2Y = 0;
        private McQueen selectedCar;
        private List<McQueen> carCollection = new List<McQueen>();
        private CarTimer carMovement;
        private bool isLeftPressed = false, isRightPressed = false, isUpPressed = false, isDownPressed = false;

        private void onTicked(object sender, Point e)
        {
            if ((selectedCar.Location.X + e.X + e.X + selectedCar.Width) >= Width || (selectedCar.Location.X + e.X) <= 0 || (selectedCar.Location.Y + e.Y + e.Y + selectedCar.Height) >= Height || (selectedCar.Location.Y + e.Y) <= 0)
            {
                carMovement.Stop();
            }
            else
            {
                foreach (var Iter in carCollection)
                {
                    if (Iter.Name != selectedCar.Name && OverlapOrNot(Iter, selectedCar, e.X, e.Y))
                    {
                        carMovement.Stop();
                        return;
                    }
                }
                selectedCar.Location = new Point(selectedCar.Location.X + e.X, selectedCar.Location.Y + e.Y);
                ratioCar1X = mcQueen1.Location.X / Convert.ToDouble(Width);
                ratioCar2X = mcQueen2.Location.X / Convert.ToDouble(Width);
                ratioCar1Y = mcQueen1.Location.Y / Convert.ToDouble(Height);
                ratioCar2Y = mcQueen2.Location.Y / Convert.ToDouble(Height);
            }
        }
 

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var Iter in carCollection)
            {
                Iter.Width = this.Width / 12;
                Iter.Height = this.Height / 12;
            }
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                isUpPressed = true;
                CheckMovement();
            }
            if (e.KeyCode == Keys.Down)
            {
                isDownPressed = true;
                CheckMovement();
            }
            if (e.KeyCode == Keys.Right)
            {
                isRightPressed = true;
                CheckMovement();
            }
            if (e.KeyCode == Keys.Left)
            {
                isLeftPressed = true;
                CheckMovement();
            }
        }

        private bool OverlapOrNot(McQueen car1, McQueen car2, int X, int Y)
        {
            if (car1.Location.X >= (car2.Location.X + X) && car1.Location.X <= ((car2.Location.X + X) + car2.Width) && car1.Location.Y >= (car2.Location.Y + Y) && car1.Location.Y <= ((car2.Location.Y + Y) + car2.Height))
            {
                return true;
            }
            else if ((car1.Location.X + car1.Width) >= (car2.Location.X + X) && (car1.Location.X + car1.Width) <= ((car2.Location.X + X) + car2.Width) && car1.Location.Y >= (car2.Location.Y + Y) && car1.Location.Y <= ((car2.Location.Y + Y) + car2.Height))
            {
                return true;
            }
            else if (car1.Location.X >= (car2.Location.X + X) && car1.Location.X <= ((car2.Location.X + X) + car2.Width) && (car1.Location.Y + car1.Height) >= (car2.Location.Y + Y) && (car1.Location.Y + car1.Height) <= ((car2.Location.Y + Y) + car2.Height))
            {
                return true;
            }
            else if ((car1.Location.X + car1.Width) >= (car2.Location.X + X) && (car1.Location.X + car1.Width) <= ((car2.Location.X + X) + car2.Width) && (car1.Location.Y + car1.Height) >= (car2.Location.Y + Y) && (car1.Location.Y + car1.Height) <= ((car2.Location.Y + Y) + car2.Height))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void onCarClicked(object sender, EventArgs e)
        {
            carMovement.Stop();
            selectedCar = sender as McQueen;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            foreach (var Iter in carCollection)
            {
                Iter.Width = this.Width / 12;
                Iter.Height = this.Height / 12;
            }
            carCollection[0].Location = new Point((int)(Width * ratioCar1X), (int)(Width * ratioCar1Y));
            carCollection[1].Location = new Point((int)(Width * ratioCar2X), (int)(Width * ratioCar2Y));
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (selectedCar != null)
            {
                if (e.KeyCode == Keys.Up)
                {
                    isUpPressed = false;
                }
                if (e.KeyCode == Keys.Down)
                {
                    isDownPressed = false;
                }
                if (e.KeyCode == Keys.Right)
                {
                    isRightPressed = false;
                }
                if (e.KeyCode == Keys.Left)
                {
                    isLeftPressed = false;
                }
                carMovement.Stop();
                CheckMovement();
            }
        }

        private void CheckMovement()
        {
            int Count = 0;
            if (isUpPressed)
                Count++;
            if (isDownPressed)
                Count++;
            if (isRightPressed)
                Count++;
            if (isLeftPressed)
                Count++;

            if (Count > 2)
                return;

            if (isUpPressed && isLeftPressed)
            {
                carMovement.Start(-(Width / 120), -(Width / 120));
            }
            if (isUpPressed && isRightPressed)
            {
                carMovement.Start(Width / 120, -(Width / 120));
            }
            if (isDownPressed && isLeftPressed)
            {
                carMovement.Start(-(Width / 120), Width / 120);
            }
            if (isDownPressed && isRightPressed)
            {
                carMovement.Start(Width / 120, Width / 120);
            }

            if (Count == 2)
                return;

            if (isLeftPressed)
            {
                carMovement.Start(-(Width / 120), 0); ;
            }
            if (isUpPressed)
            {
                carMovement.Start(0, -(Width / 120));
            }
            if (isDownPressed)
            {
                carMovement.Start(0, Width / 120);
            }
            if (isRightPressed)
            {
                carMovement.Start(Width / 120, 0);
            }
        }

        private void IntitalizeRace()
        {
            carCollection.Add(mcQueen1);
            carCollection.Add(mcQueen2);

            ratioCar1X = mcQueen1.Location.X / Width;
            ratioCar2X = mcQueen2.Location.X / Width;
            ratioCar1Y = mcQueen1.Location.Y / Height;
            ratioCar2Y = mcQueen2.Location.Y / Height;

            carMovement = new CarTimer();
            carMovement.Interval = 50;
            carMovement.CarMovementTicked += onTicked;
        }
        private void Sum(int size, int[][] inputArr)
        {
            //int TopLeftCorner, BottomLeftCorner, TopRight, BottomRight, Total = 0;
            //for(int ctr=0; ctr<size; ctr++)
            //{
            //    for(int ptr=0; ptr<size; ptr++)
            //    {
            //        if(ctr==0 || ptr==0)
            //    }
            //}
        }
    }
}
