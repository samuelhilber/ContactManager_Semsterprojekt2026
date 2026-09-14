using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json; // wandelt C#-Objekte in JSON um.
using System.Text.Json.Serialization; //enthält JsonStringEnumConverter um Enums zu lesen

namespace SemsterProjekt
{
    /// <summary>
    /// Speichert die Kontaktdaten als JSON-Datei und lädt sie wieder.
    /// </summary>
    /// <remarks>
    /// Die Datei liegt im lokalen Anwendungsdatenordner des Benutzers unter
    /// <c>%LOCALAPPDATA%\Semesterprojekt\contact-data.json</c>. Enums werden als Text
    /// (z.B. "Marketing") statt als Zahl gespeichert, damit die Datei lesbar bleibt.
    /// </remarks>
    internal class DataStorage
    {
        private readonly string _filepath;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters =
            {
                new JsonStringEnumConverter() // ohne das würden Enums (z.B. Job, Salutation) als Zahl statt als Text gespeichert - schlecht lesbar und bricht, sobald sich die Reihenfolge der Enum-Werte ändert
            }
        };

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="DataStorage"/>-Klasse und legt den Pfad
        /// der JSON-Datei fest (siehe <see cref="FilePath"/>).
        /// </summary>
        public DataStorage()
        {
            // sollte C:\Users\Benutzername\AppData\Local liefern und wird mit \SemsterProjekt\contact-data.json erweitert
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Semesterprojekt");

            _filepath = Path.Combine(folderPath, "contact-data.json");
        }

        /// <summary>
        /// Speichert die übergebenen Kontaktdaten als JSON-Datei.
        /// </summary>
        /// <remarks>
        /// Der Ordner wird bei Bedarf erstellt. Eine bestehende Datei wird vollständig überschrieben.
        /// </remarks>
        /// <param name="data">Die zu speichernden Mitarbeiter und Kunden.</param>
        /// <exception cref="IOException">
        /// Wird ausgelöst, wenn die Datei nicht geschrieben werden kann.
        /// </exception>
        public void Save(ContactData data)
        {
            string? folderPath = Path.GetDirectoryName(_filepath);

            if (!string.IsNullOrEmpty(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            //wandelt ContactData Object in JSON um
            string json = JsonSerializer.Serialize(data, _options);
            //Schreibt Text auf die Festplatte, Falls neue Mitarbeiter / Kunden ergänzt werden ersetzt der neue Text den alten
            File.WriteAllText(_filepath, json);
        }

        /// <summary>
        /// Lädt die Kontaktdaten aus der JSON-Datei.
        /// </summary>
        /// <remarks>
        /// Beim Laden laufen alle Werte durch die Setter und werden dabei erneut validiert.
        /// </remarks>
        /// <returns>
        /// Die geladenen Kontaktdaten oder ein leeres <see cref="ContactData"/>-Objekt,
        /// wenn noch keine Datei vorhanden ist.
        /// </returns>
        /// <exception cref="JsonException">
        /// Wird ausgelöst, wenn die JSON-Datei beschädigt ist.
        /// </exception>
        /// <exception cref="IOException">
        /// Wird ausgelöst, wenn die Datei nicht gelesen werden kann.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Wird ausgelöst, wenn die Datei einen ungültigen Wert enthält, der von einem Setter abgelehnt wird.
        /// </exception>
        public ContactData Load()
        {
            if (!File.Exists(_filepath)) // prüft ob Json datei bereits existiert
            {
                return new ContactData();
            }

            string json = File.ReadAllText(_filepath); //datei als string lesen

            ContactData? data =
                JsonSerializer.Deserialize<ContactData>(
                    json,
                    _options);

            return data ?? new ContactData();  // wenn data vorhanden ist gib data zurück, wenn null gib leeren Datenstamm zurück
        }

        /// <summary>
        /// Gibt den vollständigen Pfad der JSON-Datei zurück, in der die Kontaktdaten gespeichert werden.
        /// </summary>
        public string FilePath
        {
            get => _filepath;
        }
    }
}
