namespace Evanto.BL.Operations.VendorOperations
{
    public class UpdateVendorDescriptionInput : OperationParameters
    {
        public string Description { get; set; }
    }
    public class UpdateVendorDescriptionOutput
    { 
        public bool IsUpdated { get; set; }
    }
}
