// -----------------------------------------------------------------------
//  <copyright file="INewsletterSender.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSender
{
    using System.Collections.Generic;
    
    public interface INewsletterSender
    {
        /// <summary>
        /// Testowanie połączenia z serwisem 
        /// </summary>
        /// <returns>Odpowiedź z serwera</returns>
        Response TestSender();

        /// <summary>
        /// Metoda zwraca jedną listę subskrybentów o nazwie podanej jako argument
        /// </summary>
        /// <param name="name">Odpowiedź otrzymana od serwera</param>
        /// <returns>Odpowiedź otrzymana od serwera</returns>
        Response GetSubscribersList(string name);

        /// <summary>
        /// Metoda zwraca listę wszystkich list subskrybentów 
        /// (ich id i nazwy przechowywane w obiekcie klasy SubscribersList)
        /// </summary>
        /// <returns>Lista z danymi o wszystkich listach subskrybentów</returns>
        List<SubscribersList> GetAllLists();

        /// <summary>
        /// Metoda dodaje subskrybenta do listy po nazwie listy
        /// </summary>
        /// <param name="listName">Nazwa listy subskrybentów</param>
        /// <param name="receiver">Odbiorca maila</param>
        /// <returns>Odpowiedź od serwera</returns>
        Response AddSubscriberTolistByName(string listName, Receiver receiver);

        /// <summary>
        /// Metoda dodaje subskrybentów do listy po Id Listy
        /// </summary>
        /// <param name="listId">Id listy subskrybentów</param>
        /// <param name="receiver">Odbiorca maila</param>
        /// <returns>Odpowiedź od serwera</returns>
        Response AddSubscriberTolistById(string listId, Receiver receiver);
    }
}
