using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace slider1
{
    [Activity(Label = "slider1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, SeekBar.IOnSeekBarChangeListener
    {
        SeekBar seekBar;
        TextView textView;
        Button randomGen;
        TextView randomVal;
        int randomno;
        int seekval;
        Random rand1 = new Random();
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            seekBar = FindViewById<SeekBar>(Resource.Id.seekBar1);
            textView = FindViewById<TextView>(Resource.Id.textView1);
            randomGen = FindViewById<Button>(Resource.Id.button1);
            randomVal = FindViewById<TextView>(Resource.Id.textView2);
            randomVal.Text = string.Format("{0}", 0);
            seekBar.Enabled = false;
            // Assign this class as a listener for the SeekBar events
            seekBar.SetOnSeekBarChangeListener(this);
            randomGen.Click += (object sender, EventArgs e) =>
                {
                    textView.Text = string.Format("Slide the seekbar to know your accuracy");
                    randomno = rand1.Next(0, 100);
                    randomVal.Text = string.Format("{0}", randomno);
                };
        }
         public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
            if (fromUser)
            {
                // textView.Text = string.Format("The user adjusted the value of the SeekBar to {0}", seekBar.Progress);
                seekval = seekBar.Progress;
                int score = 100 - Java.Lang.Math.Abs(seekval - randomno);
                textView.Text = string.Format("" + score);
            }
        }

        
       

        public void OnStartTrackingTouch(SeekBar seekBar)
        {
            System.Diagnostics.Debug.WriteLine("Tracking changes.");
        }

        public void OnStopTrackingTouch(SeekBar seekBar)
        {
            System.Diagnostics.Debug.WriteLine("Stopped tracking changes.");
        }
    }
}

