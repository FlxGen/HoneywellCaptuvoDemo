using Foundation;
using UIKit;
using CaptuvoSDK;

namespace HoneywellCaptuvoDemo
{
    public partial class ViewController : UIViewController
    {
        public ViewController()
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;
            Title = "HoneywellCaptuvoDemo";

            var textView = new UITextView()
            {
                Frame = View.Frame,
                ScrollEnabled = true,
                Editable = false,
                Selectable = false,
                ShowsHorizontalScrollIndicator = true,
                ShowsVerticalScrollIndicator = true
            };

            var range = new NSRange(0, textView.Text.Length - 1);
            textView.ScrollRangeToVisible(range);

            View.AddSubview(textView);

            var scanDecoder = new ScanDecoder(textView);
        }

        private class ScanDecoder: CaptuvoEventsProtocol
        {
            private Captuvo captuvo;
   
            public UITextView TextView;

            public ScanDecoder(UITextView textView)
            {
                captuvo = Captuvo.SharedCaptuvoDevice;

                TextView = textView;
                TextView.Text = "SDK Version: " + captuvo.SDKshortVersion + "\n";

                captuvo.AddCaptuvoDelegate(this);
                captuvo.StartDecoderHardware(250);
                captuvo.StartPMHardware(250);
                captuvo.StartMSRHardware(250);
            }

            public override void CaptuvoConnected()
            {
                TextView.Text = TextView.Text + "Captuvo Conntected\n";

                captuvo.StartDecoderHardware(250);
                captuvo.StartPMHardware(250);
                captuvo.StartMSRHardware(250);
            }

            public override void CaptuvoDisconnected()
            {
                TextView.Text = TextView.Text + "Captuvo Disconntected\n";

                captuvo.StopDecoderHardware();
                captuvo.StopPMHardware();
                captuvo.StopMSRHardware();
            }

            public override void DecoderReady()
            {
                TextView.Text = TextView.Text + "Decoder Ready\n";
            }

            public override void PmReady()
            {
                TextView.Text = TextView.Text + "Battery Ready\n";
            }

            public override void ResponseBatteryDetailInformation(cupertinoBatteryDetailInfo batteryInfo)
            {
                TextView.Text = TextView.Text + "Battery: " + batteryInfo.Percentage + "\n";
            }

            public override void DecoderDataReceived(string data)
            {
                TextView.Text = TextView.Text + data + "\n";
            }
        }
    }
}