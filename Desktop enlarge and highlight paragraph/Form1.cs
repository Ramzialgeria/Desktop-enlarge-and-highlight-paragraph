using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using AForge.Imaging.Filters;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Desktop_enlarge_and_highlight_paragraph
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevicesList;
        private IVideoSource videoSource;

        Rectangle mSelect;
        Rectangle HighlightRect;
        Rectangle AnnotationRect;
        bool mDragging;
        bool HighlightDragging;
        bool AnnotationDragging;
        string Action = "Selection";
        int startLine = -1, endLine = -1, secondstartLine = -1;
        int startLine2 = -1, endLine2 = -1, secondstartLine2 = -1;
        int LineNumbers = 0;
        int LineNumbers2 = 0;
        int[,] Lines;
        int[,] Lines2;
        int selectedLine;
        Image[] Bitmapistory;
        int BitmapistoryCount = -1;
        int MaxHeight;
        int MaxWidth;
        bool savedSiz = false;
        int Value = 170;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            string message = "Are you sure to exit ?";
            DialogResult dr = MessageBox.Show(message, "Confirmation", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                try
                {
                    videoSource.Stop();
                }
                catch (Exception ex)
                {
                }

                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            MaxHeight = this.Height - 144;
            MaxWidth = this.Width - 522;

            Bitmapistory = new Bitmap[100];

            double pictureBoxDocumentWidth = this.Size.Height * 8.5 / 11;

            pictureBoxDocument.Location = new Point((this.Size.Width - Convert.ToInt32(pictureBoxDocumentWidth)) / 2, 0);

            pictureBoxDocument.Size = new System.Drawing.Size(Convert.ToInt32(pictureBoxDocumentWidth), this.Size.Height);
            //pictureBoxDocument.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBoxDocument.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            

            buttonEnlarge.Enabled = true;
            buttonHighlight.Enabled = false;
            buttonAnnotation.Enabled = false;
            buttonUndo.Enabled = false;

            try
            {
                StreamReader s = new StreamReader("s.ini");
                string[] size = (s.ReadLine()).Split(' ');
                s.Close();

                pictureBoxDocument.Size = new System.Drawing.Size(Convert.ToInt32(size[0]), Convert.ToInt32(size[1]));
                pictureBoxDocument.Location = new Point((this.Size.Width - Convert.ToInt32(size[0])) / 2, (this.Size.Height - Convert.ToInt32(size[1])) / 2);
                savedSiz = true;
            }
            catch(Exception ex)
            { }
            


            String line;
            try
            {

                StreamReader sr = new StreamReader("myco.ini");
                line = sr.ReadLine();
                sr.Close();

                int indexDevice = 0;

                if (line != "")
                {
                    var videoDevicesList = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                    for (int i=0; i<videoDevicesList.Count;i++) 
                    {
                        if (videoDevicesList[i].Name == line)
                        {
                            indexDevice = i;
                        }
                        
                    }
                    videoSource = new VideoCaptureDevice(videoDevicesList[Convert.ToInt32(line)].MonikerString);
                    videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                    videoSource.Start();
                }

                

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }


           
          
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

            if (!savedSiz)
            {
                pictureBoxDocument.Size = new System.Drawing.Size(bitmap.Width, bitmap.Height);
                pictureBoxDocument.Location = new Point((this.Size.Width - bitmap.Width) / 2, (this.Size.Height - bitmap.Height) / 2);
            }

            if(bitmap.Width > pictureBoxDocument.Width)
            {
                Bitmap resized = new Bitmap(bitmap, new Size(pictureBoxDocument.Width, bitmap.Height * pictureBoxDocument.Width / bitmap.Width));
                pictureBoxDocument.Image = resized;
            }
            else
            {
                pictureBoxDocument.Image = bitmap;
            }
            
            //Bitmap resized = new Bitmap(bitmap, new Size(pictureBoxDocument.Width, pictureBoxDocument.Height));

           
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            Size defaultSize = new Size(Convert.ToInt32(this.Size.Height * 8.5 / 11),this.Size.Height);


            FormConfig form = new FormConfig(pictureBoxDocument.Size, defaultSize);
            form.ShowDialog();

            try
            {
                StreamReader s = new StreamReader("s.ini");
                string[] size = (s.ReadLine()).Split(' ');
                s.Close();

                pictureBoxDocument.Size = new System.Drawing.Size(Convert.ToInt32(size[0]), Convert.ToInt32(size[1]));
                pictureBoxDocument.Location = new Point((this.Size.Width - Convert.ToInt32(size[0])) / 2, (this.Size.Height - Convert.ToInt32(size[1])) / 2);
            }
            catch (Exception ex)
            { }

            string line;
            try
            {

                StreamReader sr = new StreamReader("myco.ini");
                line = sr.ReadLine();
                sr.Close();

                int indexDevice = 0;

                if (line != "")
                {
                    var videoDevicesList = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                    for (int i = 0; i < videoDevicesList.Count; i++)
                    {
                        if (videoDevicesList[i].Name == line)
                        {
                            indexDevice = i;
                        }

                    }

                    videoSource.Stop();///

                    videoSource = new VideoCaptureDevice(videoDevicesList[Convert.ToInt32(line)].MonikerString);
                    videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                    videoSource.Start();
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private void pictureBoxDocument_MouseDown(object sender, MouseEventArgs e)
        {
            if (Action == "Selection")
            {
                mDragging = true;
                mSelect.Location = e.Location;
                mSelect.Size = new Size(0, 0);
            }
        }

        private void pictureBoxDocument_MouseMove(object sender, MouseEventArgs e)
        {
            if (Action == "Selection")
            {
                if (mDragging)
                {
                    mSelect.Size = new Size(e.X - mSelect.Left, e.Y - mSelect.Top);
                    pictureBoxDocument.Invalidate();
                }
            }
        }

        private void pictureBoxDocument_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (Action == "Selection")
                {
                    mDragging = false;

                    if (mSelect.Height < mSelect.Width)
                    {
                        int height = this.Width * mSelect.Height / mSelect.Width;
                        if (height > MaxHeight)
                        {
                            height = MaxHeight;
                        }
                        panelPicture2.Size = new Size(this.Width, height);
                        panelPicture2.Location = new Point(0, (this.Height - panelPicture2.Height) / 2);
                        pictureBoxClone.Size = new Size(panelPicture2.Width - 8, height - 8);
                        pictureBoxClone.Location = new Point(4, 4);
                    }
                    else
                    {
                        int width = this.Height * mSelect.Width / mSelect.Height;// this.Width / 3;
                        if (width > MaxWidth)
                        {
                            width = MaxWidth;
                        }
                        panelPicture2.Size = new Size(width, this.Height);
                        panelPicture2.Location = new Point((this.Width - width) / 2, 0);
                        pictureBoxClone.Size = new Size(panelPicture2.Width - 8, panelPicture2.Height - 8);
                        pictureBoxClone.Location = new Point(4, 4);
                    }

                    if (mSelect.Height < 0 || mSelect.Width < 0)
                    {
                        return;
                    }

                    ZoomFactor zoomHelper = new ZoomFactor();
                    //Bitmap originalBitmap = new Bitmap(pictureBoxDocument.Image, new Size(pictureBoxDocument.Width, pictureBoxDocument.Height));
                    Bitmap originalBitmap = new Bitmap(pictureBoxDocument.Image);
                    Bitmap destinationbmp = new Bitmap(pictureBoxClone.Width, pictureBoxClone.Height);

                    //RectangleF currentSelection = mSelect;
                    //RectangleF bitmapRect = zoomHelper.TranslateZoomSelection(currentSelection, pictureBoxClone.Size, originalBitmap.Size);

                    ///var croppedBitmap = new Bitmap((int)bitmapRect.Width, (int)bitmapRect.Height, originalBitmap.PixelFormat);
                    using (var g = Graphics.FromImage(destinationbmp))
                    {
                        g.DrawImage(originalBitmap, new Rectangle(0, 0, pictureBoxClone.Width, pictureBoxClone.Height), mSelect, GraphicsUnit.Pixel);
                        pictureBoxClone.Image = destinationbmp;
                    }

                    ///
                    try
                    {
                        videoSource.Stop();
                    }
                    catch (Exception)
                    { }

                    //pictureBoxDocument.Image = originalBitmap;
                    ///

                    panelPicture2.Visible = true;
                    pictureBoxClone.Visible = true;

                    buttonEnlarge.Enabled = false;

                    buttonEnlarge.BackColor = Color.Black;
                    buttonHighlight.Enabled = true;
                    buttonAnnotation.Enabled = true;
                    buttonUndo.Enabled = true;
                    Action = "";

                    startLine = -1;
                    endLine = -1;
                    secondstartLine = -1;

                   



                    // Lock the bitmap's bits.  
                    Rectangle rect = new Rectangle(0, 0, destinationbmp.Width, destinationbmp.Height);
                
                    Color ColorPixel;
                    bool breakBoucle = false;
                    Point p1 = new Point(); 
                    Point p2 = new Point(); 
                    Point p3 = new Point();

                    Bitmap bmp5 = new Bitmap(pictureBoxClone.Image);

                    Color clr00 = bmp5.GetPixel(0, 0); // Get the color of pixel at position 5,5
                    int red = clr00.R;
                    int green = clr00.G;
                    int blue = clr00.B;

                    int red2 = clr00.R;
                    int green2 = clr00.G;
                    int blue2 = clr00.B;

                    if (red < 220 && blue < 220 && green < 220)
                        Value = 200;

                    LockBitmap lockBitmap = new LockBitmap(destinationbmp);
                   
                    lockBitmap.LockBits();

                    for (int y = 0; y < lockBitmap.Height; y++)
                    {
                        for (int x = 0; x < lockBitmap.Width; x++)
                        {
                            clr00 = bmp5.GetPixel(x, y);
                            if(clr00.R < red2 && clr00.G<green2 && clr00.B<blue2)
                            {
                                red2 = clr00.R;
                                green2 = clr00.G;
                                blue2 = clr00.B;
                            }
                        }
                    }
                    //Value = (red2 + green2 + blue2) / 3 + 60;

                    if (((red2 + green2 + blue2) / 3) > 100)
                    Value=190;
                    else
                    Value=170;
                    for (int y = 0; y < lockBitmap.Height; y++)
                    {
                        //lockBitmap.Width / 15

                        for (int x = 0; x < lockBitmap.Width / 2 ; x++)
                        {
                            ColorPixel = lockBitmap.GetPixel(x, y);

                            if (ColorPixel.R < Value && ColorPixel.G < Value && ColorPixel.B < Value)
                            {
                                if (startLine == -1)
                                {
                                    startLine = y;
                                    p1.X = x;
                                    p1.Y = y;
                                    p3.Y = y;
                                    breakBoucle = true; 
                                    break;

                                }

                            }
                        }

                        if (breakBoucle)
                        {
                            break;
                        }
                    }
                    //breakBoucle = true;

                    //for (int y = startLine; y < lockBitmap.Height; y++)
                    //{
                    //    int x = 0;
                    //    breakBoucle = true;
                    //    while (x < lockBitmap.Width/2)
                    //    {
                    //        ColorPixel = lockBitmap.GetPixel(x, y);

                    //        if (ColorPixel.R < 210 && ColorPixel.G < 210 && ColorPixel.B < 210)
                    //        {
                    //            //if (endLine != -1)
                    //            {
                    //                endLine = y;
                    //                breakBoucle = false; 
                    //                break;
                    //            }

                    //        }

                    //        x++;
                    //    }

                    //    if (x == lockBitmap.Width)
                    //    {
                    //        breakBoucle = true; 
                    //    }

                    //    if(breakBoucle)
                    //    {
                    //        break;
                    //    }
                    //}

                    //breakBoucle = false; 
                    //for (int y = endLine+1; y < lockBitmap.Height; y++)
                    //{
                    //    int x = 0;
                    //    while (x < lockBitmap.Width/2)
                    //    {
                    //        ColorPixel = lockBitmap.GetPixel(x, y);

                    //        if (ColorPixel.R < 210 && ColorPixel.G < 210 && ColorPixel.B < 210)
                    //        {
                    //            if (secondstartLine == -1 || secondstartLine <= endLine)
                    //            {
                    //                secondstartLine = y;
                    //                breakBoucle = true; 
                    //            }

                    //        }

                    //        x++;
                    //    }

                    //    if (breakBoucle)
                    //    {
                    //        break;
                    //    }
                    //}


                    ///
                    breakBoucle = false;
                    for (int y = 0; y < lockBitmap.Height; y++)
                    {
                        for (int x = lockBitmap.Width; x >= lockBitmap.Width - (lockBitmap.Width / 3) - 1; x--)
                        {
                            ColorPixel = lockBitmap.GetPixel(x, y);

                            if (ColorPixel.R < Value && ColorPixel.G < Value && ColorPixel.B < Value)
                            {
                                if (startLine2 == -1)
                                {
                                    startLine2 = y;
                                    p2.X = x;
                                    p2.Y = y;
                                    p3.X = x;
                                    breakBoucle = true;
                                    break;

                                }

                            }

                           
                        } 
                        
                        if (breakBoucle)
                            {
                                break;
                            }
                    }

                    
                    

                    lockBitmap.UnlockBits();

                    if ((p1.Y > p2.Y && p1.Y - p2.Y > 10) || (p1.Y < p2.Y && p2.Y - p1.Y > 10))
                    {
                        Bitmap bmp1 = new Bitmap(pictureBoxClone.Width, pictureBoxClone.Height);
                        Graphics g1 = Graphics.FromImage(bmp1);

                        Bitmap bmp = new Bitmap(pictureBoxClone.Image);
                        Color clr = bmp.GetPixel(0, 0);
                        g1.Clear(clr);
                        g1.DrawImage(RotateImage(pictureBoxClone.Image, p1, (float)calculateAngle1((double)p1.X, (double)p1.Y, (double)p2.X, (double)p2.Y, (double)p3.X, (double)p3.Y)), new Point(0, 0));

                        pictureBoxClone.Image = bmp1;
                        g1.Dispose();
                    }

                    BitmapistoryCount++;
                    Bitmapistory[BitmapistoryCount] = pictureBoxClone.Image;

                    lockBitmap = new LockBitmap((Bitmap)pictureBoxClone.Image);

                    lockBitmap.LockBits();


                    for (int y = 0; y < lockBitmap.Height; y++)
                    {
                        //lockBitmap.Width / 15

                        for (int x = 0; x < lockBitmap.Width / 15; x++)
                        {
                            ColorPixel = lockBitmap.GetPixel(x, y);

                            if (ColorPixel.R < Value && ColorPixel.G < Value && ColorPixel.B < Value)
                            {
                                if (startLine == -1)
                                {
                                    startLine = y;
                                    p1.X = x;
                                    p1.Y = y;
                                    p3.Y = y;
                                    breakBoucle = true;
                                    break;

                                }

                            }
                        }

                        if (breakBoucle)
                        {
                            break;
                        }
                    }
                    breakBoucle = true;

                    for (int y = startLine; y < lockBitmap.Height; y++)
                    {
                        int x = 0;
                        breakBoucle = true;
                        while (x < lockBitmap.Width)
                        {
                            ColorPixel = lockBitmap.GetPixel(x, y);

                            if (ColorPixel.R < Value && ColorPixel.G < Value && ColorPixel.B < Value)
                            {
                                //if (endLine != -1)
                                {
                                    endLine = y;
                                    breakBoucle = false;
                                    break;
                                }

                            }

                            x++;
                        }

                        if (x == lockBitmap.Width)
                        {
                            breakBoucle = true;
                        }

                        if (breakBoucle)
                        {
                            break;
                        }
                    }

                    breakBoucle = false;
                    for (int y = endLine + 1; y < lockBitmap.Height; y++)
                    {
                        int x = 0;
                        while (x < lockBitmap.Width)
                        {
                            ColorPixel = lockBitmap.GetPixel(x, y);

                            if (ColorPixel.R < Value && ColorPixel.G < Value && ColorPixel.B < Value)
                            {
                                if (secondstartLine == -1 || secondstartLine <= endLine)
                                {
                                    secondstartLine = y;
                                    breakBoucle = true;
                                }

                            }

                            x++;
                        }

                        if (breakBoucle)
                        {
                            break;
                        }
                    }


                  
                    lockBitmap.UnlockBits();

                    int EndLineWidth = endLine - startLine;
                    int EndLineToSecondStartLine = secondstartLine - endLine;

                    Lines = new int[1000, 2];
                    
                    int intermediaire;
                    for (int x = startLine; x < destinationbmp.Height; x += secondstartLine - startLine)
                    {

                        Lines[LineNumbers, 0] = startLine;
                        Lines[LineNumbers, 1] = secondstartLine - EndLineToSecondStartLine + 4;
                        intermediaire = startLine;
                        startLine = secondstartLine;
                        secondstartLine = 2 * secondstartLine - intermediaire;
                        if (destinationbmp.Height - startLine < 0)
                        {
                            Lines[LineNumbers, 1] = destinationbmp.Height;
                        }
                        LineNumbers++;

                        if (destinationbmp.Height - startLine < EndLineWidth)
                        {
                            break;
                        }
                    }

                    //int EndLineWidth2 = endLine2 - startLine2;
                    //int EndLineToSecondStartLine2 = secondstartLine2 - endLine2;

                    //Lines2 = new int[1000, 2];

                    //int intermediaire2 = 0;
                    //for (int x = startLine2; x < destinationbmp.Height; x += secondstartLine2 - startLine2)
                    //{

                    //    Lines2[LineNumbers2, 0] = startLine2;
                    //    Lines2[LineNumbers2, 1] = secondstartLine2 - EndLineToSecondStartLine2 + 4;
                    //    intermediaire2 = startLine2;
                    //    startLine2 = secondstartLine2;
                    //    secondstartLine2 = 2 * secondstartLine2 - intermediaire2;
                    //    if (destinationbmp.Height - startLine2 < 0)
                    //    {
                    //        Lines2[LineNumbers2, 1] = destinationbmp.Height;
                    //    }
                    //    LineNumbers2++;

                    //    if (destinationbmp.Height - startLine2 < EndLineWidth2)
                    //    {
                    //        break;
                    //    }
                    //}

                    

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        Bitmap RotateImage(Image image, PointF offset, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            //create a new empty bitmap to hold rotated image
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(rotatedBmp);

            //Put the rotation point in the center of the image
            g.TranslateTransform(offset.X, offset.Y);

            //rotate the image
            g.RotateTransform(angle);

            //move the image back
            g.TranslateTransform(-offset.X, -offset.Y);

            //draw passed in image onto graphics object
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }

        private Bitmap rotateImage(Bitmap b, float angle)
        {

            int maxside = (int)(Math.Sqrt(b.Width * b.Width + b.Height * b.Height));

            //create a new empty bitmap to hold rotated image

            Bitmap returnBitmap = new Bitmap(maxside, maxside);

            //make a graphics object from the empty bitmap

            Graphics g = Graphics.FromImage(returnBitmap);





            //move rotation point to center of image

            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);

            //rotate

            g.RotateTransform(angle);

            //move image back

            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);

            //draw passed in image onto graphics object

            g.DrawImage(b, new Point(0, 0));



            return returnBitmap;

        }

        /*
         *                -----------p2
         *    ------------
         * p1------------------------p3
         * */
        double calculateAngle1(double P1X, double P1Y, double P2X, double P2Y,  double P3X, double P3Y)
        {

            double numerator = P2Y * (P1X - P3X) + P1Y * (P3X - P2X) + P3Y * (P2X - P1X);
            double denominator = (P2X - P1X) * (P1X - P3X) + (P2Y - P1Y) * (P1Y - P3Y);
            double ratio = numerator / denominator;

            double angleRad = Math.Atan(ratio);
            double angleDeg = (angleRad * 180) / Math.PI;

            if (angleDeg < 0)
            {
                angleDeg = (-1) * angleDeg;
            }

            return angleDeg;
        }

        private void pictureBoxDocument_Paint(object sender, PaintEventArgs e)
        {
            if (Action == "Selection" && mDragging == true)
            {
                using (Pen p = new Pen(Color.Black))
                {
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    e.Graphics.DrawRectangle(p, mSelect);
                }
            }
        }

     

        private void buttonEnlarge_Click(object sender, EventArgs e)
        {
            Action = "Selection";
            buttonEnlarge.BackColor = Color.White;
            buttonAnnotation.BackColor = Color.Black;
            buttonHighlight.BackColor = Color.Black;
            startLine = -1;
            endLine = -1;
        }

        private void buttonHighlight_Click(object sender, EventArgs e)
        {
            Action = "highlight";
            pictureBoxClone.Cursor = new Cursor("mycursor.cur");
            buttonEnlarge.BackColor = Color.Black;
            buttonAnnotation.BackColor = Color.Black;
            buttonHighlight.BackColor = Color.White;

        }

        private void buttonAnnotation_Click(object sender, EventArgs e)
        {
            Action = "Annotation";
            pictureBoxClone.Cursor = new Cursor("mycursor.cur");
            buttonEnlarge.BackColor = Color.Black;
            buttonAnnotation.BackColor = Color.White;
            buttonHighlight.BackColor = Color.Black;
        }

        private void pictureBoxClone_MouseDown(object sender, MouseEventArgs e)
        {
            if(Action == "highlight")
            {
                HighlightDragging = true;

                HighlightRect.Location = e.Location;
                HighlightRect.Size = new Size(0, 200);
                 for(int i=0; i<LineNumbers; i++)
                {
                    if (e.Location.Y + 10 > Lines[i, 0] && e.Location.Y + 10 < Lines[i, 1])
                    {
                        selectedLine = i;
                        break;
                    }
                }
            }

            if (Action == "Annotation")
            {
                AnnotationDragging = true;

                AnnotationRect.Location = e.Location;
                AnnotationRect.Size = new Size(0, 200);
                for (int i = 0; i < LineNumbers; i++)
                {
                    if (e.Location.Y + 10 > Lines[i, 0] && e.Location.Y + 10 < Lines[i, 1])
                    {
                        selectedLine = i;
                        break;
                    }
                }
            }
        }

        private void pictureBoxClone_MouseMove(object sender, MouseEventArgs e)
        {
            if (Action == "highlight")
            {
                if (HighlightDragging)
                {

                    HighlightRect.Size = new Size(e.X - HighlightRect.Left, Lines[selectedLine, 1] - Lines[selectedLine, 0]);

                    

                    pictureBoxClone.Invalidate();
                }
            }

            if (Action == "Annotation")
            {
                if (AnnotationDragging)
                {

                    AnnotationRect.Size = new Size(e.X - AnnotationRect.Left, Lines[selectedLine, 1] - Lines[selectedLine, 0]);



                    pictureBoxClone.Invalidate();
                }
            }
        }

        private double calculateAngle(double P1X, double P1Y, double P2X, double P2Y,
            double P3X, double P3Y)
        {

            double numerator = P2Y * (P1X - P3X) + P1Y * (P3X - P2X) + P3Y * (P2X - P1X);
            double denominator = (P2X - P1X) * (P1X - P3X) + (P2Y - P1Y) * (P1Y - P3Y);
            double ratio = numerator / denominator;

            double angleRad = Math.Atan(ratio);
            double angleDeg = (angleRad * 180) / Math.PI;

            if (angleDeg < 0)
            {
                angleDeg = 180 + angleDeg;
            }

            return angleDeg;
        }

        private void Rect2Pointfs(Rectangle rect, float angle, out PointF[] lpfs)
        {
            using (var graph = new GraphicsPath())
            {
                Point Center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
                graph.AddRectangle(rect);
                var a = -angle * (Math.PI / 180);
                var n1 = (float)Math.Cos(a);
                var n2 = (float)Math.Sin(a);
                var n3 = -(float)Math.Sin(a);
                var n4 = (float)Math.Cos(a);
                var n5 = (float)(Center.X * (1 - Math.Cos(a)) + Center.Y * Math.Sin(a));
                var n6 = (float)(Center.Y * (1 - Math.Cos(a)) - Center.X * Math.Sin(a));
                graph.Transform(new Matrix(n1, n2, n3, n4, n5, n6));
                lpfs = graph.PathPoints;
            }
        }

        private void pictureBoxClone_Paint(object sender, PaintEventArgs e)
        {
            if (Action == "highlight" && HighlightDragging == true)
            {

                Bitmap originalBitmap = new Bitmap(pictureBoxClone.Image);


                LockBitmap lockBitmap = new LockBitmap(originalBitmap);
                lockBitmap.LockBits();
                Color ColorPixel;
                for (int y = Lines[selectedLine, 0]; y < Lines[selectedLine, 1]; y++)
                {

                    for (int x = HighlightRect.Left; x < HighlightRect.Right; x++)
                    {
                        try
                        {
                            ColorPixel = lockBitmap.GetPixel(x, y);


                            if (ColorPixel.R > Value && ColorPixel.G > Value && ColorPixel.B > Value)
                            {
                                lockBitmap.SetPixel(x, y, Color.Yellow);
                            }
                        }
                        catch (Exception ex) { }
                    }

                }
                lockBitmap.UnlockBits();

                pictureBoxClone.Image = originalBitmap;
               
                
            }

            if (Action == "Annotation" && AnnotationDragging == true)
            {

                Bitmap originalBitmap = new Bitmap(pictureBoxClone.Image);


                LockBitmap lockBitmap = new LockBitmap(originalBitmap);
                lockBitmap.LockBits();
                Color ColorPixel;
                for (int y = Lines[selectedLine, 1] - 4; y < Lines[selectedLine, 1]; y++)
                {

                    for (int x = AnnotationRect.Left; x < AnnotationRect.Right; x++)
                    {
                        
                            lockBitmap.SetPixel(x, y, Color.Red);
                        
                    }

                }
                lockBitmap.UnlockBits();

                pictureBoxClone.Image = originalBitmap;


            }
        }

        private void pictureBoxClone_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (Action == "highlight")
                {
                    HighlightDragging = false; 
                    
                    BitmapistoryCount++;
                    Bitmapistory[BitmapistoryCount] = pictureBoxClone.Image;

                }
                if (Action == "Annotation")
                {
                    AnnotationDragging = false;

                    BitmapistoryCount++;
                    Bitmapistory[BitmapistoryCount] = pictureBoxClone.Image;
                }

               
            }
            catch(Exception ex)
            { 
                //MessageBox.Show(BitmapistoryCount.ToString() + " " + ex.Message); 
            }
        }

        
        private void buttonUndo_Click(object sender, EventArgs e)
        {
            try
            {
                BitmapistoryCount--;
                Action = "Return";
                if (BitmapistoryCount > -1)
                {
                    pictureBoxClone.Image = Bitmapistory[BitmapistoryCount];
                    pictureBoxClone.Refresh();
                }
                else
                {
                    panelPicture2.Visible = false;
                    //
                    buttonEnlarge.BackColor = Color.White;
                    buttonAnnotation.BackColor = Color.Black;
                    buttonHighlight.BackColor = Color.Black;
                    buttonAnnotation.Enabled = false;
                    buttonHighlight.Enabled = false;
                    buttonUndo.Enabled = false;

                    Action = "Selection";

                    try
                    {
                        pictureBoxDocument.Image = null;
                        videoSource.Start();
                    }
                    catch (Exception ex) { }
                }
            }
            catch(Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonPic_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefiledialog1 = new SaveFileDialog();
            savefiledialog1.Filter = "";

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;

            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                savefiledialog1.Filter = String.Format("{0}{1}{2} ({3})|{3}", savefiledialog1.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }

            savefiledialog1.Filter = String.Format("{0}{1}{2} ({3})|{3}", savefiledialog1.Filter, sep, "All Files", "*.*");

            savefiledialog1.DefaultExt = ".png"; // Default file extension 

            if(savefiledialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (panelPicture2.Visible == false)
                {
                    try
                    {
                        pictureBoxDocument.Image.Save(savefiledialog1.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        pictureBoxClone.Image.Save(savefiledialog1.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (BitmapistoryCount > -1)
            {
                BitmapistoryCount = -1;

                panelPicture2.Visible = false;
                //
                buttonEnlarge.BackColor = Color.White;
                buttonAnnotation.BackColor = Color.Black;
                buttonHighlight.BackColor = Color.Black;
                buttonAnnotation.Enabled = false;
                buttonHighlight.Enabled = false;
                buttonUndo.Enabled = false;

                Action = "Selection";

                try
                {
                    pictureBoxDocument.Image = null;
                    videoSource.Start();
                }
                catch (Exception ex) { }
               
            }
        }

        private void buttonEnlarge_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Enlargement", buttonEnlarge);
        }

        private void buttonHighlight_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Highlight", buttonHighlight);
        }

        private void buttonAnnotation_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Annotation", buttonAnnotation);
        }

        private void buttonUndo_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Undo", buttonUndo);
        }

        private void buttonPic_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Save current view", buttonPic);
        }

        private void btnConfig_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Configuration", btnConfig);
        }

        private void buttonClear_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Clear all", buttonClear);
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Close", btnClose);
        }

        private void pictureBoxDocument_MouseClick(object sender, MouseEventArgs e)
        {
            //using (Bitmap bmp = new Bitmap(pictureBoxDocument.Image))
            //{
            //    Color clr = bmp.GetPixel(e.X, e.Y); // Get the color of pixel at position 5,5
            //    int red = clr.R;
            //    int green = clr.G;
            //    int blue = clr.B;
            //    MessageBox.Show(e.X.ToString() + "," + e.Y.ToString() + " ----- " + red.ToString() + "," + green.ToString() + "," + blue.ToString());
            //}
        }

        private void pictureBoxDocument_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxClone_MouseClick(object sender, MouseEventArgs e)
        {
            
            //using (Bitmap bmp = new Bitmap(pictureBoxClone.Image))
            //{
            //    Color clr = bmp.GetPixel(e.X, e.Y); // Get the color of pixel at position 5,5
            //   int red = clr.R;
            //    int green = clr.G;
            //    int blue = clr.B;
            //    MessageBox.Show(e.X.ToString() + "," + e.Y.ToString() + " ----- " + red.ToString() + "," + green.ToString() + "," + blue.ToString());
            //}

            
        }

    }
}
