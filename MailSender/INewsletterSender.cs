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
        Response TestSender();

        Response GetSubscribersList(string name);

        Response AddSubscriberTolistByName(string listName, Receiver receiver);

        Response AddSubscriberTolistById(string listId, Receiver receiver);
    }
}
