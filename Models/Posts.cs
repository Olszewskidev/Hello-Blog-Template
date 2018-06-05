namespace WebApplication1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;
    using System.Web.Mvc;

    public partial class Posts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public System.DateTime DateTime { get; set; }
        [Required]
        [AllowHtml]
        public string Body { get; set; }
        public string PicImg { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImgPost { get; set; }
    }
}
