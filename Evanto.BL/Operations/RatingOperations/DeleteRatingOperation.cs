using Evanto.DAL.Context;

namespace Evanto.BL.Operations.RatingOperations
{
    public class DeleteRatingOperation : Operation<DeleteRatingInput, DeleteRatingOutput>
    {
        public override void DoExecute()
        {
            DeleteRatingOutput output = new DeleteRatingOutput ();
            var rating = this.Uow.GetRepository<Rating>().GetById(Parameters.Id);
            Uow.GetRepository<Rating>().Delete(rating);
            Uow.SaveChanges();
            output.IsDeleted = true;
            Result.Output = output;
        }
    }
}
