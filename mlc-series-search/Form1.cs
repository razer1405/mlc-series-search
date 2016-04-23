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
                    this.SearchResultList.Items.Insert(0, property1.Name);
                }


                /*foreach (JToken grandChild in child)
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
    }
    }

