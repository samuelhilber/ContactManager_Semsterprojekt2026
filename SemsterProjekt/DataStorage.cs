using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json; // wandelt C#-Objekte in JSON um.
using System.Text.Json.Serialization; //enthält JsonStringEnumConverter um Enums zu lesen

namespace SemsterProjekt
{
    internal class DataStorage
    {
        private readonly string _filepath;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };

        public DataStorage()
        {
            // sollte C:\Users\Benutzername\AppData\Local liefern und wird mit \SemsterProjekt\contact-data.json erweitert
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Semesterprojekt");

            _filepath = Path.Combine(folderPath, "contact-data.json");
        }

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

        public ContactData Load()
        {
            if (!File.Exists(_filepath)) // prüft ob Json datei bereits existiert
            {
                return new ContactData();
            }
            string json = File.ReadAllText(_filepath); //datei als string lesen
            ContactData? data = JsonSerializer.Deserialize<ContactData>(json, _options); 

            if (data != null)
            {
                return new ContactData();
            }

            return data;
        }
        public string FilePath
        {
            get => _filepath;
        }
    }
}
