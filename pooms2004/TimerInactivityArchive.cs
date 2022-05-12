namespace pooms2004
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TimerInactivityArchive")]
    public partial class TimerInactivityArchive
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TimerInactivityArchiveId { get; set; }

        public int? UserId { get; set; }

        public int? AreaId { get; set; }

        public int? DocumentId { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateFinish { get; set; }

        public int? DurationInSeconds { get; set; }

        public int? StatusId { get; set; }

        [StringLength(350)]
        public string Comment { get; set; }
    }
}
