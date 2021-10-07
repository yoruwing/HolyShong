namespace HolyShong.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }

        public int MemberId { get; set; }

        public int? DeliverId { get; set; }

        public int StoreId { get; set; }

        public decimal DeliveryFee { get; set; }

        public decimal? Tips { get; set; }

        [Required]
        public string Notes { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        public bool IsTablewares { get; set; }

        public bool IsPlasticbag { get; set; }

        public bool PaymentStatus { get; set; }

        public bool DeliverStatus { get; set; }

        public bool OrderStatus { get; set; }

        public DateTime UpdateTime { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public int? MemberDiscountId { get; set; }

        public int? DiscountId { get; set; }

        public int? DiscountMemberId { get; set; }

        public virtual Deliver Deliver { get; set; }

        public virtual Member Member { get; set; }

        public virtual MemberDiscount MemberDiscount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
