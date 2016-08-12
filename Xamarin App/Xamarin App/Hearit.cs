using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Speech.Tts;

namespace Xamarin_App
{
    [Activity(Label = "Speak Activity",Theme = "@style/Theme.Custom")]
    public class Hearit : Activity, TextToSpeech.IOnInitListener
    {
        public TextToSpeech SpeechText
    {
        get;
        set;
    }

    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);

        SetContentView(Resource.Layout.Heartit);
            EditText tbun = FindViewById<EditText>(Resource.Id.editText1);

            // create text to speech object to use synthesize and speak functions.
            // first parameter: context
            // second parameter: object implemeting TextToSpeech.IOnInitListener
            this.SpeechText = new TextToSpeech(this, this);

        Button testSpeechButton = FindViewById<Button>(Resource.Id.button1);
        testSpeechButton.Click += delegate {
            if (String.IsNullOrEmpty(tbun.Text))
                Toast.MakeText(this, "Enter text to speak ", ToastLength.Short).Show();
            else
            {
                this.SpeechText.Speak(tbun.Text, QueueMode.Flush, null);
            }
          
        };

     
    }

    public void OnInit(OperationResult status)
    {
            // here you can setup language settings

           // if (status.Equals(OperationResult.Success)) 
            // Toast.MakeText(this, "Text To Speech Succeed!", ToastLength.Long).Show();
           // else
           // Toast.MakeText(this, "Text To Speech Fail", ToastLength.Long).Show();
    }
}
}