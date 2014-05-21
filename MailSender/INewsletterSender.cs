// -----------------------------------------------------------------------
//  <copyright file="ISender.cs" company="m (m.dobrzynski@outlook.com)">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSender
{
    using System.Collections.Generic;
    
    interface INewsletterSender
    {
        string CreateReceiversList(List<Receiver> receivers);

        List<Receiver> GetReceiversLists();

        string CreateCampaign(string listid, Mail mail);

        string StartCampaign(string campaignid);

        string PauseCampaign(string campaignid);

        string ResumeCampaign(string campaignid);

        string SearchCampaign(string query);

    }
}
