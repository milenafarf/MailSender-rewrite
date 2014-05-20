// -----------------------------------------------------------------------
//  <copyright file="Receiver.cs" company="m (m.dobrzynski@outlook.com)">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSender
{
    public class Receiver
    {
		public Receiver(string email, string name)
        {
			Email = email;
			Name = name;
        }

		public string Email { get; set;}
		public string Name { get; set;}
    }
}
