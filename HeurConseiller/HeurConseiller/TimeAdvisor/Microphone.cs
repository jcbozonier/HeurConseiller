using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using HeurConseiller.TimeAdvisor.SoundLookup;
using Microsoft.DirectX.DirectSound;
using VorbisDotNet;

namespace HeurConseiller.TimeAdvisor
{
    public interface ICanPlay
    {
        void PlaySound(string fileName);
    }

    public class Microphone : ICommunicationDevice, ICanPlay
    {
        private readonly FrameworkElement _Element;

        public Microphone(ContentControl window)
        {
            _Element = (FrameworkElement)window.Content;
        }

        public void SpeakInto(Sound[] o)
        {
            foreach(var sound in o)
            {
                sound.PlayWith(this);
            }
            //var buffer = new VorbisDotNet.VorbisBuffer();
        }

        public void PlaySound(string fileName)
        {
            IntPtr handle = IntPtr.Zero;
            _Element.Dispatcher.Invoke(((Action)(() =>
                                                {
                                                    handle = ((HwndSource) PresentationSource.FromVisual(_Element)).Handle;
                                                })));
            

            var device = new Device(DSoundHelper.DefaultPlaybackDevice);
            device.SetCooperativeLevel(handle, CooperativeLevel.Normal);

            //using (var player = new SoundPlayer(@"C:\Code\French121\HeurConseiller\HeurConseiller\AudioFiles\bugsbunny.wav"))
            //{
            //    player.Play();
            //}

            using (var buffer = new VorbisBuffer(fileName, device, false, VorbisCaps.GlobalFocus))
            {
                buffer.Play(false);

                while (buffer.InternalBuffer.Status.Playing)
                {
                    // do nada
                }
            }
        }
    }
}
