using System.ComponentModel;

namespace mlc_series_search
{
    partial class mlcseriessearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mlcseriessearch));
            this.SearchText = new System.Windows.Forms.TextBox();
            this.SeasonCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EpisodeCombo = new System.Windows.Forms.ComboBox();
            this.filter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.abobtn = new System.Windows.Forms.Button();
            this.SearchResultList = new System.Windows.Forms.ListBox();
            this.EpisodeList = new System.Windows.Forms.ListBox();
            this.SeasonCheck = new System.Windows.Forms.CheckBox();
            this.EpisodeCheck = new System.Windows.Forms.CheckBox();
            this.xRelList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LaufzeitLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.GerneLabel = new System.Windows.Forms.Label();
            this.AirDateLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SeriesNameLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BeschreibungText = new System.Windows.Forms.RichTextBox();
            this.SeriesPic = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.abolist = new System.Windows.Forms.ListBox();
            this.del_abo = new System.Windows.Forms.Button();
            this.mlcupslist = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.requesttext = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.bylabel = new System.Windows.Forms.Label();
            this.proglabel = new System.Windows.Forms.Label();
            this.versionlabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnxRelNFO = new System.Windows.Forms.Button();
            this.btnxRelRel = new System.Windows.Forms.Button();
            this.releinheit = new System.Windows.Forms.Label();
            this.l = new System.Windows.Forms.Label();
            this.relsize = new System.Windows.Forms.Label();
            this.relaud = new System.Windows.Forms.Label();
            this.relvid = new System.Windows.Forms.Label();
            this.relrating = new System.Windows.Forms.Label();
            this.relgroup = new System.Windows.Forms.Label();
            this.reltime = new System.Windows.Forms.Label();
            this.reldate = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.relname = new System.Windows.Forms.Label();
            this.VideoCombo = new System.Windows.Forms.ComboBox();
            this.AudioCombo = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.EngCheck = new System.Windows.Forms.CheckBox();
            this.MLCWorker = new System.ComponentModel.BackgroundWorker();
            this.mlcwork = new System.Windows.Forms.Button();
            this.xRelWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeriesPic)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(12, 18);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(317, 20);
            this.SearchText.TabIndex = 0;
            this.SearchText.TextChanged += new System.EventHandler(this.SearchText_Validated);
            this.SearchText.Validated += new System.EventHandler(this.SearchText_Validated);
            // 
            // SeasonCombo
            // 
            this.SeasonCombo.FormattingEnabled = true;
            this.SeasonCombo.Location = new System.Drawing.Point(337, 18);
            this.SeasonCombo.Name = "SeasonCombo";
            this.SeasonCombo.Size = new System.Drawing.Size(118, 21);
            this.SeasonCombo.TabIndex = 2;
            this.SeasonCombo.SelectedIndexChanged += new System.EventHandler(this.Season_Changed);
            this.SeasonCombo.SelectionChangeCommitted += new System.EventHandler(this.Season_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Suchen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Abonnements:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Staffel:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(458, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Folge:";
            // 
            // EpisodeCombo
            // 
            this.EpisodeCombo.FormattingEnabled = true;
            this.EpisodeCombo.Location = new System.Drawing.Point(461, 18);
            this.EpisodeCombo.Name = "EpisodeCombo";
            this.EpisodeCombo.Size = new System.Drawing.Size(118, 21);
            this.EpisodeCombo.TabIndex = 13;
            this.EpisodeCombo.SelectedIndexChanged += new System.EventHandler(this.Episode_Change);
            this.EpisodeCombo.SelectionChangeCommitted += new System.EventHandler(this.Episode_Change);
            // 
            // filter
            // 
            this.filter.Location = new System.Drawing.Point(587, 60);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(227, 20);
            this.filter.TabIndex = 15;
            this.filter.TextChanged += new System.EventHandler(this.Filter_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(587, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Zusatzfilter:";
            // 
            // abobtn
            // 
            this.abobtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.abobtn.Location = new System.Drawing.Point(903, 15);
            this.abobtn.Name = "abobtn";
            this.abobtn.Size = new System.Drawing.Size(108, 23);
            this.abobtn.TabIndex = 18;
            this.abobtn.Text = "Abonieren";
            this.abobtn.UseVisualStyleBackColor = false;
            this.abobtn.Click += new System.EventHandler(this.Abo_Click);
            // 
            // SearchResultList
            // 
            this.SearchResultList.FormattingEnabled = true;
            this.SearchResultList.Location = new System.Drawing.Point(12, 44);
            this.SearchResultList.Name = "SearchResultList";
            this.SearchResultList.Size = new System.Drawing.Size(317, 147);
            this.SearchResultList.TabIndex = 19;
            this.SearchResultList.Click += new System.EventHandler(this.SearchResultList_Click);
            // 
            // EpisodeList
            // 
            this.EpisodeList.FormattingEnabled = true;
            this.EpisodeList.Location = new System.Drawing.Point(338, 100);
            this.EpisodeList.Name = "EpisodeList";
            this.EpisodeList.Size = new System.Drawing.Size(241, 290);
            this.EpisodeList.TabIndex = 21;
            this.EpisodeList.Click += new System.EventHandler(this.EpisodeList_Click);
            // 
            // SeasonCheck
            // 
            this.SeasonCheck.AutoSize = true;
            this.SeasonCheck.Location = new System.Drawing.Point(337, 44);
            this.SeasonCheck.Name = "SeasonCheck";
            this.SeasonCheck.Size = new System.Drawing.Size(71, 17);
            this.SeasonCheck.TabIndex = 22;
            this.SeasonCheck.Text = "ab Staffel";
            this.SeasonCheck.UseVisualStyleBackColor = true;
            this.SeasonCheck.CheckedChanged += new System.EventHandler(this.Season_Changed);
            // 
            // EpisodeCheck
            // 
            this.EpisodeCheck.AutoSize = true;
            this.EpisodeCheck.Checked = true;
            this.EpisodeCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EpisodeCheck.Location = new System.Drawing.Point(461, 45);
            this.EpisodeCheck.Name = "EpisodeCheck";
            this.EpisodeCheck.Size = new System.Drawing.Size(67, 17);
            this.EpisodeCheck.TabIndex = 23;
            this.EpisodeCheck.Text = "ab Folge";
            this.EpisodeCheck.UseVisualStyleBackColor = true;
            this.EpisodeCheck.CheckedChanged += new System.EventHandler(this.Episode_Change);
            // 
            // xRelList
            // 
            this.xRelList.FormattingEnabled = true;
            this.xRelList.HorizontalScrollbar = true;
            this.xRelList.Location = new System.Drawing.Point(587, 100);
            this.xRelList.Name = "xRelList";
            this.xRelList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.xRelList.Size = new System.Drawing.Size(227, 290);
            this.xRelList.TabIndex = 24;
            this.xRelList.SelectedIndexChanged += new System.EventHandler(this.xRelList_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(587, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Releases";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Folgen";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LaufzeitLabel);
            this.groupBox1.Controls.Add(this.StatusLabel);
            this.groupBox1.Controls.Add(this.GerneLabel);
            this.groupBox1.Controls.Add(this.AirDateLabel);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.SeriesNameLabel);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.BeschreibungText);
            this.groupBox1.Controls.Add(this.SeriesPic);
            this.groupBox1.Location = new System.Drawing.Point(12, 396);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 200);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serien Info";
            // 
            // LaufzeitLabel
            // 
            this.LaufzeitLabel.AutoSize = true;
            this.LaufzeitLabel.Location = new System.Drawing.Point(488, 61);
            this.LaufzeitLabel.Name = "LaufzeitLabel";
            this.LaufzeitLabel.Size = new System.Drawing.Size(0, 13);
            this.LaufzeitLabel.TabIndex = 11;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(488, 43);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 13);
            this.StatusLabel.TabIndex = 10;
            // 
            // GerneLabel
            // 
            this.GerneLabel.AutoSize = true;
            this.GerneLabel.Location = new System.Drawing.Point(246, 61);
            this.GerneLabel.Name = "GerneLabel";
            this.GerneLabel.Size = new System.Drawing.Size(0, 13);
            this.GerneLabel.TabIndex = 9;
            // 
            // AirDateLabel
            // 
            this.AirDateLabel.AutoSize = true;
            this.AirDateLabel.Location = new System.Drawing.Point(246, 43);
            this.AirDateLabel.Name = "AirDateLabel";
            this.AirDateLabel.Size = new System.Drawing.Size(0, 13);
            this.AirDateLabel.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(429, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Laufzeit:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(429, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Status:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(153, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Gerne:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(153, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Erstausstrahlung:";
            // 
            // SeriesNameLabel
            // 
            this.SeriesNameLabel.AutoSize = true;
            this.SeriesNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeriesNameLabel.Location = new System.Drawing.Point(152, 19);
            this.SeriesNameLabel.Name = "SeriesNameLabel";
            this.SeriesNameLabel.Size = new System.Drawing.Size(0, 20);
            this.SeriesNameLabel.TabIndex = 3;
            this.SeriesNameLabel.UseMnemonic = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(153, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Beschreibung";
            // 
            // BeschreibungText
            // 
            this.BeschreibungText.Location = new System.Drawing.Point(153, 98);
            this.BeschreibungText.Name = "BeschreibungText";
            this.BeschreibungText.ReadOnly = true;
            this.BeschreibungText.Size = new System.Drawing.Size(408, 96);
            this.BeschreibungText.TabIndex = 1;
            this.BeschreibungText.Text = "";
            // 
            // SeriesPic
            // 
            this.SeriesPic.Location = new System.Drawing.Point(6, 19);
            this.SeriesPic.Name = "SeriesPic";
            this.SeriesPic.Size = new System.Drawing.Size(135, 175);
            this.SeriesPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SeriesPic.TabIndex = 0;
            this.SeriesPic.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(63, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(266, 10);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 28;
            this.progressBar1.Visible = false;
            // 
            // abolist
            // 
            this.abolist.FormattingEnabled = true;
            this.abolist.Location = new System.Drawing.Point(12, 217);
            this.abolist.Name = "abolist";
            this.abolist.Size = new System.Drawing.Size(317, 173);
            this.abolist.TabIndex = 29;
            this.abolist.Click += new System.EventHandler(this.abolist_Click);
            // 
            // del_abo
            // 
            this.del_abo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.del_abo.Location = new System.Drawing.Point(1017, 15);
            this.del_abo.Name = "del_abo";
            this.del_abo.Size = new System.Drawing.Size(28, 23);
            this.del_abo.TabIndex = 30;
            this.del_abo.Text = "X";
            this.del_abo.UseVisualStyleBackColor = false;
            this.del_abo.Click += new System.EventHandler(this.del_abo_Click);
            // 
            // mlcupslist
            // 
            this.mlcupslist.FormattingEnabled = true;
            this.mlcupslist.HorizontalScrollbar = true;
            this.mlcupslist.Location = new System.Drawing.Point(820, 100);
            this.mlcupslist.Name = "mlcupslist";
            this.mlcupslist.Size = new System.Drawing.Size(227, 147);
            this.mlcupslist.TabIndex = 31;
            this.mlcupslist.DoubleClick += new System.EventHandler(this.mlcupslist_DoubleClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(817, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Uploads";
            // 
            // requesttext
            // 
            this.requesttext.Location = new System.Drawing.Point(820, 277);
            this.requesttext.Name = "requesttext";
            this.requesttext.Size = new System.Drawing.Size(227, 76);
            this.requesttext.TabIndex = 33;
            this.requesttext.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(819, 261);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Request";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(829, 359);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 35;
            this.button2.Text = "Normal";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button3.Location = new System.Drawing.Point(944, 359);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 23);
            this.button3.TabIndex = 36;
            this.button3.Text = "Spender";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // bylabel
            // 
            this.bylabel.AutoSize = true;
            this.bylabel.Location = new System.Drawing.Point(1010, 594);
            this.bylabel.Name = "bylabel";
            this.bylabel.Size = new System.Drawing.Size(44, 13);
            this.bylabel.TabIndex = 37;
            this.bylabel.Text = "by raz3r";
            // 
            // proglabel
            // 
            this.proglabel.AutoSize = true;
            this.proglabel.Location = new System.Drawing.Point(810, 594);
            this.proglabel.Name = "proglabel";
            this.proglabel.Size = new System.Drawing.Size(107, 13);
            this.proglabel.TabIndex = 38;
            this.proglabel.Text = "MLC Serien Manager";
            // 
            // versionlabel
            // 
            this.versionlabel.AutoSize = true;
            this.versionlabel.Location = new System.Drawing.Point(923, 594);
            this.versionlabel.Name = "versionlabel";
            this.versionlabel.Size = new System.Drawing.Size(81, 13);
            this.versionlabel.TabIndex = 39;
            this.versionlabel.Text = "Version: 0.0.0.1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnxRelNFO);
            this.groupBox2.Controls.Add(this.btnxRelRel);
            this.groupBox2.Controls.Add(this.releinheit);
            this.groupBox2.Controls.Add(this.l);
            this.groupBox2.Controls.Add(this.relsize);
            this.groupBox2.Controls.Add(this.relaud);
            this.groupBox2.Controls.Add(this.relvid);
            this.groupBox2.Controls.Add(this.relrating);
            this.groupBox2.Controls.Add(this.relgroup);
            this.groupBox2.Controls.Add(this.reltime);
            this.groupBox2.Controls.Add(this.reldate);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.relname);
            this.groupBox2.Location = new System.Drawing.Point(590, 396);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(449, 200);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Release Info";
            // 
            // btnxRelNFO
            // 
            this.btnxRelNFO.Enabled = false;
            this.btnxRelNFO.Location = new System.Drawing.Point(254, 158);
            this.btnxRelNFO.Name = "btnxRelNFO";
            this.btnxRelNFO.Size = new System.Drawing.Size(165, 23);
            this.btnxRelNFO.TabIndex = 29;
            this.btnxRelNFO.Text = "xRel NFO";
            this.btnxRelNFO.UseVisualStyleBackColor = true;
            this.btnxRelNFO.Click += new System.EventHandler(this.btnxRelNFO_Click);
            // 
            // btnxRelRel
            // 
            this.btnxRelRel.Enabled = false;
            this.btnxRelRel.Location = new System.Drawing.Point(20, 158);
            this.btnxRelRel.Name = "btnxRelRel";
            this.btnxRelRel.Size = new System.Drawing.Size(165, 23);
            this.btnxRelRel.TabIndex = 28;
            this.btnxRelRel.Text = "xRel Serie";
            this.btnxRelRel.UseVisualStyleBackColor = true;
            this.btnxRelRel.Click += new System.EventHandler(this.btnxRelRel_Click);
            // 
            // releinheit
            // 
            this.releinheit.AutoSize = true;
            this.releinheit.Location = new System.Drawing.Point(310, 118);
            this.releinheit.Name = "releinheit";
            this.releinheit.Size = new System.Drawing.Size(0, 13);
            this.releinheit.TabIndex = 27;
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.Location = new System.Drawing.Point(251, 118);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(42, 13);
            this.l.TabIndex = 26;
            this.l.Text = "Einheit:";
            // 
            // relsize
            // 
            this.relsize.AutoSize = true;
            this.relsize.Location = new System.Drawing.Point(310, 99);
            this.relsize.Name = "relsize";
            this.relsize.Size = new System.Drawing.Size(0, 13);
            this.relsize.TabIndex = 25;
            // 
            // relaud
            // 
            this.relaud.AutoSize = true;
            this.relaud.Location = new System.Drawing.Point(310, 80);
            this.relaud.Name = "relaud";
            this.relaud.Size = new System.Drawing.Size(0, 13);
            this.relaud.TabIndex = 24;
            // 
            // relvid
            // 
            this.relvid.AutoSize = true;
            this.relvid.Location = new System.Drawing.Point(310, 61);
            this.relvid.Name = "relvid";
            this.relvid.Size = new System.Drawing.Size(0, 13);
            this.relvid.TabIndex = 23;
            // 
            // relrating
            // 
            this.relrating.AutoSize = true;
            this.relrating.Location = new System.Drawing.Point(111, 118);
            this.relrating.Name = "relrating";
            this.relrating.Size = new System.Drawing.Size(0, 13);
            this.relrating.TabIndex = 22;
            // 
            // relgroup
            // 
            this.relgroup.AutoSize = true;
            this.relgroup.Location = new System.Drawing.Point(111, 99);
            this.relgroup.Name = "relgroup";
            this.relgroup.Size = new System.Drawing.Size(0, 13);
            this.relgroup.TabIndex = 21;
            // 
            // reltime
            // 
            this.reltime.AutoSize = true;
            this.reltime.Location = new System.Drawing.Point(111, 80);
            this.reltime.Name = "reltime";
            this.reltime.Size = new System.Drawing.Size(0, 13);
            this.reltime.TabIndex = 20;
            // 
            // reldate
            // 
            this.reldate.AutoSize = true;
            this.reldate.Location = new System.Drawing.Point(111, 61);
            this.reldate.Name = "reldate";
            this.reldate.Size = new System.Drawing.Size(0, 13);
            this.reldate.TabIndex = 19;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(17, 80);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(43, 13);
            this.label23.TabIndex = 18;
            this.label23.Text = "Uhrzeit:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(17, 99);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 13);
            this.label22.TabIndex = 17;
            this.label22.Text = "Rel. Group";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(17, 118);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 13);
            this.label21.TabIndex = 16;
            this.label21.Text = "Bewertung:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(17, 61);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 13);
            this.label20.TabIndex = 15;
            this.label20.Text = "Datum:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(251, 99);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 13);
            this.label19.TabIndex = 14;
            this.label19.Text = "Größe:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(251, 80);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "Audio:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(251, 61);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 12;
            this.label17.Text = "Video:";
            // 
            // relname
            // 
            this.relname.AutoSize = true;
            this.relname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relname.Location = new System.Drawing.Point(15, 29);
            this.relname.Name = "relname";
            this.relname.Size = new System.Drawing.Size(0, 13);
            this.relname.TabIndex = 12;
            // 
            // VideoCombo
            // 
            this.VideoCombo.FormattingEnabled = true;
            this.VideoCombo.Location = new System.Drawing.Point(587, 18);
            this.VideoCombo.Name = "VideoCombo";
            this.VideoCombo.Size = new System.Drawing.Size(115, 21);
            this.VideoCombo.TabIndex = 41;
            this.VideoCombo.SelectedIndexChanged += new System.EventHandler(this.VideoCombo_SelectedIndexChanged);
            // 
            // AudioCombo
            // 
            this.AudioCombo.FormattingEnabled = true;
            this.AudioCombo.Location = new System.Drawing.Point(708, 18);
            this.AudioCombo.Name = "AudioCombo";
            this.AudioCombo.Size = new System.Drawing.Size(106, 21);
            this.AudioCombo.TabIndex = 42;
            this.AudioCombo.SelectedIndexChanged += new System.EventHandler(this.AudioCombo_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(584, 2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 43;
            this.label15.Text = "Video:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(705, 2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 44;
            this.label16.Text = "Audio:";
            // 
            // EngCheck
            // 
            this.EngCheck.AutoSize = true;
            this.EngCheck.Location = new System.Drawing.Point(461, 68);
            this.EngCheck.Name = "EngCheck";
            this.EngCheck.Size = new System.Drawing.Size(117, 17);
            this.EngCheck.TabIndex = 45;
            this.EngCheck.Text = "inkl. Eng. Releases";
            this.EngCheck.UseVisualStyleBackColor = true;
            this.EngCheck.CheckedChanged += new System.EventHandler(this.EngCheck_CheckedChanged);
            // 
            // MLCWorker
            // 
            this.MLCWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MLCWorker_DoWork);
            this.MLCWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.MLCWorker_RunWorkerCompleted);
            // 
            // mlcwork
            // 
            this.mlcwork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.mlcwork.BackgroundImage = global::mlc_series_search.Properties.Resources.refresh;
            this.mlcwork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mlcwork.Cursor = System.Windows.Forms.Cursors.Default;
            this.mlcwork.Location = new System.Drawing.Point(1013, 61);
            this.mlcwork.Name = "mlcwork";
            this.mlcwork.Size = new System.Drawing.Size(32, 29);
            this.mlcwork.TabIndex = 46;
            this.mlcwork.UseVisualStyleBackColor = false;
            this.mlcwork.Click += new System.EventHandler(this.mlcwork_Click);
            // 
            // xRelWorker
            // 
            this.xRelWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.xRelWorker_DoWork);
            // 
            // mlcseriessearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 607);
            this.Controls.Add(this.mlcwork);
            this.Controls.Add(this.EngCheck);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.AudioCombo);
            this.Controls.Add(this.VideoCombo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.versionlabel);
            this.Controls.Add(this.proglabel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.bylabel);
            this.Controls.Add(this.requesttext);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.mlcupslist);
            this.Controls.Add(this.del_abo);
            this.Controls.Add(this.abolist);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.xRelList);
            this.Controls.Add(this.EpisodeCheck);
            this.Controls.Add(this.SeasonCheck);
            this.Controls.Add(this.EpisodeList);
            this.Controls.Add(this.SearchResultList);
            this.Controls.Add(this.abobtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.filter);
            this.Controls.Add(this.EpisodeCombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SeasonCombo);
            this.Controls.Add(this.SearchText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mlcseriessearch";
            this.Text = "MLC Series Search";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeriesPic)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.ComboBox SeasonCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox EpisodeCombo;
        private System.Windows.Forms.TextBox filter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button abobtn;
        private System.Windows.Forms.ListBox SearchResultList;
        private System.Windows.Forms.ListBox EpisodeList;
        private System.Windows.Forms.CheckBox SeasonCheck;
        private System.Windows.Forms.CheckBox EpisodeCheck;
        private System.Windows.Forms.ListBox xRelList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox SeriesPic;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox BeschreibungText;
        private System.Windows.Forms.Label SeriesNameLabel;
        private System.Windows.Forms.Label LaufzeitLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label GerneLabel;
        private System.Windows.Forms.Label AirDateLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListBox abolist;
        private System.Windows.Forms.Button del_abo;
        private System.Windows.Forms.ListBox mlcupslist;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox requesttext;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label bylabel;
        private System.Windows.Forms.Label proglabel;
        private System.Windows.Forms.Label versionlabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox VideoCombo;
        private System.Windows.Forms.ComboBox AudioCombo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox EngCheck;
        private System.Windows.Forms.Label releinheit;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.Label relsize;
        private System.Windows.Forms.Label relaud;
        private System.Windows.Forms.Label relvid;
        private System.Windows.Forms.Label relrating;
        private System.Windows.Forms.Label relgroup;
        private System.Windows.Forms.Label reltime;
        private System.Windows.Forms.Label reldate;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label relname;
        private System.Windows.Forms.Button btnxRelNFO;
        private System.Windows.Forms.Button btnxRelRel;
        private BackgroundWorker MLCWorker;
        private System.Windows.Forms.Button mlcwork;
        private BackgroundWorker xRelWorker;
    }
}

