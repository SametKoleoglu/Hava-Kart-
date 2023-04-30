using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Hava_Kartı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string api = "c866b5b572b40aa5407a4827ca508c77";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument hava = XDocument.Load(connection);
            var sicaklik = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var ruzgar = hava.Descendants("speed").ElementAt(0).Attribute("value").Value;
            var nem = hava.Descendants("humidity").ElementAt(0).Attribute("value").Value;
            var durum = hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
            label2.Text = DateTime.Now.ToShortDateString();
            label3.Text = sicaklik.ToString();
            label7.Text = ruzgar + " m/s";
            label8.Text = nem + " %";
            label10.Text = durum;
            
            switch (durum)
            {
                case "açık":
                    pictureBox1.ImageLocation = "C:\\Users\\VICTUS\\Downloads\\Resimler\\Güneşli.png";
                    label10.Text = "AÇIK";
                    break;
                case "az bulutlu":
                    pictureBox1.ImageLocation = "C:\\Users\\VICTUS\\Downloads\\az bulutlu.png";
                    label10.Text = "AZ BULUTLU";
                    break;
                case "yağmurlu":
                    pictureBox1.ImageLocation = "C:\\Users\\VICTUS\\Downloads\\Resimler\\yağmurlu.png";
                    label10.Text = "YAĞMURLU";
                    break;
                case "parçalı bulutlu":
                    pictureBox1.ImageLocation = "C:\\Users\\VICTUS\\Downloads\\Resimler\\parçalı bulutlu.png";
                    label10.Text = "PARÇALI BULUTLU";
                    break;
            }
        }

    }
}
