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

namespace mlc_series_search
{
    public partial class mlcseriessearch : Form
    {

        public mlcseriessearch()
        {
            InitializeComponent();
        }

        Stopwatch sw = new Stopwatch();
        
        DataSet TVDBSearch = new DataSet();
        DataSet TVDBSeries = new DataSet();
        DataSet xRel1 = new DataSet();
        DataView EpisodeView = new DataView();

        string xRelURL;
        bool xRel_Timeout = false;


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

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                string path = @"C:\Users\Pascal\Desktop\SERIEN_API.json";
                string jsonText = File.ReadAllText(path);

                JObject JSON = JObject.Parse(jsonText);
                foreach (JToken Series in JSON.Children())
                //foreach (JToken  in JSON.Descendants())
                {
                    // foreach (var Season in Series)
                    // {
                    //     MessageBox.Show(Season.ToString());
                    // }
                }


                var o = JObject.Parse(jsonText);

                foreach (JToken child in o.Children())
                {
                    var property1 = child as JProperty;
                    if (property1 != null)
                    {
                        string serie = property1.Name;
                    }
                    // this.SearchResultList.Items.Insert(0, property1.Name);
                }


                /*     foreach (JToken grandChild in child)
                      {
                         var property2 = grandChild as JProperty;

                          if (property2 != null)
                           {
                               string staffel = property2.Name;
                           }

                           foreach (JToken grandGrandChild in grandChild)
                           {

                       /        var property = grandGrandChild as JProperty;

                               if (property != null)
                              {
                                 this.checkedListBox2.Items.Insert(0, property.Name + ":" + property.Value);
                              }
                         }
                      }*/


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

        }

        private void SearchText_Validated(object sender, EventArgs e)
        {
            try
            {

                string xmlString = HTTPtoString("http://thetvdb.com/api/GetSeries.php?language=DE&seriesname=" + this.SearchText.Text);

                ClearDataSet(TVDBSearch);
                xmltodataset(TVDBSearch, xmlString);

                if (TVDBSearch.Tables.Count >= 0)
                {
                    TVDBSearch.Tables[0].DefaultView.RowFilter = "Language = 'DE'";
                    SearchResultList.DataSource = TVDBSearch.Tables[0].DefaultView;
                    SearchResultList.DisplayMember = "SeriesName";
                    SearchResultList.ValueMember = "seriesid";
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
            if (EpisodeList.SelectedValue != null && EpisodeList.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string episode = Int32.Parse(EpisodeList.Text.Split(new char[] { ' ', '.' })[1]).ToString("D2");
                string staffel = Int32.Parse(EpisodeList.Text.Split(new char[] { ' ', '.' })[0]).ToString("D2");
                string xRelURL_new = "https://api.xrel.to/v2/search/releases.xml?q=" + SearchResultList.Text + " S" + staffel + "E" + episode + "&scene=1";

                if (this.xRelURL != xRelURL_new)
                {
                    this.xRelURL = xRelURL_new;

                    sw.Start();
                    progressBar1.Maximum = 6000;
                    progressBar1.Step = 1;

                    while (sw.Elapsed < TimeSpan.FromSeconds(6))
                    {
                        progressBar1.PerformStep();
                    }
                    sw.Stop();
                    sw.Reset();
                    sw.Start();
                    //MessageBox.Show("https://api.xrel.to/v2/search/releases.xml?q=" + SearchResultList.Text + " S" + staffel + "E" + episode + "&scene=1");
                    string xRelXML = HTTPtoString("https://api.xrel.to/v2/search/releases.xml?q=" + SearchResultList.Text + " S" + staffel + "E" + episode + "&scene=1");


                    ClearDataSet(xRel1);
                    xmltodataset(xRel1, xRelXML);
                    if (xRel1.Tables.Count >= 2)
                    {
                        xRelList.DataSource = xRel1.Tables[2].DefaultView;
                        xRelList.DisplayMember = "dirname";
                    }

                }
            }
        }
    }

}

