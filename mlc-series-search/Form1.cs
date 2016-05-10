using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Net;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace mlc_series_search
{
    public partial class mlcseriessearch : Form
    {

        public mlcseriessearch()
        {
            InitializeComponent();

            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(mydocpath + @"\AboData.xml"))
            {
                AboData.ReadXml(mydocpath + @"\AboData.xml");
            }
            else
            {
                InitAboTable(AboData);
            }

            abolist.DataSource = AboData.Tables[0].DefaultView;
            abolist.DisplayMember = "Display";
            abolist.ValueMember = "Serie";

            InitMLCTable(MLCresults);

            
        }

        Stopwatch sw = new Stopwatch();

        DataSet TVDBSearch = new DataSet();
        DataSet TVDBSeries = new DataSet();
        DataSet xRel1 = new DataSet();
        DataView EpisodeView = new DataView();
        DataView RelView = new DataView();
        DataSet AboData = new DataSet();
        StringWriter AboWrite = new StringWriter();
        DataTable MLCresults = new DataTable();
        DataRow workRow;




        string xRelURL;

        private void InitMLCTable(DataTable table) { 
            MLCresults.Columns.Add("ID", typeof(string));
            MLCresults.Columns.Add("Release", typeof(string));
            MLCresults.Columns.Add("Gewicht", typeof(string));
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

        private void MLCSearch(DataTable Data, String SearchString)
        {

             try
             { 
            if (SearchString != null && SearchString != "") {
                    ClearTable(MLCresults);     
                string jsonText = HTTPtoString("https://searchapi.mlc.to/search?q=" + SearchString);
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
                                    }
                                    if (property4.Name == "title")
                                    {
                                        string release = property4.Value.ToString();
                                        workRow["Release"] = release;
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

            
               }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
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

        public void setRELFilter(DataView dv, string filter)
        {
            if (filter != "System.Data.DataRowView" && filter != "")
            {
                dv.RowFilter = "dirname LIKE '*" + Regex.Replace(filter,@"[*]"," ") + "*'";
            }
        }

        public void setSeriesInfo(DataTable data)
        {
            DataView Series = getDataView(data);
            SeriesPic.Load("http://thetvdb.com/banners/" + Series.Table.Rows[0]["poster"].ToString());
            BeschreibungText.Text = Series.Table.Rows[0]["overview"].ToString();
            SeriesNameLabel.Text = Series.Table.Rows[0]["SeriesName"].ToString();
            AirDateLabel.Text = Series.Table.Rows[0]["FirstAired"].ToString();
            GerneLabel.Text = Series.Table.Rows[0]["Genre"].ToString();
            LaufzeitLabel.Text = Series.Table.Rows[0]["Runtime"].ToString() + " min";
            StatusLabel.Text = Series.Table.Rows[0]["Status"].ToString();


        }

        private void SearchText_Validated(object sender, EventArgs e)
        {
            try
            {
                if (this.SearchText.Text != "")
                {
                    string xmlString = HTTPtoString("http://thetvdb.com/api/GetSeries.php?language=DE&seriesname=" + this.SearchText.Text);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

        }

        private void SearchResultList_Click(object sender, EventArgs e)
        {

            /*try
            {
            */
            SearchResultList.Refresh();
           
            if (SearchResultList.SelectedValue != null)
            {
                string xmlString = HTTPtoString("http://thetvdb.com/api/1D62F2F90030C444/series/" + SearchResultList.SelectedValue.ToString() + "/all/de.xml");

                ClearDataSet(TVDBSeries);
                xmltodataset(TVDBSeries, xmlString);

                if (TVDBSeries.Tables.Count >= 1)
                {
                    TVDBSeries.Tables[1].Columns.Add("Display", typeof(string), "SeasonNumber+'.'+EpisodeNumber + ' ' + EpisodeName");


                    DataTable StaffelnDB;
                    StaffelnDB = TVDBSeries.Tables[1].DefaultView.ToTable(true, "SeasonNumber");

                    SeasonCombo.DataSource = StaffelnDB;
                    SeasonCombo.DisplayMember = "SeasonNumber";

                    setSeriesInfo(TVDBSeries.Tables[0]);
                }

            }
            /* }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "ERROR");
             } */

        }

        private void Episode_Change(object sender, EventArgs e)
        {
            EpisodeView = getDataView(TVDBSeries.Tables[1]);

            setFilter(EpisodeView, SeasonCombo.Text, EpisodeCombo.Text, SeasonCheck.Checked, EpisodeCheck.Checked);

            EpisodeList.DataSource = EpisodeView;
            EpisodeList.DisplayMember = "Display";
            EpisodeList.ValueMember = "Display";
        }

        private void Season_Changed(object sender, EventArgs e)
        {
            EpisodeView = getDataView(TVDBSeries.Tables[1]);
            DataTable EpisodenDB;

            setFilter(EpisodeView, SeasonCombo.Text, "", false, true);

            EpisodenDB = EpisodeView.ToTable(true, "EpisodeNumber");

            setFilter(EpisodeView, SeasonCombo.Text, EpisodeCombo.Text, SeasonCheck.Checked, EpisodeCheck.Checked);

            EpisodeList.DataSource = EpisodeView;
            EpisodeList.DisplayMember = "Display";
            EpisodeList.ValueMember = "Display";


            EpisodeCombo.DataSource = EpisodenDB;
            EpisodeCombo.DisplayMember = "EpisodeNumber";
        }

        private void EpisodeList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (EpisodeList.SelectedValue != null && EpisodeList.SelectedValue.ToString() != "System.Data.DataRowView" && sender.ToString() != "System.Data.DataRowView")
            {
                string episode = Int32.Parse(EpisodeList.Text.Split(new char[] { ' ', '.' })[1]).ToString("D2");
                string staffel = Int32.Parse(EpisodeList.Text.Split(new char[] { ' ', '.' })[0]).ToString("D2");
               
                string xRelURL_new = "https://api.xrel.to/v2/search/releases.xml?q=" + SearchResultList.Text + " S" + staffel + "E" + episode + "&scene=1";

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
                    if (xRel1.Tables.Count >= 2)
                    {
                        RelView = getDataView(xRel1.Tables[2]);

                        setRELFilter(RelView, filter.Text);

                        xRelList.DataSource = RelView;
                        xRelList.DisplayMember = "dirname";
                    }

                }
            }
        }

        private void Filter_TextChanged(object sender, EventArgs e)
        {
            if (xRel1.Tables.Count >= 2)
            {
                RelView = getDataView(xRel1.Tables[2]);

                setRELFilter(RelView, filter.Text);

                xRelList.DataSource = RelView;
                xRelList.DisplayMember = "dirname";
            }
        }

        private void Abo_Click(object sender, EventArgs e)
        {

            AboData.Tables[0].Select("Serie = '" + SearchResultList.Text + "'");
            if (AboData.Tables[0].Rows.Count >= 1 && AboData.Tables[0].Rows[0]["Serie"].ToString() == SearchResultList.Text)
            {
                AboData.Tables[0].Rows[0]["Serie"] = SearchResultList.Text;
                AboData.Tables[0].Rows[0]["Staffel"] = SeasonCombo.Text;
                AboData.Tables[0].Rows[0]["Episode"] = EpisodeCombo.Text;
                AboData.Tables[0].Rows[0]["abStaffel"] = SeasonCheck.Checked;
                AboData.Tables[0].Rows[0]["abEpisode"] = EpisodeCheck.Checked;
                AboData.Tables[0].Rows[0]["Filter"] = filter.Text;
                AboData.Tables[0].Rows[0]["Display"] = SearchResultList.Text + " > " + SeasonCombo.Text + "." + EpisodeCombo.Text + " " + filter.Text;
            }
            else
            {
                AboData.Tables[0].Rows.Add(SearchResultList.Text, SeasonCombo.Text, EpisodeCombo.Text, SeasonCheck.Checked, EpisodeCheck.Checked, filter.Text, SearchResultList.Text + " > " + SeasonCombo.Text + "." + EpisodeCombo.Text + " " + filter.Text);
            }
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            AboData.WriteXml(mydocpath + @"\AboData.xml");

        }

        private void del_abo_Click(object sender, EventArgs e)
        {
            AboData.Tables[0].Select("Serie = '" + abolist.SelectedValue.ToString() + "'");
            if (AboData.Tables[0].Rows[0]["Serie"].ToString() == abolist.SelectedValue.ToString())
            {
                AboData.Tables[0].Rows[0].Delete();
            }
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (AboData.Tables[0].Rows.Count == 0)
            {
                File.Delete(mydocpath + @"\AboData.xml");
            }
            else
            {
                AboData.WriteXml(mydocpath + @"\AboData.xml");
            }
        }

        private void abolist_Click(object sender, EventArgs e)
        {
            AboData.Tables[0].Select("Serie = '" + abolist.SelectedValue.ToString() + "'");
            if (AboData.Tables[0].Rows[0]["Serie"].ToString() == abolist.SelectedValue.ToString())
            {
                SearchText.Text = AboData.Tables[0].Rows[0]["Serie"].ToString();
                SearchText_Validated(sender, e);
                SearchResultList_Click(sender, e);

                SeasonCombo.Text = AboData.Tables[0].Rows[0]["Staffel"].ToString();
                SeasonCheck.Checked = Boolean.Parse(AboData.Tables[0].Rows[0]["abStaffel"].ToString());
                Season_Changed(sender, e);

                EpisodeCombo.Text = AboData.Tables[0].Rows[0]["Episode"].ToString();
                EpisodeCheck.Checked = Boolean.Parse(AboData.Tables[0].Rows[0]["abEpisode"].ToString());
                Episode_Change(sender, e);



                filter.Text = AboData.Tables[0].Rows[0]["Filter"].ToString();

            }
        }

        private void xRelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (xRelList.Text != "System.Data.DataRowView" && sender.ToString() != "System.Data.DataRowView" && xRelList.Text != "") { 
                MLCSearch(MLCresults, xRelList.Text);

                mlcupslist.DataSource = MLCresults;
                mlcupslist.DisplayMember = "Release";
                mlcupslist.ValueMember = "ID";

                requesttext.Text = "Name:\r\nSprache:\r\nQualität:\r\nReleasetitel:" + xRelList.Text;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mlcboard.com/forum/forumdisplay.php?202-Spender-Suche");
        }

        private void mlcupslist_DoubleClick(object sender, EventArgs e)
        {
            if (sender.ToString() != "System.Data.DataRowView" && sender.ToString() != "")
            {
                System.Diagnostics.Process.Start("https://mlcboard.com/forum/showthread.php?" +mlcupslist.SelectedValue.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mlcboard.com/forum/forumdisplay.php?62-Suche");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mlcboard.com/");
        }
    }

}

