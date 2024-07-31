using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace DynamicSoundTrack
{

    /**
     * TODO Debug Why Code Fires Async
     * Add in features to add / remove samples
     * Code GUI
     * Add CAN Read
     * Profit
     * 
     */
    class MusicPlayer
    {
        MediaPlayer[] player = new MediaPlayer[7];
        List<MediaPlayer> CurrentPlayers = new List<MediaPlayer>();
        //private MediaPlayer player;

        public void Play(int i, String Path)
        {
            
            player[i] = new MediaPlayer();
            if (!CurrentPlayers.Contains(player[i]))
            {
                CurrentPlayers.Add(player[i]);
            }
            System.Diagnostics.Debug.WriteLine("Setting Event Handler for {0}", player[i].Source);
            player[i].MediaEnded += new EventHandler(Media_Ended);

            player[i].Open(new System.Uri(Path));
         
            
            player[i].Play();
            Dispatcher.Run();


        }

        private void Media_Ended(object sender, EventArgs e)
        {
            MediaPlayer temp = (MediaPlayer)sender;
            System.Diagnostics.Debug.WriteLine("Source File {0}", temp.Source);
            temp.Position = TimeSpan.Zero;
            for (int i = 0; i < CurrentPlayers.Count; i++)
            {
                if (CurrentPlayers[i].Get) { 
                }
            }
            temp.Play();
        }

    }


    internal class MusicHandler
    {
        String FolderPath;
        String SoundName;
        String BackingTrack, First, Second, Third, Fourth, Fifth, Sixth;
        MusicPlayer music;
        public MusicHandler()
        {
            FolderPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            BackingTrack = Path.GetFullPath(Path.Combine(FolderPath, "CarSamples", "StartCar.wav"));
            First = Path.GetFullPath(Path.Combine(FolderPath, "CarSamples", "FirstGear.wav"));
            Second = Path.GetFullPath(Path.Combine(FolderPath, "CarSamples", "SecondGear.wav"));
            Third = Path.GetFullPath(Path.Combine(FolderPath, "CarSamples", "ThirdGear.wav"));
            Fourth = Path.GetFullPath(Path.Combine(FolderPath, "CarSamples", "FourthGear.wav"));
            Fifth = Path.GetFullPath(Path.Combine(FolderPath, "CarSamples", "FifthGear.wav"));
            Sixth = Path.GetFullPath(Path.Combine(FolderPath, "CarSamples", "SixthGear.wav"));
            Console.WriteLine("Backing Track Path {0}\n Folder Path {1}", BackingTrack, FolderPath);
            music = new MusicPlayer();
            PlayAll();




        }

        public void PlayAll()
        {
            String[] tracks = { BackingTrack, First, Second, Third, Fourth, Fifth, Sixth };
            //String[] tracks = { BackingTrack, First };

            Parallel.For(0, tracks.Length, i => {music.Play(i, tracks[i]); }) ;

            //for (int i = 0; i < tracks.Length; i++)
            //{

            //    music.Play(tracks[i]);
            //}


            Console.WriteLine("Playing Music");
        }

    }

   class MyMediaPlayer
    {
        MediaPlayer music;
        bool isStopped;
        String track;

    }


}
