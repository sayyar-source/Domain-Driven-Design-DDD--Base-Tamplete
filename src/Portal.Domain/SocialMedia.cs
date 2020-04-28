using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain
{
   public class SocialMedia
    {
        public string Instageram { get; set; }
        public string TelegramCanal { get; set; }
        public string TelegramGroup { get; set; }
        public SocialMedia(string instageram,string telegramCanal, string telegramGroup)
        {
            Instageram = instageram;
            TelegramGroup = telegramGroup;
            TelegramCanal = telegramCanal;
        }

    }
}
