using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DragonBallWiki.Models
{
    public class CharacterModel
    {
        #region Properties
        public int ID { get; set; }
        public string Name { get; set; } = "Unbekannt";
        public string Description { get; set; } = "Leer";
        public string OriginAnime { get; set; } = "Unbekannt";
        public List<AbilityModel> Abilities { get; set; } = new() { new() };
        public Image Image { get; private set; } = new();
        private string imageData = "nicht vorhanden";
        public string ImageData
        {
            get => imageData;
            set
            {
                imageData = value;

                byte[] binaryData = Convert.FromBase64String(imageData);

                var bi = new BitmapImage();
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();

                Image = new Image
                {
                    Source = bi
                };
            }
        }
        #endregion


        #region Overrides
        public override string ToString ()
        {
            var chararcterString = $"{Name}\n{Description}\n{OriginAnime}\nAbilities:\n";
            foreach (var ability in Abilities) chararcterString += $"\t{ability}\n";
            return chararcterString.TrimEnd('\n');
        }

        public override bool Equals (object? obj) => obj is not null
                                                  && obj is CharacterModel other
                                                  && other.ID == ID
                                                  && other.OriginAnime.Equals(OriginAnime)
                                                  && other.Name.Equals(Name);

        public override int GetHashCode () => base.GetHashCode();
        #endregion
    }
}
