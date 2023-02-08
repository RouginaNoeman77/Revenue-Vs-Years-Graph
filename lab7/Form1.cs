using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form1 : Form
    {
        //for text 
        string CompanyName;
        string CompanyReportTitle;
        Font FontCompanyName;
        Font FontCompanyReport;
        Font FontTableData;
        Font FontTable;
        Brush BrushTable;
        Color ColorBrushTable;
        Brush BrushCompanyName;
        Color ColorBrushCompanyName;
        Brush BrushCompanyReport;
        Color ColorBrushCompanyReport;
        Brush BrushTableData;
        Color ColorTableData;
        SizeF companyNameSize;
        SizeF companyReportTitleSize;
        float xForCompanyName;
        float yForCompanyName;
        float xForCompanyReport;
        float yForCompanyReport;
        float EndOfTitle;
        float HeightOfTitleLine;
        float EndOfST; //End Of SubTitle Line
        float HeightOfSTL; //Heifht of Subtitle line
        Pen CompanyNameLinePen;
        Color CompanyNameLineColor;

        //Preparing Table Data

        Rectangle TableRectangle;
        string[] YearsVsRevenue;
        int[,] YearsRevenueData;

        //X-Axis line 
        Color XLineColor;
        Pen xpen;
        Point xstartpoint;
        Point xendpoint;
        int startXx = 50;
        int startXy = 500;
        int endXx = 650;
        int endXy = 500;

        //Y-Axis Line
        Color YlineColor;
        Pen Ypen;
        Point YptStart; //(50,600)
        Point YptEnd; //()


        //X-Axis Data

        string[] years = { "1987", "1988", "1989", "1990", "1991", "1992", "1993", "1994", "1995", "1996", "1997" };

        Font FontXAxisData;
        Brush BrushXAsixData;
        Color ColorXAxisData;



        //y-axisData
        string[] revenue = { "0", "40", "80", "120", "160", "200", "240", "280" };
        Font FontYAxisData;
        Brush BrushYAxisData;
        Color ColorYAxisData;

        //X-axis-vertical-lines
        Pen XVerticalLinesPen;
        Color XVerticalLinesColor;


        //Y-axis-horizontal-line

        Pen YHorizontalLinesPen;
        Color YHorizontalLinesColor;


        // Points 

        Color GraphLinesColor;
        Pen GraphLinesPen;
        DashStyle GraphLineStyle;

        Point y1;
        Point y2;
        Point y3;
        Point y4;
        Point y5;
        Point y6;
        Point y7;
        Point y8;
        Point y9;
        Point y10;


        //BarChart Data  

        Color Bar_ForeColor;
        Color Bar_BackColor;

        Rectangle Bar_y1;
        Rectangle Bar_y2;
        Rectangle Bar_y3;
        Rectangle Bar_y4;
        Rectangle Bar_y5;
        Rectangle Bar_y6;
        Rectangle Bar_y7;
        Rectangle Bar_y8;
        Rectangle Bar_y9;
        Rectangle Bar_y10;
        Brush Bar_Brush;
        HatchStyle Bar_Style;

        
        //XAxisLabel
        string XAxisLabel;
        Color XLabelColor;
        Brush XBrushLabel;
        Point XlabelPoint;
        Font XlabelFont;

        //YAxisLabel
        string YAxisLabel;
        Color YLabelColor;
        Brush YBrushLabel;
        Point YlabelPoint;
        Font YlabelFont;

       
        public Form1()
        {
            InitializeComponent();
            
            CompanyName = "ABC Company";
            CompanyReportTitle = "Annual Revenue";
            //creating font to text and line under text
            FontCompanyName = new Font("Times New Roman", 20);
            FontCompanyReport = new Font("Times New Roman", 16);
            ColorBrushCompanyName = Color.Black;
            ColorBrushCompanyReport = Color.Green;
            BrushCompanyName = new SolidBrush(ColorBrushCompanyName);
            BrushCompanyReport = new SolidBrush(ColorBrushCompanyReport);
            CompanyNameLineColor = Color.Black;
            CompanyNameLinePen = new Pen(CompanyNameLineColor, 1);

            TableRectangle = new Rectangle(1000, 100, 500, 560);

            FontTableData = new Font("Arial", 16);
            ColorTableData = Color.Black;
            BrushTableData = new SolidBrush(ColorTableData);
            FontTable = new Font("Arial", 12);
            ColorBrushTable = Color.Blue;
            BrushTable = new SolidBrush(ColorBrushTable);

            //XAxisline 
            XLineColor = Color.Black;
            xpen = new Pen(XLineColor, 1);
            xstartpoint = new Point(startXx, startXy);
            xendpoint = new Point(endXx-150, endXy);

            //YAxisline
            YlineColor = Color.Black;
            Ypen = new Pen(YlineColor, 1);
            YptStart = new Point(startXx, startXy);
            YptEnd = new Point(startXx, startXy - 340);

            //XAxisData
            FontXAxisData = new Font("Arial", 10);
            ColorXAxisData = Color.Black;
            BrushXAsixData = new SolidBrush(ColorXAxisData);

            //YAxisData 
            FontYAxisData = new Font("Arial", 10);
            ColorYAxisData = Color.Black;
            BrushYAxisData = new SolidBrush(ColorYAxisData);


            //VerticalLinesofXAxis

            XVerticalLinesColor = Color.Black;
            XVerticalLinesPen = new Pen(XVerticalLinesColor, 1);

            //HorizontalLinesAxis

            YHorizontalLinesColor = Color.Black;
            YHorizontalLinesPen = new Pen(YHorizontalLinesColor, 1);


            //graphcolorandpen

            GraphLinesColor = Color.Blue;

            GraphLinesPen = new Pen(GraphLinesColor, 2);

            //GraphData 

            Bar_BackColor= Color.Empty;
            Bar_ForeColor= Color.Red;
            Bar_Style = HatchStyle.BackwardDiagonal;
            Bar_Brush = new HatchBrush (Bar_Style, Bar_ForeColor ,Bar_BackColor);


            //XAxisLabel
            XLabelColor= Color.Black;
            XBrushLabel = new SolidBrush(XLabelColor);
            XlabelPoint = new Point(500, 510);
            XAxisLabel = "Years";
            XlabelFont = new Font("Arial", 10);



            //YAxisLabel
            YAxisLabel = "Revenue";
            YLabelColor = Color.Black;
            YBrushLabel = new SolidBrush(YLabelColor);
            YlabelPoint = new Point(40, 120);
            YlabelFont = new Font("Arial", 10);

           

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DisplayCompanyName();
            DisplayTitleLine();
            DisplaySubTitleLine();
            DisplayTable();
            WriteInTable();
            DisplayXAxis();
            DisplayYAxis();
            DisplayXAxisData();
            DisplayYAxisData();
            DisplayVerticalLines();
            DisplayHorizontalLine();
            DrawGraph();
            Draw_Bar_Chart();
            DisplayXLabel();
            DisplayYLabel();
        }

        public void DisplayCompanyName()
        {
            Graphics g = this.CreateGraphics();

            //measuring text size
            companyNameSize = g.MeasureString(CompanyName, FontCompanyName);
            companyReportTitleSize = g.MeasureString(CompanyReportTitle, FontCompanyName);
            //companyName&titaleCentring
            xForCompanyName = (this.Width - companyNameSize.Width) / 2;
            yForCompanyName = 0;
            xForCompanyReport = (this.Width - companyReportTitleSize.Width + 50) / 2;
            yForCompanyReport = companyNameSize.Height;

            g.DrawString(CompanyName, FontCompanyName, BrushCompanyName, xForCompanyName, yForCompanyName+45);
            g.DrawString(CompanyReportTitle, FontCompanyReport, BrushCompanyReport, xForCompanyReport, yForCompanyReport+40);


        }

        public void DisplayTitleLine()
        {
            Graphics g = this.CreateGraphics();
            EndOfTitle = companyNameSize.Width + xForCompanyName;
            HeightOfTitleLine = companyNameSize.Height+40;

            g.DrawLine(CompanyNameLinePen, xForCompanyName, companyNameSize.Height+40, EndOfTitle, HeightOfTitleLine);

        }

        public void DisplaySubTitleLine()
        {
            Graphics g = this.CreateGraphics();
            EndOfST = xForCompanyReport + companyReportTitleSize.Width - 40;
            HeightOfSTL = companyReportTitleSize.Height + companyNameSize.Height+30;

            g.DrawLine(CompanyNameLinePen, xForCompanyReport, HeightOfSTL, EndOfST, HeightOfSTL);

        }

        public void DisplayTable()
        {
            Graphics g = this.CreateGraphics();
            g.DrawRectangle(Pens.Black, TableRectangle);

            Pen pen = new Pen(Color.Black, 2);
            for (int i = 0; i <= 10; i++)
            {
                int y = i * 50 + 100;
                g.DrawLine(pen, TableRectangle.X, y, TableRectangle.X + TableRectangle.Width, y);
            }

            //Drawing a vertical line that divides the table into 2 equal sides  
            g.DrawLine(pen, 1000 + TableRectangle.Width / 2, TableRectangle.Y, 1000 + TableRectangle.Width / 2, TableRectangle.Y + TableRectangle.Height);

        }


        public void WriteInTable()
        {
            Graphics g = CreateGraphics();
            YearsVsRevenue = new string[2];
            YearsVsRevenue[0] = "Years";
            YearsVsRevenue[1] = "Revenue";

            YearsRevenueData = new int[2, 10] { { 1988, 1989, 1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997 }, { 150, 170, 180, 175, 200, 250, 210, 240, 280, 140 } };
            g.DrawString(YearsVsRevenue[0], FontTableData, BrushTableData, 1090, 100 + 1 * 10);
            g.DrawString(YearsVsRevenue[1], FontTableData, BrushTableData, 1330, 100 + 2 * 5);


            for (int i = 0; i < 10; i++)
            {
                int year = YearsRevenueData[0, i];
                int revenue = YearsRevenueData[1, i];


                g.DrawString(year.ToString(), FontTableData, BrushTableData, 1090, 170 + i * 50);
                g.DrawString(revenue.ToString(), FontTableData, BrushTableData, 1330, 170 + i * 50);
            }

        }

        public void DisplayXLabel ()
        {
            Graphics g = CreateGraphics();
            g.DrawString(XAxisLabel,XlabelFont, XBrushLabel, XlabelPoint);

        }

        public void DisplayYLabel ()
        {
            Graphics g = CreateGraphics();  
            g.DrawString(YAxisLabel,YlabelFont, YBrushLabel, YlabelPoint);
        }

        public void DisplayXAxis()

        {
             xpen.EndCap = LineCap.Custom;
             xpen.CustomEndCap = new AdjustableArrowCap(6, 6);
            Graphics g = CreateGraphics();
            g.DrawLine(xpen, xstartpoint, xendpoint);
        }

        public void DisplayYAxis()
        {
            Graphics g = CreateGraphics();
            Ypen.EndCap = LineCap.Custom;
            Ypen.CustomEndCap = new AdjustableArrowCap(6, 6);
            g.DrawLine(Ypen, YptStart, YptEnd);
        }


        public void DisplayXAxisData()
        {
            Graphics g = CreateGraphics();


            for (int i = 0; i <= 10; i++)
            {
                g.DrawString(years[i], FontXAxisData, BrushXAsixData, new Point(startXx + 40 * i, startXy + 10));
            }

        }

        public void DisplayYAxisData()
        {
            Graphics g = CreateGraphics();
            for (int i = 0; i < 8; i++)
            {
                g.DrawString(revenue[i], FontYAxisData, BrushYAxisData, new Point(startXx - 40, startXy - 40 * i));

            }

        }


        public void DisplayVerticalLines()

        {
            Graphics g = CreateGraphics();
            for (int i = 1; i <= 10; i++)
            {
                g.DrawLine(XVerticalLinesPen, new Point(startXx + 40 * i, startXy), new Point(startXx + 40 * i, startXy + 10));
            }

        }


        public void DisplayHorizontalLine()
        {
            Graphics g = CreateGraphics();
            for (int i = 1; i < 8; i++)
            {
                g.DrawLine(YHorizontalLinesPen, new Point(startXx, startXy - 40 * i), new Point(startXx - 10, startXy - 40 * i));
            }
        }


        public void DrawGraph ()
        {
            Graphics g = CreateGraphics();

            y1 = new Point(90, 350);
            y2 = new Point(130, 330);
            y3 = new Point(170, 320);
            y4 = new Point(210, 325);
            y5 = new Point(250, 300);
            y6 = new Point(290, 250);
            y7 = new Point(330, 290);
            y8 = new Point(370, 260);
            y9 = new Point(410, 220);
            y10 = new Point(450, 360);

            g.DrawLine(GraphLinesPen, y1, y2);
            g.DrawLine(GraphLinesPen, y2, y3);
            g.DrawLine(GraphLinesPen, y3, y4);
            g.DrawLine(GraphLinesPen, y4, y5);
            g.DrawLine(GraphLinesPen, y5, y6);
            g.DrawLine(GraphLinesPen, y6, y7);
            g.DrawLine(GraphLinesPen, y7, y8);
            g.DrawLine(GraphLinesPen, y8, y9);
            g.DrawLine(GraphLinesPen, y9, y10);
        }

        public void Draw_Bar_Chart()
        {
            Graphics g = this.CreateGraphics();
            Bar_y1 = new Rectangle(80, 350, 20, 150);
            Bar_y2 = new Rectangle(120, 330, 20, 170);
            Bar_y3 = new Rectangle(160, 320, 20, 180);
            Bar_y4 = new Rectangle(200, 325, 20, 175);
            Bar_y5 = new Rectangle(240, 300, 20, 200);
            Bar_y6 = new Rectangle(280, 250, 20, 250);
            Bar_y7 = new Rectangle(320, 290, 20, 210);
            Bar_y8 = new Rectangle(360, 260, 20, 240);
            Bar_y9 = new Rectangle(400, 220, 20, 280);
            Bar_y10 = new Rectangle(440, 360, 20, 140);
            


            g.FillRectangle(Bar_Brush, Bar_y1);
            g.FillRectangle(Bar_Brush, Bar_y2);
            g.FillRectangle(Bar_Brush, Bar_y3);
            g.FillRectangle(Bar_Brush, Bar_y4);
            g.FillRectangle(Bar_Brush, Bar_y5);
            g.FillRectangle(Bar_Brush, Bar_y6);
            g.FillRectangle(Bar_Brush, Bar_y7);
            g.FillRectangle(Bar_Brush, Bar_y8);
            g.FillRectangle(Bar_Brush, Bar_y9);
            g.FillRectangle(Bar_Brush, Bar_y10);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch ((int)e.KeyChar)
            {
                case 2:
                    GraphLinesColor = Color.Blue;
                    break;

                case 7:
                    GraphLinesColor = Color.Green;
                    break;

                case 18: 
                    GraphLinesColor = Color.Red;
                    break;


            }

            Invalidate();
            GraphLinesPen.Color=GraphLinesColor;

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if ( e.X > startXx && e.X< endXx && e.Y< startXy&& e.Y>endXy-300)
            {
                if(e.Button== MouseButtons.Right)
                {
                    //var years = (((e.X - startXx) / 40) + 1987);

                    //var revenue = (startXy - e.Y);

                    //MessageBox.Show("Year: " + years + "\t" +"Revenue :"+ revenue);
                    this.ContextMenuStrip = contextMenuStrip2;
                }
            }
            else
            {
                this.ContextMenuStrip = contextMenuStrip1;
            }
        
        }
        
        
        //LineMenuEvents
        
        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            redToolStripMenuItem.Checked = true;
            greenToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = false;
            toolStripButton1.Checked = true;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = false;

            GraphLinesColor = Color.Red;
            Invalidate();
            GraphLinesPen.Color = GraphLinesColor;


        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = true;
            blueToolStripMenuItem.Checked = false;
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = true;
            toolStripButton3.Checked = false;
            GraphLinesColor = Color.Green;
            Invalidate();
            GraphLinesPen.Color = GraphLinesColor;

        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {

            redToolStripMenuItem.Checked = false;
            greenToolStripMenuItem.Checked = false;
            blueToolStripMenuItem.Checked = true;
            toolStripButton1.Checked = false;
            toolStripButton2.Checked =  false;
            toolStripButton3.Checked = true;
            GraphLinesColor = Color.Blue;
            Invalidate();
            GraphLinesPen.Color = GraphLinesColor;
        }

        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton4.Checked= true;
            toolStripButton5.Checked = false;
            toolStripButton6.Checked = false;
            solidToolStripMenuItem.Checked= true;
            dottedToolStripMenuItem.Checked = false;
            dashToolStripMenuItem.Checked = false;

            GraphLineStyle = DashStyle.Solid;
            Invalidate();
            GraphLinesPen.DashStyle = GraphLineStyle;
        }

        private void dashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton4.Checked = false;
            toolStripButton5.Checked = true;
            toolStripButton6.Checked = false;
            solidToolStripMenuItem.Checked = false;
            dottedToolStripMenuItem.Checked = true;
            dashToolStripMenuItem.Checked = false;
            GraphLineStyle = DashStyle.Dash;
            Invalidate();
            GraphLinesPen.DashStyle = GraphLineStyle;
        }

        private void dottedToolStripMenuItem_Click(object sender, EventArgs e)
        {

            solidToolStripMenuItem.Checked = false;
            dottedToolStripMenuItem.Checked = false;
            dashToolStripMenuItem.Checked = true;
            toolStripButton4.Checked = false;
            toolStripButton5.Checked = false;
            toolStripButton6.Checked = true;
            GraphLineStyle = DashStyle.Dot;
            Invalidate();
            GraphLinesPen.DashStyle = GraphLineStyle;

        }


        //Rectangle Menu Events 
        private void redToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            redToolStripMenuItem1.Checked = true;
            greenToolStripMenuItem1.Checked = false;
            blueToolStripMenuItem1.Checked = false;
            toolStripButton7.Checked = true;
            toolStripButton8.Checked = false;
            toolStripButton9.Checked= false;

            Bar_ForeColor = Color.Red;
            Bar_Brush = new HatchBrush(Bar_Style, Bar_ForeColor, Bar_BackColor);

            Invalidate();

        }

        private void greenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            redToolStripMenuItem1.Checked = false;
            greenToolStripMenuItem1.Checked = true;
            blueToolStripMenuItem1.Checked = false;
            toolStripButton7.Checked = false;
            toolStripButton8.Checked = true;
            toolStripButton9.Checked = false;


            Bar_ForeColor = Color.Green;

            Bar_Brush = new HatchBrush(Bar_Style, Bar_ForeColor, Bar_BackColor);
            
            Invalidate();
        }

        private void blueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            redToolStripMenuItem1.Checked = false;
            greenToolStripMenuItem1.Checked = false;
            blueToolStripMenuItem1.Checked = true;
            toolStripButton7.Checked = false;
            toolStripButton8.Checked = false;
            toolStripButton9.Checked = true;
            Bar_ForeColor = Color.Blue;

            Bar_Brush = new HatchBrush(Bar_Style, Bar_ForeColor, Bar_BackColor);

            Invalidate();

        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {

            rightToolStripMenuItem.Checked = true;
            leftToolStripMenuItem.Checked = false;
            crossToolStripMenuItem.Checked = false;
            toolStripButton10.Checked = true;
            toolStripButton11.Checked = false;
            toolStripButton12.Checked = false;

            Bar_Style = HatchStyle.BackwardDiagonal;
            Bar_Brush = new HatchBrush(Bar_Style,Bar_ForeColor,Bar_BackColor);
            Invalidate();
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {

            rightToolStripMenuItem.Checked = false;
            leftToolStripMenuItem.Checked = true;
            crossToolStripMenuItem.Checked = false;
            toolStripButton10.Checked = false;
            toolStripButton11.Checked = true;
            toolStripButton12.Checked = false;
            Bar_Style = HatchStyle.ForwardDiagonal;
            Bar_Brush = new HatchBrush(Bar_Style, Bar_ForeColor, Bar_BackColor);
            Invalidate();
        }

        private void crossToolStripMenuItem_Click(object sender, EventArgs e)
        {

            rightToolStripMenuItem.Checked = false;
            leftToolStripMenuItem.Checked = false;
            crossToolStripMenuItem.Checked = true;
            toolStripButton10.Checked = false;
            toolStripButton11.Checked = false;
            toolStripButton12.Checked = true; 
            Bar_Style = HatchStyle.Cross;
            Bar_Brush = new HatchBrush(Bar_Style, Bar_ForeColor, Bar_BackColor);
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > startXx && e.X < endXx && e.Y < startXy && e.Y > endXy - 300)
            {


                Year.Text = "Year " + (((e.X - startXx) / 40) + 1987);

                r.Text = "Revenue " + (startXy - e.Y);

            }
        }

        private void companyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();

            DialogResult dlgResult;

            frm.textBox = CompanyName;
            frm.ColorDlg = ColorBrushCompanyName;
            frm.FontProprety = FontCompanyName.Name;
            frm.SizeProprety = FontCompanyName.Size;

            dlgResult = frm.ShowDialog();

            if ( dlgResult == DialogResult.OK )
            {
                CompanyName = frm.textBox;
                ColorBrushCompanyName = frm.ColorDlg;
                FontCompanyName = new Font(frm.FontProprety, frm.SizeProprety);
                BrushCompanyName = new SolidBrush(ColorBrushCompanyName);
                Invalidate();
            }
        }

        private void companyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 Frm = new Form3();
            DialogResult DResult;

            DResult= Frm.ShowDialog();  



        }
    }
    }
    






        


