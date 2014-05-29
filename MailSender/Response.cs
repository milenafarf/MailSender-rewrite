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

        public Response(ResponseCode code, string message)
            : this(code, ResponseSubCode.None, message)
        {
        }

        public Response(ResponseCode code)
            : this(code, ResponseSubCode.None, string.Empty)
        {
        }

        public Response(ResponseCode code, ResponseSubCode subCode)
            : this(code, subCode, string.Empty)
        {
        }
        
        public ResponseCode Code { get; set; }

        public ResponseSubCode SubCode { get; set; }

        public string Message { get; set; }

        public Response(ResponseCode code, ResponseSubCode subCode, string message)
        {
            this.Code = code;
            this.SubCode = subCode;
            this.Message = message;
        }
    }
}
