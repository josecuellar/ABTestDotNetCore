

using System;

namespace ABTestDotNetCore.Main
{
    public class Version
    {

        public string KeyWord { get;  set; }

        public string Title { get;  set; }

        public int Percentage { get;  set; }

        public int TimesSent { get;  set; }


        public Version()
        {

        }


        public Version(string keyWord, string title, int percentage)
        {
            ThrowExceptionIfNotValidParameters(keyWord, title, percentage);

            this.KeyWord = keyWord;
            this.Title = title;
            this.Percentage = percentage;
            this.TimesSent = 0;
        }

        public Version(string keyWord, string title, int percentage, int timesSent)
        {
            ThrowExceptionIfNotValidParameters(keyWord, title, percentage);

            this.KeyWord = keyWord;
            this.Title = title;
            this.Percentage = percentage;
            this.TimesSent = timesSent;
        }

        private void ThrowExceptionIfNotValidParameters(string keyWord, string title, int percentage)
        {
            if (string.IsNullOrEmpty(keyWord))
                throw (new ArgumentNullException("KeyWord definition for version is required"));

            if (string.IsNullOrEmpty(title))
                throw (new ArgumentNullException("Title version is required"));

            if (percentage > 100 || percentage < 0)
                throw (new ArgumentNullException("Percentage must rage 0 to 100"));
        }

        public Version AddSent()
        {
            return new Version(this.KeyWord, this.Title, this.Percentage, (this.TimesSent + 1));
        }
    }
}
