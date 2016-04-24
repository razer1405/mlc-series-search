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

        DataTable EpisodeData = new DataTable();
        DataTable SeriesData = new DataTable();

        public void initSeasonDB(DataTable dt)
        {
            dt.Columns.Add("Serie", typeof(String));
            dt.Columns.Add("ID", typeof(String));
            dt.Columns.Add("Sprache", typeof(String));
        }

        public void fillSeasonDB(DataTable dt, string name, string id, string sprache)
        {
            DataRow workRow = dt.NewRow();
            workRow["Serie"] = name;
            workRow["ID"] = id;
            workRow["Sprache"] = sprache;
            dt.Rows.Add(workRow);
        }

        public void XMLtoSeasonDB(DataTable dt, string XML)
        {
            XmlReader Reader = XmlReader.Create(new StringReader(XML));
            while (Reader.Read())
            {
                if (Reader.Name.Equals("Series") && (Reader.NodeType == XmlNodeType.Element))
                {
                    Reader.ReadToFollowing("seriesid");
                    string id = Reader.ReadElementContentAsString();
                    Reader.ReadToFollowing("language");
                    string sprache = Reader.ReadElementContentAsString();
                    Reader.ReadToFollowing("SeriesName");
                    string name = Reader.ReadElementContentAsString();

                    if (sprache == "de")
                    {
                        fillSeasonDB(dt, name, id, sprache);
                    }
                }
            }
        }

        public string HTTPtoString(string http)
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

                initSeasonDB(SeriesData);

                XMLtoSeasonDB(SeriesData, xmlString);

                SearchResultList.DataSource = SeriesData;
                SearchResultList.DisplayMember = "Serie";
                SearchResultList.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

        }

        private void SearchResultList_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SearchResultList.GetItemText(SearchResultList.SelectedItem));
            MessageBox.Show(SearchResultList.SelectedValue.ToString());


            try
            {

                string xmlString = HTTPtoString("http://thetvdb.com/api/1D62F2F90030C444/series/" + SearchResultList.SelectedValue.ToString() + "/all/de.xml");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

        }
    }
}

