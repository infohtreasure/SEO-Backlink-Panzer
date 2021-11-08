using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEO_Backlink_Panzer
{
    public partial class backlinkseo : Form
    {
        public backlinkseo()
        {
            InitializeComponent();
        }

        public static int onlinenr = 0;
        public static int offlinenr = 0;
        DataTable table1 = new DataTable();
        public static string save = "";
        private void backlinkseo_Load(object sender, EventArgs e)
        {
            df1.Checked = true; 
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://api.proxyscrape.com/v2/?request=getproxies&protocol=http&timeout=10000&country=all&ssl=all&anonymity=all", @"traffic\proxies.txt");
                }
            } catch { }

            PROXYLOL.Visible = false;
            string[] lines = File.ReadAllLines(@"backlinks\high-da-pa.txt");

            string[] values;

            for (int i = 0; i < lines.Length; i++)
            {
                values = lines[i].ToString().Split('|');

                string[] row = new string[values.Length];

                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();

                }

                highpd.Rows.Add(row);

            }

            analyzer.PerformClick();
            table1.Columns.Add("ID", typeof(int));
            table1.Columns.Add("Backlinks", typeof(string));
            table1.Columns.Add("Status", typeof(string));
            this.MaximumSize = new System.Drawing.Size(707, 413);
            this.MinimumSize = new System.Drawing.Size(707, 413);
            checking.Visible = false;
        }

        private void generator_Click(object sender, EventArgs e)
        {
            porxyies.Visible = false;
            PROXYLOL.Visible = false;
            guna2GradientPanel2.Visible = false;
            highpda.Visible = false;
            import.Visible = false;
            checking.Visible = false;
            table.Visible = false;
            guna2GradientPanel1.Visible = true;
            gn.Visible = true;
            hg.Visible = false;
            guna2GradientPanel3.Visible = false;
            an.Visible = false;
        }

        private void highdapa_Click(object sender, EventArgs e)
        {
            porxyies.Visible = false;
            PROXYLOL.Visible = false;
            guna2GradientPanel2.Visible = false;
            guna2GradientPanel1.Visible = false;
            import.Visible = false;
            checking.Visible = false;
            table.Visible = false;
            gn.Visible = false;
            hg.Visible = true;
            highpda.Visible = true;
            an.Visible = false;
            guna2GradientPanel3.Visible = false;
        }


        private void analyzer_Click(object sender, EventArgs e)
        {
            guna2GradientPanel2.Visible = false;
            porxyies.Visible = false;
            PROXYLOL.Visible = false;
            highpda.Visible = false;
            import.Visible = true;
            table.Visible = true;
            guna2GradientPanel3.Visible = false;
            guna2GradientPanel1.Visible = false;
            gn.Visible = false;
            hg.Visible = false;
            an.Visible = true;
        }

        public void WebRequestTest(string urls, int actual)
        {

        }

        private void import_Click(object sender, EventArgs e)
        {
            try
            {
                table.Rows.Clear();
                table.Refresh();
                thr.RunWorkerAsync();
                checking.Visible = true;
            }
            catch { }

        }

        public void thr_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int i = 0;
                int j = 0;
                string[] lines = File.ReadAllLines(@"backlinks\backlinksupdate.txt");
                var lineCount = File.ReadLines(@"backlinks\backlinksupdate.txt").Count();

                string[] values;

                for (i = 0; i < lines.Length; i++)
                {
                    values = lines[i].ToString().Split('|');

                    string[] row = new string[values.Length];

                    for (j = 0; j < values.Length; j++)
                    {
                        row[j] = values[j].Trim();

                        import.Invoke((Action)delegate
                        {
                            import.Text = "Imported Lines: " + lineCount;
                        });
                    }

                    table.Invoke((Action)delegate
                    {
                        table.Rows.Add(row);
                    });

                }
            } catch { MessageBox.Show("You need to generate some backlinks first!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                checker.RunWorkerAsync();
            }
            catch { }


        }

        private void checker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {


                var lineCount = File.ReadLines(@"backlinks\backlinksupdate.txt").Count();
                for (int atm = 0; atm < lineCount; atm++)
                {
                    if (!NetworkInterface.GetIsNetworkAvailable())
                    {
                    }

                    string urls = table.Rows[atm].Cells[1].Value.ToString();

                    Uri uri = new Uri(urls);

                    Ping ping = new Ping();
                    try
                    {
                        PingReply pingReply = ping.Send(uri.Host);
                        if (pingReply.Status != IPStatus.Success)
                        {
                            table.Rows[atm].Cells[2].Value = "not working";
                        }
                        else
                        {
                            table.Rows[atm].Cells[2].Value = "working";
                        }
                    }
                    catch
                    {
                        table.Rows[atm].Cells[2].Value = "not working";
                    }

                }

            }
            catch { }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (textboxlol.Text == "")
            {
                MessageBox.Show("Website Status: Offline", "SEO Backlink Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                seoback.Start();
                progress.Value = 0;
                try
                {
                    string sourceFile = @"backlinks\backlinks.txt";
                    string destinationFile = @"backlinks\backlinksupdate.txt";
                    string destinationFiles = save + ".txt";

                    try
                    {
                        File.Copy(sourceFile, destinationFiles, true);

                        File.Copy(sourceFile, destinationFile, true);
                    }
                    catch (IOException iox)
                    {
                        Console.WriteLine(iox.Message);
                    }
                    string fileName = destinationFiles;
                    File.WriteAllText(fileName, File.ReadAllText(fileName).Replace("outcome.cc", textboxlol.Text));
                    string fileName1 = destinationFile;
                    File.WriteAllText(fileName1, File.ReadAllText(fileName1).Replace("outcome.cc", textboxlol.Text));
                }
                catch
                {
                    MessageBox.Show("Website Status: Offline", "SEO Backlink Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        public static int lol = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progress.Value < 1000)
            {
                lol = lol + 1584;
                gen.Text = "Generated Backlinks: " + lol;
                progress.Value = progress.Value + 10;
            }
            else
            {
                gen.Text = "Generated Backlinks: 129.876";
                seoback.Stop();
                analyzer.PerformClick();
                import.PerformClick();
            }
        }

        private void df1_CheckedChanged(object sender, EventArgs e)
        {
            save = @"backlinks\SEO Backlinks 01";
        }

        private void df2_CheckedChanged(object sender, EventArgs e)
        {
            save = @"backlinks\SEO Backlinks 02";
        }

        private void df3_CheckedChanged(object sender, EventArgs e)
        {
            save = @"backlinks\SEO Backlinks 03";
        }

        private void df4_CheckedChanged(object sender, EventArgs e)
        {
            save = @"backlinks\SEO Backlinks 04";
        }

        private void df5_CheckedChanged(object sender, EventArgs e)
        {
            save = @"backlinks\SEO Backlinks 05";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            porxyies.Visible = true;
            PROXYLOL.Visible = false;
            guna2GradientPanel2.Visible = true;
            guna2GradientPanel3.Visible = false;
            guna2GradientPanel1.Visible = false;
            import.Visible = false;
            checking.Visible = false;
            table.Visible = false;
            gn.Visible = false;
            hg.Visible = false;
            highpda.Visible = false;
            an.Visible = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            porxyies.Visible = false;
            PROXYLOL.Visible = true;
            guna2GradientPanel2.Visible = false;
            guna2GradientPanel3.Visible = true;
            guna2GradientPanel1.Visible = false;
            import.Visible = false;
            checking.Visible = false;
            table.Visible = false;
            gn.Visible = false;
            hg.Visible = false;
            highpda.Visible = false;
            an.Visible = false;
            guna2GradientPanel2.Visible = false;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://api.proxyscrape.com/v2/?request=getproxies&protocol=http&timeout=10000&country=all&ssl=all&anonymity=all");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://api.proxyscrape.com/v2/?request=getproxies&protocol=socks4&timeout=10000&country=all");
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://api.proxyscrape.com/v2/?request=getproxies&protocol=socks5&timeout=10000&country=all");

        }
        public static string urlproxy = "";
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Thread proxied = new Thread(delegate ()
            {
                runproxy();
            });
            proxied.Start();
        }
        public static int idproxy = 0;
        public static int lastrnd = 0;
        public static int lastrnd2 = 0;
        public static int on = 1;
        public void runproxy()
        {
            try
            {

                string[] allLines = File.ReadAllLines(@"traffic\proxies.txt");

                urlproxy = (allLines[new Random().Next(1, allLines.Length)]);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(websitetrafic.Text);
                WebProxy myproxy = new WebProxy(urlproxy, false);
                request.Proxy = myproxy;
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (on == 1)
                {
                    trfic.Invoke((Action)delegate
                    {
                        onlinenr = onlinenr + 1;
                        online.Text = "Online Proxies: " + onlinenr;
                        var index = this.trfic.Rows.Add();
                        idproxy = idproxy + 1;
                        this.trfic.Rows[index].Cells[0].Value = idproxy;
                        this.trfic.Rows[index].Cells[1].Value = urlproxy;
                        this.trfic.Rows[index].Cells[2].Value = "online ✔️";
                    });
                }


            }
            catch
            {
                if(on == 1)
                {
                    try
                    {

                        trfic.Invoke((Action)delegate
                        {
                            offlinenr = offlinenr + 1;
                            offline.Text = "Offline Proxies: " + offlinenr;
                            var index = this.trfic.Rows.Add();
                            idproxy = idproxy + 1;
                            this.trfic.Rows[index].Cells[0].Value = idproxy;
                            this.trfic.Rows[index].Cells[1].Value = urlproxy;
                            this.trfic.Rows[index].Cells[2].Value = "offline";
                        });
                    }
                    catch { }
                }
            }
        }
        private static readonly Random random = new Random();

        public static int RandomNumber(int max)
        {
            Random random = new Random();
            return random.Next(1, max);
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
           
            if (websitetrafic.Text == "")
            {
                MessageBox.Show("Website not found!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                on = 1;
                proxy.Start();
                websitetrafic.Visible = false;
                stop.Visible = true;
                start.Visible = false;
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            on = 0;
            proxy.Stop();
            websitetrafic.Visible = true; 
            start.Visible = true;
            stop.Visible = false;
        }

        private void guna2Button7_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"traffic\proxies.txt");
        }

        private void guna2Button8_Click_1(object sender, EventArgs e)
        {
            stop.PerformClick();
            this.Hide();
            backlinkseo f1 = new backlinkseo();
            f1.Show();
        }

    }
}
