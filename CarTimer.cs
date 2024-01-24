using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDraft
{
    public class CarTimer:Timer
    {
        public delegate void CarMovementHandler(object sender, Point movement);
        public event CarMovementHandler CarMovementTicked;
        private Point stepMovement;

        public void Start(int X, int Y)
        {
            stepMovement = new Point(X, Y);
            base.Start();
        }

        protected override void OnTick(EventArgs e)
        {
            CarMovementTicked?.Invoke(this, stepMovement);
        }
    }
}
