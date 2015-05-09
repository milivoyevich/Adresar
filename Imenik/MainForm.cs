/*
 * Created by SharpDevelop.
 * User: Milivoyevich
 * Date: 06-09-2013
 * Time: 23:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ICSharpCode.Reports.Core;
using ICSharpCode.Reports.Core.Exporter;
using System.IO;
using System.Data;

namespace Imenik
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		int indeks=0;
		int ida=0;
		string osistem;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ToolStripMenuItem1Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		void ToolStripMenuItem7Click(object sender, EventArgs e)
		{
			Button1Click(this,null);
		}
		
		void ToolStripMenuItem6Click(object sender, EventArgs e)
		{
		ToolStripMenuItem1Click(this,null);
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			dataSet1.Tables["tPomocna"].Rows.Clear();
			ReportParameters pm=new ReportParameters();
			DataRow red=dataSet1.Tables["tPomocna"].NewRow();
			red.ItemArray=dataSet1.Tables["tAdresar"].Rows.Find(Convert.ToInt32(label12.Text)).ItemArray;
			dataSet1.Tables["tPomocna"].Rows.Add(red);
			    ReportEngine engine = new ReportEngine();
			    if(osistem.Contains("Win"))
			   {
			    engine.PreviewPushDataReport(Application.StartupPath+@"\ReportAdr.srd",dataSet1.Tables["tPomocna"],pm);
			       }
			       else{
			       	 engine.PreviewPushDataReport(Application.StartupPath+@"\ReportAdr.srd",dataSet1.Tables["tPomocna"],pm);
			       }
			    
		}
		void postavi_temu()
		{
			string sTema=dataSet1.Tables["tPostavke"].Rows[0]["tema"].ToString();
			if(sTema=="Зелена"){ZelenaToolStripMenuItemClick(this,null);}
			if(sTema=="Плава"){PlavaToolStripMenuItemClick(this,null);}
			if(sTema=="Црвена"){CrvenaToolStripMenuItemClick(this,null);}
		}
			void postavi_jezik()
		{
			string sJezik=dataSet1.Tables["tPostavke"].Rows[0]["jezik"].ToString();
			if(sJezik=="Српски"){SrpskiToolStripMenuItemClick(this,null);}
			if(sJezik=="English"){EngleskiToolStripMenuItemClick(this,null);}
			
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			string postavka="";
			string adresar="";
			toolStripStatusLabel2.Text=" Владимир Миливојевић, +381 64 211 3258, milivoyevich@gmail.com     ";
			osistem=System.Environment.OSVersion.Platform.ToString();
			if(osistem.Contains("Win"))
			   {
			   	postavka="\\tPostavke.xml";
			   	adresar="\\tAdresar.xml";
			   }
			   else{
				button6.Enabled=false;
				button7.Enabled=false;
			   	 postavka="/tPostavke.xml";
			   	adresar="/tAdresar.xml";
			   }
			string putanja=Application.StartupPath;
			if (!File.Exists(putanja+postavka))
			    {
				dataSet1.Tables["tPostavke"].Rows.Clear();
			dataSet1.Tables["tPostavke"].Rows.Add(dataSet1.Tables["tPostavke"].NewRow());
			dataSet1.Tables["tPostavke"].Rows[0]["tema"]="Зелена";
			dataSet1.Tables["tPostavke"].Rows[0]["jezik"]="Српски";
			    	dataSet1.Tables["tPostavke"].WriteXml("tPostavke.xml");
			    }
			else {
			    dataSet1.Tables["tPostavke"].ReadXml("tPostavke.xml");
			    }	
			postavi_temu();
			postavi_jezik();
			if (!File.Exists(putanja+adresar))
			    {
			    	dataSet1.Tables["tAdresar"].WriteXml("tAdresar.xml");
			    }
			    else {
			    dataSet1.Tables["tAdresar"].ReadXml("tAdresar.xml");
			    }			    
			    dataSet1.AcceptChanges();			
			    toolStripStatusLabel1.Text=dataSet1.Tables["tAdresar"].Rows.Count.ToString("00000");
		}
		

		void Button7Click(object sender, EventArgs e)
		{
			ReportParameters pm=new ReportParameters();
			    ReportEngine engine = new ReportEngine();
			    if(osistem.Contains("Win"))
			   {
			    engine.PreviewPushDataReport(Application.StartupPath+@"\RepSpisak.srd",dataSet1.Tables["tAdresar"],pm);
			       }
			       else{
			       	engine.PreviewPushDataReport(Application.StartupPath+@"/RepSpisak.srd",dataSet1.Tables["tAdresar"],pm);
			       }
		}
		
		void GroupBox2Enter(object sender, EventArgs e)
		{
			
		}
		void zakljucb()
		{
			button1.Enabled=false;
			button2.Enabled=false;
			button3.Enabled=false;
			button4.Enabled=true;
			button5.Enabled=true;
			button8.Enabled=false;
		}
		void otkljucb()
		{
			button1.Enabled=true;
			button2.Enabled=true;
			button3.Enabled=true;
			button4.Enabled=false;
			button5.Enabled=false;
			button8.Enabled=true;
		}
		void zakljuct()
		{
			textBox1.ReadOnly=true;
			textBox2.ReadOnly=true;
			textBox3.ReadOnly=true;
			textBox4.ReadOnly=true;
			textBox5.ReadOnly=true;
			textBox6.ReadOnly=true;
			textBox7.ReadOnly=true;
			textBox8.ReadOnly=true;
			textBox9.ReadOnly=true;
			textBox10.ReadOnly=true;
			richTextBox1.ReadOnly=true;
			listBox1.Enabled=true;
		}
			void otkljuct()
		{
			textBox1.ReadOnly=false;
			textBox2.ReadOnly=false;
			textBox3.ReadOnly=false;
			textBox4.ReadOnly=false;
			textBox5.ReadOnly=false;
			textBox6.ReadOnly=false;
			textBox7.ReadOnly=false;
			textBox8.ReadOnly=false;
			textBox9.ReadOnly=false;
			textBox10.ReadOnly=false;
			richTextBox1.ReadOnly=false;
			listBox1.Enabled=false;			
		}
		void Button1Click(object sender, EventArgs e)
		{
			indeks=bindingSource1.IndexOf(bindingSource1.Current);
			DataRow novred=dataSet1.Tables["tAdresar"].NewRow();
			dataSet1.Tables["tAdresar"].Rows.Add(novred);
			bindingSource1.MoveLast();
			otkljuct();
			zakljucb();
		}
		
		void Button4Click(object sender, EventArgs e)
		{			
			if(!string.IsNullOrEmpty( textBox1.Text.Trim())){
				zakljuct();
			dataSet1.Tables["tAdresar"].AcceptChanges();
			dataSet1.Tables["tAdresar"].WriteXml("tAdresar.xml");
			toolStripStatusLabel1.Text=dataSet1.Tables["tAdresar"].Rows.Count.ToString("00000");
			otkljucb();}
			else{MessageBox.Show("Нисте унели назив!");}
			listBox1.Focus();
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			zakljuct();
			dataSet1.Tables["tAdresar"].RejectChanges();
			bindingSource1.ResetCurrentItem();
			otkljucb();
			bindingSource1.Position=indeks;
			listBox1.Focus();
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			indeks=bindingSource1.IndexOf(bindingSource1.Current);
			otkljuct();
			zakljucb();
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			indeks=bindingSource1.IndexOf(bindingSource1.Current);
			bindingSource1.RemoveCurrent();
			zakljucb();
		}
		
		void ToolStripMenuItem8Click(object sender, EventArgs e)
		{
			Button2Click(this,null);
		}
		
		void ToolStripMenuItem9Click(object sender, EventArgs e)
		{
			Button3Click(this,null);
		}
		
		void Button8Click(object sender, EventArgs e)
		{
			if(button8.Text=="Тражи"){
				button1.Enabled=false;
				button2.Enabled=false;
				button3.Enabled=false;
			string rech=textBox11.Text.Trim();
			bindingSource1.Filter="Naziv like '%"+rech+"%' or Ime like '%"+rech+"%' or Prezime like '%"+rech+"%'";
			bindingSource1.Filter+=" or Adresa like '%"+rech+"%' or Mesto like '%"+rech+"%' or Telefon like '%"+rech+"%'";
			bindingSource1.Filter+=" or Mob1 like '%"+rech+"%' or Mob2 like '%"+rech+"%' or Email1 like '%"+rech+"%'";
			bindingSource1.Filter+=" or Email2 like '%"+rech+"%' or Ostalo like '%"+rech+"%'";
			button8.Text="Одбаци";
			if(bindingSource1.Find("id",ida)>=0){bindingSource1.Position=bindingSource1.Find("id",ida);}
			}
			else{
				button1.Enabled=true;
				button2.Enabled=true;
				button3.Enabled=true;
				textBox11.Text="";
				bindingSource1.RemoveFilter();
				button8.Text="Тражи";
				bindingSource1.Position=bindingSource1.Find("id",ida);
			}
			listBox1.Focus();
		}
		
		void SrpskiToolStripMenuItemClick(object sender, EventArgs e)
		{
srpskiToolStripMenuItem.Checked=true;
engleskiToolStripMenuItem.Checked=false;
dataSet1.Tables["tPostavke"].Rows[0]["jezik"]="Српски";
dataSet1.Tables["tPostavke"].WriteXml("tPostavke.xml");
		}
		
		void EngleskiToolStripMenuItemClick(object sender, EventArgs e)
		{
		srpskiToolStripMenuItem.Checked=false;
engleskiToolStripMenuItem.Checked=true;	
dataSet1.Tables["tPostavke"].Rows[0]["jezik"]="English";
dataSet1.Tables["tPostavke"].WriteXml("tPostavke.xml");
		}
		
		void ZelenaToolStripMenuItemClick(object sender, EventArgs e)
		{
zelenaToolStripMenuItem.Checked=true;
plavaToolStripMenuItem.Checked=false;
crvenaToolStripMenuItem.Checked=false;
this.BackColor=Color.DarkSlateGray;
dataSet1.Tables["tPostavke"].Rows[0]["tema"]="Зелена";
dataSet1.Tables["tPostavke"].WriteXml("tPostavke.xml");
foreach (Control C in this.Controls)
{
	if (C.GetType()==typeof(Label)) {C.ForeColor=Color.MediumAquamarine;}
	if (C.GetType()==typeof(TextBox) || C.GetType()==typeof(RichTextBox) || C.GetType()==typeof(ListBox))
	{C.ForeColor=Color.DarkSlateGray; C.BackColor=Color.MediumAquamarine;}
	
}
		}
		
		void PlavaToolStripMenuItemClick(object sender, EventArgs e)
		{
			zelenaToolStripMenuItem.Checked=false;
plavaToolStripMenuItem.Checked=true;
crvenaToolStripMenuItem.Checked=false;
this.BackColor=Color.DarkSlateBlue;
dataSet1.Tables["tPostavke"].Rows[0]["tema"]="Плава";
dataSet1.Tables["tPostavke"].WriteXml("tPostavke.xml");
foreach (Control C in this.Controls)
{
	if (C.GetType()==typeof(Label)) {C.ForeColor=Color.AliceBlue;}
	if (C.GetType()==typeof(TextBox) || C.GetType()==typeof(RichTextBox) || C.GetType()==typeof(ListBox))
	{C.ForeColor=Color.DarkSlateBlue; C.BackColor=Color.AliceBlue;}
	
}
		}
		
		void CrvenaToolStripMenuItemClick(object sender, EventArgs e)
		{
zelenaToolStripMenuItem.Checked=false;
plavaToolStripMenuItem.Checked=false;
crvenaToolStripMenuItem.Checked=true;	
this.BackColor=Color.Maroon;
dataSet1.Tables["tPostavke"].Rows[0]["tema"]="Црвена";
dataSet1.Tables["tPostavke"].WriteXml("tPostavke.xml");
foreach (Control C in this.Controls)
{
	if (C.GetType()==typeof(Label)) {C.ForeColor=Color.MistyRose;}
	if (C.GetType()==typeof(TextBox) || C.GetType()==typeof(RichTextBox) || C.GetType()==typeof(ListBox))
	{C.ForeColor=Color.Maroon; C.BackColor=Color.MistyRose;}
	
}
		}
		
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			indeks=bindingSource1.IndexOf(bindingSource1.Current);
			ida=Convert.ToInt32(label12.Text);
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			toolStripStatusLabel2.Text=toolStripStatusLabel2.Text.Substring(1)+toolStripStatusLabel2.Text.Substring(0,1);
		}
	}
}
