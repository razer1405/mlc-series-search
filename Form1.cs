using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Net;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace mlc_series_search
{
    public partial class mlcseriessearch : Form
    {

        Stopwatch sw = new Stopwatch();
        DataSet TVDBSearch = new DataSet();
        DataSet TVDBSeries = new DataSet();
        DataSet xRel1 = new DataSet();
        DataView EpisodeView = new DataView();
        DataView RelView = new DataView();
        DataSet AboData = new DataSet();
        StringWriter AboWrite = new StringWriter();
        DataSet MLCData = new DataSet();
        DataView MLCView = new DataView();
        DataTable StaffelnDB;
        DataTable EpisodenDB;
        DataTable VideoDB;
        DataTable AudioDB;
        DataTable MLCresults = new DataTable();
        DataRow workRow;


        string appname = "MLC Serien Manager";

        string mydocpath = Environment.CurrentDirectory;

        string myMLCURL = "https://mlcboard.com";
        string myMLCAPI = "http://seriesapi.mlc.to/series.xml";
        string myXRELURL = "https://api.xrel.to/v2/search/releases.xml?q=";
        string myTVDBAPI = "http://thetvdb.com/api/GetSeries.php?language=DE&seriesname=";
        string myTVDBAPI2 = "http://thetvdb.com/api/1D62F2F90030C444/series/";
        string myTVDBBAN = "http://thetvdb.com/banners/";
        string myReqmask = "Name:\r\nSprache:\r\nQualität:\r\nReleasetitel:";
        string myWerbung = "\r\n\r\n[SIZE=1]Erstellt mit dem [URL='https://mlcboard.com/forum/showthread.php?204438-WIN-MLC-Serien-Manager']MLC Serien Manager[/URL] by raz3r[/SIZE]";


        string xRelRUrl = "";
        string xRelNFOUrl = "";
        string SelSerie = "";
        string SelSerieID = "";
        string SelIMDB = "";
        string SelSerieAlias = "";
        string SelCoEpisode = "";
        string SelCoStaffel = "";
        string SelLiEpispde = "";
        string SelLiStaffel = "";
        string cleanserie = "";
        bool myMLCData = false;
        string SetVideo = "";
        string SetAudio = "";
        string SetFilter = "";
        string SetENG = "";
        string OldSearch = "";
        


        string xRelURL;
        int index;

        public mlcseriessearch()
        {


            InitializeComponent();

            string version = System.Windows.Forms.Application.ProductVersion;

            //  INTI OR GET ABO-DATA //
            if (File.Exists(mydocpath + @"\AboData.xml"))
            {
                AboData.ReadXml(mydocpath + @"\AboData.xml");
            }
            else
            {
                InitAboTable(AboData);
            }


            // SET DATATABLES
            InitMLCTable(MLCresults);

            // GET MLC DATA
            isloading(true);
            isMLCData(false);
            MLCWorker.RunWorkerAsync();
            

            abolist.DataSource = AboData.Tables[0].DefaultView;
            abolist.DisplayMember = "Display";
            abolist.ValueMember = "Serie";


            // SET TEXTS 
            requesttext.Text = myReqmask + myWerbung;
            this.Text = appname + " " + version;
            versionlabel.Text = "Version: " + version;

            // GET DLL's
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

        }

        // *********************FUNCTIONS************************* //
        private void isloading(bool stat)
        {
            if (stat)
            {
                xRelList.Enabled = false;
                abolist.Enabled = false;
                EpisodeList.Enabled = false;
                progressBar1.Visible = true;
                EngCheck.Enabled = false;
            }
            else
            {
                xRelList.Enabled = true;
                abolist.Enabled = true;
                EpisodeList.Enabled = true;
                progressBar1.Visible = false;
                EngCheck.Enabled = true;
            } 
        }

        private void isMLCData(bool stat)
        {
            myMLCData = stat;

            if (stat)
            {
                mlcwork.BackColor = Color.FromArgb(192, 255, 192);
            }
            else
            {
                mlcwork.BackColor = Color.FromArgb(255, 128, 128);
            }
        }

        public string clean(string input)
        {
            return Regex.Replace(input, @"['*$%/()=?]", "");
        }

        public void setLabelFontsize(Label label1)
        {
            //Reset Fontsize
            label1.Font = new Font(relname.Font.FontFamily, 12, relname.Font.Style);

            //Recalc Fontsize
            while (label1.Width < System.Windows.Forms.TextRenderer.MeasureText(label1.Text,
             new Font(label1.Font.FontFamily, label1.Font.Size, label1.Font.Style)).Width)
            {
                label1.Font = new Font(label1.Font.FontFamily, label1.Font.Size - 0.1f, label1.Font.Style);
            }
        }

        private void InitAboTable(DataSet table)
        {
            table.Tables.Add("AboData");
            table.Tables[0].Columns.Add("Serie", typeof(string));
            table.Tables[0].Columns.Add("Staffel", typeof(string));
            table.Tables[0].Columns.Add("Episode", typeof(string));
            table.Tables[0].Columns.Add("abStaffel", typeof(bool));
            table.Tables[0].Columns.Add("abEpisode", typeof(bool));
            table.Tables[0].Columns.Add("Filter", typeof(string));
            table.Tables[0].Columns.Add("Display", typeof(string));
            table.Tables[0].Columns.Add("audio", typeof(string));
            table.Tables[0].Columns.Add("video", typeof(string));
            table.Tables[0].Columns.Add("eng", typeof(bool));
        }

        private void InitMLCTable(DataTable table)
        {
            MLCresults.Columns.Add("ID", typeof(string));
            MLCresults.Columns.Add("name", typeof(string));
            MLCresults.Columns.Add("Gewicht", typeof(string));
            MLCresults.Columns.Add("link", typeof(string));
        }

        private void ClearTable(DataTable table)
        {
            try
            {
                table.Clear();
            }
            catch (DataException e)
            {
                // Process exception and return.
                Console.WriteLine("Exception of type {0} occurred.",
                    e.GetType());
            }

        }

        private void ClearDataSet(DataSet data)
        {
            try
            {
                data.Clear();
                data.Reset();

            }
            catch (DataException e)
            {
                // Process exception and return.
                Console.WriteLine("Exception of type {0} occurred.",
                    e.GetType());
            }

        }

        public Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public string HTTPtoString(string http)
        {

            try
            {

                string xrels = http.Substring(0, 19);
                // Create a request for the URL. 
                WebRequest request = WebRequest.Create(http);
                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string httpString = reader.ReadToEnd();
                // Clean up the streams and the response.
                reader.Close();
                response.Close();

                return httpString;


            }
            catch (WebException webExcp)
            {
                // If you reach this point, an exception has been caught.
                MessageBox.Show("A WebException has been caught.");
                // Write out the WebException message.
                MessageBox.Show(webExcp.ToString());
                // Get the WebException status code.
                WebExceptionStatus status = webExcp.Status;
                // If status is WebExceptionStatus.ProtocolError, 
                //   there has been a protocol error and a WebResponse 
                //   should exist. Display the protocol error.
                if (status == WebExceptionStatus.ProtocolError)
                {
                    MessageBox.Show("The server returned protocol error ");
                    // Get HttpWebResponse so that you can check the HTTP status code.
                    HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                    MessageBox.Show((int)httpResponse.StatusCode + " - "
                       + httpResponse.StatusCode);
                    return "";
                }
                return "";
            }
        }

        public void xmltodataset(DataSet newt, string xmlString)
        {
            newt.ReadXml(GenerateStreamFromString(xmlString));
        }

        private void getMLCData(DataSet Data, string APIURL)
        {
            string MLCXML = HTTPtoString(APIURL);

            ClearDataSet(Data);
            xmltodataset(Data, MLCXML);
        }

        private void MLCSearch(DataTable Data, String SearchString)
        {

            try
            {
                if (SearchString != null && SearchString != "" && SearchString != OldSearch)
                {
                    ClearTable(MLCresults);
                    string jsonText = HTTPtoString("https://searchapi.mlc.to/search?q=" + SearchString);
                    OldSearch = SearchString;
                    var o = JObject.Parse(jsonText);

                    foreach (JToken Child1 in o.Children())
                    {
                        var property1 = Child1 as JProperty;
                        if (property1 != null)
                        {
                            string serie = property1.Name;

                        }
                        foreach (JToken Child2 in Child1)
                        {
                            var property2 = Child2 as JProperty;

                            if (property2 != null)
                            {
                                string Name = property2.Name;
                            }

                            foreach (JToken Child3 in Child2)
                            {
                                var property3 = Child3 as JProperty;

                                if (property3 != null)
                                {
                                    string Name = property3.Name;
                                }

                                workRow = Data.NewRow();

                                foreach (JToken Child4 in Child3)
                                {
                                    var property4 = Child4 as JProperty;

                                    if (property4 != null)
                                    {
                                        string Name = property4.Name;
                                        if (property4.Name == "id")
                                        {
                                            string id = property4.Value.ToString();
                                            workRow["ID"] = id;
                                            workRow["link"] = myMLCURL + "/forum/showthread.php?" +id;
                                        }
                                        if (property4.Name == "title")
                                        {
                                            string release = property4.Value.ToString();
                                            workRow["name"] = release;
                                        }
                                        if (property4.Name == "weight")
                                        {
                                            string weight = property4.Value.ToString();
                                            workRow["Gewicht"] = weight;
                                        }

                                    }

                                }
                                Data.Rows.Add(workRow);
                            }

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

        }

        private void setMLCFilter(DataView dv, string SearchString)
        {
            if (SearchString != "System.Data.DataRowView" && SearchString != "")
            {
                dv.RowFilter = "name = '" + SearchString + "'";
            }
        }

        public DataView getDataView(DataTable data)
        {
            DataView dv = new DataView(data);
            return dv;
        }

        public void setFilter(DataView dv, string staffel, string episode, bool abseason, bool abepisode)
        {
            if (staffel != "System.Data.DataRowView" && staffel != "")
            {
                if (abseason)
                {
                    dv.RowFilter = "SeasonNumber >= " + staffel + " AND language = 'de'";
                }
                else
                {
                    if (episode != "System.Data.DataRowView" && episode != "")
                    {
                        if (abepisode)
                        {
                            dv.RowFilter = "SeasonNumber = " + staffel + "AND EpisodeNumber >=" + episode + " AND language = 'de'";
                        }
                        else
                        {
                            dv.RowFilter = "SeasonNumber = " + staffel + "AND EpisodeNumber =" + episode + " AND language = 'de'";
                        }
                    }
                    else
                    {
                        dv.RowFilter = "SeasonNumber = " + staffel + " AND language = 'de'";
                    }
                }
            }
        }

        public void setRELFilter(DataView dv, string filter, string audio, string video)
        {
            string myfilter = "";
            if (filter != "System.Data.DataRowView" && filter != "")
            {
                if (myfilter == "")
                {
                    myfilter = "dirname LIKE '*" + Regex.Replace(filter, @"[*]", " ") + "*'";
                }
                else
                {
                    myfilter = myfilter + "AND dirname LIKE '*" + Regex.Replace(filter, @"[*]", " ") + "*'";
                }
            }

            if (audio != "System.Data.DataRowView" && audio != "")
            {
                if (myfilter == "")
                {
                    myfilter = "audio_type = '" + audio + "'";
                }
                else
                {
                    myfilter = myfilter + "AND audio_type = '" + audio + "'";
                }
            }

            if (video != "System.Data.DataRowView" && video != "")
            {
                if (myfilter == "")
                {
                    myfilter = "video_type = '" + video + "'";
                }
                else
                {
                    myfilter = myfilter + "AND video_type = '" + video + "'";
                }
            }

            if ((filter != "System.Data.DataRowView" && filter != "") || (audio != "System.Data.DataRowView" && audio != "") || (video != "System.Data.DataRowView" && video != ""))
            {
                dv.RowFilter = myfilter;
            }

        }

        public void setSeriesInfo(DataTable data)
        {
            DataView Series = getDataView(data);
            SeriesPic.Load(myTVDBBAN + Series.Table.Rows[0]["poster"].ToString());
            BeschreibungText.Text = Series.Table.Rows[0]["overview"].ToString();
            SeriesNameLabel.Text = Series.Table.Rows[0]["SeriesName"].ToString();
            AirDateLabel.Text = Series.Table.Rows[0]["FirstAired"].ToString();
            GerneLabel.Text = Series.Table.Rows[0]["Genre"].ToString();
            LaufzeitLabel.Text = Series.Table.Rows[0]["Runtime"].ToString() + " min";
            StatusLabel.Text = Series.Table.Rows[0]["Status"].ToString();
            setLabelFontsize(SeriesNameLabel);
        }

        public void setReleaseInfo(DataSet data)
        {

            if (xRelList.SelectedValue != null && xRelList.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string rel_id = xRelList.SelectedValue.ToString();
                int relindex;
                int relindex2;
                int relindex3;
                DataView dr = data.Tables["release"].DefaultView;
                DataView dsize = data.Tables["size"].DefaultView;
                DataView dei = data.Tables["ext_info"].DefaultView;

                dr.Sort = "release_id";
                dsize.Sort = "release_id";
                dei.Sort = "release_id";

                relindex = dr.Find(rel_id);
                relindex2 = dsize.Find(rel_id);
                relindex3 = dei.Find(rel_id);

                relgroup.Text = dr[relindex]["group_name"].ToString();
                relname.Text = dr[relindex]["dirname"].ToString();
                reltime.Text = UnixTimeStampToDateTime(double.Parse(dr[relindex]["time"].ToString())).ToString("HH:mm");
                reldate.Text = UnixTimeStampToDateTime(double.Parse(dr[relindex]["time"].ToString())).ToString("d");
                if (dei.Table.Columns.Contains("rating")) { 
                    relrating.Text = dei[relindex3]["rating"].ToString();
                }
                else
                {
                    relrating.Text = "";
                }
                relaud.Text = dr[relindex]["audio_type"].ToString();
                relvid.Text = dr[relindex]["video_type"].ToString();
                relsize.Text = dsize[relindex2]["number"].ToString();
                releinheit.Text = dsize[relindex2]["unit"].ToString();

                xRelRUrl = dei[relindex3]["link_href"].ToString();
                xRelNFOUrl = dr[relindex]["link_href"].ToString();

                btnxRelNFO.Enabled = true;
                btnxRelRel.Enabled = true;

                setLabelFontsize(relname);
            }
            else
            {
                relgroup.Text = "";
                relname.Text = "";
                reltime.Text = "";
                reldate.Text = "";
                relrating.Text = "";
                relaud.Text = "";
                relvid.Text = "";
                relsize.Text = "";
                releinheit.Text = "";

                xRelRUrl = "";
                xRelNFOUrl = "";

                btnxRelNFO.Enabled = false;
                btnxRelRel.Enabled = false;
            }

        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;

        }

        public void noEngRel(DataSet data)
        {
            int relindex;
            List<DataRow> deletedRows = new List<DataRow>();
            DataTable dt = data.Tables["release"];
            if (data.Tables["flags"] != null)
            {
                DataView dv = data.Tables["flags"].DefaultView;

                foreach (DataRow row in dt.Rows)
                {

                    dv.Sort = "release_id";
                    relindex = dv.Find(row["release_id"].ToString());
                    if (dv.Table.Columns.Contains("english")) { 
                    if (row["release_id"].ToString() == dv[relindex]["release_id"].ToString() && dv[relindex]["english"].ToString() == "1")
                    {
                        deletedRows.Add(data.Tables["release"].Rows[relindex]);
                    }
                    }
                }

                foreach (DataRow dataRow in deletedRows)
                {
                    dataRow.Delete();
                }
                data.AcceptChanges();
            }
        }

        public void checkIMDB(DataSet data)
        {
            int relindex;
            List<DataRow> deletedRows = new List<DataRow>();
            DataTable dt = data.Tables["release"];
            if (data.Tables["uris"] != null)
            {
                DataView dv = data.Tables["uris"].DefaultView;

                foreach (DataRow row in dt.Rows)
                {

                    dv.Sort = "ext_info_id";
                    relindex = dv.Find(row["release_id"].ToString());
                    if (dv.Table.Columns.Contains("uri"))
                    {
                        if (row["release_id"].ToString() == dv[relindex]["ext_info_id"].ToString() && dv[relindex]["uri"].ToString() != "imdb:"+SelIMDB)
                        {
                            deletedRows.Add(data.Tables["release"].Rows[relindex]);
                        }
                    }
                }

                foreach (DataRow dataRow in deletedRows)
                {
                    dataRow.Delete();
                }
                data.AcceptChanges();
            }
        }

        private void AddNewDataRowView(DataView view, string collum)
        {
            DataRowView rowView = view.AddNew();

            // Change values in the DataRow.
            rowView[collum] = "";
            rowView.EndEdit();
        }

        private void changeRelFilter()
        {
            if (xRel1.Tables.Count >= 2)
            {
                RelView = getDataView(xRel1.Tables[2]);

                setRELFilter(RelView, filter.Text, AudioCombo.Text, VideoCombo.Text);

                xRelList.DataSource = RelView;
                xRelList.DisplayMember = "dirname";

                if (xRelList.Text == "") { requesttext.Text = myReqmask + myWerbung; }
            }
        }

        System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(',') ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");

            dllName = dllName.Replace(".", "_");

            if (dllName.EndsWith("_resources")) return null;

            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());

            byte[] bytes = (byte[])rm.GetObject(dllName);

            return System.Reflection.Assembly.Load(bytes);
        }

        private void MLCWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            getMLCData(MLCData, myMLCAPI);         
        }

        private void MLCWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            isloading(false);
            isMLCData(true);
            xRelList_SelectedIndexChanged(sender, e);
        }

        private void xRelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
           
            string xRelURL_new = myXRELURL + cleanserie + " S" + SelLiStaffel + "E" + SelLiEpispde + "&scene=1";

            if (this.xRelURL != xRelURL_new)
            {
                this.xRelURL = xRelURL_new;

                while (sw.Elapsed < TimeSpan.FromSeconds(6) && sw.IsRunning)
                {
                    //Warte
                }

                sw.Stop();
                sw.Reset();
                sw.Start();

                string xRelXML = HTTPtoString(this.xRelURL);


                ClearDataSet(xRel1);
                xmltodataset(xRel1, xRelXML);


            }
        }

        private void xRelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (xRel1.Tables.Count >= 2)
            {
                if (!EngCheck.Checked)
                {
                    noEngRel(xRel1);
                }

                checkIMDB(xRel1);

                RelView = getDataView(xRel1.Tables["release"]);

                setRELFilter(RelView, filter.Text, AudioCombo.Text, VideoCombo.Text);

                xRelList.DataSource = RelView;
                xRelList.DisplayMember = "dirname";
                xRelList.ValueMember = "release_id";

                VideoDB = xRel1.Tables["release"].DefaultView.ToTable(true, "video_type");
                AddNewDataRowView(VideoDB.DefaultView, "video_type");

                VideoCombo.DataSource = VideoDB;
                VideoCombo.DisplayMember = "video_type";
                VideoCombo.SelectedIndex = VideoCombo.Items.Count - 1;

                AudioDB = xRel1.Tables["release"].DefaultView.ToTable(true, "audio_type");
                AddNewDataRowView(AudioDB.DefaultView, "audio_type");

                AudioCombo.DataSource = AudioDB;
                AudioCombo.DisplayMember = "audio_type";
                AudioCombo.SelectedIndex = AudioCombo.Items.Count - 1;

                if (SetAudio != "") { AudioCombo.Text = SetAudio; }
                if (SetVideo != "") { VideoCombo.Text = SetVideo; }
                if (SetFilter != "") { filter.Text = SetFilter; }
                if (SetENG != "")
                {
                    if (SetENG == "True")
                    {
                        EngCheck.Checked = true;
                    }
                    else
                    {
                        EngCheck.Checked = false;
                    }
                }
                SetAudio = "";
                SetVideo = "";
                SetFilter = "";
                SetENG = "";
                
                if (xRelList.Text != null || xRelList.Text != "")
                {
                    xRelList_SelectedIndexChanged(sender, e);
                }
                
            }
            if (xRelWorker.IsBusy != true) { 
                isloading(false);
            }
        }

        // ******************Form Events*******************************//


        // VALID Sucheeingabe
        private void SearchText_Validated(object sender, EventArgs e)
        {
            try
            {
                if (this.SearchText.Text != "")
                {
                    string xmlString = HTTPtoString(myTVDBAPI + this.SearchText.Text);

                    ClearDataSet(TVDBSearch);
                    xmltodataset(TVDBSearch, xmlString);

                    if (TVDBSearch.Tables.Count >= 1)
                    {
                        TVDBSearch.Tables[0].DefaultView.RowFilter = "Language = 'DE'";
                        SearchResultList.DataSource = TVDBSearch.Tables[0].DefaultView;
                        SearchResultList.DisplayMember = "SeriesName";
                        SearchResultList.ValueMember = "seriesid";
                    }
                }
                else
                {
                    ClearDataSet(TVDBSearch);
                    ClearDataSet(xRel1);
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

        }

        // Click auf Suchergebniss -> Hole SerienInfo
        private void SearchResultList_Click(object sender, EventArgs e)
        {

            try
            {

                SearchResultList.Refresh();
                ClearDataSet(xRel1);

                if (SearchResultList.SelectedValue != null)
                {
                    SelCoEpisode = "";
                    SelCoStaffel = "";
                    xRelURL = "";
                    SelSerieID = SearchResultList.SelectedValue.ToString();

                    string xmlString = HTTPtoString(myTVDBAPI2 + SelSerieID + "/all/de.xml");

                    ClearDataSet(TVDBSeries);
                    xmltodataset(TVDBSeries, xmlString);

                    if (TVDBSeries.Tables.Count >= 1)
                    {
                        SelSerie = TVDBSeries.Tables["Series"].Rows[0]["SeriesName"].ToString();
                        if (TVDBSeries.Tables["Series"].Columns.Contains("AliasNames"))
                        {
                            SelSerieAlias = TVDBSeries.Tables["Series"].Rows[0]["AliasNames"].ToString();
                        }else
                        {
                            SelSerieAlias = "";
                        }
                        SelIMDB = TVDBSeries.Tables["Series"].Rows[0]["IMDB_ID"].ToString();
                        TVDBSeries.Tables["Episode"].Columns.Add("Display", typeof(string), "SeasonNumber+'.'+EpisodeNumber + ' ' + EpisodeName");

                        StaffelnDB = TVDBSeries.Tables[1].DefaultView.ToTable(true, "SeasonNumber");

                        SeasonCombo.DataSource = StaffelnDB;
                        SeasonCombo.DisplayMember = "SeasonNumber";

                        setSeriesInfo(TVDBSeries.Tables[0]);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

        }

        // COMBO CHANGE 
        private void Episode_Change(object sender, EventArgs e)
        {
            if (EpisodeCombo.SelectedValue != null && SelCoEpisode != EpisodeCombo.Text && EpisodeCombo.Text != "System.Data.DataRowView")
            {
                SelCoEpisode = EpisodeCombo.Text;
                EpisodeView = getDataView(TVDBSeries.Tables[1]);

                EpisodeList.DataSource = EpisodeView;
                EpisodeList.DisplayMember = "Display";
                EpisodeList.ValueMember = "Display";
            }

            setFilter(EpisodeView, SeasonCombo.Text, EpisodeCombo.Text, SeasonCheck.Checked, EpisodeCheck.Checked);
        }

        private void Season_Changed(object sender, EventArgs e)
        {
            if (SelCoStaffel != SeasonCombo.Text && SeasonCombo.Text != "" && SeasonCombo.Text != "System.Data.DataRowView")
            {
                SelCoStaffel = SeasonCombo.Text;
                EpisodeView = getDataView(TVDBSeries.Tables[1]);

                setFilter(EpisodeView, SeasonCombo.Text, "", false, true);

                EpisodenDB = EpisodeView.ToTable(true, "EpisodeNumber");

                setFilter(EpisodeView, SeasonCombo.Text, EpisodeCombo.Text, SeasonCheck.Checked, EpisodeCheck.Checked);

                EpisodeList.DataSource = EpisodeView;
                EpisodeList.DisplayMember = "Display";
                EpisodeList.ValueMember = "Display";


                EpisodeCombo.DataSource = EpisodenDB;
                EpisodeCombo.DisplayMember = "EpisodeNumber";
            }



        }

        // Wähle andere Episode
        private void EpisodeList_Click(object sender, EventArgs e)
        {
            requesttext.Text = myReqmask + myWerbung;


            if (EpisodeList.SelectedValue != null && EpisodeList.SelectedValue.ToString() != "System.Data.DataRowView" && sender.ToString() != "System.Data.DataRowView")
            {
                SearchResultList.Refresh();
                EpisodeList.Refresh();

                SelLiEpispde = Int32.Parse(EpisodeList.Text.Split(new char[] { ' ', '.' })[1]).ToString("D2");
                SelLiStaffel = Int32.Parse(EpisodeList.Text.Split(new char[] { ' ', '.' })[0]).ToString("D2");

                cleanserie = SelSerie;

                cleanserie = cleanserie.Replace("&", "und");
                cleanserie = cleanserie.Replace("(US)", "");

                isloading(true);
                xRelWorker.RunWorkerAsync();
            }

        }

        // Eingabe Filter
        private void Filter_TextChanged(object sender, EventArgs e)
        {
            changeRelFilter();
        }

        //ABO ADD oder Akt
        private void Abo_Click(object sender, EventArgs e)
        {
            if (sender != null && SelSerie != "") { 
            abolist.Refresh();
            index = 0;
            DataTable dt = AboData.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                if (row["Serie"].ToString() == clean(SelSerie))
                {
                    index = dt.Rows.IndexOf(row);
                }
            }

            string EngCH = "";
            if (EngCheck.Checked)
            {
                EngCH = "+ENG";
            }
            else
            {
                EngCH = "";
            }

            string displaytext = clean(SelSerie) + " > " + SeasonCombo.Text + "." + EpisodeCombo.Text +" " + VideoCombo.Text + " " + AudioCombo.Text + " " + filter.Text + " " + EngCH;

            if (AboData.Tables[0].Rows.Count >= 1 && AboData.Tables[0].Rows[index]["Serie"].ToString() == clean(SelSerie))
            {
                AboData.Tables[0].Rows[index]["Serie"] = clean(SelSerie);
                AboData.Tables[0].Rows[index]["Staffel"] = SeasonCombo.Text;
                AboData.Tables[0].Rows[index]["Episode"] = EpisodeCombo.Text;
                AboData.Tables[0].Rows[index]["abStaffel"] = SeasonCheck.Checked;
                AboData.Tables[0].Rows[index]["abEpisode"] = EpisodeCheck.Checked;
                AboData.Tables[0].Rows[index]["Filter"] = filter.Text;
                AboData.Tables[0].Rows[index]["Display"] = displaytext;
                AboData.Tables[0].Rows[index]["audio"] = AudioCombo.Text;
                AboData.Tables[0].Rows[index]["video"] = VideoCombo.Text;
                AboData.Tables[0].Rows[index]["eng"] = EngCheck.Checked;
            }
            else
            {
                AboData.Tables[0].Rows.Add(clean(SelSerie), SeasonCombo.Text, EpisodeCombo.Text, SeasonCheck.Checked, EpisodeCheck.Checked, filter.Text, displaytext, AudioCombo.Text, VideoCombo.Text, EngCheck.Checked);
            }


            AboData.WriteXml(mydocpath + @"\AboData.xml");
            }
        }

        // ABO Löschen
        private void del_abo_Click(object sender, EventArgs e)
        {
            abolist.Refresh();
            if (sender != null && SelSerie != "")
            {
                index = 0;
                abolist.Refresh();
                DataTable dt = AboData.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Serie"].ToString() == clean(SelSerie))
                    {
                        index = dt.Rows.IndexOf(row);
                    }
                }


                if (AboData.Tables[0].Rows[index]["Serie"].ToString() == clean(SelSerie))
                {
                    AboData.Tables[0].Rows[index].Delete();
                }


                if (AboData.Tables[0].Rows.Count == 0)
                {
                    File.Delete(mydocpath + @"\AboData.xml");
                }
                else
                {
                    AboData.WriteXml(mydocpath + @"\AboData.xml");
                }
            }
        }

        // ABO in Ansicht laden
        private void abolist_Click(object sender, EventArgs e)
        {
            abolist.Refresh();
            if (abolist.SelectedItem != null)
            {
                DataRow[] foundRows;

                foundRows = AboData.Tables[0].Select("Serie = '" + abolist.SelectedValue.ToString() + "'");

                if (foundRows[0]["Serie"].ToString() == abolist.SelectedValue.ToString())
                {
                    SelCoEpisode = "";
                    SelCoStaffel = "";
                    xRelURL = "";
                    SearchText.Text = foundRows[0]["Serie"].ToString();
                    SearchText_Validated(sender, e);
                    SearchResultList_Click(sender, e);

                    SeasonCombo.Text = foundRows[0]["Staffel"].ToString();
                    SeasonCheck.Checked = Boolean.Parse(foundRows[0]["abStaffel"].ToString());


                    EpisodeCombo.Text = foundRows[0]["Episode"].ToString();
                    EpisodeCheck.Checked = Boolean.Parse(foundRows[0]["abEpisode"].ToString());

                    SetVideo = foundRows[0]["video"].ToString();
                    SetAudio = foundRows[0]["audio"].ToString();
                    SetFilter = foundRows[0]["Filter"].ToString();
                    SetENG = foundRows[0]["eng"].ToString();

                    Season_Changed(sender, e);
                    Episode_Change(sender, e);
                    EpisodeList_Click(sender, e);

                }
            }
        }

        // xRel Release -> Foreneintrag suchen 
        private void xRelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            requesttext.Text = myReqmask;
            setReleaseInfo(xRel1);
            MLCView = getDataView(MLCData.Tables["upload"]);

            if (xRelList.Text != "System.Data.DataRowView" && sender.ToString() != "System.Data.DataRowView" && xRelList.Text != "")
            {
                
                setMLCFilter(MLCView, xRelList.Text);

                if(MLCView.Count == 0) {
                    
                    MLCSearch(MLCresults, xRelList.Text);

                    if (MLCresults.DefaultView.Count > 0)
                    {
                        MLCView = MLCresults.DefaultView;
                    }
                            

                }
                requesttext.Text = myReqmask + xRelList.Text + myWerbung;
            }
            else
            {               
                setMLCFilter(MLCView, "--_--");
                ClearTable(MLCresults);
                requesttext.Text = myReqmask + myWerbung;
            }

            mlcupslist.DataSource = MLCView;
            mlcupslist.DisplayMember = "name";
            mlcupslist.ValueMember = "link";
        }

        // Öffne Forenbeitrag
        private void mlcupslist_DoubleClick(object sender, EventArgs e)
        {
            if (sender.ToString() != "System.Data.DataRowView" && sender.ToString() != "")
            {
                System.Diagnostics.Process.Start(mlcupslist.SelectedValue.ToString());
            }
        }

        // MLC Suche Button
        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(requesttext.Text);
            System.Diagnostics.Process.Start(myMLCURL + "/forum/forumdisplay.php?205-S-Movies");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(requesttext.Text);
            System.Diagnostics.Process.Start(myMLCURL + "/forum/forumdisplay.php?65-S-Movies");
        }

        //Video Filter
        private void VideoCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeRelFilter();
        }

        //Audio Filter
        private void AudioCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeRelFilter();
        }

        //inkl English Release Check
        private void EngCheck_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Change ENG");
            isloading(false);
            xRelURL = ""; // HOLE xREL DATEN NEU
            EpisodeList_Click(sender, e);
        }

        private void btnxRelRel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(xRelRUrl);
        }

        private void btnxRelNFO_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(xRelNFOUrl);
        }

        private void mlcwork_Click(object sender, EventArgs e)
        {
            if (myMLCData) {
                isloading(true);
                isMLCData(false);
                MLCWorker.RunWorkerAsync();
            }
        }

        private void requesttext_Click(object sender, EventArgs e)
        {
            if (requesttext.SelectionLength == 0) {
                // Select all text in the text box.
                requesttext.SelectAll();
            }
        }
    }

}

