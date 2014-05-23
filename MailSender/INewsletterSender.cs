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

        Response CreateNewReceiversList(List<Receiver> receivers);
    }
}
