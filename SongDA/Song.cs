namespace SongDA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public int ReleaseYear { get; set; }
    }
}
