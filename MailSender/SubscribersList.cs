// -----------------------------------------------------------------------
//  <copyright file="SubscribersList.cs" company="DevCore.NET">
//      Author: Milena Farfułowska (m.farfulowskai@gmail.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSender
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Klasa przechowująca dane o listach subskrybentów
    /// </summary>
    public class SubscribersList
    {
        /// <summary>
        /// Inicjalizuje nową instancję klasy <see cref="SubscribersList" />.
        /// </summary>
        public SubscribersList()
        {
        }

        /// <summary>
        /// Pobiera lub ustawia Id listy subskrybentów
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Pobiera lub ustawia nazwę listy subskrybentów
        /// </summary>
        public string Name { get; set; }
    }
}
