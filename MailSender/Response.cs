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
        /// <summary>
        /// Inicjalizuje nową instancję klasy <see cref="Response" />
        /// </summary>
        /// <param name="code">Zwracany kod błędu</param>
        /// <param name="message">Wiadomość zwracana z serwera</param>
        public Response(ResponseCode code, string message)
            : this(code, ResponseSubCode.None, message)
        {
        }

        /// <summary>
        /// Inicjalizuje nową instancję klasy <see cref="Response" />
        /// </summary>
        /// <param name="code">Zwracany kod błędu lub Ok</param>
        public Response(ResponseCode code)
            : this(code, ResponseSubCode.None, string.Empty)
        {
        }

        /// <summary>
        /// Inicjalizuje nową instancję klasy <see cref="Response" />
        /// </summary>
        /// <param name="code">Zwracany kod błędu lub Ok</param>
        /// <param name="subCode">Opis zwracanego błędu</param>
        public Response(ResponseCode code, ResponseSubCode subCode)
            : this(code, subCode, string.Empty)
        {
        }

        /// <summary>
        /// Inicjalizuje nową instancję klasy <see cref="Response" />
        /// </summary>
        /// <param name="code">Zwracany kod błędu lub Ok</param>
        /// <param name="subCode">Opis zwracanego błędu</param>
        /// <param name="message">Wiadomość zwracana z serwera</param>
        public Response(ResponseCode code, ResponseSubCode subCode, string message)
        {
            this.Code = code;
            this.SubCode = subCode;
            this.Message = message;
        }

        /// <summary>
        /// Zwracany komunikaty o błędzie lub Ok
        /// </summary>
        public enum ResponseCode
        {   
            /// <summary>
            /// zwracane, gdy operacja przebiegła pomyślnie
            /// </summary>
            Ok,

            /// <summary>
            /// zwracane, gdy nieznany błąd
            /// </summary>
            UnknownError,

            /// <summary>
            /// zwracane, gdy podany błędny klucz 
            /// </summary>
            WrongApiKey
        }

        /// <summary>
        /// Opisy zwracanego błędu
        /// </summary>
        public enum ResponseSubCode
        {
            /// <summary>
            /// zwracane, gdy brak objaśnienia błędu
            /// </summary>
            None
        }
        
        /// <summary>
        /// Pobiera lub ustawia zwracany kod błędu lub Ok
        /// </summary>
        public ResponseCode Code { get; set; }

        /// <summary>
        /// Pobiera lub ustawia opis zwracanego błędu
        /// </summary>
        public ResponseSubCode SubCode { get; set; }

        /// <summary>
        /// Pobiera lub ustawia wiadomość otrzymaną serwera
        /// </summary>
        public string Message { get; set; }
    }
}
