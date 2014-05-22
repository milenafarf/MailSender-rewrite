// -----------------------------------------------------------------------
//  <copyright file="JsonSerializer.cs" company="m (m.dobrzynski@outlook.com)">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSenderHelpers
{
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;

    /// <summary>
    /// Klasa pozwalająca na zserializowanie obiektu typu T na
    /// string zawierający obiekt JSON
    /// </summary>
    /// <typeparam name="T">Typ obiektu do zserializowania.</typeparam>
    public class JsonSerializer<T>
    {
        /// <summary>
        /// Pole przechowujące serializator obiektów DataContract
        /// </summary>
        private readonly DataContractJsonSerializer serializer; 

        /// <summary>
        /// Inicjalizuje nową instancję klasy <see cref="JsonSerializer{T}" />.
        /// </summary>
        public JsonSerializer()
        {
            this.serializer = new DataContractJsonSerializer(typeof(T));    
        }

        /// <summary>
        /// Serializuje przekazany obiekt do formatu JSON.
        /// </summary>
        /// <param name="obj">Obiekt który ma zostać zserializowany.</param>
        /// <returns>String zawierający obiekt w formacie JSON.</returns>
        public string Serialize(T obj)
        {
            var mem = new MemoryStream();
            this.serializer.WriteObject(mem, obj);
            return Encoding.UTF8.GetString(mem.ToArray);
        }
    }
}
