namespace Desktop_enlarge_and_highlight_paragraph
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBoxDocument = new System.Windows.Forms.PictureBox();
            this.pictureBoxClone = new System.Windows.Forms.PictureBox();
            this.buttonEnlarge = new System.Windows.Forms.Button();
            this.buttonHighlight = new System.Windows.Forms.Button();
            this.buttonAnnotation = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.panelPicture2 = new System.Windows.Forms.Panel();
            this.buttonPic = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClone)).BeginInit();
            this.panelPicture2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfig.BackgroundImage")));
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.Location = new System.Drawing.Point(1117, 12);
            this.btnConfig.Margin = new System.Windows.Forms.Padding(6);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(50, 50);
            this.btnConfig.TabIndex = 0;
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            this.btnConfig.MouseHover += new System.EventHandler(this.btnConfig_MouseHover);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1239, 7);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(22, 22);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseHover += new System.EventHandler(this.btnClose_MouseHover);
            // 
            // pictureBoxDocument
            // 
            this.pictureBoxDocument.BackColor = System.Drawing.Color.DimGray;
            this.pictureBoxDocument.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDocument.Location = new System.Drawing.Point(288, 12);
            this.pictureBoxDocument.Name = "pictureBoxDocument";
            this.pictureBoxDocument.Size = new System.Drawing.Size(622, 640);
            this.pictureBoxDocument.TabIndex = 2;
            this.pictureBoxDocument.TabStop = false;
            this.pictureBoxDocument.Click += new System.EventHandler(this.pictureBoxDocument_Click);
            this.pictureBoxDocument.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxDocument_Paint);
            this.pictureBoxDocument.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDocument_MouseClick);
            this.pictureBoxDocument.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDocument_MouseDown);
            this.pictureBoxDocument.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDocument_MouseMove);
            this.pictureBoxDocument.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDocument_MouseUp);
            // 
            // pictureBoxClone
            // 
            this.pictureBoxClone.BackColor = System.Drawing.Color.DimGray;
            this.pictureBoxClone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxClone.Location = new System.Drawing.Point(14, 18);
            this.pictureBoxClone.Name = "pictureBoxClone";
            this.pictureBoxClone.Size = new System.Drawing.Size(1273, 239);
            this.pictureBoxClone.TabIndex = 3;
            this.pictureBoxClone.TabStop = false;
            this.pictureBoxClone.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxClone_Paint);
            this.pictureBoxClone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxClone_MouseClick);
            this.pictureBoxClone.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxClone_MouseDown);
            this.pictureBoxClone.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxClone_MouseMove);
            this.pictureBoxClone.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxClone_MouseUp);
            // 
            // buttonEnlarge
            // 
            this.buttonEnlarge.BackColor = System.Drawing.Color.White;
            this.buttonEnlarge.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonEnlarge.BackgroundImage")));
            this.buttonEnlarge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEnlarge.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonEnlarge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEnlarge.Location = new System.Drawing.Point(15, 12);
            this.buttonEnlarge.Margin = new System.Windows.Forms.Padding(6);
            this.buttonEnlarge.Name = "buttonEnlarge";
            this.buttonEnlarge.Size = new System.Drawing.Size(50, 50);
            this.buttonEnlarge.TabIndex = 4;
            this.buttonEnlarge.UseVisualStyleBackColor = false;
            this.buttonEnlarge.Click += new System.EventHandler(this.buttonEnlarge_Click);
            this.buttonEnlarge.MouseHover += new System.EventHandler(this.buttonEnlarge_MouseHover);
            // 
            // buttonHighlight
            // 
            this.buttonHighlight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonHighlight.BackgroundImage")));
            this.buttonHighlight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonHighlight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonHighlight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHighlight.Location = new System.Drawing.Point(77, 12);
            this.buttonHighlight.Margin = new System.Windows.Forms.Padding(6);
            this.buttonHighlight.Name = "buttonHighlight";
            this.buttonHighlight.Size = new System.Drawing.Size(50, 50);
            this.buttonHighlight.TabIndex = 5;
            this.buttonHighlight.UseVisualStyleBackColor = true;
            this.buttonHighlight.Click += new System.EventHandler(this.buttonHighlight_Click);
            this.buttonHighlight.MouseHover += new System.EventHandler(this.buttonHighlight_MouseHover);
            // 
            // buttonAnnotation
            // 
            this.buttonAnnotation.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAnnotation.BackgroundImage")));
            this.buttonAnnotation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAnnotation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonAnnotation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnnotation.Location = new System.Drawing.Point(139, 12);
            this.buttonAnnotation.Margin = new System.Windows.Forms.Padding(6);
            this.buttonAnnotation.Name = "buttonAnnotation";
            this.buttonAnnotation.Size = new System.Drawing.Size(50, 50);
            this.buttonAnnotation.TabIndex = 6;
            this.buttonAnnotation.UseVisualStyleBackColor = true;
            this.buttonAnnotation.Click += new System.EventHandler(this.buttonAnnotation_Click);
            this.buttonAnnotation.MouseHover += new System.EventHandler(this.buttonAnnotation_MouseHover);
            // 
            // buttonUndo
            // 
            this.buttonUndo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonUndo.BackgroundImage")));
            this.buttonUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonUndo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUndo.Location = new System.Drawing.Point(201, 12);
            this.buttonUndo.Margin = new System.Windows.Forms.Padding(6);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(50, 50);
            this.buttonUndo.TabIndex = 7;
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            this.buttonUndo.MouseHover += new System.EventHandler(this.buttonUndo_MouseHover);
            // 
            // panelPicture2
            // 
            this.panelPicture2.BackColor = System.Drawing.Color.Gray;
            this.panelPicture2.Controls.Add(this.pictureBoxClone);
            this.panelPicture2.Location = new System.Drawing.Point(82, 170);
            this.panelPicture2.Name = "panelPicture2";
            this.panelPicture2.Size = new System.Drawing.Size(200, 100);
            this.panelPicture2.TabIndex = 8;
            this.panelPicture2.Visible = false;
            // 
            // buttonPic
            // 
            this.buttonPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPic.BackgroundImage")));
            this.buttonPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPic.Location = new System.Drawing.Point(1055, 12);
            this.buttonPic.Margin = new System.Windows.Forms.Padding(6);
            this.buttonPic.Name = "buttonPic";
            this.buttonPic.Size = new System.Drawing.Size(50, 50);
            this.buttonPic.TabIndex = 9;
            this.buttonPic.UseVisualStyleBackColor = true;
            this.buttonPic.Click += new System.EventHandler(this.buttonPic_Click);
            this.buttonPic.MouseHover += new System.EventHandler(this.buttonPic_MouseHover);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClear.BackgroundImage")));
            this.buttonClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Location = new System.Drawing.Point(1179, 12);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(6);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(50, 50);
            this.buttonClear.TabIndex = 11;
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            this.buttonClear.MouseHover += new System.EventHandler(this.buttonClear_MouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1269, 741);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonPic);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.buttonAnnotation);
            this.Controls.Add(this.buttonHighlight);
            this.Controls.Add(this.buttonEnlarge);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.panelPicture2);
            this.Controls.Add(this.pictureBoxDocument);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClone)).EndInit();
            this.panelPicture2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBoxDocument;
        private System.Windows.Forms.PictureBox pictureBoxClone;
        private System.Windows.Forms.Button buttonEnlarge;
        private System.Windows.Forms.Button buttonHighlight;
        private System.Windows.Forms.Button buttonAnnotation;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Panel panelPicture2;
        private System.Windows.Forms.Button buttonPic;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

