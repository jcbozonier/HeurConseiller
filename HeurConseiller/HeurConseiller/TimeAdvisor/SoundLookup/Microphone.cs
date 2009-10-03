using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using Microsoft.DirectX.DirectSound;
using VorbisDotNet;

namespace HeurConseiller.TimeAdvisor.SoundLookup
{
    public class Microphone : ICommunicationDevice, IPlaysSound
    {
        private readonly FrameworkElement _Element;

        public Microphone(ContentControl window)
        {
            _Element = (FrameworkElement)window.Content;
        }

        public void SpeakInto(Sound[] sounds)
        {
            foreach(var sound in sounds)
            {
                sound.PlayWith(this);
            }
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