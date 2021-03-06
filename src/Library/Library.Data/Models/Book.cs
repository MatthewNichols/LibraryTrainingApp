using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Library.Data.Interfaces;

namespace Library.Data.Models
{
	public partial class Book : IHasId
	{
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            Authors = new HashSet<Author>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [StringLength(13)]
        public string ISBN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Author> Authors { get; set; }
    }
}
