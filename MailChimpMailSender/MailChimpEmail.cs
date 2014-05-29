// -----------------------------------------------------------------------
//  <copyright file="MailChimpEmail.cs" company="DevCore.NET">
//      Author: Milena Farfułowska (m.farfulowskai@gmail.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailChimpMailSender
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using MailSender;

    /// <summary>
    /// Informacje o adresie email subskrybenta
    /// </summary>
    [DataContract]
    public class MailChimpEmail
    {
        public MailChimpEmail()
        {
        }

        /// <summary>
        /// Pobiera lub ustawia adres email subskrybenta.
        /// </summary>
        /// <value>Adres email subskrybenta.</value>
        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

        /// <summary>
        /// Pobiera lub ustawia id subskrybenta.
        /// </summary>
        /// <value>Unikalny identyfikator adresu email subskrybenta (nie związany z listą subskrybentów).</value>
        [DataMember(Name = "euid", EmitDefaultValue = false)]
        public string Euid { get; set; }

        /// <summary>
        /// Pobiera lub ustawia id lista-email.
        /// </summary>
        /// <value>Unikalny identyfikator lista-email, nie zmienia się, gdy adres email się zmieni.</value>
        [DataMember(Name = "leid", EmitDefaultValue = false)]
        public string Leid { get; set; }
    }
}
