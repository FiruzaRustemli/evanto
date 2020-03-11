using System.ComponentModel.DataAnnotations;

namespace Evanto.BL.Operations.DiscountCouponOperations
{
    public class CreateDiscountCouponInput : OperationParameters
    {
        [Required(ErrorMessage = "CouponTypeId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "CouponTypeId must be an integer")]
        public int? StatusId { get; set; }

        [Required(ErrorMessage = "CouponTypeId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "CouponTypeId must be an integer")]
        public int CouponTypeId { get; set; }


        [Required(ErrorMessage = "CouponNumber is required")]
        [Range(1, int.MaxValue, ErrorMessage = "DiscountTypeId must be an integer")]
        public int DiscountTypeId { get; set; }

        [Required(ErrorMessage = "CouponNumber is required")]
        public string CouponNumber { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be an integer")]
        public int Quantity { get; set; }

        public string Description { get; set; }
    }

    public class CreateDiscountCouponOutput : OperationParameters
    {
        public bool IsCreated { get; set; } = false;
    }

}
