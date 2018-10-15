using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindX
{
    public partial class Form1 : Form
    {
        bool[,] checkingSigns;

        public Form1()
        {
            InitializeComponent();
        }

        List<Point> GetCenterPoints(int beginX, int beginY, int lenth, int range, Bitmap bitmap)
        {
            List<Point> centerPoints = new List<Point>();

            int centerX = beginX + lenth / 2;
            int centerY = beginY + lenth / 2;

            centerPoints.Add(new Point(centerX, centerY));

            while (range > 0)
            {
                if (IsInImage(bitmap, centerX + range, centerY + range))
                {
                    centerPoints.Add(new Point(centerX + range, centerY + range));
                }

                if (IsInImage(bitmap, centerX - range, centerY - range))
                    centerPoints.Add(new Point(centerX - range, centerY - range));
                range--;
            }

            return centerPoints;
        }


        bool IsSameColor(Color color1, Color color2)
        {
            int range = 10;
            int deltaR = Math.Abs((color1.R - color2.R));
            int deltaG = Math.Abs(color1.G - color2.G);
            int deltaB = Math.Abs(color1.B - color2.B);
            return deltaR <= range && deltaG <= range && deltaB <= range;
        }

        void SetOriginImag(Image image)
        {
            if (originImagePic.Image != null)
            {
                originImagePic.Image.Dispose();
            }
            originImagePic.Image = image;
            originImagePic.Refresh();
        }

        void SetFindXImage(Image image)
        {
            if (FindXPic.Image != null)
            {
                FindXPic.Image.Dispose();
            }
            FindXPic.Image = image;
            FindXPic.Refresh();
        }

        void SetResultPic(Image image)
        {
            if (ResultPic.Image != null)
            {
                ResultPic.Image.Dispose();
            }
            ResultPic.Image = image;
            ResultPic.Refresh();
        }

        private void ChoseImgButton_Click(object sender, EventArgs e)
        {
            if (imageFileDialog.ShowDialog() == DialogResult.OK)
            {
                Log("FileName: " + imageFileDialog.FileName);
                Log("SafeFileName: " + imageFileDialog.SafeFileName);

                Bitmap bitmap = new Bitmap(Image.FromFile(imageFileDialog.FileName));

                SetOriginImag(bitmap);

                Log("Width: " + bitmap.Width);
                Log("Height " + bitmap.Height);

                int partWidth = 400;
                int partHeight = 400;

                Point[] fourPoint = Get4BeginPoints(partWidth, partHeight, bitmap.Size);


                FindXWithAnOriginPoint(fourPoint[1], partWidth, partHeight, bitmap);
            }
        }


        void FindXWithAnOriginPoint(Point origin, int height, int width, Bitmap bitmap)
        {
            Color[,] colors = new Color[height, width];

            for (int i = 0; i < colors.GetLength(0); i++)
            {
                for (int j = 0; j < colors.GetLength(1); j++)
                {
                    colors[i, j] = bitmap.GetPixel(origin.X + i, origin.Y + j);
                }
            }

            Bitmap checkingBitmap = GetBitmapWithColors(colors);
            SetFindXImage(checkingBitmap);
            Bitmap resultBitmap = new Bitmap(checkingBitmap);
            SetResultPic(resultBitmap);

            checkingSigns = new bool[checkingBitmap.Width, checkingBitmap.Height];

            for (int i = 0; i < checkingBitmap.Width; i++)
            {
                for (int j = 0; j < checkingBitmap.Height; j++)
                {
                    if (!checkingSigns[i, j])
                    {
                        int totalLenth = 0;
                        totalLenth = CheckLine(checkingBitmap, i, j, resultBitmap);
                        if (totalLenth > 10)
                        {
                            List<Point> centerPoints = GetCenterPoints(i, j, totalLenth, 5, checkingBitmap);
                            foreach (Point centerPoint in centerPoints)
                            {
                                //DrawLine(resultBitmap, centerPoint.X, centerPoint.Y, 1, 1, 1, Color.Black);
                                int topLenth = 0;
                                int bottomLenth = 0;
                                int crossTotalLenth = CheckReverseLine(checkingBitmap, centerPoint.X, centerPoint.Y, ref topLenth, ref bottomLenth, resultBitmap);
                                if (crossTotalLenth > 10)
                                {

                                    Point leftTop = new Point(i, j);
                                    Point rightBottom = new Point(i + totalLenth, j + totalLenth);
                                    Point rightTop = new Point(centerPoint.X + topLenth, centerPoint.Y - topLenth);
                                    Point leftBottom = new Point(centerPoint.X - bottomLenth, centerPoint.Y + bottomLenth);

                                    if (IsAX(centerPoint, checkingBitmap, leftTop, rightBottom, rightTop, leftBottom))
                                    {
                                        DrawLine(resultBitmap, i, j, 1, 1, totalLenth, Color.Red);
                                        DrawLine(resultBitmap, rightTop.X, rightTop.Y, -1, +1, crossTotalLenth, Color.Red);
                                        //Log("TotalLenth" + totalLenth);
                                        //Log("TopLenth" + topLenth);
                                        //Log("BottomLenth" + bottomLenth);
                                        //Log("");
                                        //Wait(50);
                                    }
                                    
                                }
                            }
                        }
                    }
                }
            }

            Refresh();
        }


        bool IsAX(Point center, Bitmap bitmap, Point leftTop, Point rightBottom, Point rightTop, Point leftBottom)
        {
            int constDeltaOffset = 5;

            int step = 2;

            float constRate = 0.2f;

            int delta = Math.Abs(leftTop.Y - rightTop.Y);
            if (delta >= constDeltaOffset)
            {
                return false;
            }

            delta = Math.Abs(leftBottom.Y - rightBottom.Y);
            if (delta >= constDeltaOffset)
            {
                return false;
            }
            delta = Math.Abs(leftTop.X - leftBottom.X);
            if (delta >= constDeltaOffset)
            {
                return false;
            }
            delta = Math.Abs(rightTop.X - rightBottom.X);
            if (delta >= constDeltaOffset)
            {
                return false;
            }

            int top = Math.Max(leftTop.Y, rightTop.Y);
            int bottom = Math.Min(leftBottom.Y, rightBottom.Y);
            int left = Math.Max(leftTop.X, leftBottom.X);
            int right = Math.Min(rightTop.X, rightBottom.X);



            Color color = bitmap.GetPixel(center.X, center.Y);

            Point toUp = center;
            Point toDown = center;
            Point toLeft = center;
            Point toRight = center;

            int sample = 0;
            int sameColor = 0;
            while (true)
            {
                bool canUp = toUp.Y > top;
                bool canDown = toDown.Y < bottom ;
                bool canLeft = toLeft.X > left ;
                bool canRight = toRight.X < right;

                if (canUp)
                {
                    toUp.Offset(0, -step);
                    if (IsInImage(bitmap, toUp))
                    {
                        sample++;
                        if (IsSameColor(color, bitmap.GetPixel(toUp.X, toUp.Y)))
                        {
                            sameColor++;
                        }
                    }
                    
                }

                if (canDown)
                {
                    toDown.Offset(0, step);
                    if (IsInImage(bitmap, toDown))
                    {
                        sample++;
                        if (IsSameColor(color, bitmap.GetPixel(toDown.X, toDown.Y)))
                        {
                            sameColor++;
                        }
                    }
                }

                if (canLeft)
                {
                    toLeft.Offset(-step, 0);
                    if (IsInImage(bitmap, toLeft))
                    {
                        sample++;
                        if (IsSameColor(color, bitmap.GetPixel(toLeft.X, toLeft.Y)))
                        {
                            sameColor++;
                        }
                    }
                }

                if (canRight)
                {
                    toRight.Offset(step, 0);
                    if (IsInImage(bitmap, toRight))
                    {
                        sample++;
                        if (IsSameColor(color, bitmap.GetPixel(toRight.X, toRight.Y)))
                        {
                            sameColor++;
                        }
                    }
                    
                }


                if (!canUp && !canDown && !canLeft && !canRight)
                {
                    break;
                }
            }

            float rate = sameColor / (float)sample;
            

            if (rate > constRate)
            {
                
                return false;
            }

            Log("Rate: " + rate);
            Log("");
            return true;
        }



        int CheckLine(Bitmap bitmap, int x, int y, Bitmap result)
        {
            return FindLineInADirectionAndReturnLenth(bitmap, x, y, 1, 1, bitmap.GetPixel(x, y), checkingSigns, result);

        }

        void DrawLine(Bitmap bitmap, int x, int y, int xOffset, int yOffset, int lenth, Color color)
        {
            while (lenth > 0)
            {
                if (IsInImage(bitmap, x, y))
                {
                    bitmap.SetPixel(x, y, color);
                }
                x += xOffset;
                y += yOffset;
                 Wait(1);
                lenth--;
            }
        }


        int FindLineInADirectionAndReturnLenth(Bitmap bitmap, int x, int y, int xStep, int yStep, Color lastPixelColor, bool[,] checkingMap, Bitmap result)
        {
            if (!IsInImage(bitmap, x, y))
            {
                return 0;
            }

            Color color = bitmap.GetPixel(x, y);
            if (IsSameColor(color, lastPixelColor))
            {
                if (checkingMap != null)
                {
                    checkingMap[x, y] = true;
                }
                if (result != null)
                {
                    //Color.FromArgb((color.R + 1) % 256, (color.G + 1) % 256, (color.B + 1) % 256)
                    //result.SetPixel(x, y,Color.Blue );
                }
                //Wait(1);
                var res = FindLineInADirectionAndReturnLenth(bitmap, x + xStep, y + yStep, xStep, yStep, color, checkingMap, result) + 1;
                if (result != null&&result.GetPixel(x,y)!=Color.Red)
                {
                    //result.SetPixel(x, y, color);
                }
                return res;
            }
            else
            {
                return 0;
            }
        }

        int CheckReverseLine(Bitmap bitmap, int crossPointx, int crossPointy, ref int topLenth, ref int bottomLenth, Bitmap result)
        {
            Color crossPointColor = bitmap.GetPixel(crossPointx, crossPointy);
            topLenth = FindLineInADirectionAndReturnLenth(bitmap, crossPointx, crossPointy, 1, -1, crossPointColor, null, result);
            bottomLenth = FindLineInADirectionAndReturnLenth(bitmap, crossPointx, crossPointy, -1, +1, crossPointColor, null, result);
            return topLenth + bottomLenth;

        }

        void Wait(int time)
        {
            Refresh();
            System.Threading.Thread.Sleep(time);
        }


        Bitmap GetBitmapWithColors(Color[,] colors)
        {
            Bitmap bitmap = new Bitmap(colors.GetLength(0), colors.GetLength(1));
            for (int i = 0; i < colors.GetLength(0); i++)
            {
                for (int j = 0; j < colors.GetLength(1); j++)
                {
                    bitmap.SetPixel(i, j, colors[i, j]);
                }
            }

            return bitmap;
        }


        Point[] Get4BeginPoints(float heightPercent, float widthPercent, Size imageSize)
        {
            int height = (int)(imageSize.Height * heightPercent);
            int width = (int)(imageSize.Width * widthPercent);
            return Get4BeginPoints(height, width, imageSize);
        }

        Point[] Get4BeginPoints(int height, int width, Size imageSize)
        {
            Point leftTop = new Point(0, 0);
            Point rightTop = new Point(imageSize.Width - width, 0);
            Point leftBottom = new Point(0, imageSize.Height - height);
            Point rightBottom = new Point(imageSize.Width - width, imageSize.Height - height);

            Point[] points = new Point[] { leftTop, rightTop, leftBottom, rightBottom };
            return points;
        }

        bool IsInImage(Bitmap bitmap, int x, int y)
        {
            if (x >= bitmap.Width || y >= bitmap.Height || x < 0 || y < 0)
            {
                return false;
            }

            return true;
        }

        bool IsInImage(Bitmap bitmap, Point point)
        {
            return IsInImage(bitmap, point.X, point.Y);
        }

        void Log(string msg)
        {
            logTextBox.Text += msg + Environment.NewLine;
            //logTextBox.Refresh();
        }
    }
}
