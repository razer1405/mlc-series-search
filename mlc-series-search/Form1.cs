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
                         if (property1 != null) {
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
            // Create a request for the URL. 
            WebRequest request = WebRequest.Create(
              "http://thetvdb.com/api/GetSeries.php?language=DE&seriesname=" + this.textBox1.Text);
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
            string xmlString = reader.ReadToEnd();
            // Clean up the streams and the response.
            reader.Close();
            response.Close();


            List<String> searchResult = new List<String>();


            //string path = @"C:\Users\Pascal\Desktop\Serie.xml";
            //string xmlString = File.ReadAllText(path);
            int i = 0;
            XmlReader Reader = XmlReader.Create(new StringReader(xmlString));
            while (Reader.Read())
            {
                if (Reader.Name.Equals("Series") && (Reader.NodeType == XmlNodeType.Element))
                {
                    i = +1;
                    string listid = i.ToString();
                    Reader.ReadToFollowing("seriesid");
                    string id = Reader.ReadElementContentAsString();
                    Reader.ReadToFollowing("language");
                    string sprache = Reader.ReadElementContentAsString();
                    Reader.ReadToFollowing("SeriesName");
                    string name = Reader.ReadElementContentAsString();
                    // Reader.ReadToFollowing("FirstAired");
                    // string airtime = Reader.ReadElementContentAsString();
                    if (sprache == "de")
                    {
                        searchResult.Add(name);
                    }

                }
            }
            this.SearchResultList.DataSource = searchResult;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

        }
    }
 }

