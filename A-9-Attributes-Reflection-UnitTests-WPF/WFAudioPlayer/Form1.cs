using AudioPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAudioPlayer
{
    public partial class Form1 : Form
    {
        private Player player = new Player();

        public Form1()
        {
            InitializeComponent();
            player.SongStart += Player_SongStart;
        }

        private void Player_SongStart()
        {
            ShowSongs();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    player.Load(fbd.SelectedPath);
                    ShowSongs();
                }
            }
        }

        private void ShowSongs()
        {
            var songs = player
                .Songs
                .Select(s => s == player.PlayingSong ? $">>{s.Title}<<" : s.Title);

            label1.Text = String.Join("\n", songs);
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.Play();
        }
    }
}
