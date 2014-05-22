// -----------------------------------------------------------------------
//  <copyright file="Receiver.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSender
{
    public class Receiver
    {
        /// <summary>
        /// nicjalizuje nową instancję klasy <see cref="MailSender.Receiver"/>.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="name">Nazwa odbiorcy.</param>
        public Receiver(string email, string name)
        {
            this.Email = email;
            this.Name = name;
        }

        /// <summary>
        /// Pobiera lub ustawia adres email obiorcy.
        /// </summary>
        /// <value>Adres email odbiorcy.</value>
        public string Email { get; set; }

        /// <summary>
        /// Pobiera lub ustawia nazwę odbiorcy emaila.
        /// </summary>
        /// <value>Nazwa odbiorcy emaila</value>
        public string Name { get; set; }
    }
}
