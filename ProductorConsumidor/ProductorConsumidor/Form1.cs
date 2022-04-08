using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ProductorConsumidor
{
    public partial class Form1 : Form
    {
        System.Timers.Timer waitP;
        System.Timers.Timer waitC;
        private Thread producerT;
        private Thread consumerT;
        private Semaphore semaforo = new Semaphore();
        private bool consumerSleeping;
        private bool producerSleeping;
        private int consumerPoint;
        private int producerPoint;
        private bool other;
        private int all;
        private bool waitProducer;
        private bool waitConsumer;
        private bool goProducer;
        private bool finished;
        public Form1()
        {
            InitializeComponent();

        }
        private void fill()
        {
            for (int i = 0; i < 20; i++)
            {
                fillElement(i);
            }

            table.CellPaint += tableLayoutPanel1_CellPaint;
        }
        private void clear()
        {
            consumerPoint = 0;
            producerPoint = 0;
            producerSleeping = false;
            consumerSleeping = true;
            all = 0;
            semaforo.Reset();
            goProducer = true;
            other = true;
            this.Refresh();
            for (int i = 0; i < table.ColumnCount; i++)
            {
                for (int j = 0; j < table.RowCount; j++)
                {
                    PictureBox x = table.GetControlFromPosition(i, j) as PictureBox;
                    if (x != null)
                    {
                        x.Visible = false;
                    }

                }
            }
            table.CellPaint += tableLayoutPanel1_CellPaint;
            currentImg.Image = null;
            producerLbl.Text = "";
            customerLbl.Text = "";
            productLbl.Text = "";

        }
        private void fillElement(int k)
        {
            int j = k / table.ColumnCount;
            int i = k - (j * table.ColumnCount);
            PictureBox pB = table.GetControlFromPosition(i, j) as PictureBox;
            if (pB == null)
            {
                pB = new PictureBox
                {
                    Size = MaximumSize,
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                pB.Image = rose.Image;
                table.Controls.Add(pB, i, j);
            }
            pB.Visible = true;

            all++;
            this.BeginInvoke(new MethodInvoker(delegate
            {
                if (finished)
                {
                    clear();
                    return;
                }
                productLbl.Text = all.ToString();
            }));
        }
        public void clearElement(int k)
        {
            int j = k / table.ColumnCount;
            int i = k - (j * table.ColumnCount);
            PictureBox x = table.GetControlFromPosition(i, j) as PictureBox;
            if (x != null)
            {
                x.Visible = false;
            }
            all--;
            this.BeginInvoke(new MethodInvoker(delegate
              {
                  if (finished)
                  {
                      clear();
                      return;
                  }
                  productLbl.Text = all.ToString();
              }));
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            this.KeyPreview = true;
            clear();
            button1.BackColor = Color.DeepSkyBlue;
            SetDoubleBuffered(table);

        }


        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered",
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }
        void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

            var panel = sender as TableLayoutPanel;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            var rectangle = e.CellBounds;
            using (var pen = new Pen(Color.Purple, 3))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                if (e.Row == (panel.RowCount - 1))
                {
                    rectangle.Height -= 1;
                }

                if (e.Column == (panel.ColumnCount - 1))
                {
                    rectangle.Width -= 1;
                }

                e.Graphics.DrawRectangle(pen, rectangle);
            }
        }
        public void Producer()
        {
            try
            {
                waitP = new System.Timers.Timer(1000);
                waitP.Elapsed += FinishP;
                Random rp = new Random();
                int tp;
                while (other)
                {
                    if (goProducer)
                    {

                        while (producerSleeping && other)
                        {
                            continue;
                        }
                        if (!other)
                        {
                            return;
                        }
                        tp = rp.Next(1, 3);
                        Thread.Sleep(tp * 1000);

                        this.BeginInvoke(new MethodInvoker(delegate
                        {
                            if (finished)
                            {
                                clear();
                                return;
                            }
                            producerLbl.Text = "Intentando";
                        }));
                        waitProducer = true;
                        waitP.Start();
                        while (waitProducer)
                        {
                            continue;
                        }
                        if (semaforo.products < 20)
                        {
                            int cantP = rp.Next(1, 4);
                            if (semaforo.products + cantP > 20)
                            {
                                cantP = 20 - semaforo.products;
                            }
                            while (!semaforo.available)
                            {
                                continue;
                            }
                            semaforo.available = false;
                            semaforo.SemWait(0);
                            semaforo.available = true;
                            while (semaforo.wait[0] == 0 && other)
                            {
                                continue;
                            }
                            if (!other)
                            {
                                return;
                            }
                            this.BeginInvoke(new MethodInvoker(delegate
                            {
                                if (finished)
                                {
                                    clear();
                                    return;
                                }
                                currentImg.Image = producerImg.Image;
                                producerLbl.Text = "Trabajando " + cantP.ToString();
                            }));
                            waitProducer = true;
                            waitP.Start();
                            while (waitProducer)
                            {
                                continue;
                            }
                            if (!other)
                            {
                                return;
                            }
                            this.BeginInvoke(new MethodInvoker(delegate
                            {
                                if (finished)
                                {
                                    clear();
                                    return;
                                }
                                semaforo.products += cantP;
                                for (int i = 0; i < cantP; i++)
                                {

                                    fillElement(producerPoint++);

                                    producerPoint %= 20;
                                }
                                producerLbl.Text = "Durmiendo";
                                currentImg.Image = null;


                            }));
                            while (!semaforo.available)
                            {
                                continue;
                            }
                            semaforo.available = false;
                            semaforo.SemSignal(0);
                            semaforo.available = true;
                            consumerSleeping = false;

                            int zzz = rp.Next(1, 100);
                            if (zzz % 2 == 0)
                            {
                                goProducer = true;
                                producerSleeping = false;
                            }
                            else
                            {
                                goProducer = false;
                                consumerSleeping = false;
                            }
                        }
                        else
                        {
                            producerSleeping = true;
                            this.BeginInvoke(new MethodInvoker(delegate
                            {
                                if (finished)
                                {
                                    clear();
                                    return;
                                }
                                producerLbl.Text = "Durmiendo";
                            }));
                            int zzz = rp.Next(1, 100);
                            if (zzz % 2 == 0)
                            {
                                goProducer = true;
                                producerSleeping = false;
                            }
                            else
                            {
                                goProducer = false;
                                consumerSleeping = false;
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                producerLbl.Text = "";
                customerLbl.Text = "";
                productLbl.Text = "";

            }
        }
        public void Consumer()
        {
            try
            {
                waitC = new System.Timers.Timer(1000);
                waitC.Elapsed += FinishC;
                Random rc = new Random();
                int tc;
                while (other)
                {
                    if (!goProducer)
                    {

                        while (consumerSleeping && other)
                        {
                            continue;
                        }
                        if (!other)
                        {
                            return;
                        }
                        tc = rc.Next(1, 3);
                        Thread.Sleep(tc * 1000);
                        this.BeginInvoke(new MethodInvoker(delegate
                        {
                            if (finished)
                            {
                                clear();
                                return;
                            }
                            customerLbl.Text = "Intentando";
                        }));
                        waitConsumer = true;
                        waitC.Start();
                        while (waitConsumer)
                        {
                            continue;
                        }
                        if (semaforo.products > 0)
                        {
                            int cantC = rc.Next(1, 4);
                            if (semaforo.products < cantC)
                            {
                                cantC = semaforo.products;
                            }
                            while (!semaforo.available)
                            {
                                continue;
                            }
                            semaforo.available = false;
                            semaforo.SemWait(1);
                            semaforo.available = true;
                            while (semaforo.wait[1] == 0 && other)
                            {
                                continue;
                            }
                            if (!other)
                            {
                                return;
                            }
                            this.BeginInvoke(new MethodInvoker(delegate
                            {
                                if (finished)
                                {
                                    clear();
                                    return;
                                }
                                currentImg.Image = consumerImg.Image;

                                customerLbl.Text = "Comprando " + cantC.ToString();
                            }));
                            waitConsumer = true;
                            waitC.Start();
                            while (waitConsumer)
                            {
                                continue;
                            }
                            if (!other)
                            {
                                return;
                            }
                            this.BeginInvoke(new MethodInvoker(delegate
                            {
                                if (finished)
                                {
                                    clear();
                                    return;
                                }
                                semaforo.products -= cantC;
                                for (int i = 0; i < cantC; i++)
                                {

                                    clearElement(consumerPoint++);
                                    consumerPoint %= 20;

                                }
                                customerLbl.Text = "Durmiendo";
                                currentImg.Image = null;
                            }));

                            while (!semaforo.available)
                            {
                                continue;
                            }
                            semaforo.available = false;
                            semaforo.SemSignal(1);
                            semaforo.available = true;
                            producerSleeping = false;

                            int zzz = rc.Next(1, 100);
                            if (zzz % 2 == 0)
                            {
                                goProducer = true;
                                producerSleeping = false;
                            }
                            else
                            {
                                goProducer = false;
                                consumerSleeping = false;
                            }

                        }
                        else
                        {
                            consumerSleeping = true;
                            this.BeginInvoke(new MethodInvoker(delegate
                            {
                                if (finished)
                                {
                                    clear();
                                    return;
                                }
                                customerLbl.Text = "Durmiendo";
                            }));
                            int zzz = rc.Next(1, 100);
                            if (zzz % 2 == 0)
                            {
                                goProducer = true;
                                producerSleeping = false;
                            }
                            else
                            {
                                goProducer = false;
                                consumerSleeping = false;
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                producerLbl.Text = "";
                customerLbl.Text = "";
                productLbl.Text = "";
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                this.Close();


            }
        }
        private void stop()
        {
            finished = true;
            if (button1.Text == "Iniciar")
            {
                return;
            }
            try
            {
                waitProducer = false;
                waitP.Stop();
                waitConsumer = false;
                waitC.Stop();
                other = false;
                while (producerT.IsAlive || consumerT.IsAlive)
                {
                    continue;
                }
                clear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        private void startBtn_Click(object sender, EventArgs e)
        {
            producerT.Start();
            consumerT.Start();
        }

        public void FinishP(object sender, ElapsedEventArgs e)
        {
            waitProducer = false;
            waitP.Stop();
        }

        public void FinishC(object sender, ElapsedEventArgs e)
        {

            waitConsumer = false;
            waitC.Stop();
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            other = false;
            while (producerT.IsAlive || consumerT.IsAlive)
            {
                continue;
            }
            clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop();
        }

        private void table_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Iniciar")
            {
                finished = false;
                producerT = new Thread(new ThreadStart(Producer));
                consumerT = new Thread(new ThreadStart(Consumer));

                producerT.Start();
                consumerT.Start();
                button1.Text = "Detener";
                button1.BackColor = Color.DarkOliveGreen;
                button1.ForeColor = Color.White;
            }
            else
            {
                button1.BackColor = Color.DeepSkyBlue;
                button1.ForeColor = Color.Black;
                stop();

                button1.Text = "Iniciar";

            }

        }
    }
}
