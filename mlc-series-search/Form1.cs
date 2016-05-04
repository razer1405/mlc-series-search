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

namespace mlc_series_search
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
        }

        DataTable SeasonData = new DataTable();
        DataTable SeriesData = new DataTable();
        DataTable ReleaseData = new DataTable();
        DataSet xRel1 = new DataSet();
        DataView EpisodenView;

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
                }
                return "";
            }
        }

        public void xmltodataset(DataSet newt,string xmlString) { 
        newt.ReadXml(GenerateStreamFromString(xmlString));
        }

        public void setEpisodeSeason(DataView dv, string staffel, bool filter)
        {
            if (staffel != "System.Data.DataRowView")
            {
                dv = new DataView(SeasonData);
                if (filter)
                {
                    dv.RowFilter = "Staffel >= " + staffel;
                }
                else
                {
                    dv.RowFilter = "Staffel = " + staffel;
                }

                listBox1.DataSource = dv;
                listBox1.DisplayMember = "Display";
                listBox1.ValueMember = "Display";
            }
        }

        public void setEpisodeFilter(DataView dv, string staffel, string episode, bool filter)
        {
            if (staffel != "System.Data.DataRowView" && episode != "System.Data.DataRowView")
            {
                dv = new DataView(SeasonData);
                if (filter)
                {
                    dv.RowFilter = "Staffel = " + staffel + " AND Episode >= " + episode;
                }
                else
                {
                    dv.RowFilter = "Staffel = " + staffel + " AND Episode = " + episode;
                }

                listBox1.DataSource = dv;
                listBox1.DisplayMember = "Display";
                listBox1.ValueMember = "Display";
            }
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

        private void textBox1_Validated(object sender, EventArgs e)
        {
            try
            {

                string xmlString = HTTPtoString("http://thetvdb.com/api/GetSeries.php?language=DE&seriesname=" + this.textBox1.Text);


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



                DataTable StaffelnDB;
                StaffelnDB = SeasonData.DefaultView.ToTable(true, "Staffel");

                comboBox1.DataSource = StaffelnDB;
                comboBox1.DisplayMember = "Staffel";

                DataTable EpisodenDB;
                EpisodenDB = SeasonData.DefaultView.ToTable(true, "Episode");

                comboBox2.DataSource = EpisodenDB;
                comboBox2.DisplayMember = "Episode";
            }
            /* }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "ERROR");
             } */

        }

        private void Season_Change(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
               // setEpisodeSeason(EpisodenView, comboBox1.Text, checkBox1.Checked);

                if (comboBox2.Text != "")
                {
                    if (!checkBox2.Checked)
                    {
                       // setEpisodeFilter(EpisodenView, comboBox1.Text, comboBox2.Text, checkBox2.Checked);
                    }
                }
            }
        }

        private void Episode_Change(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "")
            {
               // checkBox1.Checked = false;
               // setEpisodeFilter(EpisodenView, comboBox1.Text, comboBox2.Text, checkBox2.Checked);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox1.SelectedValue != null && listBox1.SelectedValue.ToString() != "System.Data.DataRowView")
            {

               string xmlString = HTTPtoString("https://api.xrel.to/v2/search/releases.xml?q="+ SearchResultList.Text +" "+ listBox1.Text.Substring(0,6) + "&scene=1");

                xmltodataset(xRel1, xmlString);
               if (xRel1.Tables.Count >= 2) { 
                listBox2.DataSource = xRel1.Tables[2].DefaultView;
                listBox2.DisplayMember = "dirname";
                }

            }
        }
    }
}

