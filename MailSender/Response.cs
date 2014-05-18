// -----------------------------------------------------------------------
//  <copyright file="Response.cs" company="m (m.dobrzynski@outlook.com)">
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
        #region constructors

        public Response(ResponseCode code, ResponseSubCode subCode, string message)
        {
            this.Code = code;
            this.SubCode = subCode;
            this.Message = message;
        }

        public Response (ResponseCode code, string message)
            : this (code, ResponseSubCode.None, message)
        {
        }

        #endregion

        #region fields

        public ResponseCode Code;

        public ResponseSubCode SubCode;

        public string Message;

        #endregion



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
