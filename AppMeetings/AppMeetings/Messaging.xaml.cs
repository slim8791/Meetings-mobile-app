using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;
using Xamarin.Forms;

namespace AppMeetings
{
    public partial class Messaging : ContentPage
    {
        public Messaging()
        {
            InitializeComponent();
        }

        private void MakeCall(object sender, EventArgs e)
        {
            var phoneCaller = CrossMessaging.Current.PhoneDialer;
            if(phoneCaller.CanMakePhoneCall)
                phoneCaller.MakePhoneCall(PhoneNumber.Text);
        }

        private void SendSMS(object sender, EventArgs e)
        {
            var smsMessenger = CrossMessaging.Current.SmsMessenger;
            if(smsMessenger.CanSendSms)
                smsMessenger.SendSms(PhoneNumber.Text,SMSMessage.Text);
        }

        private void SendEmail(object sender, EventArgs e)
        {
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if(emailMessenger.CanSendEmail)
                emailMessenger.SendEmail(Adress.Text,Subject.Text, EmailMessage.Text);

        }
    }
}
