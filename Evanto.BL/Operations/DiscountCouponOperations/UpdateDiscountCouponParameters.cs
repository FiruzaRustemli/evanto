using System.ComponentModel.DataAnnotations;
using Evanto.BL.DTOs.Core;
using Evanto.Resources.Operations.DiscountCoupon.Update;

namespace Evanto.BL.Operations.DiscountCouponOperations
{
    public class UpdateDiscountCouponInput:OperationParameters
    {
        [Required(ErrorMessageResourceName = "IdIsRequired", ErrorMessageResourceType = typeof(UpdateDiscountCouponResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "IdRange", ErrorMessageResourceType = typeof(UpdateDiscountCouponResource))]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "StatusIdIsRequired", ErrorMessageResourceType = typeof(UpdateDiscountCouponResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "StatusIdRange", ErrorMessageResourceType = typeof(UpdateDiscountCouponResource))]
        public int StatusId { get; set; }

        [Required(ErrorMessageResourceName = "CouponTypeIdIsRequired", ErrorMessageResourceType = typeof(UpdateDiscountCouponResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "CouponTypeIdRange", ErrorMessageResourceType = typeof(UpdateDiscountCouponResource))]
        public int CouponTypeId { get; set; }

        [Required(ErrorMessageResourceName = "DiscountTypeIdIsRequired", ErrorMessageResourceType = typeof(UpdateDiscountCouponResource))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "DiscountTypeIdRange", ErrorMessageResourceType = typeof(UpdateDiscountCouponResource))]
        public int DiscountTypeId { get; set; }

        [Required(ErrorMessageResourceName = "CouponNumberIsRequired", ErrorMessageResourceType = typeof(UpdateDiscountCouponResource))]
        public string CouponNumber { get; set; }

        [Required(ErrorMessageResourceName = "QuantityIsRequired", ErrorMessageResourceType = typeof(UpdateDiscountCouponResource))]
        public int Quantity { get; set; }
        public string Description { get; set; }
    }

    public class UpdateDiscountCouponOutput
    {
        public DiscountCouponDto DiscountCoupon { get; set; }
        public bool IsUpdated { get; set; } = false;
    }
}
