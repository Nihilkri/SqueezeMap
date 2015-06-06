using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqueezeMap {
	public partial class Form1 : Form {
		#region Variables
		Graphics gb, gf; Bitmap gi;
		int fx, fy, fx2, fy2;
		Bitmap cwp = new Bitmap("E:\\Shared\\!COREY'S WANTED PICTURE.png");
		int ix, iy, ix2, iy2;

		#endregion Variables

		public Form1() {InitializeComponent();}
		private void Form1_Load(object sender, EventArgs e) {
			ix2 = (ix = cwp.Width) / 2; iy2 = (iy = cwp.Height) / 2;

			Width = ix * 5; Height = iy * 5;
			fx2 = (fx = Width) / 2; fy2 = (fy = Height) / 2;
			gi = new Bitmap(fx, fy); gb = Graphics.FromImage(gi);
			gf = CreateGraphics();

			//cwp = new Bitmap(ix, iy); 
			double x, y;
			for(int X = 0 ; X < ix ; X++) {
				x = X - ix2;
				for(int Y = 0 ; Y < iy ; Y++) {
					y = Y - iy2;
					//cwp.SetPixel(X, Y, ((Math.Abs(x * x - y * y - 100.0) < 50.0) ? Color.Red : Color.FromArgb(0, 0, 0, 0)));
					cwp.SetPixel(X, Y, ((Math.Abs(x * x - y * y - 100.0) < 50.0) ? Color.Red : cwp.GetPixel(X, Y)));
				}
			}

			gb.Clear(Color.Black);
			gb.DrawImage(cwp, 0, 0);
			gb.DrawString(fx + ", " + fy, Font, Brushes.White, 0, iy + 6);
			gb.DrawString(ix + ", " + iy, Font, Brushes.White, 0, iy + 18);

			double tx, ty, sx, sy; SolidBrush b; int tfr=0;
			for(double a = 0.2 ; a < 5.2 ; a += 0.2) {
			//double a = 1; {
				tfr++;
				sx = Math.Max(a, 1); sy = Math.Max(1/a, 1);
				for(int X = 0 ; X < ix ; X++) {
					//tx = (int)Math.Round(a*X);
					x = a * X;
					for(int Y = 0 ; Y < iy ; Y++) {
						y = Y / a;
						b = new SolidBrush(Color.FromArgb(63, cwp.GetPixel(X, Y)));
						//b = new SolidBrush(cwp.GetPixel(X, Y));
						//gi.SetPixel(tx, (int)Math.Round(y / a), cwp.GetPixel(x, y));
						//gb.FillRectangle(b, tx, (int)Math.Round(Y / a), sx, sy);
						gb.FillRectangle(b, (float)x, (float)y, (float)sx, (float)sy);
						b.Dispose();
					}
				}
				gf.DrawImage(gi, 0, 0);
			}
		}
		private void Form1_Paint(object sender, PaintEventArgs e) { gf.DrawImage(gi, 0, 0); }
		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			switch(e.KeyCode) {
				case Keys.Escape: Close(); break;

			}
		}
	}
}
