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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeriesPic)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(15, 18);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(317, 20);
            this.SearchText.TabIndex = 0;
            this.SearchText.TextChanged += new System.EventHandler(this.SearchText_Validated);
            this.SearchText.Validated += new System.EventHandler(this.SearchText_Validated);
            // 
            // SeasonCombo
            // 
            this.SeasonCombo.FormattingEnabled = true;
            this.SeasonCombo.Location = new System.Drawing.Point(337, 32);
            this.SeasonCombo.Name = "SeasonCombo";
            this.SeasonCombo.Size = new System.Drawing.Size(124, 21);
            this.SeasonCombo.TabIndex = 2;
            this.SeasonCombo.SelectedIndexChanged += new System.EventHandler(this.Season_Changed);
            this.SeasonCombo.SelectionChangeCommitted += new System.EventHandler(this.Season_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Suchen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Abonnements:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Staffel:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Folge:";
            // 
            // EpisodeCombo
            // 
            this.EpisodeCombo.FormattingEnabled = true;
            this.EpisodeCombo.Location = new System.Drawing.Point(467, 32);
            this.EpisodeCombo.Name = "EpisodeCombo";
            this.EpisodeCombo.Size = new System.Drawing.Size(124, 21);
            this.EpisodeCombo.TabIndex = 13;
            this.EpisodeCombo.SelectedIndexChanged += new System.EventHandler(this.Episode_Change);
            this.EpisodeCombo.SelectionChangeCommitted += new System.EventHandler(this.Episode_Change);
            // 
            // filter
            // 
            this.filter.Location = new System.Drawing.Point(597, 32);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(126, 20);
            this.filter.TabIndex = 15;
            this.filter.TextChanged += new System.EventHandler(this.Filter_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(593, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Zusatzfilter:";
            // 
            // abobtn
            // 
            this.abobtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.abobtn.Location = new System.Drawing.Point(729, 32);
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
            this.SearchResultList.Size = new System.Drawing.Size(317, 186);
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
            this.SeasonCheck.Location = new System.Drawing.Point(338, 59);
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
            this.EpisodeCheck.Location = new System.Drawing.Point(467, 59);
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
            this.groupBox1.Location = new System.Drawing.Point(338, 396);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 200);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
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
            this.BeschreibungText.Size = new System.Drawing.Size(543, 96);
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
            this.progressBar1.Size = new System.Drawing.Size(269, 10);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 28;
            // 
            // abolist
            // 
            this.abolist.FormattingEnabled = true;
            this.abolist.Location = new System.Drawing.Point(12, 247);
            this.abolist.Name = "abolist";
            this.abolist.Size = new System.Drawing.Size(317, 342);
            this.abolist.TabIndex = 29;
            this.abolist.Click += new System.EventHandler(this.abolist_Click);
            // 
            // del_abo
            // 
            this.del_abo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.del_abo.Location = new System.Drawing.Point(843, 32);
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
            this.bylabel.Location = new System.Drawing.Point(990, 37);
            this.bylabel.Name = "bylabel";
            this.bylabel.Size = new System.Drawing.Size(44, 13);
            this.bylabel.TabIndex = 37;
            this.bylabel.Text = "by raz3r";
            // 
            // proglabel
            // 
            this.proglabel.AutoSize = true;
            this.proglabel.Location = new System.Drawing.Point(927, 5);
            this.proglabel.Name = "proglabel";
            this.proglabel.Size = new System.Drawing.Size(107, 13);
            this.proglabel.TabIndex = 38;
            this.proglabel.Text = "MLC Serien Manager";
            // 
            // versionlabel
            // 
            this.versionlabel.AutoSize = true;
            this.versionlabel.Location = new System.Drawing.Point(953, 21);
            this.versionlabel.Name = "versionlabel";
            this.versionlabel.Size = new System.Drawing.Size(81, 13);
            this.versionlabel.TabIndex = 39;
            this.versionlabel.Text = "Version: 0.0.0.1";
            // 
            // mlcseriessearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 607);
            this.Controls.Add(this.versionlabel);
            this.Controls.Add(this.proglabel);
            this.Controls.Add(this.bylabel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label14);
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
    }
}

