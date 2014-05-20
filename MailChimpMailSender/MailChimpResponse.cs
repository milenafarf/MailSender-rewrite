using System;

namespace MailChimpMailSender
{
    public class MailChimpResponse
    {
        [DataMember(Name = "total")]
        /// <summary>
        /// Pobiera lub ustawia liczbę kampanii spełniających kryteria zapytania.
        /// </summary>
        /// <value>Status wiadomości</value>
        public string Total { get; set; }

        /// <summary>
        /// Pobiera lub ustawia zawartość html kampanii.
        /// </summary>
        /// <value>The HTML content used for the campaign with merge tags intact</value>
        [DataMember(Name = "html")]
        public string Html { get; set; }

        /// <summary>
        /// Pobiera lub ustawia tekst.
        /// </summary>
        /// <value>The Text content used for the campaign with merge tags intact</value>
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }


}

