// -----------------------------------------------------------------------
//  <copyright file="Response.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSender
{
    using System;

    /// <summary>
    /// Klasa przechowująca odpowiedź otrzymaną od serwera.
    /// </summary>
    public class Response
    {   
        public Response(ResponseCode code, ResponseSubCode subCode, string message, string id)
        {
            this.Code = code;
            this.SubCode = subCode;
            this.Message = message;
            this.id = id;
        }

        public Response(ResponseCode code, string message)
            : this(code, ResponseSubCode.None, message, string.Empty)
        {
        }

        public Response(ResponseCode code)
            : this(code, ResponseSubCode.None, string.Empty, string.Empty)
        {
        }

        public Response(ResponseCode code, ResponseSubCode subCode)
            : this(code, subCode, string.Empty, string.Empty)
        {
        }

        public Response(ResponseCode code, string id)
            : this(code, ResponseSubCode.None, string.Empty, id)
        {
        }

        public ResponseCode Code;

        public ResponseSubCode SubCode;

        public string Message;

        /// <summary>
        /// Pobiera lub ustawia id listy subskrybentow
        /// </summary>
        public string Id { get; set; }

        public enum ResponseCode
        {
            Ok,
            UnknownError,
            WrongApiKey
        }

        public enum ResponseSubCode
        {
            None
        }
    }
}
