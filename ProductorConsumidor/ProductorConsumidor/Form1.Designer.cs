
namespace ProductorConsumidor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.consumerImg = new System.Windows.Forms.PictureBox();
            this.producerImg = new System.Windows.Forms.PictureBox();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.rose = new System.Windows.Forms.PictureBox();
            this.customerLbl = new System.Windows.Forms.Label();
            this.producerLbl = new System.Windows.Forms.Label();
            this.productLbl = new System.Windows.Forms.Label();
            this.currentImg = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.consumerImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.producerImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentImg)).BeginInit();
            this.SuspendLayout();
            // 
            // consumerImg
            // 
            this.consumerImg.Image = ((System.Drawing.Image)(resources.GetObject("consumerImg.Image")));
            this.consumerImg.Location = new System.Drawing.Point(663, 191);
            this.consumerImg.Name = "consumerImg";
            this.consumerImg.Size = new System.Drawing.Size(109, 113);
            this.consumerImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.consumerImg.TabIndex = 0;
            this.consumerImg.TabStop = false;
            // 
            // producerImg
            // 
            this.producerImg.Image = ((System.Drawing.Image)(resources.GetObject("producerImg.Image")));
            this.producerImg.Location = new System.Drawing.Point(41, 191);
            this.producerImg.Name = "producerImg";
            this.producerImg.Size = new System.Drawing.Size(125, 113);
            this.producerImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.producerImg.TabIndex = 1;
            this.producerImg.TabStop = false;
            // 
            // table
            // 
            this.table.AutoSize = true;
            this.table.BackColor = System.Drawing.Color.White;
            this.table.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.table.ColumnCount = 5;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.table.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.table.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.table.Location = new System.Drawing.Point(189, 125);
            this.table.Name = "table";
            this.table.RowCount = 4;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.table.Size = new System.Drawing.Size(448, 226);
            this.table.TabIndex = 2;
            this.table.Paint += new System.Windows.Forms.PaintEventHandler(this.table_Paint);
            // 
            // rose
            // 
            this.rose.Image = ((System.Drawing.Image)(resources.GetObject("rose.Image")));
            this.rose.Location = new System.Drawing.Point(316, 357);
            this.rose.Name = "rose";
            this.rose.Size = new System.Drawing.Size(100, 81);
            this.rose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rose.TabIndex = 3;
            this.rose.TabStop = false;
            // 
            // customerLbl
            // 
            this.customerLbl.AutoSize = true;
            this.customerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerLbl.Location = new System.Drawing.Point(659, 168);
            this.customerLbl.Name = "customerLbl";
            this.customerLbl.Size = new System.Drawing.Size(57, 20);
            this.customerLbl.TabIndex = 4;
            this.customerLbl.Text = "label1";
            // 
            // producerLbl
            // 
            this.producerLbl.AutoSize = true;
            this.producerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.producerLbl.Location = new System.Drawing.Point(37, 168);
            this.producerLbl.Name = "producerLbl";
            this.producerLbl.Size = new System.Drawing.Size(57, 20);
            this.producerLbl.TabIndex = 5;
            this.producerLbl.Text = "label2";
            // 
            // productLbl
            // 
            this.productLbl.AutoSize = true;
            this.productLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productLbl.Location = new System.Drawing.Point(422, 386);
            this.productLbl.Name = "productLbl";
            this.productLbl.Size = new System.Drawing.Size(57, 20);
            this.productLbl.TabIndex = 6;
            this.productLbl.Text = "label3";
            // 
            // currentImg
            // 
            this.currentImg.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.currentImg.Location = new System.Drawing.Point(364, 3);
            this.currentImg.Name = "currentImg";
            this.currentImg.Size = new System.Drawing.Size(100, 116);
            this.currentImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.currentImg.TabIndex = 7;
            this.currentImg.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(491, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 34);
            this.button1.TabIndex = 8;
            this.button1.Text = "Iniciar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.currentImg);
            this.Controls.Add(this.productLbl);
            this.Controls.Add(this.producerLbl);
            this.Controls.Add(this.customerLbl);
            this.Controls.Add(this.rose);
            this.Controls.Add(this.table);
            this.Controls.Add(this.producerImg);
            this.Controls.Add(this.consumerImg);
            this.Name = "Form1";
            this.Text = "Productor Consumidor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.consumerImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.producerImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox consumerImg;
        private System.Windows.Forms.PictureBox producerImg;
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.PictureBox rose;
        private System.Windows.Forms.Label customerLbl;
        private System.Windows.Forms.Label producerLbl;
        private System.Windows.Forms.Label productLbl;
        private System.Windows.Forms.PictureBox currentImg;
        private System.Windows.Forms.Button button1;
    }
}

