using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuadTree {
    public partial class Form1 : Form
    {
        private TreeWrapper _treeWrapper;
        private bool _isMoving = false;
        private Image _img;
        private bool _isImage = false;
        private bool _isGenerated = false;
        private Bitmap _quadTreeBitmap;
        private Bitmap _compressedBitmap;
        public Form1() {
            InitializeComponent();
        }
        private void Form1_ResizeEnd(object sender, EventArgs e) {
            if (_isImage is false) {
                float ratio = Width / 660f < Height / 560f ? Width / 660f : Height / 560f;
                pictureBox.Width = (int)(500f * ratio);
                pictureBox.Height = (int)(500f * ratio);
            }
           
        }

        private void button1_Click(object sender, EventArgs e) {
            ButtonShowCompressed.Enabled = false;
            buttonGenerate.Enabled = false;
            buttonMovingControl.Enabled = true;
            _isImage = false;
            pictureBox.Refresh();
            QuadTreePoints.Capacity = (int) numericUpDownNodeCapacity.Value;
            int pointAmount = (int) numericUpDownPointAmount.Value;
            _treeWrapper = TreeOps.GenerateTree(pointAmount);
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            TreeOps.Draw(_treeWrapper, pictureBox, graphics);
            pictureBox.Image = bitmap;
            ButtonShowCompressed.Text = "Show compressed image";
            buttonGenerate.Text = "Generate";
        }

        private void pictureBox_SizeChanged(object sender, EventArgs e) {
            if (_isImage is false) {
                pictureBox.Refresh();
                if (_treeWrapper is not null) {
                    Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                    Graphics graphics = Graphics.FromImage(bitmap);
                    TreeOps.Draw(_treeWrapper, pictureBox, graphics);
                    pictureBox.Image = bitmap;
                }
            }
            else {

                //pictureBox.Image = _img;
            }
                
        }

        private void buttonMovingControl_Click(object sender, EventArgs e) {
            _isMoving = !_isMoving;
            if (_isMoving) {
                // Thread thread = new Thread(movePoints);
                // thread.Start();
                var t = new Task(movePoints);
                t.Start();
                buttonMovingControl.Text = "Stop moving points";
                buttonLoad.Enabled = false;
            }
            else {
                buttonLoad.Enabled = true;
                buttonMovingControl.Text = "Start moving points";
            }
                
        }

        private object _locker = new object();
        private void movePoints() {
            Random random = new Random();
            while (_isMoving) {
                
                foreach (var point in _treeWrapper.Points) {
                    point.X += (float) (random.NextDouble() * 2 - 1);
                    CheckBoundaries(point, 100f);
                    point.Y += (float) (random.NextDouble() * 2 - 1);
                }

                _treeWrapper = TreeOps.UpdateTree(_treeWrapper.Points);
                lock (_locker) {
                    Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                    Graphics graphics = Graphics.FromImage(bitmap);
                    TreeOps.Draw(_treeWrapper, pictureBox, graphics);
                    pictureBox.Image = bitmap;
                }
                Thread.Sleep(50);
            }
        }

        private static void CheckBoundaries(Point point, float max) {
            if (point.X >= max)
                point.X = max;
            if (point.X < 0)
                point.X = 0f;
            if (point.Y >= max)
                point.Y = max;
            if (point.Y < 0)
                point.Y = 0f;
        }

        private void buttonLoad_Click_1(object sender, EventArgs e) {
            string path;
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.InitialDirectory = @"c:\\";
                openFileDialog.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    _isGenerated = false;
                    buttonGenerate.Text = "Generate";
                    buttonMovingControl.Enabled = false;
                    buttonGenerate.Enabled = true;
                    
                    path = openFileDialog.FileName;
                    _img = ImageOps.getImage(path);
                    pictureBox.Image = _img;
                    _isImage = true;
                    if (_img.Height > 900 || _img.Width > 1600) {
                        //double ratio = _img.Width / (double) _img.Height;
                        if (_img.Height > _img.Width) {
                            pictureBox.Height = 900;
                            pictureBox.Width = _img.Width * 900 / _img.Height;
                        }
                        else {
                            pictureBox.Width = 1600;
                            pictureBox.Height = _img.Height * 1600 / _img.Width;
                        }
                    }
                    else {
                        pictureBox.Width = _img.Width;
                        pictureBox.Height = _img.Height;
                    }

                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            
        }

        private void buttonGenerate_Click(object sender, EventArgs e) {
            if (_isGenerated) {
                pictureBox.Image = _quadTreeBitmap;
                ButtonShowCompressed.Text = "Show compressed image";
            }
            else {
                QuadTreeBitmap.ColorTolerance = (int)numericUpDownColorTolerance.Value;
                QuadTreeBitmap.DesiredRatio = (double)numericUpDownDesiredRatio.Value;
                QuadTreeBitmap bitmapTree = ImageOps.generateTree(_img);
                Bitmap bitmap = new Bitmap(_img);
                Graphics graphics = Graphics.FromImage(bitmap);
                TreeOps.DrawTreeBitmap(bitmapTree, pictureBox, graphics);
                _quadTreeBitmap = bitmap;
                pictureBox.Image = _quadTreeBitmap;
                _quadTreeBitmap.Save("quadTreeBitmap.jpg");
                _compressedBitmap = new Bitmap(_img);
                _compressedBitmap = TreeOps.getCompressedImage(bitmapTree, _compressedBitmap, 0);
                _compressedBitmap.Save("compressed.jpg");
                ButtonShowCompressed.Enabled = true;
                _isGenerated = true;
                buttonGenerate.Text = "Show quadtree";
            }
        }

        private void ButtonShowCompressed_Click(object sender, EventArgs e) {
            if (pictureBox.Image == _img || pictureBox.Image == _quadTreeBitmap) {
                pictureBox.Image = _compressedBitmap;
                ButtonShowCompressed.Text = "Show original bitmap";
            }
            else {
                pictureBox.Image = _img;
                ButtonShowCompressed.Text = "Show compressed image";
            }
            
        }
    }
}
