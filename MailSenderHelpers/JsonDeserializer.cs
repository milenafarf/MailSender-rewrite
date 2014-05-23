// -----------------------------------------------------------------------
//  <copyright file="JsonDeserializer.cs" company="DevCore.NET">
//      Author: m (m.dobrzynski@outlook.com).
//  </copyright>
// -----------------------------------------------------------------------

namespace MailSenderHelpers
{
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;

    /// <summary>
    /// Klasa pozwalająca na deserializowanie obiektu typu JSON na
    /// obiekt typu T
    /// </summary>
    /// <typeparam name="T">Typ obiektu do zdeserializowania.</typeparam>
    public class JsonDeserializer<T>
    {
        /// <summary>
        /// Pole przechowujące serializator obiektów DataContract
        /// </summary>
        private readonly DataContractJsonSerializer deserializer; 

        /// <summary>
        /// Inicjalizuje nową instancję klasy <see cref="JsonDeserializer{T}" />.
        /// </summary>
        public JsonDeserializer()
        {
            this.deserializer = new DataContractJsonSerializer(typeof(T));    
        }

        /// <summary>
        /// Deserializuje przekazany obiekt w formacie JSON do obiektu typu T.
        /// </summary>
        /// <param name="json">String zawierający obiekt zapisany w formacie JSON.</param>
        /// <returns>Zdeserializowany obiekt typu T</returns>
        public T Deserialize(string json)
        {
            T obj;
            var tempString = Encoding.UTF8.GetBytes(json);
            var mem = new MemoryStream(tempString);
            obj = (T)this.deserializer.ReadObject(mem);
            return obj;
        }
    }
}
