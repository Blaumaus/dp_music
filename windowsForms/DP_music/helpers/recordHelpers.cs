﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Media;

namespace DP_music.helpers
{
    public class recordHelpers
    {
        SoundPlayer soundPlayer = null;
        private string url = "http://164.90.166.133:7402/";



        public recordHelpers(string path)
        {
            //mediaPlayer = new MediaPlayer();
            //mediaPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/example_video.mkv"));
            //mediaPlayer.Play();
        }

        public static void PlayMp3FromUrl(string url)
        {
            using (Stream ms = new MemoryStream())
            {
                using (Stream stream = WebRequest.Create(url)
                    .GetResponse().GetResponseStream())
                {
                    byte[] buffer = new byte[32768];
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                }

                //ms.Position = 0;
                //using (WaveStream blockAlignedStream =
                //    new BlockAlignReductionStream(
                //        WaveFormatConversionStream.CreatePcmStream(
                //            new Mp3FileReader(ms))))
                //{
                //    using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                //    {
                //        waveOut.Init(blockAlignedStream);
                //        waveOut.Play();
                //        while (waveOut.PlaybackState == PlaybackState.Playing)
                //        {
                //            System.Threading.Thread.Sleep(100);
                //        }
                //    }
                //}
            }
        }
    }
}
