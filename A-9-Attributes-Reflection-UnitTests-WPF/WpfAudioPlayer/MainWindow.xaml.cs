using AudioPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAudioPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player player = new Player();

        public MainWindow()
        {
            InitializeComponent();
            player.SongStart += Player_SongStart;
        }

        private void Player_SongStart()
        {
            ShowSongs();
        }

        private void ShowSongs()
        {
            var songs = player
                .Songs
                .Select(s => s == player.PlayingSong ? $">>{s.Title}<<" : s.Title);

            label.Content = String.Join("\n", songs);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();

                if (!string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    player.Load(dialog.SelectedPath);
                    ShowSongs();
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            player.Play();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }
    }
}
