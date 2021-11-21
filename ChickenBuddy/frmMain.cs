using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ChickenBuddy
{
	[DesignerGenerated]
	public class frmMain : Form
	{
		private IContainer components;

		internal virtual Button cmdStartStop
		{
			[CompilerGenerated]
			get
			{
				return _cmdStartStop;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler value2 = cmdStartStop_Click;
				Button button = _cmdStartStop;
				if (button != null)
				{
					button.Click -= value2;
				}
				_cmdStartStop = value;
				button = _cmdStartStop;
				if (button != null)
				{
					button.Click += value2;
				}
			}
		}

		[field: AccessedThroughProperty("gbOverview")]
		internal virtual GroupBox gbOverview
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("lblCurrentLife")]
		internal virtual Label lblCurrentLife
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("lblGameClose")]
		internal virtual Label lblGameClose
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("lblLifePercent")]
		internal virtual Label lblLifePercent
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("lblMaxLife")]
		internal virtual Label lblMaxLife
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("txtCloseGameAt")]
		internal virtual TextBox txtCloseGameAt
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("txtLifePercent")]
		internal virtual TextBox txtLifePercent
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("txtMaxLife")]
		internal virtual TextBox txtMaxLife
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("txtCurrentLife")]
		internal virtual TextBox txtCurrentLife
		{
			get; [MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Timer tmrChicken
		{
			[CompilerGenerated]
			get
			{
				return _tmrChicken;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[CompilerGenerated]
			set
			{
				EventHandler value2 = tmrChicken_Tick;
				Timer timer = _tmrChicken;
				if (timer != null)
				{
					timer.Tick -= value2;
				}
				_tmrChicken = value;
				timer = _tmrChicken;
				if (timer != null)
				{
					timer.Tick += value2;
				}
			}
		}

		public frmMain()
		{
			InitializeComponent();
		}

		private void cmdStartStop_Click(object sender, EventArgs e)
		{
			if (!Versioned.IsNumeric(txtCloseGameAt.Text))
			{
				Interaction.MsgBox("Enter a valid number");
			}
			else if (Operators.CompareString(cmdStartStop.Text, "Start", TextCompare: false) == 0)
			{
				cmdStartStop.Text = "Stop";
				cmdStartStop.BackColor = Color.Firebrick;
				txtCurrentLife.Text = "";
				txtMaxLife.Text = "";
				txtLifePercent.Text = "";
				tmrChicken.Enabled = true;
			}
			else
			{
				cmdStartStop.Text = "Start";
				cmdStartStop.BackColor = Color.Lime;
				tmrChicken.Enabled = false;
				txtCurrentLife.Text = "";
				txtMaxLife.Text = "";
				txtLifePercent.Text = "";
			}
		}

		private void tmrChicken_Tick(object sender, EventArgs e)
		{
			if (Process.GetProcessesByName("D2R").Count() == 0)
			{
				txtCurrentLife.Text = "Game not found";
				txtMaxLife.Text = "Game not found";
				txtLifePercent.Text = "Game not found";
				return;
			}
			GameData gameData = new GameData(Process.GetProcessesByName("D2R").ElementAt(0));
			if (gameData.mapSeed == 0)
			{
				txtCurrentLife.Text = "Not in a Game";
				txtMaxLife.Text = "Not in a Game";
				txtLifePercent.Text = "Not in a Game";
				return;
			}
			int num = Conversions.ToInteger(gameData.getStatValue(6));
			int num2 = Conversions.ToInteger(gameData.getStatValue(7));
			double num3 = Math.Round((double)num / (double)num2, 2) * 100.0;
			txtCurrentLife.Text = num.ToString();
			txtMaxLife.Text = num2.ToString();
			txtLifePercent.Text = num3.ToString();
			if (!(num3 < (double)int.Parse(txtCloseGameAt.Text)))
			{
				return;
			}
			cmdStartStop.PerformClick();
			while (Process.GetProcessesByName("D2R").Count() > 0)
			{
				try
				{
					Process.GetProcessesByName("D2R").ElementAt(0).Kill();
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ProjectData.ClearProjectError();
				}
			}
		}

		[DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		[System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChickenBuddy.frmMain));
			cmdStartStop = new System.Windows.Forms.Button();
			gbOverview = new System.Windows.Forms.GroupBox();
			txtCloseGameAt = new System.Windows.Forms.TextBox();
			txtLifePercent = new System.Windows.Forms.TextBox();
			txtMaxLife = new System.Windows.Forms.TextBox();
			txtCurrentLife = new System.Windows.Forms.TextBox();
			lblGameClose = new System.Windows.Forms.Label();
			lblLifePercent = new System.Windows.Forms.Label();
			lblMaxLife = new System.Windows.Forms.Label();
			lblCurrentLife = new System.Windows.Forms.Label();
			tmrChicken = new System.Windows.Forms.Timer(components);
			gbOverview.SuspendLayout();
			SuspendLayout();
			cmdStartStop.BackColor = System.Drawing.Color.Lime;
			cmdStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			cmdStartStop.Location = new System.Drawing.Point(216, 161);
			cmdStartStop.Name = "cmdStartStop";
			cmdStartStop.Size = new System.Drawing.Size(95, 26);
			cmdStartStop.TabIndex = 1;
			cmdStartStop.Text = "Start";
			cmdStartStop.UseVisualStyleBackColor = false;
			gbOverview.Controls.Add(txtCloseGameAt);
			gbOverview.Controls.Add(txtLifePercent);
			gbOverview.Controls.Add(txtMaxLife);
			gbOverview.Controls.Add(txtCurrentLife);
			gbOverview.Controls.Add(lblGameClose);
			gbOverview.Controls.Add(lblLifePercent);
			gbOverview.Controls.Add(lblMaxLife);
			gbOverview.Controls.Add(lblCurrentLife);
			gbOverview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			gbOverview.Location = new System.Drawing.Point(12, 12);
			gbOverview.Name = "gbOverview";
			gbOverview.Size = new System.Drawing.Size(299, 143);
			gbOverview.TabIndex = 6;
			gbOverview.TabStop = false;
			gbOverview.Text = "Overview";
			txtCloseGameAt.Location = new System.Drawing.Point(176, 111);
			txtCloseGameAt.Name = "txtCloseGameAt";
			txtCloseGameAt.Size = new System.Drawing.Size(117, 22);
			txtCloseGameAt.TabIndex = 14;
			txtCloseGameAt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtLifePercent.Location = new System.Drawing.Point(176, 83);
			txtLifePercent.Name = "txtLifePercent";
			txtLifePercent.Size = new System.Drawing.Size(117, 22);
			txtLifePercent.TabIndex = 13;
			txtLifePercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtMaxLife.Location = new System.Drawing.Point(176, 55);
			txtMaxLife.Name = "txtMaxLife";
			txtMaxLife.Size = new System.Drawing.Size(117, 22);
			txtMaxLife.TabIndex = 12;
			txtMaxLife.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			txtCurrentLife.Location = new System.Drawing.Point(176, 27);
			txtCurrentLife.Name = "txtCurrentLife";
			txtCurrentLife.Size = new System.Drawing.Size(117, 22);
			txtCurrentLife.TabIndex = 11;
			txtCurrentLife.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			lblGameClose.AutoSize = true;
			lblGameClose.Location = new System.Drawing.Point(6, 114);
			lblGameClose.Name = "lblGameClose";
			lblGameClose.Size = new System.Drawing.Size(153, 16);
			lblGameClose.TabIndex = 10;
			lblGameClose.Text = "Close game below %";
			lblLifePercent.AutoSize = true;
			lblLifePercent.Location = new System.Drawing.Point(6, 86);
			lblLifePercent.Name = "lblLifePercent";
			lblLifePercent.Size = new System.Drawing.Size(50, 16);
			lblLifePercent.TabIndex = 9;
			lblLifePercent.Text = "Life %";
			lblMaxLife.AutoSize = true;
			lblMaxLife.Location = new System.Drawing.Point(6, 58);
			lblMaxLife.Name = "lblMaxLife";
			lblMaxLife.Size = new System.Drawing.Size(65, 16);
			lblMaxLife.TabIndex = 8;
			lblMaxLife.Text = "Max Life";
			lblCurrentLife.AutoSize = true;
			lblCurrentLife.Location = new System.Drawing.Point(6, 30);
			lblCurrentLife.Name = "lblCurrentLife";
			lblCurrentLife.Size = new System.Drawing.Size(86, 16);
			lblCurrentLife.TabIndex = 7;
			lblCurrentLife.Text = "Current Life";
			tmrChicken.Interval = 10;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(323, 198);
			base.Controls.Add(gbOverview);
			base.Controls.Add(cmdStartStop);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "frmMain";
			Text = "ChickenBuddy by Dragonelf";
			gbOverview.ResumeLayout(false);
			gbOverview.PerformLayout();
			ResumeLayout(false);
		}
	}
}
